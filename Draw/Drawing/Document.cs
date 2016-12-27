using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;

using GeoIM.CHIDI.DZ.BLL.Geometry;
using GeoIM.CHIDI.DZ.BLL.YSZL;

using GeoIM.CHIDI.DZ.Util.Common;

namespace Draw.Drawing
{
    using Draw.CoordSys;

    public struct drawingParameter
    {
        /// <summary>
        /// 数据来源ID
        /// </summary>
        public string SJLYID;

        /// <summary>
        /// 数据来源类型
        /// </summary>
        public string SJLYLXID;

        /// <summary>
        /// 数据来源类型名称
        /// </summary>
        public string SJLYLXMC;


        /// <summary>
        /// 地质对象ID
        /// </summary>
        public string DZDXID;


        /// <summary>
        /// 地质对象类型
        /// </summary>
        public string DZDXLX;

        /// <summary>
        /// 编号
        /// </summary>
        public string BH;


        /// <summary>
        /// 名称
        /// </summary>
        public string MC;
    }

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

        Dictionary<int, ShapeBase> items = new Dictionary<int, ShapeBase>();  // 存的是什么坐标？屏幕坐标？

        private CoordSys.M1 m1 = null;

        private CoordSys.M3 m3 = null;
        private DataSet EditDataSet;
        private DataTable dt;
        private sg_Vector3 NormalVector;

        public bool IsChanged
        {
            get;
            set;
        }

        public Document(drawParameter para)
        {
            SJLYID = para.SJLYID;
            SJLYLXID = para.SJLYLXID;
            SJLYLXMC = para.SJLYLXMC;
            DZDXID = para.DZDXID;
            DZDXLX = para.DZDXLX;
            BH = para.BH;
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

            sg_Vector3[] ptsForM3; // 用于求M3的控制点
            dt = BLHTBLL.GetXDMXJDZB(SJLYID); // 用于求M3（可能重构进入CoordHelp相关函数中）
            if (!CoordHelp.get_JBBLZBPt3(SJLYID, out ptsForM3))
            {
                return;
            }

            // 根据三个控制点，建立M3
            if (!CoordHelp.IsPtsCollinear(ptsForM3))
            {
                this.m3 = new M3(ptsForM3);
            }
            
            // 根据M1、M3算M2  （需要吗？）

            // 确定矩形参数
            // 绘制矩形



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

        public void AddShape(ShapeBase shape)
        {
            if (!items.ContainsKey(shape.Id))
            {
                items.Add(shape.Id, shape);
                IsChanged = true;
            }
        }
        /// <summary>
        /// 在Graphics
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            foreach (int itemid in items.Keys)
            {
                ShapeBase item = items[itemid];
                item.Draw(g);
            }
        }
    }
}
