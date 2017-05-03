﻿using Menu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class PublicRoom : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;
        private Uri roomUri = null;

        public PublicRoom(Uri logged, Uri roomUri, HttpClient clt, UserModel user)
        {
            this.url = logged;
            this.user = user;
            client = clt;
            this.roomUri = roomUri;
            InitializeComponent();
        }

        private void leaveRoomButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                this.Hide();
                var createForm = new UserPanel(url, client, user);
                createForm.Closed += (s, args) => this.Close();
                createForm.Show();
            }
            catch (Exception)
            {

            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void enterToGameButton_Click(object sender, EventArgs e)
        {

        }
        private async Task<GameRoomModel> GetPlayerName(string path)
        {
            GameRoomModel room = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                room = await response.Content.ReadAsAsync<GameRoomModel>();
            }
            return room;
        }

        private async void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                var room = await GetPlayerName(roomUri.PathAndQuery);
                foreach (var p in room.Players)
                {
                    playerListText.Text += p.User.Name + "\n" ;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("błąd!");
            }
          
        }
    }
}
