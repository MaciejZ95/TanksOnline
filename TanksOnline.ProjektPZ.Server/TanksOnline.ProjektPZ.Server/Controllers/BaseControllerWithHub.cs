using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TanksOnline.ProjektPZ.Server.Controllers
{
    public abstract class BaseControllerWithHub<THub, T> : BaseController where THub : Hub <T> where T : class
    {
        Lazy<IHubContext<T>> hub = new Lazy<IHubContext<T>>(
            () => GlobalHost.ConnectionManager.GetHubContext<THub, T>()
        );

        protected IHubContext<T> Hub {
            get { return hub.Value; }
        }
    }
}
