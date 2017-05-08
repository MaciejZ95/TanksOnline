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
        public int IdInMatch { get; set; }

        public Player() : this(false) { }

        public Player(bool init)
        {
            if (init)
            {
                TankHP = Consts.DEFAULT_TANK_HP;
            }
        }
    }

    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.TankHP).IsRequired();
            HasRequired(x => x.User);
            Property(x => x.IdInMatch).IsRequired();
        }
    }
}