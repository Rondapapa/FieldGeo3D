using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;

using GeoIM.CHIDI.DZ.BLL.Geometry;
using GeoIM.CHIDI.DZ.BLL.YSZL;
using GeoIM.CHIDI.DZ.COM;
using GeoIM.CHIDI.DZ.Util.Common;
using MathNet.Spatial.Euclidean;

namespace Draw.Drawing
{
    using Draw.CoordSys;
    
    /// <summary>
    /// 管理一个绘制对象所有的绘制单元(线条)，并负责把数据取出和把修改保存到数据库
    /// </summary>
    public class Document
    {
        /// <summary>
        /// 数据来源ID
        /// </summary>
        public string SJLYID
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据来源类型
        /// </summary>
        public string SJLYLXID
        {
            get;
            private set;
        }
        /// <summary>
        /// 数据来源类型名称
        /// </summary>
        public string SJLYLXMC
        {
            get;
            private set;
        }

        /// <summary>
        /// 地质对象ID
        /// </summary>
        public string DZDXID
        {
            get;
            private set;
        }

        /// <summary>
        /// 地质对象类型
        /// </summary>
        public string DZDXLX { get; private set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string BH
        {
            get;
            private set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string MC
        {
            get;
            private set;
        }

        /// <summary>
        /// 三个控制点
        /// </summary>
        public IGPoint[] CtrlPts
        {
            get;
            set;
        }
        public string AllLines
        {
            get;set;
        }
        /// <summary>
        /// 编录绘图的类型：边坡编录(BP)、基础编录(JC)、洞室编录(DS)
        /// </summary>
        public string TypeOfBLHT
        {
            get;set;
        }

        /// <summary>
        /// 专用于洞室编录
        /// </summary>
        public double CaveWidth { get; set; }
        public double CaveHeight { get; set; }



        Dictionary<int, ShapeBase> items = new Dictionary<int, ShapeBase>();  // 存的是什么坐标？屏幕坐标？


        // 该线所对应 的三个坐标系
        private CoordSys.M1 m1 = null;
        private CoordSys.M3 m3Raw = null;
        private CoordSys.M3 m3Screen = null;

        // 宽高比，用于绘制图形
        public double widthHeightRito;
        public double recWidth;       // 局部坐标下 包络矩形的宽
        public double recHeight;      // 局部坐标下，包络矩形的高

        /// <summary>
        /// 开挖坐标下的三个控制点
        /// </summary>
        public sg_Vector3[] ptsForM3;
        /// <summary>
        /// 用于画在画板上，三个点的顺序为 上方顶点、左下点、右下点
        /// </summary>
        public Point3D[] ptsTriangleSC = new Point3D[3];


        private DataSet EditDataSet;
        private DataTable dt;
        private sg_Vector3 NormalVector;

        public bool IsChanged { get; set; }

        public Document(drawParameter para)
        {
            CtrlPts = para.CtrlPts;
            AllLines = para.AllLines;
            SJLYID = para.SJLYID;
            SJLYLXID = para.SJLYLXID;
            SJLYLXMC = para.SJLYLXMC;
            DZDXID = para.DZDXID;
            DZDXLX = para.DZDXLX;
            BH = para.BH;
            TypeOfBLHT = para.TypeOfBLHT;
            if (TypeOfBLHT == "DS")
            {
                CaveHeight = para.CaveHeight;
                CaveWidth = para.CaveWidth;
            }

            MC = para.MC;
            IsChanged = false;

            Init();
        }

        /// <summary>
        /// 设定初始数据
        /// </summary>
        private void Init()
        {
            // 获取地质对象的三个控制点，若找不到控制点，则退出
            sg_Vector3[] ptsForM1;
            if (!CoordSys.CoordHelp.get_KWZBPt3(SJLYID, out ptsForM1))
            {
                return;
            }

            // 根据三个控制点，建立M1
            if (ptsForM1.Count() > 2)
            {
                m1 = new CoordSys.M1(ptsForM1);
            }

            string DXID = string.Empty;
            string OperateID = GUIDGenerator.NewGUID;

            EditDataSet = GLDXMDXKBLL.GetEditDataSet(SJLYID, OperateID, DXID, string.Empty); // ?



             // 用于求M3的控制点
            dt = BLHTBLL.GetXDMXJDZB(SJLYID); // 用于求M3（可能重构进入CoordHelp相关函数中）

            if (!CoordHelp.get_JBBLZBPt3(SJLYID, CtrlPts, out ptsForM3))
            {
                return;
            }

            // 根据三个控制点，建立M3
            if (!CoordHelp.IsPtsCollinear(ptsForM3))
            {
                this.m3Raw = new M3(ptsForM3);
            }

            if (!this.m3Raw.IsValid)
            {
                throw new Exception("M3创建失败，请检查控制点坐标。");
            }

         
            // 建立M3Screen （M3与M3Screen）
          //  this.m3Screen = new M3(ptsForM3, xOffset, yOffset);

            Point3D[] Pts = new Point3D[3];
            Pts[0] = new Point3D(ptsForM3[0].x, ptsForM3[0].y, ptsForM3[0].z);
            Pts[1] = new Point3D(ptsForM3[1].x, ptsForM3[1].y, ptsForM3[1].z);
            Pts[2] = new Point3D(ptsForM3[2].x, ptsForM3[2].y, ptsForM3[2].z);

            //  确定三角形上方顶点、左下的点、右下的点
            //  以三角形中最长的边为底边
            Point3D pLeftDown = Pts[0], pRightDown = Pts[1], pUp = Pts[2];
            if (Pts[1].DistanceTo(Pts[2]) > pLeftDown.DistanceTo(pRightDown))
            {
                pLeftDown = Pts[1];
                pRightDown = Pts[2];
                pUp = Pts[0];
            }
            if (Pts[2].DistanceTo(Pts[0]) > pLeftDown.DistanceTo(pRightDown))
            {
                pLeftDown = Pts[2];
                pRightDown = Pts[0];
                pUp = Pts[1];
            }
            Vector3D tmpBA = pRightDown - pLeftDown;
            Vector3D tmpCA = pUp - pLeftDown;

            //叉乘，如果方向指向下，就要把三角形镜像一下，否则不符合勘察人员的视角
            //镜像，左下方的点和右下方的点互换即可
            Vector3D tmpResult = tmpCA.CrossProduct(tmpBA);
            if (tmpResult.Z < 0)
            {
                Point3D tmpP = pLeftDown;
                pLeftDown = pRightDown;
                pRightDown = tmpP;
            }
            
            // 根据海伦公式，计算三角的高
            double distAB = pLeftDown.DistanceTo(pRightDown);
            double distAC = pLeftDown.DistanceTo(pUp);
            double distBC = pRightDown.DistanceTo(pUp);

            double r = (distAB + distAC + distBC) / 2;
            double S = Math.Sqrt(r * (r - distBC) * (r - distAB) * (r - distAC));
            double h = 2 * S / distAB;

            //计算包络矩形的宽高比
            widthHeightRito = distAB / h;
            ptsTriangleSC[0] = pUp;
            ptsTriangleSC[1] = pLeftDown;
            ptsTriangleSC[2] = pRightDown;
        }

        /// <summary>
        /// 由点集计算平面法向量 //？？？
        /// </summary>
        /// <returns></returns>
        private bool CalcNormalVector(sg_Vector3[] pts)
        {
            NormalVector = new sg_Vector3(0, 0, 0);
            return true;
        }

        
        public void AddLine(Line newLine)      // 添加线
        {
            if (!items.ContainsKey(newLine.Id))
            {
                items.Add(newLine.Id, newLine);
                IsChanged = true;
            }
        }
    }
}
