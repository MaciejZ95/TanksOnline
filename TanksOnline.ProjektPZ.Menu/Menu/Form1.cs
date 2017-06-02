using Microsoft.AspNet.SignalR.Client;
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


namespace Menu
{
    public partial class Form1 : Form
    {
        private HubConnection hubConnection;
        private IHubProxy myHub;
        UserModel user;

        public Form1(Uri logged, HttpClient clt, UserModel user, UserModel usr)
        {
            InitializeComponent();

            this.user = user;
            hubConnection = new HubConnection("http://localhost:21021");
            myHub = hubConnection.CreateHubProxy("MyHub");
            myHub.On<Test>("SomeOneSendHello", x =>
            {
                Console.WriteLine($"{x.Name} pisze: {x.Message}");
                this.Invoke((Action)(() => Messages.AppendText($"{x.Name} pisze: {x.Message}\n")));
            });

            hubConnection.Start().Wait();
        }

        private async void SendMessage_Click(object sender, EventArgs e)
        {
            await myHub.Invoke("Hello", new Test { Name = user.Name, Message = TbMessage.Text });
            TbMessage.Clear();
        }

    }

    class Test
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}