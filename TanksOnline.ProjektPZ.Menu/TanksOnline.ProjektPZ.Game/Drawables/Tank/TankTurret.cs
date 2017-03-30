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

    public class TankTurret : Drawable, IMoveAble
    {
        private float _rad, _len;
        private Vector2f _pos;
        private Color _color;
        private TankCabin _cabin;
        private RectangleShape _turret;

        public float TurretAnchor {
            get { return _turret.Rotation; }
            set { _turret.Rotation = value; }
        }

        public Color FillColor {
            get { return _color; }
            set { _cabin.FillColor = _turret.FillColor = _color = value; }
        }

        public Vector2f Position {
            get { return _pos; }
            set {
                _pos = value;
                _cabin.Position = value;
                _turret.Position = value + new Vector2f(_rad, _rad);
            }
        }

        public TankTurret(float radius, float length)
        {
            _rad = radius;
            _len = length;
            _cabin = new TankCabin(radius)
            {
                FillColor = Color.Green,
                OutlineColor = Color.Black,
                OutlineThickness = radius * 0.075f
            };

            _turret = new RectangleShape(new Vector2f(radius * 0.5f, length))
            {
                FillColor = Color.Green,
                OutlineColor = Color.Black,
                OutlineThickness = radius * 0.075f,
                Position = new Vector2f(radius, radius),
                Origin = new Vector2f(radius * 0.25f, 0f),
                Rotation = 270f
            };
        }

        public TankTurret(float radius) : this(radius, radius * 2f) { }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_turret);
            target.Draw(_cabin);
        }
    }
}
