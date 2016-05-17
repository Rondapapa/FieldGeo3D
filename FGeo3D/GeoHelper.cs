using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using System.Data.Entity.Spatial;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace FGeo3D_TE
{
    internal class PolarData:IComparable
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

        public PolarData()
        {
            
        }

        public int CompareTo(object obj)
        {
            
            var that = obj as PolarData;
            if (that != null)
            {
                
            }
            else
            {
                
            }
            return 0;
        }
    }

    static class GeoHelper
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
        public static List<GeoPoint> FitPlane(List<GeoPoint> inGeoPoints)
        {
            //获取中心点
            var centrialPoint = CentrialPoint(inGeoPoints);
            var xAve = centrialPoint.X;
            var yAve = centrialPoint.Y;
            var hAve = centrialPoint.H;

            //构造Jacobian矩阵
            var jacobian = new DenseMatrix(inGeoPoints.Count, 3);
            foreach (var point in inGeoPoints)
            {
                var gradient = new DenseVector(3)
                {
                    [0] = point.X - xAve,
                    [1] = point.Y - yAve,
                    [2] = point.H - hAve
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
            return (from point in inGeoPoints let x = point.X let y = point.Y let h = point.H - a/c*(x - xAve) - b/c*(y - yAve) select new GeoPoint(x, y, h, "#Fitting Point#")).ToList();
        }

        /// <summary>
        /// 获取某一点集的中心点
        /// </summary>
        /// <param name="inGeoPoints"></param>
        /// <returns></returns>
        public static GeoPoint CentrialPoint(List<GeoPoint> inGeoPoints)
        {
            var xSum = 0.0;
            var ySum = 0.0;
            var hSum = 0.0;
            foreach (var point in inGeoPoints)
            {
                xSum += point.X;
                ySum += point.Y;
                hSum += point.H;
            }
            var xAve = xSum / inGeoPoints.Count;
            var yAve = ySum / inGeoPoints.Count;
            var hAve = hSum / inGeoPoints.Count;
            return new GeoPoint(xAve, yAve, hAve, "##Centrial Point##");
        }

        /// <summary>
        /// 获取二维、三维散点集的近似平面轮廓有序点集
        /// </summary>
        /// <param name="inGeoPoints"></param>
        /// <returns></returns>
        public static List<GeoPoint> GetHullPoints(List<GeoPoint> inGeoPoints)
        {
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
        
    }
}
