using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class GeoAttitude
    {
        double Dip { set; get; } //倾向，以N为0，顺时针（存储数值为弧度） 
        double DipAngel { set; get; } //倾角，以水平为0，向下（存储数值为弧度）

        GeoAttitude(double dip, double dipAngel)//输入角度
        {
            Dip = dip * Math.PI / 180;
            DipAngel = dipAngel * Math.PI / 180;
        }

        public override string ToString()
        {
            return $"{Dip*180/Math.PI}°∠{DipAngel*180/Math.PI}°";
        }
    }
}
