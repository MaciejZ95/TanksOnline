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
using Menu.Model;
using TanksOnline.ProjektPZ.Game.Views;
using TanksOnline.ProjectPZ.HttpListener;

namespace Menu
{
    public partial class UserPanel : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;

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

        public UserPanel(Uri logged, HttpClient clt, UserModel user, bool huehue)
            : this(logged, clt, user)
        {
            this.Hide();
            startButton_Click(null, null);
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
            this.Hide();
            // TODO RK: Chwilowo bez sensu byle coś działało
            var listener = new HttpListener();
            var room = await listener.GetRoom();

            var gameWindow = new GameWindow(room, room.Players.First());
            gameWindow.Closed += (s, args) => this.Close();
            gameWindow.Show();
        }
    }
}
