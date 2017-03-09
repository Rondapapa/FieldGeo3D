using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Draw.Drawing
{
    public abstract class ShapeBase
    {
       // public abstract void Draw(Graphics g);
      //  public abstract RectangleF getBounds();
        private static int IdCount;
        public ShapeBase()
        {
            Id = IdCount;
            IdCount++;
        }
        public int Id
        {
            get;
            private set;
        }

        //public bool Contains(ShapeBase shape)
        //{
        //    return getBounds().Contains(shape.getBounds());
        //}

        //public bool Contains(PointF pt)
        //{
        //    return getBounds().Contains(pt);
        //}

        //public bool Contains(RectangleF rect)
        //{
        //    return getBounds().Contains(rect);
        //}

        //public bool Contains(float x, float y)
        //{
        //    return getBounds().Contains(x, y);
        //}

        //public bool IntersectsWith(RectangleF rect)
        //{
        //    return getBounds().IntersectsWith(rect);
        //}
    }
}
