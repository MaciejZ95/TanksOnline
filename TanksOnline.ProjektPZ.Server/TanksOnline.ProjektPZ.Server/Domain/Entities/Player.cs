using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    /// <summary>
    /// Klasa wykorzystywana w trakcie rozgrywki
    /// </summary>
    public class Player
    {
        public int Id { get; set; }
        public int TankHP { get; set; }
        public User User { get; set; }
        public Match Match { get; set; }
        public GameRoom GameRoom { get; set; }
        public int IdInMatch { get; set; }
        public float TurretAngle { get; set; }
    }

    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.TankHP).IsRequired();
            HasRequired(x => x.User);
            HasOptional(x => x.Match);
            HasRequired(x => x.GameRoom).WithMany(gr => gr.Players);
            Property(x => x.IdInMatch).IsRequired();
            Property(x => x.TurretAngle).IsRequired();
        }
    }
}