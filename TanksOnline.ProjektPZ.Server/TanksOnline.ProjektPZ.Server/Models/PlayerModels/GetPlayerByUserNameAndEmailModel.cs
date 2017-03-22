using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Models.PlayerModels
{
    public class GetPlayerByUserNameAndEmailModel
    {
        public string Email { get; internal set; }
        public string Name { get; internal set; }
    }
}