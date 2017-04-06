using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TanksOnline.ProjektPZ.Server.App_Start.Startup))]
namespace TanksOnline.ProjektPZ.Server.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}