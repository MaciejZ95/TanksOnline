using System.Collections.Generic;

namespace TanksOnline.ProjectPZ.HttpListener.Models
{
    public class MatchModel
    {
        public int ActualPlayer { get; set; }
        public List<PlayerModel> Players { get; set; }
    }
}