using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Infrastructure.Interfaces
{
    public interface IMoveAble
    {
        SFML.System.Vector2f Position { get; set; }
    }
}
