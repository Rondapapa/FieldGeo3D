using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using MathNet;
using System.Data.Entity.Spatial;

namespace FGeo3D_TE
{
    class GeoPlane:GeoObject
    {
        public List<GeoPoint> Points { get; set; }
        private string _skylineId;

        public GeoPlane(List<GeoPoint> points)
        {
            Points = points;
            Type = GeometryType.Plane;
        }

        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);

            //擦除已绘制的模型，以便重新绘制
            Erase(ref sgworld);

            //获取边界点集
            var hullPoints = GeoHelper.GetHullPoints(Points);
            
            //边界点集转化为VerticesList
            var verticesList = new List<double>();
            foreach (var point in hullPoints)
            {
                verticesList.Add(point.X);
                verticesList.Add(point.Y);
                verticesList.Add(point.H);
            }

            //根据VerticeList创建Polygon
            var nLineColor = 0xFFFF0000;
            var nFillColor = 0xFFFF6464;
            var item = sgworld.Creator.CreatePolygonFromArray(verticesList.ToArray(), nLineColor, nFillColor, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE, sgworld.ProjectTree.HiddenGroupID, Name);

            //获取Skyline ID
            _skylineId = item.ID;
        }

        public void Draw(ref SGWorld66 sgworld, bool isFittingPlane)
        {
            //Erase(ref sgworld);

            if (!isFittingPlane)
                Draw(ref sgworld);
            else
            {
                //实现三维散点的回归平面
                var fittingPoints = GeoHelper.FitPlane(Points);

                //获取边界点集
                var hullPoints = GeoHelper.GetHullPoints(fittingPoints);

                //hullPoints转化为VerticesList
                var verticesList = new List<double>();
                foreach (var point in hullPoints)
                {
                    verticesList.Add(point.X);
                    verticesList.Add(point.Y);
                    verticesList.Add(point.H);
                }

                //根据VerticeList创建Polygon
                var nLineColor = 0xFFFF0000;
                var nFillColor = 0xFF6464FF;
                var item = sgworld.Creator.CreatePolygonFromArray(verticesList.ToArray(), nLineColor, nFillColor, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE, sgworld.ProjectTree.HiddenGroupID, Name);

                //获取Skyline ID
                _skylineId = item.ID;

            }
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
