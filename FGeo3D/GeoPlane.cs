using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using MathNet;
using System.Data.Entity.Spatial;

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
            //过所有边界点作Polygon
            //如何确定不严格在一个平面内的三维散点的边界点？
        }

        public void Draw(ref SGWorld66 sgworld, bool isFittingPlane)
        {
            if (!isFittingPlane)
                Draw(ref sgworld);
            else
            {
                //实现三维散点的回归平面
                var fittingPoints = GeoHelper.FitPlane(Points);
                
            }
        }

        public override void Store()
        {
            base.Store();
        }
    }
}
