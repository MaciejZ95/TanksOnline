﻿using SFML.Graphics;
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
        public const double DEG_TO_RAD = 0.0174532925D;

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
            obj.Position += new Vector2f(
                10000f * obj.Speed * (float)Math.Cos(DEG_TO_RAD * obj.Angle) / 10000f,
                10000f * obj.Speed * (float)Math.Sin(DEG_TO_RAD * obj.Angle) / 10000f
            );
        }
    }
}
