using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using Menu.Models;
using Newtonsoft.Json;
using Menu.Views;

namespace Menu
{
    public partial class UserPanel : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;
        private readonly bool _gameDebugMode;

        public UserPanel(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            this.url = logged;
            this.user = user;
            client = clt;
            nicknameLabel.Text = user.Name;
        }

        public UserPanel(Uri logged, HttpClient clt, UserModel user, bool gameDebugMode)
            : this(logged, clt, user)
        {
            _gameDebugMode = gameDebugMode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createForm = new Settings(url, client, user);
            createForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Ranking form = new Ranking();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            friendsList.View = View.Details;
            friendsList.Columns.Add("Znajomi", 250);
            ImageList list = new ImageList();
            list.ImageSize = new Size(30,30);
            // dodanie obrazków z bazy danych
            friendsList.SmallImageList = list;
        }

        #region Create public room button 
        private async void startButton_Click(object sender, EventArgs e)
        {
            if (_gameDebugMode)
            {
                // Tryb testowy, nie ruszać - korzystam tu ze stałych wartości dla ułatwienia
                var player = JsonConvert.DeserializeObject<PlayerModel>(await client.GetStringAsync($"api/Players/User/{user.Id}"));
                var room = JsonConvert.DeserializeObject<GameRoomModel>(await client.GetStringAsync($"api/GameRooms/GetByPlayer/{player.Id}"));

                this.Hide();
                var game = await GameWindow.Create(room, player, client);
                game.Closed += (s, ev) => this.Close();
                game.Show();
            }
            else
            {
                if (false == await GetCheckRoomAsync())
                {
                    //Todo --- gdy nie ma pokoju to tworzymy nowy pokój publiczny, a gdy istenieje to dochodzimy do istniejącego
                    this.Enabled = false;
                    try
                    {
                        RoomModel model = new RoomModel()
                        {
                            Id = user.Id,
                            Limit = 2
                        };
                        var roomUri = await CreateRoomAsync(model);
                        var room = await GetRoomAsync(roomUri.PathAndQuery);
                        var player = room.Players.Where(x => x.User.Id == user.Id).FirstOrDefault();
                        this.Hide();
                        var createForm = new PublicRoom(url, room, client, user, player);
                        createForm.Closed += (s, args) => this.Close();
                        createForm.Show();

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                    finally
                    {
                        this.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("SĄ WOLNE MIEJSCA!!");
                    try
                    {
                        var room = await AddPlayerToRoomAsync(user.Id);
                        var player = room.Players.Where(x => x.User.Id == user.Id).FirstOrDefault();
                        this.Hide();
                        var createForm = new PublicRoom(url, room, client, user, player);
                        createForm.Closed += (s, args) => this.Close();
                        createForm.Show();

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                    finally
                    {
                        this.Enabled = true;
                    }
                }
            }
        }
        #endregion

        #region Create Private room button
        private async void CreatePrivateRoom_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            try
            {
                RoomModel model = new RoomModel()
                {
                    Id = user.Id,
                    Limit = 2
                };
                var roomUri = await CreateRoomAsync(model);
                var room = await GetRoomAsync(roomUri.PathAndQuery);
                var player = room.Players.Where(x => x.User.Id == user.Id).FirstOrDefault();

                this.Hide();
                var createForm = new PrivateRoom(url, room, client, user, player);
                createForm.Closed += (s, args) => this.Close();
                createForm.Show();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }
        #endregion

        #region POST ROOM
        static async Task<Uri> CreateRoomAsync(RoomModel model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/GameRooms", model);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }
        #endregion

        #region Check rooms exists    
        private async Task<PlayerModel> GetPlayerAsync()
        {
            PlayerModel player = null;
            HttpResponseMessage response = await client.GetAsync($"api/GameRooms");
            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<PlayerModel>();
            }
            return player;
        }
        #endregion

        #region Check rooms exists    
        private async Task<bool> GetCheckRoomAsync()
        {
            bool room = false;
            HttpResponseMessage response = await client.GetAsync($"api/GameRooms");
            if (response.IsSuccessStatusCode)
            {
                room = await response.Content.ReadAsAsync<bool>();
            }
            return room;
        }
        #endregion

        #region Add player to room 
        private async Task<GameRoomModel> AddPlayerToRoomAsync(int id)
        {
            GameRoomModel room = null;
            HttpResponseMessage response = await client.GetAsync($"api/GameRooms/FindEmptyRoom/ForUser/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                room = await response.Content.ReadAsAsync<GameRoomModel>();
            }
            return room;
        }
        #endregion

        #region Get player room 
        private async Task<GameRoomModel> GetRoomAsync(string path)
        {
            GameRoomModel room = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                room = await response.Content.ReadAsAsync<GameRoomModel>();
            }
            return room;
        }
        #endregion

        #region Get player 

        #endregion
    }
}
