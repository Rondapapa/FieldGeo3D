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

        /// <summary>
        /// 两点间距离
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public double DistanceToPoint(GeoPoint that)
        {
            var distanceSq = Math.Pow(X - that.Y, 2) + Math.Pow(Y - that.Y, 2) + Math.Pow(H - that.H, 2);
            return Math.Sqrt(distanceSq);
        }

        /// <summary>
        /// 两点的水平面方位角（笛卡尔坐标系x轴为零，逆时针，-PI ~ PI）
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public double YawTo(GeoPoint that)
        {
            var deltaX = that.X - X;
            var deltaY = that.Y - Y;
            return Math.Atan2(deltaY, deltaX);
        }

        /// <summary>
        /// 两点的竖直面俯仰角（笛卡尔坐标系，水平面为零，-PI/2 ~ PI/2）
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public double PitchTo(GeoPoint that)
        {
            var deltaX = that.X - X;
            var deltaY = that.Y - Y;
            var deltaH = that.H - H;
            var dHorizonSq = Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2);
            return Math.Atan2(deltaH, Math.Sqrt(dHorizonSq));
        }


        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);

            //画小圆点表示（待改正）
            double radius = 8.0;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFFFF0000;
            var nFillColor = 0xFFFF6464;
            var SegmentDensity = -1;
            string gid = GeoHelper.CreateGroup("地质点", ref sgworld);
            IPosition66 cPos = sgworld.Creator.CreatePosition(X, Y, H, AltitudeTypeCode.ATC_ON_TERRAIN);
            var item = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);

            //获取Skyline中的ID
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
