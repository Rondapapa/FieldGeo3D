using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class GeoPlane:GeoObject
    {
        public List<GeoPointNew> Points { get; set; }

        public GeoPlane(List<GeoPointNew> points)
        {
            Points = points;
            Type = GeometryType.Plane;
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
