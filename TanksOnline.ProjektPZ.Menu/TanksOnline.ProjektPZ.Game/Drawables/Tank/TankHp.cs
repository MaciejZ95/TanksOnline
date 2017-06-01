using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables.TankNs
{
    public class TankHp : Drawable
    {
        private Vector2f _pos;
        private RectangleShape _hpRed;
        private RectangleShape _hpGreen;
        private readonly float MAX_HP;
        private readonly float RAD;
        private float _hp;

        /// <summary>
        /// Liczba punktów życia pojazdu
        /// </summary>
        public int HP {
            get { return Convert.ToInt32(_hp); }
            set {
                _hp = value;
                _hpGreen.Size = new Vector2f(RAD * 6 * (_hp / MAX_HP), RAD);
            }
        }
        
        public Vector2f Position {
            get { return _pos; }
            set {
                _pos = value;
                _hpGreen.Position = value + new Vector2f(-RAD * 1.5f, -RAD * 3);
                _hpRed.Position = value + new Vector2f(-RAD * 1.5f, -RAD * 3);
                //_pos = value;
                //_turret.Position = value;
                //_wheels.Position = value + new Vector2f(-1.5f * Rad, 2.25f * Rad);
                //_box.Position = value;
            }
        }

        public TankHp(float radius, int maxHp)
        {
            RAD = radius;
            _hpRed = new RectangleShape
            {
                FillColor = Color.Red,
                Position = new Vector2f(-RAD * 1.5f, -RAD * 3),
                Size = new Vector2f(RAD * 6, RAD),
                OutlineColor = Color.Black,
                OutlineThickness = RAD * 0.075f
            };
            _hpGreen = new RectangleShape
            {
                FillColor = Color.Green,
                Position = new Vector2f(-RAD * 1.5f, -RAD * 3),
                Size = new Vector2f(RAD * 6, RAD),
            };
            _hp = MAX_HP = HP = maxHp;
        }

        public TankHp(float radius) : this(radius, 4) { }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_hpRed);
            target.Draw(_hpGreen);
        }
    }
}
