using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DevComponents.DotNetBar.Rendering;
using TerraExplorerX;

namespace FGeo3D_TE
{
    public class GeoObject
    {
        //ID:以此链接至ProjectTree中的Object
        public string ObjectID { get; set; }
        //对象实例引用
        public IGeometry ObjGeometry{ get; set; }
        //名称
        public string Name { get; set; }
        //对象类型
        public string ObjectType { get; set; }
        //线颜色、边界颜色
        public IColor65 LineColor { get; set; }
        //填充颜色
        public IColor65 FillColor { get; set; }
        //分组名
        public string GroupID { get; set; }
        //描述
        public string Description { get; set; }
        //用户数据
        public string ClientData { get; set; }

        public GeoObject(string pbhander)
        {
            ObjectType = pbhander;
            Name = "未命名地质对象";
        }

        
    }
}
