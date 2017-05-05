using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables.TankNs
{
    using SFML.System;
    using SFML.Graphics;
    using Infrastructure.Interfaces;
    using Collision;

    /// <summary>
    /// Partial związany z wyświetlaniem obiektu
    /// </summary>
    public class Tank : Drawable, IMoveAble, ICollidable
    {
        private Vector2f _pos;
        private TankTurret _turret;
        private TankWheel _wheels;
        private Color _col;
        private TankCollisionBox _box;
        private Explosion _flame1, _flame2, _flame3;
        private bool _boxVisible;

        public float Rad { get; }
        public bool Dead { get; set; }
        public int IdInMatch { get; private set; }
        public bool ChangedColor { get; set; }
        public int TankHp { get; set; }

        /// <summary>
        /// Wartość jest przesunięta o 180 stopni. Wynika to z charakterystyki widoku w SFMl. 
        /// SFML ma wartość Y jadącą w dół, stąd cały wykres kartezjański jest odwrócony o 180.
        /// </summary>
        public float TurretAngle {
            get { return _turret.TurretAnchor - 180; }
            set { _turret.TurretAnchor = value + 180; }
        }
        
        public Color FillColor {
            get { return _col; }
            set { _turret.FillColor = _wheels.FillColor = _col = value; }
        }

        public Vector2f Position {
            get { return _pos; }
            set {
                _pos = value;
                _turret.Position = value;
                _wheels.Position = value + new Vector2f(-1.5f * Rad, 2.25f * Rad);
                _box.Position = value;
            }
        }

        public Tank(float radius, int idInMatch, bool isColBoxVisible)
        {
            IdInMatch = idInMatch;
            Rad = radius;
            _col = Color.Green;
            _turret = new TankTurret(Rad * 1.5f);
            _wheels = new TankWheel(Rad)
            {
                Position = new Vector2f(-1.5f * Rad, 2.25f * Rad),
            };
            _box = new TankCollisionBox(radius);
            _boxVisible = isColBoxVisible;
        }

        public Tank(float radius, int idInMatch) : this(radius, idInMatch, false) { }

        public Tank(float radius) : this(radius, -1, false) { }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (_boxVisible) target.Draw(_box);

            // sprawdzanie czy przypadkiem czołg nie został zniszczony
            if (!ChangedColor && Dead)
            {
                _wheels.FillColor = Color.Black;
                _flame1 = new Explosion(_turret.Position + new Vector2f(0, Rad * 2))
                {
                    Infinite = true
                };
                _flame2 = new Explosion(_turret.Position + new Vector2f(Rad * 1.5f, Rad))
                {
                    Infinite = true
                };
                _flame3 = new Explosion(_turret.Position + new Vector2f(Rad * 3, Rad * 2))
                {
                    Infinite = true,
                    Rotation = 90
                };
                ChangedColor = true;
            }

            // rysowanie w zależności czy nie jest martwy
            if (Dead) {
                target.Draw(_flame1);
                target.Draw(_flame3);
                target.Draw(_flame2);
                target.Draw(_wheels);
            }
            else
            {
                target.Draw(_turret);
                target.Draw(_wheels);
            }
        }

        public bool CheckCol(Bullet obj)
        {
            if (obj.Owner != this)
            {
                return _box.CheckCol(obj);
            }
            else return false;
        }
    }
}
