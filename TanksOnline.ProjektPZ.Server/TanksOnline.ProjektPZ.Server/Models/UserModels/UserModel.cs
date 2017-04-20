using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TanksOnline.ProjektPZ.Server.Domain.Entities;

namespace TanksOnline.ProjektPZ.Server.Models.UserModels
{
    /// <summary>
    /// Klasa z danymi o użytkowniku (poza hasłem, ono jest przekazywane tylko przy logowaniu).
    /// W tym id do zapytań GET.
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TankInfo TankInfo { get; set; }
    }
}