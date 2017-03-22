using System;
using System.Collections.Generic;
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
        public int IdInMatch { get; set; }
        public float TurretAngle { get; set; }
    }
}