using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Models.GameRoomModels
{
    using AutoMapper;
    using Domain.Entities;
    using MatchModels;
    using PlayerModels;
    using UserModels;

    public class GameRoomModel
    {
        public int Id { get; set; }
        public int PlayersLimit { get; set; }
        public MatchModel Match { get; set; }
        public UserModel Owner { get; set; }
        public List<PlayerModel> Players { get; set; }
    }
}