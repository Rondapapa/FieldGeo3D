using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGeo3D.GeoCurvedSurface
{
    using FGeo3D.GeoObj;

    public class SurfaceEquation
    {
        private double _a0, _a1, _a2;

        private readonly List<Point> sourcePoints;

        public double ShapeRadium { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurfaceEquation"/> class.
        /// </summary>
        /// <param name="a0">
        /// The a0.
        /// </param>
        /// <param name="a1">
        /// The a1.
        /// </param>
        /// <param name="a2">
        /// The a2.
        /// </param>
        /// <param name="sourcePoints">
        /// The source points.
        /// </param>
        /// <param name="shapeRadium">
        /// The shape radium.
        /// </param>
        public SurfaceEquation(double a0, double a1, double a2, IList<Point> sourcePoints, double shapeRadium = 50)
        {
            this._a0 = a0;
            this._a1 = a1;
            this._a2 = a2;
            this.sourcePoints = new List<Point>(sourcePoints);
            this.ShapeRadium = shapeRadium;
        }

        public double GetInterpolateValue(double x, double y)
        {
            // 判断R是否有效，否则设置默认值50
            if (this.ShapeRadium <= 0) this.ShapeRadium = 50;

            double zPlane = this._a0 + this._a1 * x + this._a2 * y;

            double zSpline = 0.0;
            foreach (var point in this.sourcePoints)
            {
                double f = point.Z - zPlane;
                double r2 = Math.Pow(x - point.X, 2) + Math.Pow(y - point.Y, 2);
                double ratio = r2 / this.ShapeRadium / this.ShapeRadium;
                double w = ratio * Math.Log(ratio) - ratio + 1;
                zSpline += f * w;
            }
            return zPlane + zSpline;
        }

    }
}
