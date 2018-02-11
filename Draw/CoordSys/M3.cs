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
        public sg_Vector3[] ctrlPts;

        public bool IsValid { get; private set; }


        public M3(sg_Vector3[] pts, double xOffset = 0.0, double yOffset = 0.0) : this(pts[0], pts[1], pts[2], xOffset, yOffset)

        {
            ctrlPts = pts;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pt1">局部编录坐标控制点1</param>
        /// <param name="pt2">局部编录坐标控制点2</param>
        /// <param name="pt3">局部编录坐标控制点3</param>
        public M3(sg_Vector3 pt1, sg_Vector3 pt2, sg_Vector3 pt3, double xOffset = 0.0, double yOffset = 0.0)
        {
            ctrlPts = new sg_Vector3[3];
            ctrlPts[0] = pt1;
            ctrlPts[1] = pt2;
            ctrlPts[2] = pt3;


            sg_Vector3 v12 = pt2 - pt1;
            sg_Vector3 v13 = pt3 - pt1;
            if (v12.isParallel(v13))
            {
                
            }
            else
            {
                
            }


            sg_Vector3 newZ = new sg_Vector3(0, 0, 1);
            sg_Vector3 newX = pt2 - pt1;

            sg_Vector3 YR1 = pt3 - pt1;
            sg_Vector3 newY = newZ.crossMul(newX);
            double angle = Math.Abs(YR1.getInterAngle(newY)); // 两向量夹角
            if (angle > 90)
            {
                newY.reverse();
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

            sg_Vector3 origin = new sg_Vector3(pt1.x + xOffset, pt1.y + yOffset, pt1.z);
            this.mTrans = new sg_Transformation(nz, nx, ny, origin);
            IsValid = true;

        }



        /// <summary>
        /// 根据已有的M3，平移形成新的M3
        /// </summary>
        /// <param name="inM3">已有的M3</param>
        /// <param name="offSetX">原点X偏移</param>
        /// <param name="offSetY">原点Y偏移</param>
        public M3(M3 inM3, double offSetX, double offSetY)
        {
            
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
