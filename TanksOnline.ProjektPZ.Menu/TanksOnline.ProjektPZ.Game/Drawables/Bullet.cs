using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    using SFML.Graphics;
    using Infrastructure.Interfaces;

    public class Bullet : CircleShape, IMoveAbleProjectile
    {
        public float Angle { get; }
        public float Speed { get; }
        public TankNs.Tank Owner { get; private set; }
        public float AirForce { get; }
        public float Time { get; set; }
        public float Mass { get; }
        public float Gravity { get; set; }
        public int ShootedMatchId { get; private set; }
        public TankNs.Tank KilledTank { get; internal set; }
        public bool IsDummy { get; private set; }

        public Bullet(TankNs.Tank owner, float angle, float speed, float airForce, float mass, float gravity, int shootedMatchId, bool isDummy = false)
        {
            Owner = owner;
            Angle = angle;
            Speed = speed;
            AirForce = airForce;
            Mass = mass;
            Gravity = gravity;
            ShootedMatchId = shootedMatchId;
            IsDummy = isDummy;
        }

        public Bullet(Bullet b, int shootedMatchId) : this(b.Owner, b.Angle, b.Speed, b.AirForce, b.Mass, b.Gravity, shootedMatchId) { }
    }
}
