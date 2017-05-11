using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Menu.Models;
using System.IO;

namespace Menu
{
    public partial class AddFriends : Form
    {
        static HttpClient client;
        UserModel user;
        Bitmap Image;
        ImageList imagelist;
        UserModel usr;
        public AddFriends(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            client = clt;
            this.user = user;
            imagelist = new ImageList();
            imagelist.ImageSize = new Size(50, 50);
        }

        static async Task<Uri> CheckUser(UserModel model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/Users", model);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
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

        static async Task<Uri> PostFriend(FriendsModel user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/friends", user);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        private async void CheckKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                listView1.Items.Clear();
                imagelist.Images.Clear();
                usr = await GetUserAsync(nicknameInput.Text);
                if (usr != null && usr.Email!=user.Email)
                {
                    if (usr.Photo != null)
                    {
                        using (var ms = new MemoryStream(usr.Photo))
                        {
                            Image = new Bitmap(ms);
                        }
                        imagelist.Images.Add(Image);
                        listView1.SmallImageList = imagelist;
                    }
                    ListViewItem item1 = new ListViewItem(usr.Name);
                    item1.ImageIndex = 0;
                    if (usr.status == UserModel.UserStatus.Offline)
                    {
                        item1.SubItems.Add("Offline");
                    }
                    else
                    {
                        item1.SubItems.Add("Online");
                    }
                    listView1.Items.Add(item1);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono takiego użytkownika", "Informacja");
                }
            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {

            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //jeśli nie są znajomymi
            if (listView1.SelectedItems.Count == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FriendsModel f = new FriendsModel();
            f.FriendId = usr.Id;
            f.UserId = user.Id;
            await PostFriend(f);
            MessageBox.Show("Dodano znajomego", "Informacja");
        }
    }
}
