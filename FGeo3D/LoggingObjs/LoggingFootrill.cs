using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingFootrill:LoggingObject
    {

        public List<GeoPoint> Links { get; set; } = new List<GeoPoint>();  //平硐控制点

        

        public LoggingFootrill(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
            Type = LoggingType.Footrill;
            //控制点
            for (var index = 0; index < dataObj.Points.Count; index++)
            {
                var thisPoint = dataObj.Points.GetPoint(index);
                Links.Add(new GeoPoint(thisPoint));
            }
            Draw(ref sgworld);
        }


        /// <summary>
        /// 绘制平硐洞口
        /// </summary>
        /// <param name="sgworld"></param>
        public void Draw(ref SGWorld66 sgworld)
        {
            //硐口
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF64FF64;
            var SegmentDensity = -1;
            string gid = GeoHelper.CreateGroup("硐探", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(Top.X, Top.Y, Top.Z, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE);
            SkylineMouthObj = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);

            //硐身
            List<double> ListVertices = new List<double>();
            
            foreach (var point in Links)
            {
                ListVertices.Add(point.X);
                ListVertices.Add(point.Y);
                ListVertices.Add(point.Z);
            }
            var lineColor = sgworld.Creator.CreateColor(255, 0, 0, 128);
            SkylineBodyObj = sgworld.Creator.CreatePolylineFromArray(ListVertices.ToArray(), lineColor, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
                sgworld.ProjectTree.HiddenGroupID, Name);

            //标签
            var cLabelStyle = sgworld.Creator.CreateLabelStyle();
            cLabelStyle.MultilineJustification = "Center";
            cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
            cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
            cLabelStyle.TextAlignment = "Bottom, Center";
            SkylineLabelObj = sgworld.Creator.CreateTextLabel(cPos, Name, cLabelStyle, sgworld.ProjectTree.HiddenGroupID, Name);


            RecordLabelSkyId();
        }



    }
}
