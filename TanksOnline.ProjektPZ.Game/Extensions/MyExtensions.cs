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
        public const double DEGREES_TO_RAD = 0.0174532925D;

        public static void Move(this Shape obj, Vector2f vec)
        {
            obj.Position += vec;
        }

        public static void Move(this MoveAble obj, Vector2f vec)
        {
            obj.Position += vec;
        }

        public static void Move(this MoveAbleWithAngle obj)
        {
            float b, a, c = obj.Speed;
            float alfa = obj.Angle;

            //cos(alfa) = a/c -> a = c * cos(alfa)
            //sin(alfa) = c/b -> b = c * sin(alfa)

            var cosAlfa = Math.Cos(DEGREES_TO_RAD * alfa);
            var sinAlfa = Math.Sin(DEGREES_TO_RAD * alfa);

            var zjebanycos = (float)cosAlfa;
            var zjebanysin = (float)sinAlfa;

            obj.Position += new Vector2f(
                x: 10000f * c * (float)cosAlfa / 10000f,
                y: 10000f * c * (float)sinAlfa / 10000f
            );
        }
    }
}
