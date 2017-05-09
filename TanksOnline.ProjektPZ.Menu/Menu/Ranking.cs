using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Menu
{
    public partial class Ranking : Form
    {
        static HttpClient client;
        UserModel user;
        ImageList imagelist;

        public Ranking(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            client = clt;
            this.user = user;
        }

        private async void Ranking_Load(object sender, EventArgs e)
        {
            var result = await client.GetStringAsync($"api/users/");
            var us = JsonConvert.DeserializeObject<List<UserModel>>(result);
            for (int i = 0; i < us.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(us[i].Name);
                item1.SubItems.Add(us[i].UserScore.PlayedGames.ToString());
                item1.SubItems.Add(us[i].UserScore.WonGames.ToString());
                item1.SubItems.Add(us[i].UserScore.LostGames.ToString());
                item1.SubItems.Add(us[i].UserScore.AFK_kicks.ToString());
                listView1.Items.Add(item1);
            }
        }
    }
}
