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

        Dictionary<int, ShapeBase> items = new Dictionary<int, ShapeBase>();
        private CoordSys.M1 m1 = null;
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

        private void Init()
        {
            sg_Vector3[] pts;
            if (!CoordSys.CoordHelp.get_KWZBPt3(SJLYID, out pts))
            {

                return;
            }
            if (pts.Count() > 2)
            {
                m1 = new CoordSys.M1(pts);
            }

            string DXID = string.Empty;
            string OperateID = GUIDGenerator.NewGUID;

            EditDataSet = GLDXMDXKBLL.GetEditDataSet(SJLYID, OperateID, DXID, string.Empty);
            dt = BLHTBLL.GetXDMXJDZB(SJLYID);

        }

        /// <summary>
        /// 由点集计算平面法向量
        /// </summary>
        /// <returns></returns>
        private bool CacNormalVector(sg_Vector3[] pts)
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
