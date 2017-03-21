using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TanksOnline.ProjektPZ.Server.Domain.Entities;

namespace TanksOnline.ProjektPZ.Server.Domain
{
    public class Db : DbContext
    {
        public Db() : base("TanksOnlineDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<TankInfo> TankInfoes { get; set; }
        public DbSet<UserScore> UserScores { get; set; }
        public DbSet<GameRoom> GameRooms { get; set; }

        public System.Data.Entity.DbSet<TanksOnline.ProjektPZ.Server.Domain.Entities.Player> Players { get; set; }
    }
}