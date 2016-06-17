using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    //废
    class GeoMarkPoint:GeoPoint
    {
        //public GeoTecture Tecture { get; set; }
        public string MarkerType { get; set; }
        public string MarkerData { get; set; }

        public double Dip { get; set; }
        public double DipAngle { get; set; }




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
