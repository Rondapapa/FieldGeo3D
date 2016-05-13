using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoPoint:GeoObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        private string _skylineId;

        public GeoPoint(double x, double y, double h, string name)
        {
            X = x;
            Y = y;
            H = h;
            Name = name;
            Type = GeometryType.Point;
        }

        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
            double radius = 8;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFFFF0000;
            var nFillColor = 0xFFFF6464;
            var SegmentDensity = -1;
            string gid = GeoHelper.CreateGroup("地质点", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(X, Y, H, AltitudeTypeCode.ATC_ON_TERRAIN);
            var item = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);
            _skylineId = item.ID;
        }

        public override void Erase(ref SGWorld66 sgworld)
        {
            base.Erase(ref sgworld);
            if (string.IsNullOrWhiteSpace(_skylineId))
                return;
            sgworld.ProjectTree.DeleteItem(_skylineId);

        }

        public override void Store()
        {
            base.Store();
        }
    }
}
