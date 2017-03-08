using System;

namespace TanksOnline.ProjektPZ.Game.Drawables.Tank
{
    using SFML.Graphics;
    using SFML.System;

    public class TankWheelInner : Shape
    {
        private float myRadius;
        private uint myPointCount;

        public float Radius {
            get {
                return this.myRadius;
            }
            set {
                this.myRadius = value;
                this.Update();
            }
        }

        public TankWheelInner(float radius) : this(radius, 60U) { }

        public TankWheelInner(float radius, uint pointCount)
        {
            this.Radius = radius;
            this.SetPointCount(pointCount);
        }

        public TankWheelInner(TankWheelInner copy) : base((Shape)copy)
        {
            this.Radius = copy.Radius;
            this.SetPointCount(copy.GetPointCount());
        }

        public override uint GetPointCount()
        {
            return this.myPointCount;
        }

        public void SetPointCount(uint count)
        {
            this.myPointCount = count;
            this.Update();
        }

        public override Vector2f GetPoint(uint index)
        {
            var num = (float)((double)(index * 2U) * Math.PI / (double)this.myPointCount - Math.PI / 2.0);
            var point = new Vector2f(this.myRadius + (float)Math.Cos((double)num) * this.myRadius, this.myRadius + (float)Math.Sin((double)num) * this.myRadius);

            return point + (index < (myPointCount / 2f) ? new Vector2f(this.Radius * 4f, 0f) : new Vector2f());
        }
    }
}