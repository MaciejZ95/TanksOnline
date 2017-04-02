using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class UserScoreModel
    {
        public int Id { get; set; }
        public int PlayedGames { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
        public int AFK_kicks { get; set; }
    }
}
