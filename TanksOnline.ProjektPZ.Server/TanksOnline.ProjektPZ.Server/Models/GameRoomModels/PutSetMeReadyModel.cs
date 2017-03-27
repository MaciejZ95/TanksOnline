using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Models.GameRoomModels
{
    public class PutSetMeReadyModel
    {
        public int GameRoomId { get; set; }
        public int PlayerId { get; set; }
    }
}