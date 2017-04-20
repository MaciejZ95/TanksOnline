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
using System.IO;

namespace Menu
{
    public partial class UserPanel : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;
        private readonly bool _gameDebugMode;
        static string filePath;
        static Bitmap MyImage;

        public UserPanel(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            this.url = logged;
            this.user = user;
            client = clt;
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
            createForm.FormClosed += new FormClosedEventHandler(Form1_Load);
            createForm.Show(this);
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            byte[] photo;
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName.ToString();
                ShowMyImage(filePath);
                photo = GetPhoto(filePath);
                user.Photo = photo;

                await PutUser(user.Id, user);
            }
        }

        static async Task<Uri> PutUser(int id, UserModel user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/users/" + id, user);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        public void ShowMyImage(String fileToDisplay)
        {
            if (MyImage != null)
            {
                MyImage.Dispose();
            }

            MyImage = new Bitmap(fileToDisplay);
            avatarPB.Image = (Image)MyImage;
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
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
            nicknameLabel.Text = user.Name;
            if (user.Photo != null)
            {
                using (var ms = new MemoryStream(user.Photo))
                {
                    MyImage = new Bitmap(ms);
                }
                avatarPB.Image = (Image)MyImage;
            }
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

        private void addfriendButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
