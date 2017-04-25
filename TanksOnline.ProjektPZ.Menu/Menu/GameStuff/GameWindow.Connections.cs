using Menu.Models;
using Menu.Models.Player;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TanksOnline.ProjektPZ.Game.Drawables;

namespace Menu.Views
{
    partial class GameWindow
    {
        private HubConnection hubConnection;
        private IHubProxy gameHub;
        private readonly HttpClient _client;

        private async Task InitHub()
        {
            hubConnection = new HubConnection("http://localhost:21021/");
            gameHub = hubConnection.CreateHubProxy("GameHub");
            gameHub.On<float, int>("TurretAngleChanged", (angle, playerMatchId) =>
            {
                this.Invoke(new Action(() =>
                {
                    _tanks[playerMatchId].TurretAngle = angle;
                }));
            });

            gameHub.On<int>("ThisPlayerTurn", playerMatchId =>
            {
                this.Invoke(new Action(() =>
                {
                    if (_player.IdInMatch == playerMatchId)
                    {
                        _itsMyTurn = true;
                        _httpLoopTimer.Start();
                    }
                }));
            });

            gameHub.On<PlayerShootModel>("Shoot", (model =>
            {
                this.Invoke(new Action(() =>
                {
                    _bullets.Add(new Bullet(_tanks[model.PlayerMatchId], model.Angle, model.Speed, model.AirSpeed, model.Mass, model.Gravity)
                    {
                        Origin = new Vector2f(2f, 2f),
                        Position = new Vector2f(model.X, model.Y),
                        FillColor = Color.Black,
                        Radius = 4,
                    });
                }));
            }));

            await hubConnection.Start();
            gameHub.Invoke("Connect", _player.Id, _room.Id).Wait();
        }

        private async Task BulletFallDown(float x, float y)
        {
            await gameHub.Invoke("BulletFallDown", x, y, _player.IdInMatch, _room.Id);
        }

        private async Task SetPlayerCanon(int id, float turretAngle)
        {
            await gameHub.Invoke("NewTurretAngle", _room.Id, id, turretAngle);
        }

        private async Task Shoot(PlayerShootModel model)
        {
            await gameHub.Invoke("Shoot", model);
        }

        public class PlayerShootModel
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Angle { get; set; }
            public float Speed { get; set; }
            public float AirSpeed { get; set; }
            public float Mass { get; set; }
            public float Gravity { get; set; }
            public int PlayerMatchId { get; set; }
            public int RoomId { get; set; }
        }
    }
}
