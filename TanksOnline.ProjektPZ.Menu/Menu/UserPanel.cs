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
            /*for (int i = 0; i < tab.Length; i++)
            {
                this.listView1.Items[i] = tab[i];
            }*/
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
                // TODO MZ: Maciek - normalne otwieranie okna do zrobienia przez Maćka
            }
        }
    }
}
