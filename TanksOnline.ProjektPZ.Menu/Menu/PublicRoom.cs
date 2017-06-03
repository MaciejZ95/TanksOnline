using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Menu.Views;
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
                var roomBuf = await GetActualRoomMate(this.room.Id);
                //this.room = roomBuf;
                if (roomBuf.Players.Count == roomBuf.PlayersLimit)
                {
                    //usuwanie gracza z pokoju
                    await DeleteProductAsync(player.Id);
                    this.Hide();
                    var panel = new UserPanel(url, client, user);
                    panel.Closed += (s, ev) => this.Close();
                    panel.Show();

                }
                else if (roomBuf.Players.Count == 1)
                {
                    //usuwanie gracza 
                    //usuwanie pokoju

                    this.Hide();
                    var panel = new UserPanel(url, client, user);
                    panel.Closed += (s, ev) => this.Close();
                    panel.Show();
                }
                
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
        private async Task<GameRoomModel> GetActualRoomMate(int Id)
        {
            GameRoomModel room = null;
            HttpResponseMessage response = await client.GetAsync($"api/GameRooms/{this.room.Id}");
            if (response.IsSuccessStatusCode)
            {
                room = await response.Content.ReadAsAsync<GameRoomModel>();
            }
            return room;
        }

        private  async void refresh_Click(object sender, EventArgs e)
        {
            playerListText.Text = "";
            try
            {
                var roomBuf = await GetActualRoomMate(this.room.Id);
                //this.room = roomBuf;
                foreach (var p in roomBuf.Players)
                {
                    playerListText.Text += p.User.Name + " " + p.User.status + "\r\n";
                }
                if (roomBuf.Players.Count == roomBuf.PlayersLimit)
                {
                    MessageBox.Show("Pokój jest pełen. Można zaczynać grę!");
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


        //private async Task<>
        
    }
}
