using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Menu.Views;
using System.Net;
using System.Threading;

namespace Menu
{
    public partial class PublicRoom : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;
        private GameRoomModel room = null;
        private PlayerModel player = null;
        private Thread t = null;

        public PublicRoom(Uri logged, GameRoomModel room, HttpClient clt, UserModel user, PlayerModel player)
        {
            this.url = logged;
            this.user = user;
            this.player = player;
            client = clt;
            this.room = room;
            InitializeComponent();
            t = new Thread(checkUsers);
            t.Start();
        }

        private async void leaveRoomButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            t.Abort();
            try
            {
                var roomBuf = await GetActualRoomMate(this.room.Id);
                this.room = roomBuf;
                if (roomBuf.Players.Count == room.PlayersLimit)
                {
                    //usuwanie gracza z pokoju
                    //Dunno. 
                    await DeleteProductAsync(player.Id);
                    this.Hide();
                    var panel = new UserPanel(url, client, user);
                    panel.Closed += (s, ev) => this.Close();
                    panel.Show();
                }
                else if (room.Players.Count == 1)
                {
                    //usuwanie gracza 
                    //usuwanie pokoju
                    //Dunno.
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
            t.Abort();
            //aktualizacja pokoju
            var roomBuf = await GetActualRoomMate(this.room.Id);
            this.room = roomBuf;
            //Zmiana statusu
            if (room.Players.Count == room.PlayersLimit)
            {
                this.Hide();
                var game = await GameWindow.Create(room, player, client);
                game.Closed += (s, ev) => this.Close();
                game.Show();
            }
            else
            {
                MessageBox.Show("Pokoj nie jest pełny. Nie można rozpocząć gry!");
            }
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

        private async void checkUsers()
        {
            while (true)
            {
                playerListLabel.Text = "";
                try
                {
                    var roomBuf = await GetActualRoomMate(this.room.Id);
                    this.room = roomBuf;
                    foreach (var p in room.Players)
                    {
                        playerListLabel.Text += p.User.Name + " " + p.User.status + "\r\n";
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show(excp.Message);
                }
                Thread.Sleep(1000);
            }

        }

        private async Task<HttpStatusCode> DeleteProductAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Players/{id}");
            return response.StatusCode;
        }
    }
}
