using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Menu.Views;
using Menu.Models;
using System.Net;

namespace Menu
{
    public partial class PublicRoom : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;
        private GameRoomModel room = null;
        private PlayerModel player = null;

        public PublicRoom(Uri logged, GameRoomModel room, HttpClient clt, UserModel user, PlayerModel player)
        {
            this.url = logged;
            this.user = user;
            this.player = player;
            client = clt;
            this.room = room;
            InitializeComponent();
        }

        private async void leaveRoomButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                await DeleteProductAsync(player.Id);
                this.Hide();
                var createForm = new UserPanel(url, client, user);
                createForm.Closed += (s, args) => this.Close();
                createForm.Show();
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private async void enterToGameButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var game = await GameWindow.Create(room, player, client);
            game.Closed += (s, ev) => this.Close();
            game.Show();
        }
        private async Task<GameRoomModel> GetPlayerName(int Id)
        {
            GameRoomModel room = null;
            HttpResponseMessage response = await client.GetAsync("api/GameRooms/");
            if (response.IsSuccessStatusCode)
            {
                room = await response.Content.ReadAsAsync<GameRoomModel>();
            }
            return room;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                //var rooms = await GetPlayerName(room.Id);
                foreach (var p in room.Players)
                {
                    playerListText.Text += p.User.Name + "\r\n";
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }          
        }

        private async Task<HttpStatusCode> DeleteProductAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Players/{id}");
            return response.StatusCode;
        }

    }
}
