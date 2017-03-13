using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Collision
{
    public class FrameCollisionBox : Drawable
    {
        private List<RectangleShape> frame;

        public FrameCollisionBox()
        {
            frame = new List<RectangleShape>
            {
                new RectangleShape(new Vector2f(5f, 565f)),
                new RectangleShape(new Vector2f(5f, 565)) { Position = new Vector2f(780f, 0f) },
                new RectangleShape(new Vector2f(780f, 5f)),
                new RectangleShape(new Vector2f(780f, 5f)) { Position = new Vector2f(0f, 555f) }
            };

            frame.ForEach(x =>
            {
                x.FillColor = Color.Red;
            });
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            frame.ForEach(x => target.Draw(x));
        }
    }
}
