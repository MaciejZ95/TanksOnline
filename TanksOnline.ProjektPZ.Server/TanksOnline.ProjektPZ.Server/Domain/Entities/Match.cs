using System;
using System.Collections.Generic;
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
}