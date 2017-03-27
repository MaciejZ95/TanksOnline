using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Domain.Enums
{
    public enum UserStatus
    {
        Offline = 1,
        Logged = 2,
        Waiting = 3,
        Ready = 4,
        InGame = 5,
        Mobile = 6
    }
}