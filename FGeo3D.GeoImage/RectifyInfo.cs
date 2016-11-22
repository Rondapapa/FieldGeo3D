using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MathNet.Spatial.Euclidean;

namespace FGeo3D.GeoImage
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
        public Plane RectifyModelWdReal; //真实坐标点所构成平面

        public bool IsValid => this.RectifyDatas.Count >= 3;

        public RectifyInfo()
        {
            
        }


        private IDictionary<System.Drawing.Point, Point3D> ClockwiseFirst3Points(IDictionary<System.Drawing.Point, Point3D> pointsDict)
        {
            if (pointsDict.Count < 3) return pointsDict;

            IDictionary<System.Drawing.Point, Point3D> result = new ConcurrentDictionary<System.Drawing.Point, Point3D>();

            var list = pointsDict.ToList();
            //获取前三个键值对
            var first = list[0];
            var second = list[1];
            var third = list[2];

            


            //判定前三个K-V Pairs的顺序
            var firstPoint3D = new Point3D(first.Key.X, first.Key.Y, 0);
            var secondPoint3D = new Point3D(second.Key.X, second.Key.Y, 0);
            var thirdPoint3D = new Point3D(third.Key.X, third.Key.Y, 0);
            var vFirstToSecond = firstPoint3D.VectorTo(secondPoint3D);
            var vFirstToThird = firstPoint3D.VectorTo(thirdPoint3D);
            var nFirstSecondToFirstThird = vFirstToSecond.CrossProduct(vFirstToThird);

            result.Add(first);
            if (nFirstSecondToFirstThird.Z > 0) //顺时针
            {
                result.Add(third);
                result.Add(second);
            }
            else //逆时针
            {
                result.Add(second);
                result.Add(third);
            }

            //获取其余的键值对
            if (list.Count <= 3) return result;
            for (var index = 3; index < list.Count; ++index)
            {
                result.Add(list[index]);
            }

            return result;
        }

        /// <summary>
        /// 计算并创建校正模型
        /// </summary>
        public void CalculateRectification()
        {
            

            if (RectifyDatas.Count < 3)
            {
                MessageBox.Show(@"至少需要3个校正控制点。", @"校正未完成");
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
            var rootPointReal = new Point3D(wdXSum / RectifyDatas.Count, wdYSum / RectifyDatas.Count, wdZSum / RectifyDatas.Count);

            //获取平面的法向量
            var rectifyDataList = ClockwiseFirst3Points(RectifyDatas).ToList(); //前三个 顺时针排序；
            var normalVectorListX = new List<Vector3D>();
            var normalVectorListY = new List<Vector3D>();
            var normalVectorListZ = new List<Vector3D>();
            var normalVectorListReal = new List<Vector3D>();
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
                        var vP13X = p1X.VectorTo(p3X);
                        var normalVectorX = vP12X.CrossProduct(vP13X);
                        if (normalVectorListX.Count == 0)
                        {
                            
                        }
                        else if (normalVectorListX.Count > 0 && normalVectorX.AngleTo(normalVectorListX[0]).Degrees > 90)
                        {
                            normalVectorX = normalVectorX.Negate();
                        }
                        
                        normalVectorListX.Add(normalVectorX);


                        //Y
                        var p1Y = new Point3D(rectifyDataList[i].Key.X, rectifyDataList[i].Key.Y, rectifyDataList[i].Value.Y);
                        var p2Y = new Point3D(rectifyDataList[j].Key.X, rectifyDataList[j].Key.Y, rectifyDataList[j].Value.Y);
                        var p3Y = new Point3D(rectifyDataList[k].Key.X, rectifyDataList[k].Key.Y, rectifyDataList[k].Value.Y);
                        var vP12Y = p1Y.VectorTo(p2Y);
                        var vP13Y = p1Y.VectorTo(p3Y);
                        var normalVectorY = vP12Y.CrossProduct(vP13Y);

                        if (normalVectorListY.Count == 0)
                        {

                        }
                        else if (normalVectorListY.Count > 0 && normalVectorY.AngleTo(normalVectorListY[0]).Degrees > 90)
                        {
                            normalVectorY = normalVectorY.Negate();
                        }

                        normalVectorListY.Add(normalVectorY);

                        //Z
                        var p1Z = new Point3D(rectifyDataList[i].Key.X, rectifyDataList[i].Key.Y, rectifyDataList[i].Value.Z);
                        var p2Z = new Point3D(rectifyDataList[j].Key.X, rectifyDataList[j].Key.Y, rectifyDataList[j].Value.Z);
                        var p3Z = new Point3D(rectifyDataList[k].Key.X, rectifyDataList[k].Key.Y, rectifyDataList[k].Value.Z);
                        var vP12Z = p1Z.VectorTo(p2Z);
                        var vP13Z = p1Z.VectorTo(p3Z);
                        var normalVectorZ = vP12Z.CrossProduct(vP13Z);

                        if (normalVectorListY.Count == 0)
                        {

                        }
                        else if (normalVectorListZ.Count > 0 && normalVectorZ.AngleTo(normalVectorListZ[0]).Degrees > 90)
                        {
                            normalVectorZ = normalVectorZ.Negate();
                        }

                        normalVectorListZ.Add(normalVectorZ);

                        //Real
                        var p1Real = new Point3D(rectifyDataList[i].Value.X, rectifyDataList[i].Value.Y, rectifyDataList[i].Value.Z);
                        var p2Real = new Point3D(rectifyDataList[j].Value.X, rectifyDataList[j].Value.Y, rectifyDataList[j].Value.Z);
                        var p3Real = new Point3D(rectifyDataList[k].Value.X, rectifyDataList[k].Value.Y, rectifyDataList[k].Value.Z);
                        var vP12Real = p1Real.VectorTo(p2Real);
                        var vp13Real = p1Real.VectorTo(p3Real);
                        var normalVectorReal = vP12Real.CrossProduct(vp13Real);

                        if (normalVectorListReal.Count > 0 &&
                            normalVectorReal.AngleTo(normalVectorListReal[0]).Degrees > 90)
                        {
                            normalVectorReal = normalVectorReal.Negate();
                        }

                        normalVectorListReal.Add(normalVectorReal);
                    }
                }
            }

            //获取平面的单位法向量
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
            //Real
            double nVxSumReal = 0, nVySumReal = 0, nVzSumReal = 0;
            foreach (var normalVector in normalVectorListReal)
            {
                nVxSumReal += normalVector.X;
                nVySumReal += normalVector.Y;
                nVzSumReal += normalVector.Z;
            }
            var vNReal = new UnitVector3D(nVxSumReal / normalVectorListReal.Count, nVySumReal / normalVectorListReal.Count, nVzSumReal / normalVectorListReal.Count);


            //构造平面模型
            RectifyModelWdX = new Plane(rootPointX, vNx);
            RectifyModelWdY = new Plane(rootPointY, vNy);
            RectifyModelWdZ = new Plane(rootPointZ, vNz);
            RectifyModelWdReal = new Plane(rootPointReal, vNReal);

            MessageBox.Show($"{RectifyDatas.Count}个校正控制点。", @"校正完成");
            
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
