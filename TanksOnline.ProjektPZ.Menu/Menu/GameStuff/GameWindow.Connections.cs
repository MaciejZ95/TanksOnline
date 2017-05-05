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
using System.Windows.Forms;
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
                    }
                }));
            });

            gameHub.On<int, int>("BulletKilledPlayer", (killedMatchId, nextPlayerMatchId) =>
            {
                this.Invoke(new Action(() =>
                {
                    _tanks[killedMatchId].Dead = true;

                    var player = _room.Players.Single(p => p.IdInMatch == killedMatchId);
                    var message = $"Czołg gracza {player.User.Name} został zniszczony!";
                    switch (MessageBox.Show(message, "Gracz został pokonany!", MessageBoxButtons.OK))
                    {
                        case DialogResult.Yes: // TODO RK: Potem można zrobić jakieś fajne akcje na tej zasadzie. Może :> 
                            break;
                        case DialogResult.No: break;
                    }

                    // TODO RK: Na razie gra powinna stać jak debil, potem powinny być akcje na zakończenie
                }));
            });

            gameHub.On<int, int>("BulletHitPlayer", (playerMatchId, nextPlayerMatchId) =>
            {
                this.Invoke(new Action(() =>
                {
                    _tanks[playerMatchId].TankHp--;

                    if (_player.IdInMatch == nextPlayerMatchId)
                    {
                        _itsMyTurn = true;
                    }
                }));
            });

            gameHub.On<PlayerShootModel>("PlayerShooted", model =>
            {
                this.Invoke(new Action(() =>
                {
                    _bullets.Add(new Bullet(_tanks[model.PlayerMatchId], model.Angle, model.Speed, model.AirSpeed, model.Mass, model.Gravity, -1, true)
                    {
                        Origin = new Vector2f(2f, 2f),
                        Position = new Vector2f(model.X, model.Y),
                        FillColor = Color.Black,
                        Radius = 4,
                    });
                }));
            });

            await hubConnection.Start();
            // Czyszczenie tylko przez pierwszego gracza
            if (_player.IdInMatch == 0) await gameHub.Invoke("ClearDbAndConnect", _room.Id, _player.Id);
            else await gameHub.Invoke("Connect", _player.Id);
        }

        private async Task BulletFallDown()
        {
            await gameHub.Invoke("BulletFallDown", _player.Id);
        }

        /// <summary>
        /// Akcja gdy pocisk rąbnie w przeciwnika
        /// </summary>
        /// <param name="shootedPlayerMatchId"></param>
        /// <returns></returns>
        private async Task BulletHitPlayer(int shootedPlayerMatchId)
        {
            await gameHub.Invoke("BulletHitPlayer", _player.Id, shootedPlayerMatchId);
        }

        private async Task BulletKilledPlayer(int killedMatchId)
        {
            await gameHub.Invoke("BulletKilledPlayer", _player.Id, killedMatchId);
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
