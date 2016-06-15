using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoLine:GeoObject
    {
        public List<GeoPoint> Points { get; set; }
        private string _skylineId;

        public GeoLine(List<GeoPoint> points)
        {
            Points = points;
            Type = GeometryType.Line;
        }

        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
            var verticesArray = new List<double>();
            foreach (var point in Points)
            {
                verticesArray.Add(point.X);
                verticesArray.Add(point.Y);
                verticesArray.Add(point.H);
            }
            var cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(verticesArray.ToArray());
            
            var lineColor = sgworld.Creator.CreateColor(255, 255, 255, 255); //黑色
            var altitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE; //待定
            string gid = GeoHelper.CreateGroup("地质线", ref sgworld);
            var item = sgworld.Creator.CreatePolyline(cLineString, lineColor, altitudeType, gid, Name);
            _skylineId = item.ID;
        }

        public override void Erase(ref SGWorld66 sgworld)
        {
            base.Erase(ref sgworld);
            if (string.IsNullOrWhiteSpace(_skylineId))
                return;
            sgworld.ProjectTree.DeleteItem(_skylineId);
            _skylineId = string.Empty;
        }

        public override void Store()
        {
            base.Store();
        }
    }


}
