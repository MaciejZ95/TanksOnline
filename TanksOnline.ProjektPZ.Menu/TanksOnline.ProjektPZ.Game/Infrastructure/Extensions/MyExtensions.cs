using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Infrastructure.Extensions
{
    using SFML.Graphics;
    using SFML.System;
    using Interfaces;

    public static class MyExtensions
    {
        public const double DEG_TO_RAD = 0.0174532925D;

        public static void Move(this Shape obj, Vector2f vec)
        {
            obj.Position += vec;
        }

        public static void Move(this IMoveAble obj, Vector2f vec)
        {
            obj.Position += vec;
        }

        public static void Move(this IMoveAbleWithAngle obj)
        {
            obj.Position += new Vector2f(
                10000f * obj.Speed * (float)Math.Cos(DEG_TO_RAD * obj.Angle) / 10000f,
                10000f * obj.Speed * (float)Math.Sin(DEG_TO_RAD * obj.Angle) / 10000f
            );
        }

        //g = 9.81
        //t = 0
        //f - siła oporu powietrza
        //m - masa ciała
        //v - prędkość początkowa
        //Δt - przyrost czasu
        //α - kąt wystrzelenia pocisku
        //kod:
        //x = x + ((v* cos(α)) - f / m* t)
        //y = y - ((v* sin(α)) - g* t)
        //t = t + Δt
        public static void Move(this IMoveAbleProjectile o)
        {
            float x = 10000f * o.Speed * (float)Math.Cos(DEG_TO_RAD * o.Angle);
            float y = 10000f * -o.Speed * (float)Math.Sin(DEG_TO_RAD * o.Angle);
            
            o.Position += new Vector2f(
                x / 10000f - o.AirForce / o.Mass * o.Time,
                -y / 10000f + 9.81f * o.Time
            );

            o.Time += 0.25f;
        }
    }
}
