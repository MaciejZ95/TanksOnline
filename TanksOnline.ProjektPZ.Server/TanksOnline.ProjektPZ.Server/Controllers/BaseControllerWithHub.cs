using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TanksOnline.ProjektPZ.Server.Controllers
{
    public abstract class BaseControllerWithHub<THub> : BaseController where THub : Hub 
    {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(
            () => GlobalHost.ConnectionManager.GetHubContext<THub>()
        );

        protected IHubContext Hub {
            get { return hub.Value; }
        }
    }
}
