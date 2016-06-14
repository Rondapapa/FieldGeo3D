using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class DrawingPoint:DrawingObject
    {
        private ITerrainSphere66 _point;

        public string Id
        {
            get
            {
                return _point.ID;
            }
        }

        public IPosition66 Position
        {
          	get { return _point.Position; }
        }

        

        public DrawingPoint(ITerrainSphere66 inSphere66)
        {
            Type = "Point";
            _point = inSphere66;
            AddObj(this, Id);
        }

        public DrawingPoint(DrawingObjectInfo geoObjInfo, ref SGWorld66 sgworld)
        {
            Type = "Point";
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
