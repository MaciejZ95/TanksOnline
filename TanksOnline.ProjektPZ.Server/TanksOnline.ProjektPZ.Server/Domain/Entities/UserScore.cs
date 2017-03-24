using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    public class UserScore
    {
        public int Id { get; set; }
        public int PlayedGames { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
        public int AFK_kicks { get; set; }
    }

    public class UserScoreMap : EntityTypeConfiguration<UserScore>
    {
        public UserScoreMap()
        {
            HasKey(x => x.Id);
            Property(x => x.PlayedGames);
            Property(x => x.WonGames);
            Property(x => x.LostGames);
            Property(x => x.AFK_kicks);
        }
    }
}