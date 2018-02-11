using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;

namespace Draw
{
    public class drawParameter
    {

        /// <summary>
        /// 数据来源ID
        /// </summary>
        public string SJLYID
        {
            get;
            set;
        }

        /// <summary>
        /// 数据来源类型
        /// </summary>
        public string SJLYLXID
        {
            get;
            set;
        }
        /// <summary>
        /// 数据来源类型名称
        /// </summary>
        public string SJLYLXMC
        {
            get;
            set;
        }

        /// <summary>
        /// 地质对象ID
        /// </summary>
        public string DZDXID
        {
            get;
            set;
        }

        /// <summary>
        /// 地质对象类型
        /// </summary>
        public string DZDXLX { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string BH
        {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string MC
        {
            get;
            set;
        }
        public IGPoint[] CtrlPts { get; set; }

        public string AllLines
        {
            get; set;
        }

        /// <summary>
        /// 编录绘图的类型：边坡编录(BP)、基础编录(JC)、洞室编录(DS)
        /// </summary>
        public string TypeOfBLHT
        {
            get; set;
        }

        /// <summary>
        /// 仅用于洞室编录
        /// </summary>
        public double CaveWidth { get; set; }
        public double CaveHeight { get; set; }

    }
}
