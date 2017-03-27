using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TanksOnline.ProjektPZ.Server.Domain.Entities;
using TanksOnline.ProjektPZ.Server.Models;
using TanksOnline.ProjektPZ.Server.Models.UserModels;

using System.Reflection;
using TanksOnline.ProjektPZ.Server.Domain;

namespace TanksOnline.ProjektPZ.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;

                cfg.AddProfiles(Assembly.GetExecutingAssembly());
            });
        }
    }
}
