using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class GeoPointNew:GeoObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }

        public GeoPointNew(double x, double y, double h, string name)
        {
            X = x;
            Y = y;
            H = h;
            Name = name;
            Type = GeometryType.Point;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Store()
        {
            base.Store();
        }
    }
}
