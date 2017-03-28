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
    public partial class Register : Form
    {
        static HttpClient client = null;
        public Register()
        {
            InitializeComponent();
        }

        private async void create_Click(object sender, EventArgs e)
        {
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:21021/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Create a new user
                    RegisterModel user = new RegisterModel
                    {
                        Email = email.Text,
                        Name = nick.Text,
                        Password = password.Text,
                    };
                    await CreateUserAsync(user);
                    this.Hide();
                    var createForm = new Login();
                    createForm.Closed += (s, args) => this.Close();
                    createForm.Show();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }

            }
        }
        static async Task<Uri> CreateUserAsync(RegisterModel user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/Register", user);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createForm = new Login();
            createForm.Closed += (s, args) => this.Close();
            createForm.Show();
        }
    }
}
