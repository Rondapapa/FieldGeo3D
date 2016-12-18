using System.Collections.Generic;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D.LoggingObj
{
    public class LoggingTrench:LoggingObject
    {

        public List<IGPoint> Links { get; set; } = new List<IGPoint>();  //控制点
        

        public LoggingTrench(IObjData dataObj, ref SGWorld66 sgworld, double xOffset = 0.0, double yOffset = 0.0) : base(dataObj, ref sgworld)
        {
            Type = LoggingType.Trench;
            //控制点
            for (var index = 0; index < dataObj.Points.Count; index++)
            {
                var thisPoint = dataObj.Points.GetPoint(index);
                Links.Add(thisPoint);
            }
            

            Draw(ref sgworld, xOffset, yOffset);
        }

        public void Draw(ref SGWorld66 sgworld, double xOffset = 0.0, double yOffset = 0.0)
        {
            string signIsInTerrain = IsLoggingObjInTerrain(ref sgworld) ? "" : "【地图以外】";

            // 口
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF64FF64;
            var SegmentDensity = -1;
            string gid = CreateGroup("槽探", ref sgworld);
            sgworld.ProjectTree.ExpandGroup(gid, true);
            IPosition66 cPos = sgworld.Creator.CreatePosition(
                Top.X + xOffset,
                Top.Y + yOffset,
                Top.Z,
                AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE);
            SkylineMouthObj = sgworld.Creator.CreateSphere(
                cPos,
                radius,
                Style,
                nLineColor,
                nFillColor,
                SegmentDensity,
                gid,
                Name + signIsInTerrain);

            //身
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
