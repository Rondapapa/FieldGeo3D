using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    public enum GeometryType
    {
        Point, Line, Plane, Surface
    }

    class GeoObject:IComparable
    {
        public string Id { get; set; }
        public GeometryType Type { get; set; }
        public string Name { get; set; }
        

        
        /// <summary>
        /// 在三维场景中绘制该对象
        /// </summary>
        public virtual void Draw(ref SGWorld66 sgworld) { }


        /// <summary>
        /// 在三维场景中移除该对象
        /// </summary>
        public virtual void Erase(ref SGWorld66 sgworld) { }


        /// <summary>
        /// 在数据库中查询该对象的详细地质信息
        /// </summary>
        public virtual void Detail() { }


        /// <summary>
        /// 将该对象存入数据库
        /// </summary>
        public virtual void Store() { }

        public int CompareTo(object obj)
        {

            throw new NotImplementedException();
        }
    }
}
