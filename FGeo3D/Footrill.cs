using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Footrill
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Depth { get; set; }
        public List<GeoPoint> Links { get; set; }
        public List<GeoMarkPoint> Marks { get; set; }

        public Footrill(string id, string name, double x, double y, double h, double depth, List<GeoPoint> links, List<GeoMarkPoint> marks)
        {
            ID = id;
            Name = name;
            X = x;
            Y = y;
            H = h;
            Depth = depth;
            Links = links;
            Marks = marks;
        }

        /// <summary>
        /// 查询该平硐的详细信息，调用GeoSmart面板。
        /// </summary>
        public void QueryDetail() { }

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

        public void DrawLinks(ref SGWorld66 sgworld)
        {
            
        }

        public void DrawMarks(ref SGWorld66 sgworld)
        {
            
        }


    }
}
