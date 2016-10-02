using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGeo3D.GeoObj
{
    using TerraExplorerX;
    using MathNet.Spatial.Euclidean;

    public class Plane:GeoObject
    {
        public ITerrainPolygon66 skyPlane { get; private set;}

        private MathNet.Spatial.Euclidean.Plane mathPlane;

        public Point RootPoint { get; }

        public double RootDepth { get; }

        public new double Dip { get; }

        public new double Angle { get; }

        public new string Name { get; }

        public Plane(Point rootPoint, double depth, double dip, double angle, string name)
        {
            Point p = rootPoint;
            RootDepth = depth;
            Dip = dip;
            Angle = angle;
            Name = name;
            RootPoint = new Point(p.X, p.Y, p.Z - RootDepth, Dip, Angle);
            this.MakeMathPlane();
            
        }

        private void MakeMathPlane()
        {
            UnitVector3D normal = new UnitVector3D(
                Math.Sin(this.Angle * Math.PI / 180) * Math.Sin(this.Dip * Math.PI / 180),
                Math.Sin(this.Angle * Math.PI / 180) * Math.Cos(this.Dip * Math.PI / 180), 
                Math.Cos(this.Angle * Math.PI / 180));
            Point3D rootPoint = new Point3D(RootPoint.X, RootPoint.Y, RootPoint.Z);
            this.mathPlane = new MathNet.Spatial.Euclidean.Plane(rootPoint, normal);
        }

        private double CalcZ(double x, double y)
        {
            return (-this.mathPlane.D - this.mathPlane.A * x - this.mathPlane.B * y) / this.mathPlane.C;
        }

        public void DrawOnSkyline(ref SGWorld66 sgworld, double height, double width, object lineColor, object fillColor)
        {


            var gid = GeoHelper.CreateGroup("产状平面", ref sgworld);

            double[] vertices =
                {
                    RootPoint.X + width, RootPoint.Y + height, CalcZ(RootPoint.X + width, RootPoint.Y + height),
                    RootPoint.X + width, RootPoint.Y - height, CalcZ(RootPoint.X + width, RootPoint.Y - height),
                    RootPoint.X - width, RootPoint.Y - height, CalcZ(RootPoint.X - width, RootPoint.Y - height),
                    RootPoint.X - width, RootPoint.Y + height, CalcZ(RootPoint.X - width, RootPoint.Y + height),
                };
            this.skyPlane = sgworld.Creator.CreatePolygonFromArray(
                vertices,
                lineColor,
                fillColor,
                AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
                gid,
                this.Name + "- 产状面");
        }

    }
}
