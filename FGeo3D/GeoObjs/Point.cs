using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Point:GeoObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }


        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point(IGPoint gPoint) :base(gPoint)
        {
            X = gPoint.X;
            Y = gPoint.Y;
            Z = gPoint.Z;
        }

        public Point(IGMarker marker) : base(marker)
        {
            X = marker.X;
            Y = marker.Y;
            Z = marker.Z;
        }

        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// 两点间距离
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public double DistanceToPoint(Point that)
        {
            var distanceSq = Math.Pow(X - that.Y, 2) + Math.Pow(Y - that.Y, 2) + Math.Pow(Z - that.Z, 2);
            return Math.Sqrt(distanceSq);
        }

        /// <summary>
        /// 两点的水平面方位角（笛卡尔坐标系x轴为零，逆时针，-PI ~ PI）
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public double YawTo(Point that)
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
        public double PitchTo(Point that)
        {
            var deltaX = that.X - X;
            var deltaY = that.Y - Y;
            var deltaH = that.Z - Z;
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
            IPosition66 cPos = sgworld.Creator.CreatePosition(X, Y, Z, AltitudeTypeCode.ATC_ON_TERRAIN);
            var item = sgworld.Creator.CreateSphere(cPos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, Name);

            //获取Skyline中的ID
            SetSkylineObj(item);
        }



        public override void Store()
        {
            base.Store();
        }
    }
}
