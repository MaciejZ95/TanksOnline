using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    public class TankInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
    }
}