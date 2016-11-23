using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Draw.Drawing
{
    public class Line : ShapeBase
    {
        float _x1, _y1, _x2, _y2;
        public Line(float x1, float y1, float x2, float y2) : base()
        {
            _x1 = x1; _x2 = x2;
            _y1 = y1; _y2 = y2;
        }
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red, 3.0F), _x1, _y1, _x2, _y2);
        }

        public override System.Drawing.RectangleF getBounds()
        {
            PointF loc = new PointF(Math.Min(_x1, _x2), Math.Min(_y1, _y2));
            SizeF size = new SizeF(Math.Abs(_x1 - _x2), Math.Abs(_y1 - _y2));
            return new RectangleF(loc, size);
        }
    }
}
