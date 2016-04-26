using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Bore
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Depth { get; set; }
        public List<GeoMarkPoint> Marks { get; set; }

        public Bore(string id, string name, double x, double y, double h, double depth, List<GeoMarkPoint> marks)
        {
            ID = id;
            Name = name;
            X = x;
            Y = y;
            H = h;
            Depth = depth;
            Marks = marks;
        }

        /// <summary>
        /// 查询该钻孔的详细信息，调用GeoSmart面板。
        /// </summary>
        public void QueryDetail() { }

        /// <summary>
        /// 绘制钻孔孔口
        /// </summary>
        /// <param name="sgworld"></param>
        public void DrawTop(ref SGWorld66 sgworld)
        {
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            string gid = GeoHelper.CreateGroup("钻孔", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(X, Y, H, AltitudeTypeCode.ATC_ON_TERRAIN);
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
