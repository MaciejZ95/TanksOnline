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

    public class TankWheel : Drawable, IMoveAble
    {
        private float rad, srad;
        private Vector2f position;
        private TankWheelInner InnerPart;
        private List<CircleShape> InnerCircles;

        public Color FillColor {
            get { return InnerPart.FillColor; }
            set { InnerPart.FillColor = value; }
        }

        public Vector2f Position {
            get { return position; }
            set {
                position = value;
                InnerPart.Position = value;
                int i = 0;
                InnerCircles.ForEach(x => x.Position = value + new Vector2f(rad + rad * i++ * 2 - x.Radius, rad - x.Radius));
            }
        }

        public TankWheel(float radius, float smallWheelRadius)
        {
            this.rad = radius;
            this.srad = smallWheelRadius;
            InnerPart = new TankWheelInner(radius) {
                OutlineColor = Color.Black,
                OutlineThickness = radius * 0.1f
            };

            InnerCircles = new List<CircleShape>();
            for (int i = 0; i < 3; i++)
            {
                var circle = new CircleShape(srad) {
                    FillColor = Color.Black,
                    Position = new Vector2f(rad + rad * i * 2 - srad, rad - srad)
                };
                InnerCircles.Add(circle);
            }
        }

        public TankWheel(float radius) : this(radius, radius * 0.4f) { }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(InnerPart);
            InnerCircles.ForEach(x => target.Draw(x));
        }
    }
}
