using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Game.Drawables.Tank
{
    using SFML.Graphics;
    using SFML.System;

    public class TankCabin : Shape
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

        public TankCabin(float radius) : this(radius, 60U) { }

        public TankCabin(float radius, uint pointCount)
        {
            this.Radius = radius;
            this.SetPointCount(pointCount);
        }

        public TankCabin(TankCabin copy) : base((Shape)copy)
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
            if (index < myPointCount / 4f || index > 3f * myPointCount / 4f)
            {
                return new Vector2f(this.myRadius + (float)Math.Cos((double)num) * this.myRadius, this.myRadius + (float)Math.Sin((double)num) * this.myRadius);
            }
            else
            {
                return new Vector2f(this.myRadius + (float)Math.Cos((double)num) * this.myRadius, this.myRadius * 2f);
            }
        }
    }
}

