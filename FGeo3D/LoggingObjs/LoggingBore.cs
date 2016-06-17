using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingBore:LoggingObject
    {
        public LoggingBore(IObjData dataObj)
            :base(dataObj)
        {
            Type = LoggingType.Bore;
        }

        
        /// <summary>
        /// 绘制钻孔孔口(需要用钻孔口模型)
        /// </summary>
        /// <param name="sgworld"></param>
        public void DrawTop(ref SGWorld66 sgworld)
        {
            //暂时用小圆点替代钻孔口模型
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            string gid = GeoHelper.CreateGroup("钻孔", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(Top.X, Top.Y, Top.Z, AltitudeTypeCode.ATC_ON_TERRAIN);
            sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);
            

            var cLabelStyle = sgworld.Creator.CreateLabelStyle();
            cLabelStyle.MultilineJustification = "Center";
            cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
            cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
            cLabelStyle.TextAlignment = "Bottom, Center";
            sgworld.Creator.CreateTextLabel(cPos, Name, cLabelStyle, gid, "钻孔标签：" + Name);
        }
    }
}
