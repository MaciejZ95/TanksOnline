using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Infrastructure.Interfaces
{
    public interface IMoveAbleWithAngle
    {
        SFML.System.Vector2f Position { get; set; }
        float Angle { get; }
        float Speed { get; }
    }
}
