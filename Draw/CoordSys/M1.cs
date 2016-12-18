using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.BLL.Geometry;

namespace Draw.CoordSys
{
    /// <summary>
    /// M1 表达大地坐标到开挖坐标的变换矩阵
    /// 注意：
    /// 规定由大地坐标变化到开挖坐标 必须保证Z轴（高程）方向不变
    /// </summary>
    public class M1
    {
        private sg_Transformation mTrans;
        public M1(sg_Vector3[] pts) : this(pts[0], pts[1], pts[2])
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orgin">开挖坐标原点</param>
        /// <param name="H_Point">开挖坐标X（横)坐标轴上一点</param>
        /// <param name="V_Point">开挖坐标Y(纵)坐标轴正方向侧的任意点</param>
        public M1(sg_Vector3 orgin, sg_Vector3 H_Point, sg_Vector3 V_Point)
        {
            sg_Vector3 newZ = new sg_Vector3(0, 0, 1);
            sg_Vector3 newX = H_Point - orgin;

            sg_Vector3 YR1 = V_Point - orgin;
            sg_Vector3 newY = newZ.crossMul(newX);
            double angle = Math.Abs(YR1.getInterAngle(newY));// 两向量夹角
            if (angle > 90)
            {
                newY.reverse();
            }
            
            mTrans = new sg_Transformation(newZ, newX, newY, orgin);
        }

        /// <summary>
        /// 由开挖坐标计算大地坐标
        /// </summary>
        /// <param name="pt">以开挖坐标表示的点</param>
        /// <returns></returns>
        public sg_Vector3 getWorldCoord(sg_Vector3 pt)
        {
            return mTrans.apply(pt);
        }

        /// <summary>
        /// 由大地坐标计算开挖坐标
        /// </summary>
        /// <param name="pt">以大地坐标表示的点</param>
        /// <returns></returns>
        public sg_Vector3 getLocCoord(sg_Vector3 pt)
        {
            return mTrans.inverse(pt);
        }
    }
}
