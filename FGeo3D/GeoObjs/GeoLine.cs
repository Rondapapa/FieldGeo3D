using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoLine:GeoObject
    {
        public List<IGPoint> Points { get; set; }


        public GeoLine(IGMarker marker)
        {
            for (var index = 0; index < marker.Points.Count; index++)
            {
                Points.Add(marker.Points.GetPoint(index));
            }
        }

        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
            var verticesArray = new List<double>();
            foreach (var point in Points)
            {
                verticesArray.Add(point.X);
                verticesArray.Add(point.Y);
                verticesArray.Add(point.Z);
            }
            var cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(verticesArray.ToArray());
            
            var lineColor = sgworld.Creator.CreateColor(255, 255, 255, 255); //黑色
            var altitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE; //待定
            string gid = GeoHelper.CreateGroup("地质线", ref sgworld);
            var item = sgworld.Creator.CreatePolyline(cLineString, lineColor, altitudeType, gid, Name);
            SetSkylineObj(item);
        }



        public override void Store()
        {
            base.Store();
        }
    }


}
