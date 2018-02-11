using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D.LoggingObj
{
    public class LoggingSlope:LoggingObject
    {
        public LoggingSlope(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
            Type = LoggingType.Bore;
            Draw(ref sgworld,dataObj);
        }
        /// <summary>
        /// 绘制边坡(需要用边坡模型)
        /// </summary>
        /// <param name="sgworld"></param>
        public void Draw(ref SGWorld66 sgworld,IObjData dataObj, double xOffset = 0.0, double yOffset = 0.0)
        {
            string signIsInTerrain = IsLoggingObjInTerrain(ref sgworld) ? "" : "【地图以外】";

            //绘制孔口：暂时用小圆点替代钻孔口模型
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            string gid = CreateGroup("边坡", ref sgworld);
            sgworld.ProjectTree.ExpandGroup(gid, true);

            // 在地面创建边坡中心点的坐标
            double centerX = (dataObj.Points.GetPoint(0).X +
                dataObj.Points.GetPoint(1).X +
                dataObj.Points.GetPoint(2).X) / 3;
            double centerY= (dataObj.Points.GetPoint(0).Y +
                dataObj.Points.GetPoint(1).Y +
                dataObj.Points.GetPoint(2).Y) / 3;
            IPosition66 cPos = sgworld.Creator.CreatePosition(
                centerX,
                centerY,
                0,
                AltitudeTypeCode.ATC_TERRAIN_RELATIVE);
            // 创建标记物
            SkylineMouthObj = sgworld.Creator.CreateSphere(
                cPos,
                radius,
                Style,
                nLineColor,
                nFillColor,
                SegmentDensity,
                gid,
                Name + signIsInTerrain);

            //绘制孔身
            //var arrVertices = new double[]
            //{
            //    Top.X, Top.Y, Top.Z,
            //    Bottom.X, Bottom.Y, Bottom.Z
            //};
            //var lineColor = sgworld.Creator.CreateColor(255, 0, 0, 128);
            //SkylineBodyObj = sgworld.Creator.CreatePolylineFromArray(arrVertices, lineColor, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
            //    sgworld.ProjectTree.HiddenGroupID, Name);


            //绘制文字标签
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
