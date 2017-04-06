using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TanksOnline.ProjektPZ.Server.Controllers.Hubs
{
    public class MyHub : Hub<MyHub.ITest>
    {
        public void Hello(Test hi)
        {
            Clients.All.SomeOneSendHello(hi);
        }

        public interface ITest
        {
            void SomeOneSendHello(Test hi);
        }

        public class Test
        {
            public string Name { get; set; }
            public string Message { get; set; }
        }
    }
}