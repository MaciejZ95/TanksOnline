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

            gameHub.On<float, int>("TurretAngleChanged", OnTurretAngleChangedEvent);
            gameHub.On<int>("ThisPlayerTurn", OnThisPlayerTurnEvent);
            gameHub.On<int>("BulletKilledPlayer", OnBulletKilledPlayerEvent);
            gameHub.On<int, int>("BulletHitPlayer", OnBulletHitPlayerEvent);
            gameHub.On<PlayerShootModel>("PlayerShooted", OnPlayerShootedEvent);
            gameHub.On("SomeOneLeaveRoom", OnSomeOneLeaveRoomEvent);

            await hubConnection.Start();
            await gameHub.Invoke("Connect", _player.Id);
        }

        #region Obsługa zewnętrznych zdarzeń SignalR
        private void OnTurretAngleChangedEvent(float angle, int playerMatchId)
        {
            this.Invoke(new Action(() =>
            {
                _tanks[playerMatchId].TurretAngle = angle;
            }));
        }

        private void OnThisPlayerTurnEvent(int playerMatchId)
        {
            this.Invoke(new Action(() =>
            {
                if (_player.IdInMatch == playerMatchId)
                {
                    _itsMyTurn = true;
                }
            }));
        }

        private void OnBulletKilledPlayerEvent(int killedMatchId)
        {
            this.Invoke(new Action(() =>
            {
                _tanks[killedMatchId].Dead = true;

                var player = _room.Players.Single(p => p.IdInMatch == killedMatchId);
                var message = $"Czołg gracza {player.User.Name} został zniszczony!";
                MessageBox.Show(message, "Gracz został pokonany!", MessageBoxButtons.OK);

                // TODO RK: Na razie gra powinna stać jak debil, potem powinny być akcje na zakończenie
            }));
        }

        private void OnPlayerShootedEvent(PlayerShootModel model)
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
        }

        private void OnBulletHitPlayerEvent(int playerMatchId, int nextPlayerMatchId)
        {
            this.Invoke(new Action(() =>
            {
                _tanks[playerMatchId].TankHp--;

                if (_player.IdInMatch == nextPlayerMatchId)
                {
                    _itsMyTurn = true;
                }
            }));
        }

        private void OnSomeOneLeaveRoomEvent()
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show("UPS", "Gracz opuścił pokój!", MessageBoxButtons.OK);
                Close();
            }));
        }
        #endregion

        #region Zdarzenia SignalR wywoływane przez użytkownika
        private async Task BulletFallDown()
        {
            await gameHub.Invoke("BulletFallDown", _player.Id);
        }

        private async Task CloseRoom()
        {
            await gameHub.Invoke("CloseRoom", _room.Id);
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
        #endregion

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
