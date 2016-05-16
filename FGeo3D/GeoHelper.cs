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


            GeoObject result = new GeoObject();
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
            var svd = jacobian.Svd(true);
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

            //结果点集，并返回（新点集与原点集的X、Y相同，H经过fitting重算）
            return (from point in inGeoPoints let x = point.X let y = point.Y let h = point.H - a/c*(x - xAve) - b/c*(y - yAve) select new GeoPoint(x, y, h, "#Fitting Point#")).ToList();
        }

        /// <summary>
        /// 获取某一点集的近似平面凸包
        /// </summary>
        /// <param name="inGeoPoints"></param>
        /// <returns></returns>
        public static List<GeoPoint> ConvexHull(List<GeoPoint> inGeoPoints)
        {
            var result = new List<GeoPoint>();
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
            var centrialPoint = new GeoPoint(xAve, yAve, hAve, "##Centrial Point##");

            return result;
        }

        
        
    }
}
