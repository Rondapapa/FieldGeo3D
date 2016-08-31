using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Spatial.Euclidean;

namespace FGeo3D_TE.GeoImage
{
    //该类用于创建、管理图像校准所用的原始点集数据，和校准模型
    class RectifyInfo
    {
        

        //原始点集数据
        public Dictionary<System.Drawing.Point, Point3D> RectifyDatas = new Dictionary<System.Drawing.Point, Point3D>();

        //校正模型
        public Plane RectifyModelWdX;
        public Plane RectifyModelWdY;
        public Plane RectifyModelWdZ;

        public RectifyInfo()
        {
            
        }


        /// <summary>
        /// 计算并创建校正模型
        /// </summary>
        public void CalculateRectification()
        {

            if (RectifyDatas.Count < 3)
            {
                MessageBox.Show(@"至少需要3个校正控制点。", @"校正失败");
                return;
            }

            //获取中心点坐标，作为RootPoint
            double scXSum = 0, scYSum = 0, wdXSum = 0, wdYSum = 0, wdZSum = 0;
            foreach (var scPointToWdPoint in RectifyDatas)
            {
                scXSum += scPointToWdPoint.Key.X; //屏幕坐标X
                scYSum += scPointToWdPoint.Key.Y; //屏幕坐标Y
                wdXSum += scPointToWdPoint.Value.X; //对应的真实坐标X!
                wdYSum += scPointToWdPoint.Value.Y; //对应的真实坐标Y!
                wdZSum += scPointToWdPoint.Value.Z; //对应的真实坐标Z!
            }
            var rootPointX = new Point3D(scXSum / RectifyDatas.Count, scYSum / RectifyDatas.Count, wdXSum / RectifyDatas.Count);
            var rootPointY = new Point3D(scXSum / RectifyDatas.Count, scYSum / RectifyDatas.Count, wdYSum / RectifyDatas.Count);
            var rootPointZ = new Point3D(scXSum / RectifyDatas.Count, scYSum / RectifyDatas.Count, wdZSum / RectifyDatas.Count);

            //获取平面的法向量，作为NormalVector
            var rectifyDataList = RectifyDatas.ToList();
            var normalVectorListX = new List<Vector3D>();
            var normalVectorListY = new List<Vector3D>();
            var normalVectorListZ = new List<Vector3D>();
            for (var i = 0; i < RectifyDatas.Count - 2; ++i)
            {
                for (var j = i + 1; j < RectifyDatas.Count - 1; ++j)
                {
                    for (var k = j + 1; k < RectifyDatas.Count; ++k)
                    {
                        //X
                        var p1X = new Point3D(rectifyDataList[i].Key.X, rectifyDataList[i].Key.Y, rectifyDataList[i].Value.X);
                        var p2X = new Point3D(rectifyDataList[j].Key.X, rectifyDataList[j].Key.Y, rectifyDataList[j].Value.X);
                        var p3X = new Point3D(rectifyDataList[k].Key.X, rectifyDataList[k].Key.Y, rectifyDataList[k].Value.X);
                        var vP12X = p1X.VectorTo(p2X);
                        var vP23X = p1X.VectorTo(p3X);
                        var normalVectorX = vP12X.CrossProduct(vP23X);

                        if (normalVectorListX.Count > 0 && normalVectorX.AngleTo(normalVectorListX[0]).Degrees > 90)
                        {
                            normalVectorX = normalVectorX.Negate();
                        }
                        
                        normalVectorListX.Add(normalVectorX);


                        //Y
                        var p1Y = new Point3D(rectifyDataList[i].Key.X, rectifyDataList[i].Key.Y, rectifyDataList[i].Value.Y);
                        var p2Y = new Point3D(rectifyDataList[j].Key.X, rectifyDataList[j].Key.Y, rectifyDataList[j].Value.Y);
                        var p3Y = new Point3D(rectifyDataList[k].Key.X, rectifyDataList[k].Key.Y, rectifyDataList[k].Value.Y);
                        var vP12Y = p1Y.VectorTo(p2Y);
                        var vP23Y = p1Y.VectorTo(p3Y);
                        var normalVectorY = vP12Y.CrossProduct(vP23Y);

                        if (normalVectorListY.Count > 0 && normalVectorY.AngleTo(normalVectorListY[0]).Degrees > 90)
                        {
                            normalVectorY = normalVectorY.Negate();
                        }

                        normalVectorListY.Add(normalVectorY);

                        //Z
                        var p1Z = new Point3D(rectifyDataList[i].Key.X, rectifyDataList[i].Key.Y, rectifyDataList[i].Value.Z);
                        var p2Z = new Point3D(rectifyDataList[j].Key.X, rectifyDataList[j].Key.Y, rectifyDataList[j].Value.Z);
                        var p3Z = new Point3D(rectifyDataList[k].Key.X, rectifyDataList[k].Key.Y, rectifyDataList[k].Value.Z);
                        var vP12Z = p1Z.VectorTo(p2Z);
                        var vP23Z = p1Z.VectorTo(p3Z);
                        var normalVectorZ = vP12Z.CrossProduct(vP23Z);

                        if (normalVectorListZ.Count > 0 && normalVectorZ.AngleTo(normalVectorListZ[0]).Degrees > 90)
                        {
                            normalVectorZ = normalVectorZ.Negate();
                        }

                        normalVectorListZ.Add(normalVectorZ);
                    }
                }
            }

            //X
            double nVxSumX = 0, nVySumX = 0, nVzSumX = 0;
            foreach (var normalVector in normalVectorListX)
            {
                nVxSumX += normalVector.X;
                nVySumX += normalVector.Y;
                nVzSumX += normalVector.Z;
            }
            var vNx = new UnitVector3D(nVxSumX / normalVectorListX.Count, nVySumX / normalVectorListX.Count, nVzSumX / normalVectorListX.Count);

            //Y
            double nVxSumY = 0, nVySumY = 0, nVzSumY = 0;
            foreach (var normalVector in normalVectorListY)
            {
                nVxSumY += normalVector.X;
                nVySumY += normalVector.Y;
                nVzSumY += normalVector.Z;
            }
            var vNy = new UnitVector3D(nVxSumY / normalVectorListY.Count, nVySumY / normalVectorListY.Count, nVzSumY / normalVectorListY.Count);

            //Z
            double nVxSumZ = 0, nVySumZ = 0, nVzSumZ = 0;
            foreach (var normalVector in normalVectorListZ)
            {
                nVxSumZ += normalVector.X;
                nVySumZ += normalVector.Y;
                nVzSumZ += normalVector.Z;
            }
            var vNz = new UnitVector3D(nVxSumZ / normalVectorListZ.Count, nVySumZ / normalVectorListZ.Count, nVzSumZ / normalVectorListZ.Count);

            //构造平面模型
            RectifyModelWdX = new Plane(rootPointX, vNx);
            RectifyModelWdY = new Plane(rootPointY, vNy);
            RectifyModelWdZ = new Plane(rootPointZ, vNz);

        }

        /// <summary>
        /// 根据校正模型，计算某点的校正坐标
        /// </summary>
        /// <param name="rawPoint">原始点（未校正）</param>
        /// <returns></returns>
        public Point3D RectPoint(Point3D rawPoint)
        {
            if (RectifyModelWdX == null || RectifyModelWdY == null || RectifyModelWdZ == null)
            {
                throw new Exception("尚未创建校正模型");
            }
            if ((rawPoint.Z - 0.0) < 0.0001)
            {
                //表面点校准

            }
            else
            {
                //延伸点校准

            }
            return new Point3D();
        }

    }
}
