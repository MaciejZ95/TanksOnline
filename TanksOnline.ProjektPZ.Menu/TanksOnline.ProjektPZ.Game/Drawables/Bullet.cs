using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    using SFML.Graphics;
    using Infrastructure.Interfaces;
    using TankNs;

    public class Bullet : CircleShape, IMoveAbleProjectile
    {
        public float Angle { get; }
        public float Speed { get; }
        public bool Dead { get; set; }
        public Tank Owner { get; private set; }
        public float AirForce { get; }
        public float Time { get; set; }
        public float Mass { get; }

        public Bullet(Tank owner, float angle = 45f, float speed = 0.0625f, float airForce = 1f, float mass = 10f)
        {
            Owner = owner;
            Angle = angle;
            Speed = speed;
            AirForce = airForce;
            Mass = mass;
        }
    }
}
