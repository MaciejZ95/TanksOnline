using Menu.Models;
using Menu.Models.Player;
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
        private readonly HttpClient _client;

        private async Task SetPlayerCanon(int id, float turretAngle)
        {
            var response = await _client.PutAsJsonAsync($"api/players/{id}/turret", new PutTurretAngleModel { Angle = turretAngle });
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception("Something is wrong");
            }
        }

        private async Task<GameRoomModel> GetRoom(int id = 1)
        {
            var response = await _client.GetStringAsync($"api/gamerooms/{id}");

            return JsonConvert.DeserializeObject<GameRoomModel>(response);
        }
    }
}
