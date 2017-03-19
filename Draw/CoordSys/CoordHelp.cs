using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GeoIM.CHIDI.DZ.BLL.Geometry;
using GeoIM.CHIDI.DZ.BLL.Common;
using GeoIM.CHIDI.DZ.BLL.XTGL;

using GeoIM.CHIDI.DZ.Util.Common;

using GeoIM.CHIDI.DZ.Model.XTGL;


namespace Draw.CoordSys
{
    using GeoIM.CHIDI.DZ.BLL.YSZL;

    public class CoordHelp
    {
        /// <summary>
        /// 得到数据来源的开挖坐标系
        /// </summary>
        /// <param name="id">数据来源ID</param>
        /// <param name="pts"></param>
        /// <returns></returns>
        public static bool get_KWZBPt3(string id, out sg_Vector3[] pts)
        {
            // 坐标系ID
            pts = new sg_Vector3[3];

            string zbxtid = ColumnType.ConvertStringNotDBNull(BaseBll.GetSingleValue(
                $"SELECT ZBXTID FROM SJLYK WHERE ID='{id}'"));
            if (string.IsNullOrEmpty(zbxtid))
            {
                //没有坐标系不计算
                return false;
            }
            //获取坐标系的控制控制点坐标  //cl 2016/09/21 这里应是获取开挖坐标系
            DataSet ds = GCKWZBXTKBLL.GetKZDZBByZTXTID(zbxtid);
            if (ds.Tables[GCKWZBXTKModel.TableName].Rows.Count == 0)
            {
                //没有坐标系不计算
                return false;
            }
            string ydid = ds.Tables[GCKWZBXTKModel.TableName].Rows[0][GCKWZBXTKModel.YDID].ToString();
            //if (!string.IsNullOrEmpty(ydid))
            //{
            if (string.IsNullOrEmpty(ydid))//修改 xyb，为什么是有值还不计算？
            {
                //没有原点坐标，不计算
                return false;
            }
            string hzbid = ds.Tables[GCKWZBXTKModel.TableName].Rows[0][GCKWZBXTKModel.HZBID].ToString();
            if (string.IsNullOrEmpty(hzbid))
            {
                //没有x方向坐标，不计算
                return false;
            }
            string zzbid = ds.Tables[GCKWZBXTKModel.TableName].Rows[0][GCKWZBXTKModel.ZZBID].ToString();
            if (string.IsNullOrEmpty(zzbid))
            {
                //没有y方向坐标，不计算
                return false;
            }

            //开挖坐标系原点坐标
            DataRow drYD = ds.Tables[GCKZDZBKModel.TableName].Rows.Find(ydid);
            double x = double.Parse(drYD["X"].ToString());
            double y = double.Parse(drYD["Y"].ToString());
            double z = double.Parse(drYD["Z"].ToString());
            pts[0] = new sg_Vector3(x, y, z);

            //开挖坐标系X坐标
            DataRow hdr = ds.Tables[GCKZDZBKModel.TableName].Rows.Find(hzbid);
            x = double.Parse(hdr["X"].ToString());
            y = double.Parse(hdr["Y"].ToString());
            z = double.Parse(hdr["Z"].ToString());
            pts[1] = new sg_Vector3(x, y, z);

            //开挖坐标系Y坐标
            DataRow zdr = ds.Tables[GCKZDZBKModel.TableName].Rows.Find(zzbid);
            x = double.Parse(zdr["X"].ToString());
            y = double.Parse(zdr["Y"].ToString());
            z = double.Parse(zdr["Z"].ToString());
            pts[2] = new sg_Vector3(x, y, z);

            return true;
        }

        /// <summary>
        /// 得到数据来源的局部编录坐标系 （还未实现）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pts"></param>
        /// <returns></returns>
        public static bool get_JBBLZBPt3(string id, out sg_Vector3[] pts)
        {
            pts = new sg_Vector3[3];    

            DataTable dt = BLHTBLL.GetXDMXJDZB(id); // 数据来源是大地坐标吗？  
            if (dt.Rows.Count == 0)
            {
                return false;
            }



            // 待实现
            return true;
        }

        /// <summary>
        /// 判断点集是否共线
        /// </summary>
        /// <param name="pts">点集</param>
        /// <returns></returns>
        public static bool IsPtsCollinear(sg_Vector3[] pts)
        {
            int iCount = pts.Length;

            // 若点集中的点数小于3个，判定共线
            if (iCount < 3) return true;

            // 获取第一个非零辅助向量
            sg_Vector3 v1 = pts[1] - pts[0];
            if (v1.isZero())
            {
                for (int i = 2; i < iCount; ++i)
                {
                    v1 = pts[i] - pts[0];
                    if (!v1.isZero()) break;
                }
            }

            // 获取第二个非零辅助向量
            for (int j = 1; j < iCount; ++j)
            {
                var v2 = pts[j] - pts[0];
                if (v2.isZero())
                {
                    continue;
                }
                
                // 若两个非零辅助向量不平行，则判定不共线
                if (!v1.isParallel(v2))
                {
                    return false;
                }
            }

            // 若两个非零辅助向量始终平行，则判定共线
            return true;
        }

        /// <summary>
        /// 由点集计算平面法向量
        /// </summary>
        /// <param name="pts">点集</param>
        /// <returns></returns>
        public static bool CalcNormalVector(sg_Vector3[] pts, out sg_Vector3 n)
        {
            n = null;
            int iCount = pts.Length;
            if (iCount < 3) return false;
            sg_Vector3 pt1 = pts[0];
            sg_Vector3 pt2 = null;
            for (int i = 1; i < iCount; i++)
            {
                pt2 = pts[i];
                if (sg_math.isZero(pt2.DistTo(pt1)))
                {
                    pt2 = null;
                }
                else
                {
                    break;
                }
            }
            if (pt2 == null) return false;
            sg_Vector3 v1 = pt2 - pt1;
            sg_Vector3 v2 = null;
            for (int i = 1; i < iCount; i++)
            {
                var pt3 = pts[i];
                if (sg_math.isZero(pt3.DistTo(pt1))
                    || sg_math.isZero(pt3.DistTo(pt2)))
                {
                    pt3 = null;
                    continue;
                }
                v2 = pt3 - pt1;
                if (!v2.isParallel(v1))
                {
                    break;
                }
                v2 = null;
            }
            if (v2 == null) return false;

            n = v1.crossMul(v2);
            // 如果与Z轴夹角大于90度 则反向
            if (n.getInterAngle(new sg_Vector3(0, 0, 1)) > 90)
            {
                n.reverse();
            }
            return true;
        }
    }
}
