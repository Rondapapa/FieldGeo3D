using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.BLL.Geometry;

namespace Draw.CoordSys
{
    /// <summary>
    /// M3 表达大地坐标到局部编录坐标的变换矩阵
    /// </summary>
    public class M3
    {
        private sg_Transformation mTrans;

        public bool IsValid { get; private set; }


        public M3(sg_Vector3[] pts) : this(pts[0], pts[1], pts[2])
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pt1">局部编录坐标控制点1</param>
        /// <param name="pt2">局部编录坐标控制点2</param>
        /// <param name="pt3">局部编录坐标控制点3</param>
        public M3(sg_Vector3 pt1, sg_Vector3 pt2, sg_Vector3 pt3)
        {
            sg_Vector3 v12 = pt2 - pt1;
            sg_Vector3 v13 = pt3 - pt1;

            if (v12.isParallel(v13))
            {
                // 若三点共线 
                // 怎么办？
                IsValid = false;
                return; 
            }

            sg_Vector3 nLocalXoY = v12.crossMul(v13);  // 局部编录面法向量
            sg_Vector3 nGeodeticXoY = new sg_Vector3(0,0,1); // 大地坐标XoY面法向量
            sg_Vector3 nx = nLocalXoY.isParallel(nGeodeticXoY)
                                ? new sg_Vector3(1, 0, 0)
                                : nLocalXoY.crossMul(nGeodeticXoY);
            sg_Vector3 ny = nLocalXoY.isParallel(nGeodeticXoY)
                                ? new sg_Vector3(0, 1, 0)
                                : nLocalXoY.crossMul(nx);
            sg_Vector3 nz = nx.crossMul(ny);
            this.mTrans = new sg_Transformation(nz, nx, ny, pt1);
            IsValid = true;
        }

        /// <summary>
        /// 由局部编录坐标计算大地坐标
        /// </summary>
        /// <param name="pt">以局部编录坐标表示的点</param>
        /// <returns></returns>
        public sg_Vector3 getWorldCoord(sg_Vector3 pt)
        {
            return mTrans.apply(pt);
        }

        /// <summary>
        /// 由大地坐标计算局部编录坐标
        /// </summary>
        /// <param name="pt">以大地坐标表示的点</param>
        /// <returns></returns>
        public sg_Vector3 getLocCoord(sg_Vector3 pt)
        {
            return mTrans.inverse(pt);
        }
    }
}
