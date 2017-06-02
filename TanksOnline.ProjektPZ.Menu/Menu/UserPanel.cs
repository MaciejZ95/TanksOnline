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
        List<FriendsModel> l;

        public UserPanel(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            this.url = logged;
            this.user = user;
            client = clt;

            imagelist = new ImageList();
            imagelist.ImageSize = new Size(50, 50);
            this.ControlBox = false;
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

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (friendsList.FocusedItem.Bounds.Contains(e.Location) == true && friendsList.FocusedItem.Group.Header == "Znajomi")
                {
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[4].Text = "Usuń znajomego";
                    contextMenuStrip1.Show(Cursor.Position);
                }
                else if (friendsList.FocusedItem.Bounds.Contains(e.Location) == true && friendsList.FocusedItem.Group.Header == "Zaproszenia")
                    {
                    contextMenuStrip1.Items[1].Visible = true;
                    contextMenuStrip1.Items[4].Text = "Usuń zaproszenie";
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        static async Task<Uri> PutUser(int id, UserModel user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/users/" + id, user);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Uri> PutFriend(int id, FriendsModel friend)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/friends/" + id, friend);
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
            var createForm = new Ranking(url, client, user, false, 0);
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
            l = new List<FriendsModel>();
            var result = await client.GetStringAsync($"api/friends/");
            l = JsonConvert.DeserializeObject<List<FriendsModel>>(result);
            int x = 0;
            int y = 0;
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
                        else if (u.status == UserModel.UserStatus.Ready)
                        {
                            item1.SubItems.Add("Czeka na przeciwnika");
                        }
                        else
                        {
                            item1.SubItems.Add("Online");
                        }
                        item1.ImageIndex=x;
                        friendsList.Items.Add(item1);
                        if (l[i].Date != null)
                        {
                            friendsList.Items[y].Group = friendsList.Groups[0];
                        }
                        else
                        {
                            friendsList.Items[y].Group = friendsList.Groups[1];
                        }
                        x++;
                        y++;
                    }
                    else
                    {
                        item1 = new ListViewItem(u.Name);
                        if (u.status == UserModel.UserStatus.Offline)
                        {
                            item1.SubItems.Add("Offline");
                        }
                        else if (u.status == UserModel.UserStatus.Ready)
                        {
                            item1.SubItems.Add("Czeka na przeciwnika");
                        }
                        else
                        {
                            item1.SubItems.Add("Online");
                        }
                        friendsList.Items.Add(item1);
                        if (l[i].Date != null)
                        {
                            friendsList.Items[y].Group = friendsList.Groups[0];
                        }
                        else
                        {
                            friendsList.Items[y].Group = friendsList.Groups[1];
                        }
                        y++;
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
            var createForm = new AddFriends(url, client, user, l);
            createForm.FormClosed += new FormClosedEventHandler(Form1_Load);
            createForm.Show(this);
        }

        private async Task<UserModel> GetUserAsync(string name)
        {
            UserModel user = null;
            HttpResponseMessage response = await client.GetAsync($"api/users/getuser/" + name);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserModel>();
            }
            return user;
        }

        private async void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string txt = friendsList.FocusedItem.Text;
            contextMenuStrip1.Hide();
            UserModel usr = new UserModel();
            FriendsModel f1, f2, f3;
            switch (e.ClickedItem.Text)
            {
                case "Dołącz do gry":
                    break;
                case "Dodaj znajomego":
                    usr = await GetUserAsync(txt);
                    f1 = new FriendsModel();
                    f1.UserId = user.Id;
                    f1.FriendId = usr.Id;
                    f1.Date = DateTime.Now;
                    for(int i=0; i<l.Count();i++)
                    {
                        if(f1.UserId == l[i].UserId && f1.FriendId == l[i].FriendId)
                        {
                            f1.RelationId = l[i].RelationId;
                        }
                    }
                    await PutFriend(f1.RelationId, f1);
                    Form1_Load(this, null);
                    break;
                case "Czat":
                    usr = await GetUserAsync(txt);
                    var createForm = new Form1(url, client, user, usr);
                    createForm.Show(this);
                    break;
                case "Statystyki znajomego":
                    usr = await GetUserAsync(txt);
                    Ranking createForm1 = new Ranking(url, client, user, true, usr.Id);
                    createForm1.Show(this);
                    break;
                case "Usuń znajomego":
                    usr = await GetUserAsync(txt);
                    f2 = new FriendsModel();
                    f3 = new FriendsModel();
                    f3.FriendId = f2.UserId = user.Id;
                    f3.UserId = f2.FriendId = usr.Id;
                    for (int i = 0; i < l.Count(); i++)
                    {
                        if (f2.UserId == l[i].UserId && f2.FriendId == l[i].FriendId)
                        {
                            f2.RelationId = l[i].RelationId;
                        }
                        else if (f3.UserId == l[i].UserId && f3.FriendId == l[i].FriendId)
                        {
                            f3.RelationId = l[i].RelationId;
                        }
                    }
                    await client.DeleteAsync($"api/friends/" + f2.RelationId);
                    await client.DeleteAsync($"api/friends/" + f3.RelationId);
                    Form1_Load(this, null);
                    break;
                case "Usuń zaproszenie":
                    usr = await GetUserAsync(txt);
                    f2 = new FriendsModel();
                    f3 = new FriendsModel();
                    f3.FriendId = f2.UserId = user.Id;
                    f3.UserId = f2.FriendId = usr.Id;
                    for (int i = 0; i < l.Count(); i++)
                    {
                        if (f2.UserId == l[i].UserId && f2.FriendId == l[i].FriendId)
                        {
                            f2.RelationId = l[i].RelationId;
                        }
                        else if (f3.UserId == l[i].UserId && f3.FriendId == l[i].FriendId)
                        {
                            f3.RelationId = l[i].RelationId;
                        }
                    }
                    await client.DeleteAsync($"api/friends/" + f2.RelationId);
                    await client.DeleteAsync($"api/friends/" + f3.RelationId);
                    Form1_Load(this, null);
                    break;
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            user.status = UserModel.UserStatus.Offline;
            await PutUser(user.Id, user);
            this.Hide();
            var createForm = new Login();
            createForm.Closed += (s, args) => this.Close();
            createForm.Show();
        }
    }
}
