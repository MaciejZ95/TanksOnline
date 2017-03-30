using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanksOnline.ProjectPZ.HttpListener.Models;
using System.IO;
using TanksOnline.ProjectPZ.HttpListener.Extensions;
using Newtonsoft.Json;
using TanksOnline.ProjectPZ.HttpListener.Models.Player;

namespace TanksOnline.ProjectPZ.HttpListener
{
    public class HttpListener
    {
        private HttpClient client;

        public HttpListener()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void CreateRoom()
        {
            //var room = new GameRoomModel
            //{
            //    Match = new MatchModel(),
            //    PlayersLimit = 2,
            //};
            //room.Players = new List<PlayerModel>
            //{
            //    new PlayerModel { IdInMatch = 0, TankHP = 4, TurretAngle = 90, User = new UserModel {  } }   
            //}
        }

        public UserModel AddUser()
        {
            var user = new UserModel
            {
                Email = "mail6@gg.pl",
                Name = "ZbigniewStonoga",
                Password = "12345",
            };
            throw new NotSupportedException();
            //var response = client.PostAsJsonAsync("api/users", user).Result;            
            //return response.Content.ReadAsAsync<UserModel>().Result;
        }

        public async Task<GameRoomModel> GetRoom(int id = 1)
        {
            var response = await client.GetStringAsync($"api/gamerooms/{id}");

            return JsonConvert.DeserializeObject<GameRoomModel>(response);
        }

        public async Task<PlayerModel> GetPlayer(int id)
        {
            var response = await client.GetStringAsync($"api/players/{id}");
            return JsonConvert.DeserializeObject<PlayerModel>(response);
        }

        public async Task SetPlayerCanon(int id, float angle)
        {
            var response = await client.PutAsJsonAsync($"api/players/{id}/turret", new PutTurretAngleModel { Angle = angle });
            if(response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception("Something is wrong");
            }
        }

        public async Task<PlayerModel> GetPlayerByNameAndEmail(string name = "RomanCzoug", string email = "mail3@gg.pl")
        {
            var response = await client.GetAsync(Uri.EscapeUriString($"api/Players/User/Name/{name}/Email/{email}/"));

            response.EnsureSuccessStatusCode();

            var str = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PlayerModel>(str);
        }
    }
}
