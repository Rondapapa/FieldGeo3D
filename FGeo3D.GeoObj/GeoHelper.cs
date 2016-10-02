using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Spatial;
using TerraExplorerX;
using MIConvexHull;

namespace FGeo3D.GeoObj
{
    using MathNet.Spatial.Euclidean;
    using MathNet.Spatial.Units;

    internal class PolarData
    {
        public int Index { get; set;}
        public double Distance { get; set; }
        public double Yaw { get; set; }
        public double Pitch { get; set; }

        public PolarData(int index, double distance, double yaw, double pitch)
        {
            Index = index;
            Distance = distance;
            Yaw = yaw;
            Pitch = pitch;
        }

        public PolarData(){}

    }

    public static class GeoHelper
    {
        public static string CreateGroup(string groupName, ref SGWorld66 sgworld)
        {
            var gid = sgworld.ProjectTree.FindItem(groupName);
            if (!string.IsNullOrEmpty(gid))
            {
                return gid;
            }
            return sgworld.ProjectTree.CreateGroup(groupName);
        }

        /// <summary>
        /// 根据ID，在数据库中返回相应的地质对象基本信息。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GeoObject GetObject(string id)
        {
            var result = new GeoObject();
            //
            return result;
        }

        /// <summary>
        /// 通过三维散点集生成回归平面，用过平面的三维点集表示
        /// </summary>
        /// <param name="inGeoPoints">三维散点集</param>
        /// <returns></returns>
        public static List<Point> FitPlane(List<Point> inGeoPoints)
        {
            //三点以下，直接返回原点集
            if(inGeoPoints.Count <= 3)
                return inGeoPoints;
            
            //获取矩阵向量参数
            var sumXiSq = 0.0;
            var sumYiSq = 0.0;
            var sumXiYi = 0.0;
            var sumXiZi = 0.0;
            var sumYiZi = 0.0;
            var sumXi = 0.0;
            var sumYi = 0.0;
            var sumZi = 0.0;
            foreach (var point in inGeoPoints)
            {
                sumXiSq += Math.Pow(point.X, 2);
                sumYiSq += Math.Pow(point.Y, 2);
                sumXiYi += point.X * point.Y;
                sumXiZi += point.X * point.Z;
                sumYiZi += point.Z * point.Y;
                sumXi += point.X;
                sumYi += point.Y;
                sumZi += point.Z;
            }
            
            //构造矩阵
            var matrix = new DenseMatrix(3, 3)
            {
                [0, 0] = sumXiSq, [0, 1] = sumXiYi, [0, 2] = sumXi,
                [1, 0] = sumXiYi, [1, 1] = sumYiSq, [1, 2] = sumYi,
                [2, 0] = sumXi,   [2, 1] = sumYi,   [2, 2] = inGeoPoints.Count
            };

            //构造向量
            var vector = new DenseVector(3)
            {
                [0] = sumXiZi,
                [1] = sumYiZi,
                [2] = sumZi
            };

            //计算平面参数
            var parameters = matrix.Inverse().Multiply(vector);
            var a0 = parameters[0];
            var a1 = parameters[1];
            var a2 = parameters[2];

            //返回结果点集（新点集与原点集的X、Y相同，H经过fitting重算）
            return (from point in inGeoPoints
                    let x = point.X
                    let y = point.Y
                    let h = a0*x + a1*y + a2
                    select new Point(x, y, h)).ToList();

            /*
            //获取中心点
            var centrialPoint = CentrialPoint(inGeoPoints);
            var xAve = centrialPoint.X;
            var yAve = centrialPoint.Y;
            var hAve = centrialPoint.Z;

            //构造Jacobian矩阵
            var jacobian = new DenseMatrix(inGeoPoints.Count, 3);
            foreach (var point in inGeoPoints)
            {
                var gradient = new DenseVector(3)
                {
                    [0] = point.X - xAve,
                    [1] = point.Y - yAve,
                    [2] = point.Z - hAve
                };
                jacobian.SetRow(inGeoPoints.IndexOf(point), gradient);
            }

            //奇异值分解
            var svd = jacobian.Svd();
            // get matrix of left singular vectors with first n columns of U
            var U = svd.U.SubMatrix(0, inGeoPoints.Count, 0, 3);
            // get matrix of singular values
            var S = new DiagonalMatrix(3, 3, svd.S.ToArray());
            // get matrix of right singular vectors
            var V = svd.VT.Transpose();

            //提取平面向量
            var param = V.Column(2);
            var a = param[0];
            var b = param[1];
            var c = param[2];

            //返回结果点集（新点集与原点集的X、Y相同，H经过fitting重算）
            return (from point in inGeoPoints let x = point.X let y = point.Y let h = point.Z - a/c*(x - xAve) - b/c*(y - yAve) select new Point(x, y, h, "#Fitting Point#")).ToList();
            */

        }

        /// <summary>
        /// 获取某一点集的中心点
        /// </summary>
        /// <param name="inGeoPoints"></param>
        /// <returns></returns>
        public static Point CentrialPoint(List<Point> inGeoPoints)
        {
            var xSum = 0.0;
            var ySum = 0.0;
            var hSum = 0.0;
            foreach (var point in inGeoPoints)
            {
                xSum += point.X;
                ySum += point.Y;
                hSum += point.Z;
            }
            var xAve = xSum / inGeoPoints.Count;
            var yAve = ySum / inGeoPoints.Count;
            var hAve = hSum / inGeoPoints.Count;
            return new Point(xAve, yAve, hAve);
        }

        /// <summary>
        /// 获取二维、三维散点集的近似平面轮廓有序点集
        /// </summary>
        /// <param name="inGeoPoints"></param>
        /// <returns></returns>
        public static List<Point> GetHullPoints(List<Point> inGeoPoints)
        {
            if (inGeoPoints.Count <= 3)
                return inGeoPoints;
            
            //获取点集中心
            var centrialPoint = CentrialPoint(inGeoPoints);

            //对应极距、水平方位角、竖直俯仰角列表
            var polarList = new List<PolarData>();
            var polarListIndex = 0;
            foreach (var point in inGeoPoints)
            {
                var polarData = new PolarData
                {
                    Index = polarListIndex,
                    Distance = centrialPoint.DistanceToPoint(point),
                    Pitch = centrialPoint.PitchTo(point),
                    Yaw = centrialPoint.YawTo(point)
                };
                polarList.Add(polarData);
                polarListIndex += 1;
            }

            //根据PolarData排序
            var hullPolarDatas = new List<PolarData>();
            const double yawInterval = Math.PI/180*5;
            for (var yawCurrent = -Math.PI; yawCurrent <= Math.PI; yawCurrent += yawInterval)
            {
                //开列表，存入水平方位角区间内的所有点
                var yawIntervalList = polarList.FindAll(x => (x.Yaw >= yawCurrent) && (x.Yaw < yawCurrent + yawInterval));
                if (yawIntervalList.Count == 0)
                    continue;
                //获取列表内距离最大的点的距离
                var maxDistanceInYawInterval = yawIntervalList.Max(x => x.Distance);
                //获取距离最大的点（距离容差为0.5）
                var targetPolarData = yawIntervalList.Find(x => Math.Abs(x.Distance - maxDistanceInYawInterval) < 0.5);
                //存入结果列表
                hullPolarDatas.Add(targetPolarData);
            }

            //返回近似平面轮廓有序点集
            return hullPolarDatas.Select(polardata => inGeoPoints[polardata.Index]).ToList();
        }



        /// <summary>
        /// 在多边形内部以给定间隔插入规则格网点
        /// </summary>
        /// <param name="polygonHull"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static List<Point> InsertPointsInPolygon(List<Point> vertexList, double interval)
        {
            List<Point> resultPointList = new List<Point>(vertexList);

            // 外围最小矩形
            var sortedListX = new List<Point>(vertexList.OrderBy(p => p.X));
            var sortedListY = new List<Point>(vertexList.OrderBy(p => p.Y));
            double Xmin = sortedListX[0].X;
            double Xmax = sortedListX[sortedListX.Count - 1].X;
            double Ymin = sortedListY[0].Y;
            double Ymax = sortedListY[sortedListY.Count - 1].Y;

            // 按照间隔值插入格网点，判断点是否在多边形内，若不在，则不插入。
            for (double x = Xmin + interval; x < Xmax; x += interval)
            {
                for (double y = Ymin + interval; y < Ymax; y += interval)
                {
                    Point p = new Point(x, y, 0);
                    if (IsPointInPolygon(vertexList, p))
                    {
                        resultPointList.Add(p);
                    }
                }
            }
            return resultPointList;
        }


        private static bool IsPointInPolygon(List<Point> vertexList, Point p)
        {
            if (vertexList.Count < 3)
            {
                return false;
            }

            List<UnitVector3D> pToVertexList = new List<UnitVector3D>(vertexList.Count);
            
            

            Point3D p3d = new Point3D(p.X, p.Y, 0);
            foreach (var vertex in vertexList)
            {
                UnitVector3D vector = p3d.VectorTo(new Point3D(vertex.X, vertex.Y, 0)).Normalize();
                pToVertexList.Add(vector);
            }

            var firstCrossPruduct = pToVertexList[0].CrossProduct(pToVertexList[1]);
            for (int i = 1; i < pToVertexList.Count - 1; ++i)
            {
                UnitVector3D crossResult = pToVertexList[i].CrossProduct(pToVertexList[i + 1]);
                if (firstCrossPruduct.AngleTo(crossResult).Degrees >= 90.0)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
