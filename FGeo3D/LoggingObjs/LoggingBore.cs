using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE.LoggingObjs
{
    class LoggingBore:LoggingObject
    {
        public LoggingBore(IObjData dataObj, ref SGWorld66 sgworld)
            :base(dataObj, ref sgworld)
        {
            Type = LoggingType.Bore;
            Draw(ref sgworld);
        }

        
        
        /// <summary>
        /// 绘制钻孔孔口(需要用钻孔口模型)
        /// </summary>
        /// <param name="sgworld"></param>
        public void Draw(ref SGWorld66 sgworld)
        {
            //绘制孔口：暂时用小圆点替代钻孔口模型
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            string gid = CreateGroup("钻探", ref sgworld);
            sgworld.ProjectTree.ExpandGroup(gid, true);
            IPosition66 cPos = sgworld.Creator.CreatePosition(Top.X, Top.Y, Top.Z, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE);
            SkylineMouthObj = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);

            //绘制孔身
            var arrVertices = new double[]
            {
                Top.X, Top.Y, Top.Z,
                Bottom.X, Bottom.Y, Bottom.Z
            };
            var lineColor = sgworld.Creator.CreateColor(255, 0, 0, 128);
            SkylineBodyObj = sgworld.Creator.CreatePolylineFromArray(arrVertices, lineColor, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE, 
                sgworld.ProjectTree.HiddenGroupID, Name);


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
