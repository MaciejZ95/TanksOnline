﻿using System;
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
using Menu.Views;
using Newtonsoft.Json;
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
        ImageList imagelist;
        Bitmap Image;

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
            imagelist = new ImageList();
            imagelist.ImageSize = new Size(50, 50);
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
            var createForm = new Ranking(url, client, user);
            createForm.Show(this);
        }

        static async Task<FriendsModel> GetFriend(int id)
        {
            FriendsModel user = null;
            HttpResponseMessage response = await client.GetAsync($"api/friends/" + id);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<FriendsModel>();
            }
            return user;
        }

        private async Task<UserModel> GetUserAsync(int id)
        {
            UserModel user = null;
            HttpResponseMessage response = await client.GetAsync($"api/users/" + id);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserModel>();
            }
            return user;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // dodanie obrazków z bazy danych
            friendsList.Items.Clear();
            imagelist.Images.Clear();
            nicknameLabel.Text = user.Name;
            if (user.Photo != null)
            {
                using (var ms = new MemoryStream(user.Photo))
                {
                    MyImage = new Bitmap(ms);
                }
                avatarPB.Image = (Image)MyImage;
            }
            List<FriendsModel> l = new List<FriendsModel>();
            var result = await client.GetStringAsync($"api/friends/");
            l = JsonConvert.DeserializeObject<List<FriendsModel>>(result);
            int x = 0;
            UserModel u;
            ListViewItem item1 = null;
            for (int i = 0; i < l.Count; i++) 
            {
                if (l[i].UserId == user.Id)
                {
                    u = await GetUserAsync(l[i].FriendId);
                    if (u.Photo != null)
                    {
                        using (var ms = new MemoryStream(u.Photo))
                        {
                            Image = new Bitmap(ms);
                        }
                        imagelist.Images.Add(Image);
                        friendsList.SmallImageList = imagelist;
                        item1 = new ListViewItem(u.Name);
                        if (u.status == UserModel.UserStatus.Offline)
                        {
                            item1.SubItems.Add("Offline");
                        }
                        else
                        {
                            item1.SubItems.Add("Online");
                        }
                        item1.ImageIndex=x;
                        friendsList.Items.Add(item1);
                        x++;
                    }
                    else
                    {
                        item1 = new ListViewItem(u.Name);
                        if (u.status == 0)
                        {
                            item1.SubItems.Add("Offline");
                        }
                        else
                        {
                            item1.SubItems.Add("Online");
                        }
                        friendsList.Items.Add(item1);
                    }
                    
                }

            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (false == await GetCheckRoomAsync())
            {
                this.Enabled = false;
                try
                {
                    RoomModel model = new RoomModel()
                    {
                        Id = user.Id,
                        Limit = 2
                    };
                    var room = await CreateRoomAsync(model);
                    var player = room.Players.Where(x => x.User.Id == user.Id).FirstOrDefault();
                    this.Hide();
                    var createForm = new PublicRoom(url, room, client, user, player);
                    createForm.Closed += (s, args) => this.Show();
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

        static async Task<GameRoomModel> CreateRoomAsync(RoomModel model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/GameRooms", model);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return JsonConvert.DeserializeObject<GameRoomModel>(await response.Content.ReadAsStringAsync());
        }
  
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

       

        private void addfriendButton_Click(object sender, EventArgs e)
        {
            var createForm = new AddFriends(url, client, user);
            createForm.FormClosed += new FormClosedEventHandler(Form1_Load);
            createForm.Show(this);
        }
    }
}
