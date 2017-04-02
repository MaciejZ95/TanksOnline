using System.Collections.Generic;

namespace Menu.Models
{
    public class MatchModel
    {
        public int ActualPlayer { get; set; }
        public List<PlayerModel> Players { get; set; }
    }
}