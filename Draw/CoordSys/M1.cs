using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.BLL.Geometry;

namespace Draw.CoordSys
{
    public class M1
    {
        private sg_Transformation mTrans;
        public M1(sg_Vector3[] pts) : this(pts[0], pts[1], pts[2])
        {

        }
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

        public sg_Vector3 getWorldCoord(sg_Vector3 pt)
        {
            return mTrans.apply(pt);
        }

        public sg_Vector3 getLocCoord(sg_Vector3 pt)
        {
            return mTrans.inverse(pt);
        }
    }
}
