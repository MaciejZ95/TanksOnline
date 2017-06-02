using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Menu
{
    public partial class Login : Form
    {
        //static User user = null;
        static HttpClient client = null;
        public Login()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                this.Hide();
                var createForm = new Register();
                createForm.Closed += (s, args) => this.Show();
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

        static async Task<Uri> PutUser(int id, UserModel user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/users/" + id, user);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                //utworzenie uzytkownika z modelu oraz przesłanie go do funkcji CheckUser
                var url = await CheckUser(new LoginModel() { Email = emailInput.Text, Password = passwordInput.Text });
                var user = await GetUserAsync(url.PathAndQuery);
                if (user.status != UserModel.UserStatus.Offline)
                {
                    MessageBox.Show("Ten użytkownik jest obecnie zalogowany.", "Informacja");
                }
                else
                {
                    user.status = UserModel.UserStatus.Logged;
                    await PutUser(user.Id, user);
                    this.Hide();
                    var createForm = new UserPanel(url, client, user);
                    createForm.Closed += (s, args) => this.Close();
                    createForm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Podano złe dane logowania", "Uwaga!");
            }
            finally
            {
                this.Enabled = true;
            }
       
        }
        //sprawdzenie użytkownika, czyli przesłanie na serwer i tam zostaje porównany i przesłany response.
        static async Task<Uri> CheckUser(LoginModel model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/Login", model);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }
        private async Task<UserModel> GetUserAsync(string path)
        {
            UserModel user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserModel>();
            }
            return user;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
