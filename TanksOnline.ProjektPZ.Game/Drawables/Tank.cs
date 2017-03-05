using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    using SFML.System;
    using SFML.Graphics;
    using Interfaces;

    public class Tank : Drawable, MoveAble
    {
        private Vector2f _pos;
        private TankTurret _turret;
        private TankWheel _wheels;
        private float _rad;
        private Color _col;

        public float TurretAnchor {
            get { return _turret.TurretAnchor; }
            set { _turret.TurretAnchor = value; }
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
                _wheels.Position = value + new Vector2f(-1.5f * _rad, 2.25f * _rad);
            }
        }

        public Tank(float radius)
        {
            _rad = radius;
            _col = Color.Green;
            _turret = new TankTurret(_rad * 1.5f);
            _wheels = new TankWheel(_rad)
            {
                Position = new Vector2f(-1.5f * _rad, 2.25f * _rad),
            };
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_turret);
            target.Draw(_wheels);
        }
    }
}
