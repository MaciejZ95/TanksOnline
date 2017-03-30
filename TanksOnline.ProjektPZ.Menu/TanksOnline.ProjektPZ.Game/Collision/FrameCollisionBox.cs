using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Collision
{
    using SFML.Graphics;
    using SFML.System;
    using Infrastructure.Interfaces;
    using Drawables;

    public class FrameCollisionBox : Drawable, ICollidable
    {
        private List<RectangleShape> frame;

        public FrameCollisionBox()
        {
            frame = new List<RectangleShape>
            {
                new RectangleShape(new Vector2f(50f, 615f)) { Position = new Vector2f(-45f, -25f) },
                new RectangleShape(new Vector2f(50f, 615f)) { Position = new Vector2f(780f, -25f) },
                new RectangleShape(new Vector2f(780f, 50f)) { Position = new Vector2f(0f, -45f) },
                new RectangleShape(new Vector2f(780f, 50f)) { Position = new Vector2f(0f, 555f) }
            };

            frame.ForEach(x =>
            {
                x.FillColor = Color.Red;
            });
        }

        public bool CheckCol(Bullet obj)
        {
            frame.ForEach(x =>
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
            frame.ForEach(x => target.Draw(x));
        }
    }
}
