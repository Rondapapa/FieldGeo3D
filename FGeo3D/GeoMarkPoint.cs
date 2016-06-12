using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoMarkPoint:GeoPoint
    {
        public GeoTecture Tecture { get; set; }

        public GeoMarkPoint(double x, double y, double h, string name, GeoTecture tecture)
            : base(x, y, h, name)
        {
            Tecture = tecture;
        }

        //绘制Mark信息（几何 + 产状）
        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
            //创建Mark位置

            //根据位置，绘制一个平面圆，方位角随产状。

        }

        public override void Erase(ref SGWorld66 sgworld)
        {
            base.Erase(ref sgworld);
        }
    }
}
