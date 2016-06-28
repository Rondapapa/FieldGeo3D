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

        public List<GeoPoint> Links { get; set; } //平硐硐身几何关键点
        
        public List<GeoSurface> Surfaces { get; set; } //平硐边壁构造


        public LoggingFootrill(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
            for (var index = 0; index < dataObj.MarkersNO1.Count; index++)
            {
                var thisMarker = dataObj.MarkersNO1.GetMarker(index);
                Links.Add(new GeoPoint(thisMarker));
            }
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
            string gid = GeoHelper.CreateGroup("平硐", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(0, 0, 0, AltitudeTypeCode.ATC_ON_TERRAIN);
            _skylineMouthObj = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);

            //硐身


            //标签
            var cLabelStyle = sgworld.Creator.CreateLabelStyle();
            cLabelStyle.MultilineJustification = "Center";
            cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
            cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
            cLabelStyle.TextAlignment = "Bottom, Center";
            _skylineLabelObj = sgworld.Creator.CreateTextLabel(cPos, Name, cLabelStyle, sgworld.ProjectTree.HiddenGroupID, Name);
        }

        public void Erase(ref SGWorld66 sgworld)
        {
            if (_skylineMouthObj != null)
            {
                sgworld.Creator.DeleteObject(_skylineMouthObj.ID);
                _skylineMouthObj = null;
            }
            if (_skylineBodyObj != null)
            {
                sgworld.Creator.DeleteObject(_skylineBodyObj.ID);
                _skylineBodyObj = null;
            }
            if (_skylineLabelObj != null)
            {
                sgworld.Creator.DeleteObject(_skylineLabelObj.ID);
                _skylineLabelObj = null;
            }
            //注意，此时没有删除dict里的字段

        }



    }
}
