using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class GeoMarkPoint:GeoPointNew
    {
        public GeoTecture Tecture { get; set; }

        public GeoMarkPoint(double x, double y, double h, string name, GeoTecture tecture)
            : base(x, y, h, name)
        {
            Tecture = tecture;
        }
    }
}
