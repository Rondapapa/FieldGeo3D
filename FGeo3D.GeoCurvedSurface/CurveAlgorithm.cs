using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FGeo3D.GeoCurvedSurface
{
    using FGeo3D.GeoObj;

    using MathNet.Numerics.LinearAlgebra.Double;
    using MathNet.Spatial.Euclidean;

    using TerraExplorerX;

    /// <summary>
    /// 曲面生成算法集合
    /// 每种算法形成一个独立的静态函数
    /// 输入：一组List-Point; 
    /// 输出：一组List-Point
    /// </summary>
    public static class CurveAlgorithm
    {
        public static SGWorld66 sgworld;

        /// <summary>
        /// 获取一组点集的四个包络顶点（平面XY）
        /// </summary>
        /// <param name="pointsList"></param>
        /// <returns></returns>
        public static List<Point> GetEdgePoints(IList<Point> pointsList, double edgeLength)
        {
            double minX = pointsList[0].X;
            double maxX = pointsList[0].X;
            double minY = pointsList[0].Y;
            double maxY = pointsList[0].Y;

            foreach (var p in pointsList)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            Point one = new Point(maxX + edgeLength * 3, maxY + edgeLength * 3, 0);
            Point two = new Point(minX - edgeLength * 3, maxY + edgeLength * 3, 0);
            Point three = new Point(minX - edgeLength * 3, minY - edgeLength * 3, 0);
            Point four = new Point(maxX + edgeLength * 3, minY - edgeLength * 3, 0);

            return new List<Point>(new[] { one, two, three, four });
        }

        /// <summary>
        /// 闭合曲线生成曲面的插值算法
        /// </summary>
        /// <param name="verticesList"></param>
        /// <param name="verticesPlane"></param>
        /// <param name="depth"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double CalcZinPlaneViaRing(IList<Point> verticesList, double depth, double x, double y)
        {
            double zTerrain =
                sgworld.Terrain.GetGroundHeightInfo(x, y, AccuracyLevel.ACCURACY_NORMAL).Position.Altitude;
            //
            Point middlePoint = MiddlePointOfPoints(verticesList);

            Point[] nearestEdge = FindEdgeNearestPoint(verticesList, new Point(x, y, 0));

            Point pVertexA = nearestEdge[0];
            Point pVertexB = nearestEdge[1];

            Point2D pA = new Point2D(pVertexA.X, pVertexA.Y);
            Point2D pB = new Point2D(pVertexB.X, pVertexB.Y);
            Point2D pM = new Point2D(middlePoint.X, middlePoint.Y);
            Point2D pX = new Point2D(x, y);

            // MX线方程
            DenseMatrix maMX = DenseMatrix.OfArray(new[,] { { pM.X, 1 }, { pX.X, 1 } });
            DenseVector vbMX = DenseVector.OfArray(new[] { pM.Y, pX.Y });
            var resultMX = maMX.LU().Solve(vbMX);
            double kMX = resultMX[0];
            double bMX = resultMX[1];

            // AB线方程
            DenseMatrix maAB = DenseMatrix.OfArray(new[,] { { pA.X, 1 }, { pB.X, 1 } });
            DenseVector vbAB = DenseVector.OfArray(new[] { pA.Y, pB.Y });
            var resultAB = maAB.LU().Solve(vbAB);
            double kAB = resultAB[0];
            double bAB = resultAB[1];

            // MX与AB线交点O坐标
            DenseMatrix maO = DenseMatrix.OfArray(new[,] { { kAB, -1 }, { kMX, -1 } });
            DenseVector vbO = DenseVector.OfArray(new[] { -bAB, -bMX });
            var resultO = maO.LU().Solve(vbO);
            double xO = resultO[0];
            double yO = resultO[1];
            Point2D pO = new Point2D(xO, yO);

            double dist = pM.DistanceTo(pX);
            double maxDist = pM.DistanceTo(pO);

            if (dist >= maxDist)
            {
                dist = maxDist;
            }

            return zTerrain - Math.Sqrt(1 - dist / maxDist) * depth;
        }




        /// <summary>
        /// 获取点集中心点
        /// </summary>
        /// <param name="pointsList"></param>
        /// <returns></returns>
        public static Point MiddlePointOfPoints(IList<Point> pointsList)
        {
            if (pointsList.Count <= 0)
            {
                throw new Exception("PointsList has No Points At All!");
            }

            //获取中心点坐标，作为RootPoint
            double XSum = 0, YSum = 0, ZSum = 0;
            foreach (var p in pointsList)
            {
                XSum += p.X; // 坐标X
                YSum += p.Y; // 坐标Y
                ZSum += p.Z;
            }
            return new Point(XSum / pointsList.Count, YSum / pointsList.Count, ZSum / pointsList.Count);
        }


        /// <summary>
        /// 寻找距离点p最近的边
        /// </summary>
        /// <param name="verticesList"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Point[] FindEdgeNearestPoint(IList<Point> verticesList, Point p)
        {
            if (verticesList.Count < 2)
            {
                throw new Exception("No Enough Points In VerticesList");
            }
            double minD = double.MaxValue;
            Point pA = null;
            Point pB = null;

            for (int i = 0; i < verticesList.Count - 1; ++i)
            {
                Point pStart = verticesList[i];
                Point pEnd = verticesList[(i != verticesList.Count - 1) ? (i + 1) : 0];
                // 线方程
                DenseMatrix ma = DenseMatrix.OfArray(new[,] { { pStart.X, 1 }, { pEnd.X, 1 } });
                DenseVector vb = DenseVector.OfArray(new[] { pStart.Y, pEnd.Y });
                var result = ma.LU().Solve(vb);
                double k = result[0];
                double b = result[1];
                double d = Math.Abs(k * p.X - p.Y + b) / Math.Sqrt(k * k + 1);
                if (d < minD)
                {
                    minD = d;
                    pA = pStart;
                    pB = pEnd;
                }
            }

            return new[] { pA, pB };
        }

        /// <summary>
        /// 获取点集之间的平均距离
        /// </summary>
        /// <param name="pointLists"></param>
        /// <returns></returns>
        public static double MeanDistanceOfPoints(IList<Point> pointLists)
        {
            if (pointLists.Count <= 0)
            {
                throw new Exception("点集为空！");
            }

            int distCount = pointLists.Count * pointLists.Count / 2;

            List<double> distances = new List<double>(distCount);
            for (int i = 0; i < pointLists.Count; ++i)
            {
                for (int j = i + 1; j < pointLists.Count; ++j)
                {
                    distances.Add(pointLists[i].DistanceToPoint(pointLists[j]));
                }
            }

            distances.Sort();

            double distSum = 0.0;
            foreach (var d in distances)
            {
                distSum += d;
            }

            return distSum / distCount;

        }
    }
}
