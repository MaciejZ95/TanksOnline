using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    /// <summary>
    /// Rozgrywka
    /// </summary>
    public class Match
    {
        public int Id { get; set; }
        public int ActualPlayer { get; set; }
        public List<Player> Players { get; set; }
    }

    public class MatchMap : EntityTypeConfiguration<Match>
    {
        public MatchMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.ActualPlayer).IsRequired();
            this.HasMany(x => x.Players);
        }
    }
}