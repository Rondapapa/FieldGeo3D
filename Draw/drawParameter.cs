using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
