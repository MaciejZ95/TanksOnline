using System;
using System.Collections.Generic;
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
}