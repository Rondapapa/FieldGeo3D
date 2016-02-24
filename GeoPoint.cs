using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoPoint:GeoObj
    {
        private ITerrainSphere65 _point;

        public string Id
        {
            get
            {
                return _point.ID;
            }
        }

        public IPosition65 Position
        {
          	get { return _point.Position; }
        }

        

        public GeoPoint(ITerrainSphere65 inSphere65)
        {
            GeoType = "Point";
            _point = inSphere65;
            AddObj(this, Id);
        }

        public GeoPoint(GeoObjInfo geoObjInfo, ref SGWorld65 sgworld)
        {
            GeoType = "Point";
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            _point = sgworld.Creator.CreateSphere(geoObjInfo.PointPosition, radius, Style, nLineColor, nFillColor, SegmentDensity, geoObjInfo.GroupId, geoObjInfo.Name);
            AddObj(this, Id);
        }
    }
}
