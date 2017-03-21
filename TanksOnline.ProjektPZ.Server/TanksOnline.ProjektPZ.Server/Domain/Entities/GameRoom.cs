using System;
using System.Collections.Generic;
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
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Limit graczy w ramach pokoju. Ustalany na starcie.
        /// </summary>
        public int PlayersLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RoomStatus RoomStatus { get; set; }
        /// <summary>
        /// Gdy wszyscy się połączą tworzona jest rozgrywka i każdy ma tam przejść.
        /// Domyślnie null, więc uwaga :>
        /// </summary>
        public Match Match { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User Owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Player> Players { get; set; }
    }
}