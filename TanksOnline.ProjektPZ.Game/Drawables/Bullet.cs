using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    using Interfaces;
    using SFML.Graphics;
    using TankNs;

    public class Bullet : CircleShape, IMoveAbleWithAngle
    {
        public float Angle { get; }
        public float Speed { get; }
        public bool Dead { get; set; }
        public Tank Owner { get; private set; }

        public Bullet(Tank owner, float angle = 45, float speed = 2f)
        {
            Owner = owner;
            Angle = angle;
            Speed = speed;
        }
    }
}
