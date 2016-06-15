using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingFootrill:LoggingObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Depth { get; set; }
        public List<GeoPoint> Links { get; set; } //平硐硐身几何关键点
        public List<GeoMarkPoint> Marks { get; set; } //平硐构造关键点
        public List<GeoSurface> Surfaces { get; set; } //平硐边壁构造

        public LoggingFootrill(string id, string name, double x, double y, double h, double depth, List<GeoPoint> links, List<GeoMarkPoint> marks, List<GeoSurface> surfaces )
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
            H = h;
            Depth = depth;
            Links = links;
            Marks = marks;
            Surfaces = surfaces;
            Type = LoggingType.Footrill;
        }

        /// <summary>
        /// 查询该平硐的详细信息，调用GeoSmart面板。
        /// </summary>
        public override void QueryDetail() { }

        /// <summary>
        /// 绘制平硐洞口
        /// </summary>
        /// <param name="sgworld"></param>
        public void DrawMouth(ref SGWorld66 sgworld)
        {
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF64FF64;
            var SegmentDensity = -1;
            string gid = GeoHelper.CreateGroup("平硐", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(X, Y, H, AltitudeTypeCode.ATC_ON_TERRAIN);
            sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);

            var cLabelStyle = sgworld.Creator.CreateLabelStyle();
            cLabelStyle.MultilineJustification = "Center";
            cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
            cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
            cLabelStyle.TextAlignment = "Bottom, Center";
            sgworld.Creator.CreateTextLabel(cPos, Name, cLabelStyle, gid, "平硐标签：" + Name);
        }

        /// <summary>
        /// 绘制平硐硐身
        /// </summary>
        /// <param name="sgworld"></param>
        public void DrawLinks(ref SGWorld66 sgworld)
        {
            
        }

        /// <summary>
        /// 绘制平硐构造关键点（有必要嘛？）
        /// </summary>
        /// <param name="sgworld"></param>
        public void DrawMarks(ref SGWorld66 sgworld)
        {
            
        }


    }
}
