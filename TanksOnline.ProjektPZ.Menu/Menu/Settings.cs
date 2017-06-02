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
using System.IO;

namespace Menu
{
    public partial class Settings : Form
    {
        static HttpClient client;
        UserModel user1;
        static Bitmap MyImage;
        static string filePath;
        public Settings(Uri logged, HttpClient clt, UserModel user)
        {
            InitializeComponent();
            emailInput.Text = user.Email;
            nicknameInput.Text = user.Name;
            if (user.Photo != null)
            {
                using (var ms = new MemoryStream(user.Photo))
                {
                    MyImage = new Bitmap(ms);
                }
                avatarPB.Image = (Image)MyImage;
            }
            client = clt;
            user1 = user;
            tankPreview1.RunPreview();
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
                user1.Photo = photo;

                await PutUser(user1.Id, user1);
            }
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewsList.Items[0].Selected == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (viewsList.Items[1].Selected == true)
            {
                panel2.Visible = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            viewsList.Items[0].Selected = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static async Task<Uri> PutUser(int id, UserModel user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/users/" + id, user);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            user1.Name = nicknameInput.Text;
            user1.Email = emailInput.Text;
            if (passwordInput.Text == passwordconfirmInput.Text && passwordInput.Text != "")
            {
                user1.Password = passwordInput.Text;
            }
            user1.TankInfo.ColorR = trackBar1.Value;
            user1.TankInfo.ColorG = trackBar2.Value;
            user1.TankInfo.ColorB = trackBar3.Value;
            await PutUser(user1.Id, user1);
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tankPreview1.RED = (byte)trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            tankPreview1.GREEN = (byte)trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            tankPreview1.BLUE = (byte)trackBar3.Value;
        }
    }
}
