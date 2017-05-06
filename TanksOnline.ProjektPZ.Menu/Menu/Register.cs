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
using Menu.Models;
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

        private async void createButton_Click(object sender, EventArgs e)
        {
            {
                this.Enabled = false;
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:21021/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    if (emailInput.Text == emailconfirmInput.Text && passwordInput.Text == passwordconfirmInput.Text && emailInput.Text!="" && passwordInput.Text!="" && nicknameInput.Text!="")
                    {
                        // Create a new user
                        RegisterModel user = new RegisterModel
                        {
                            Email = emailInput.Text,
                            Name = nicknameInput.Text,
                            Password = passwordInput.Text,
                        };
                        await CreateUserAsync(user);
                        this.Hide();
                        var createForm = new Login();
                        createForm.Closed += (s, args) => this.Close();
                        createForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wprowadź poprawne dane.", "Uwaga!");
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
                finally
                {
                    this.Enabled = true;
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
            this.Enabled = false;
            try
            {
                this.Hide();
                var createForm = new Login();
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
    }
}
