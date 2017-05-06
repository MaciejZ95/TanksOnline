using Menu.Models;
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
    public partial class PrivateRoom : Form
    {
        static HttpClient client = null;
        private Uri url = null;
        private UserModel user = null;
        private GameRoomModel room = null;
        private PlayerModel player = null;

        public PrivateRoom(Uri logged, GameRoomModel room, HttpClient clt, UserModel user, PlayerModel player)
        {
            this.url = logged;
            this.user = user;
            this.player = player;
            client = clt;
            this.room = room;
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
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
