using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using MathNet;

namespace FGeo3D_TE
{
    class GeoPlane:GeoObject
    {
        public List<GeoPoint> Points { get; set; }

        public GeoPlane(List<GeoPoint> points)
        {
            Points = points;
            Type = GeometryType.Plane;
        }

        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
            //考虑怎么实现三维散点的回归平面
        }

        public override void Store()
        {
            base.Store();
        }
    }
}
