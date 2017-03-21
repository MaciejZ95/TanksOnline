using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Models.Player
{
    using User;

    public class PostPlayerModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public int IdInMatch { get; set; }
    }
}