using Menu.Models;
using Menu.Models.Player;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Views
{
    partial class GameWindow
    {
        private HubConnection hubConnection;
        private IHubProxy myHub;
        private readonly HttpClient _client;

        private async Task InitializeSignalRHub()
        {
            hubConnection = new HubConnection("http://localhost:21021/");
            myHub = hubConnection.CreateHubProxy("TankTurretHub");
            myHub.On<TurretChangedModel> ("TurretAngleChanged", x =>
            {
                this.Invoke((Action)(() =>
                {
                    _tanks[x.PlayerMatchId].TurretAngle = x.Angle;
                }));
            });

            hubConnection.Start().Wait();
            await myHub.Invoke("Connect", _room.Id);
        }

        private async Task SetPlayerCanon(int id, float turretAngle)
        {
            //var response = await _client.PutAsJsonAsync($"api/players/{id}/turret", new PutTurretAngleModel { Angle = turretAngle });
            //if (response.StatusCode != HttpStatusCode.NoContent)
            //{
            //    throw new Exception("Something is wrong");
            //}
            await myHub.Invoke("NewTurretAngle", _room.Id, id, turretAngle);
        }

        private async Task<GameRoomModel> GetRoom(int id = 1)
        {
            var response = await _client.GetStringAsync($"api/gamerooms/{id}");

            return JsonConvert.DeserializeObject<GameRoomModel>(response);
        }
        
        class TurretChangedModel
        {
            public float Angle { get; set; }
            public int PlayerMatchId { get; set; }
        }
    }
}
