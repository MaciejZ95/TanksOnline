﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TanksOnline.ProjektPZ.Server.Domain;
using TanksOnline.ProjektPZ.Server.Domain.Entities;

namespace TanksOnline.ProjektPZ.Server.Models.UserModels
{
    public class PostUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class PostUserModelMapping : Profile
    {
        public PostUserModelMapping()
        {
            CreateMap<PostUserModel, User>()
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
        }
    }
}