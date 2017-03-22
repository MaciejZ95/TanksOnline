using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Models.PlayerModels
{
    using UserModels;

    // TODO RK: Wciąż niekompletna

    /// <summary>
    /// Klasa do tworzenia gracza w ramach danej rozgrywki
    /// </summary>
    public class PostPlayerModel
    {
        public UserModel User { get; set; }
        public int IdInMatch { get; set; }
    }
}