﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    using Interfaces;
    using SFML.Graphics;

    public class Bullet : CircleShape, IMoveAbleWithAngle
    {
        public float Angle { get; }
        public float Speed { get; }
        public bool Dead { get; set; }

        public Bullet(float angle = 45, float speed = 2f)
        {
            Angle = angle;
            Speed = speed;
        }
    }
}
