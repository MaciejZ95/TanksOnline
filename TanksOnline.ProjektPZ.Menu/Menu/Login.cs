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
using Menu.Model;
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

        private void create_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createForm = new Register();
            createForm.Closed += (s, args) => this.Close();
            createForm.Show();            
       }

        private async void login_Click(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                //utworzenie uzytkownika z modelu oraz przesłanie go do funkcji CheckUser
                var url = await CheckUser(new LoginModel() { Email = email.Text, Password = password.Text });
                var user = await GetUserAsync(url.PathAndQuery);
                this.Hide();
                var createForm = new UserPanel(url, client, user);
                createForm.Closed += (s, args) => this.Close();
                createForm.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
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
    }
}
