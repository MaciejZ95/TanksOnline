using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables.Tank
{
    using SFML.System;
    using SFML.Graphics;
    using Interfaces;

    /// <summary>
    /// Partial związany z wyświetlaniem obiektu
    /// </summary>
    public class Tank : Drawable, MoveAble
    {
        private Vector2f _pos;
        private TankTurret _turret;
        private TankWheel _wheels;
        private Color _col;
        public float Rad { get; }

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
            }
        }

        public Tank(float radius)
        {
            Rad = radius;
            _col = Color.Green;
            _turret = new TankTurret(Rad * 1.5f);
            _wheels = new TankWheel(Rad)
            {
                Position = new Vector2f(-1.5f * Rad, 2.25f * Rad),
            };
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_turret);
            target.Draw(_wheels);
        }
    }
}
