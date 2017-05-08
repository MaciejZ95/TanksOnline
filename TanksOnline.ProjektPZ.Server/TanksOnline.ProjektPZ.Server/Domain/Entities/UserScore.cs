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
        /// <summary>
        /// Gry w których gracz brał udział
        /// </summary>
        public int PlayedGames { get; set; }
        /// <summary>
        /// Liczba trafień w przeciwnika
        /// </summary>
        public int DealedHits { get; set; }
        /// <summary>
        /// Liczba trafień, które przyjął gracz
        /// </summary>
        public int HitsTaken { get; set; }
        /// <summary>
        /// Wygrane gry
        /// </summary>
        public int WonGames { get; set; }
        /// <summary>
        /// Przegrane gry
        /// </summary>
        public int LostGames { get; set; }
    }

    public class UserScoreMap : EntityTypeConfiguration<UserScore>
    {
        public UserScoreMap()
        {
            HasKey(x => x.Id);
            Property(x => x.PlayedGames);
            Property(x => x.DealedHits);
            Property(x => x.HitsTaken);
            Property(x => x.WonGames);
            Property(x => x.LostGames);
        }
    }
}