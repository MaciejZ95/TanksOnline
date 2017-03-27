using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TanksOnline.ProjektPZ.Server.Models.MatchModels;
using TanksOnline.ProjektPZ.Server.Models.UserModels;

namespace TanksOnline.ProjektPZ.Server.Models.PlayerModels
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int TankHP { get; set; }
        public UserModel User { get; set; }
        public int IdInMatch { get; set; }
        public float TurretAngle { get; set; }
    }
}