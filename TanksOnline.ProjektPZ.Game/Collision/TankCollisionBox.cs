using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksOnline.ProjektPZ.Game.Drawables;
using TanksOnline.ProjektPZ.Game.Interfaces;
using SFML.System;

namespace TanksOnline.ProjektPZ.Game.Collision
{
    public class TankCollisionBox : ICollidable, IMoveAble, Drawable
    {
        /// <summary>
        /// Ramka do kolizji
        /// </summary>
        private List<RectangleShape> _box;
        private Vector2f _pos;
        private float _rad;

        public TankCollisionBox(float radius)
        {
            _rad = radius;
            _box = new List<RectangleShape>()
            {
                new RectangleShape(new Vector2f(6f * radius, 2f * radius))
                {
                    Position = new Vector2f(-1.5f * radius, radius * 2.25f),
                    FillColor = new Color(255, 0, 0, 128),
                },
                new RectangleShape(new Vector2f(3f * radius, 3f * radius))
                {
                    Position = new Vector2f(),
                    FillColor = new Color(255, 0, 0, 128),
                },
            };
        }

        public Vector2f Position {
            get { return _pos; }
            set {
                _pos = value;
                _box[0].Position = value + new Vector2f(-1.5f * _rad, _rad * 2.25f);
                _box[1].Position = value;
            }
        }

        public bool CheckCol(Bullet obj)
        {
            _box.ForEach(x =>
            {
                var rect1 = x.GetGlobalBounds();
                var rect2 = obj.GetGlobalBounds();

                if (rect1.Left < rect2.Left + rect2.Width &&
                    rect1.Left + rect1.Width > rect2.Left &&
                    rect1.Top < rect2.Top + rect2.Height &&
                    rect1.Top + rect1.Height > rect2.Top)
                {
                    obj.Dead = true;
                }
            });
            return obj.Dead;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            _box.ForEach(x => target.Draw(x));
        }
    }
}
