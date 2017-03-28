using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu.Model;
using System.Net.Http.Headers;

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
            nick.Text = "Witaj w grze " + user.Name;
            client = clt;
        }
        private void logOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.url = null;
                this.Hide();
                var createForm = new Login();
                createForm.Closed += (s, args) => this.Close();
                createForm.Show();              
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
    }
}
