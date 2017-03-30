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

namespace Menu
{
    public partial class Settings : Form
    {
        public Settings(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            emailInput.Text = user.Email;
            nicknameInput.Text = user.Name;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewsList.Items[0].Selected == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (viewsList.Items[1].Selected == true)
            {
                panel2.Visible = true;            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            viewsList.Items[0].Selected = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }
}
