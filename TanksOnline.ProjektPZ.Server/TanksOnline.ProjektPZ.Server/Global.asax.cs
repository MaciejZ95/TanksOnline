using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TanksOnline.ProjektPZ.Server.Domain.Entities;
using TanksOnline.ProjektPZ.Server.Models;

namespace TanksOnline.ProjektPZ.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserModel, User>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Status, opt => opt.Ignore())
                    .ForMember(dest => dest.TankInfo, opt => opt.Ignore())
                    .ForMember(dest => dest.UserScore, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        dest.UserScore = new UserScore();
                        dest.TankInfo = new TankInfo();
                        dest.Status = Domain.Enums.UserStatus.Offline;
                    });
            });
        }
    }
}
