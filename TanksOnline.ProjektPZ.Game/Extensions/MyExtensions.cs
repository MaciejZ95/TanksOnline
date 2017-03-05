using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksOnline.ProjektPZ.Game.Interfaces;

namespace TanksOnline.ProjektPZ.Game
{
    public static class MyExtensions
    {
        public static void Move(this Shape obj, Vector2f vec)
        {
            obj.Position += vec;
        }

        public static void Move(this MoveAble obj, Vector2f vec)
        {
            obj.Position += vec;
        }
    }
}
