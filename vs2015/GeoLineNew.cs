using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class GeoLineNew:GeoObject
    {
        public List<GeoPointNew> Points { get; set; }

        public GeoLineNew(List<GeoPointNew> points)
        {
            Points = points;
            Type = GeometryType.Line;
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
