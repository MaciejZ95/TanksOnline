using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TanksOnline.ProjektPZ.Server.Domain.Enums;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    /// <summary>
    /// Pokój do którego dołączają gracze. Gdy wszyscy będą połączeni to przechodzą do rzeczywistej gry.
    /// </summary>
    public class GameRoom
    {
        public int Id { get; set; }
        public int PlayersLimit { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public Match Match { get; set; }
        public User Owner { get; set; }
        public List<Player> Players { get; set; }
    }

    public class GameRoomMap : EntityTypeConfiguration<GameRoom>
    {
        public GameRoomMap()
        {
            HasKey(x => x.Id);
            Property(x => x.PlayersLimit).IsRequired();
            Property(x => x.RoomStatus).IsRequired();
            HasOptional(x => x.Match);
            HasRequired(x => x.Owner);
            HasMany(gr => gr.Players).WithRequired(p => p.GameRoom);
        }
    }
}