using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjectPZ.HttpListener.Models
{
    public class GameRoomModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Limit graczy w ramach pokoju. Ustalany na starcie.
        /// </summary>
        public int PlayersLimit { get; set; }
        /// <summary>
        /// Gdy wszyscy się połączą tworzona jest rozgrywka i każdy ma tam przejść.
        /// Domyślnie null, więc uwaga :>
        /// </summary>
        public MatchModel Match { get; set; }
        public UserModel Owner { get; set; }
        public List<PlayerModel> Players { get; set; }
    }
}
