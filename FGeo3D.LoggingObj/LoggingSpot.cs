using System.IO;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D.LoggingObj
{
    public class LoggingSpot : LoggingObject
    {
        public LoggingSpot(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
            if (isValidate == true)
            {
                Type = LoggingType.Spot;
                Draw(ref sgworld);
            }

        }

        public void Draw(ref SGWorld66 sgworld)
        {
            // 判断是否在地图以外
            string signIsInTerrain = IsLoggingObjInTerrain(ref sgworld) ? "" : "【地图以外】";
            // if(signIsInTerrain== "【地图以外】") { return; }

            //绘制身：暂时用小圆点替代钻孔口模型
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            string gid = CreateGroup("地质点", ref sgworld);
            sgworld.ProjectTree.ExpandGroup(gid, true);
            IPosition66 cPos = sgworld.Creator.CreatePosition(Top.X, Top.Y, Top.Z, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE);
            SkylineBodyObj = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name + signIsInTerrain);

            //绘制旗子
            var imageFileName = Path.Combine(Directory.GetCurrentDirectory(), "flag.png");
            SkylineMouthObj = sgworld.Creator.CreateImageLabel(cPos, imageFileName, null,
                sgworld.ProjectTree.HiddenGroupID);




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
