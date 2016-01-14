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
        //名称
        public string Name { get; set; }
        //ID:以此链接至ProjectTree中的Object
        public string ObjectID { get; set; }
        //对象类型
        public string ObjectType { get; set; }
        //分组名
        public string GroupID { get; set; }
        //描述
        public string Description { get; set; }

        //是否为地质点
        public bool IsGeoPoint { get; set; }

        public ITerrainSphere65 GeoPointGeometry { get; set; }

        //是否有几何实体
        public bool HasGeometry { get; set; }
        //对象实例引用
        public IGeometry ObjGeometry{ get; set; }
        //线颜色、边界颜色
        public IColor65 LineColor { get; set; }
        //填充颜色
        public IColor65 FillColor { get; set; }



        //是否为标签
        public bool IsLabel { get; set; }
        //标签实体
        public ITerrainLabel65 GeoLabel { get; set; }
        //标签样式
        public ILabelStyle65 LabelStyle { get; set; }


        //用户数据
        public string ClientData { get; set; }


        public GeoObject(string pbhander)
        {
            ObjectType = pbhander;
            Name = "未命名地质对象";
            if(pbhander == "GeoTag" || pbhander == "GeoPoint")
            {
                HasGeometry = false;
            }
            else
            {
                HasGeometry = true;
            }


            if(pbhander=="GeoPoint")
            {
                IsGeoPoint = true;
            }

            if(pbhander=="GeoTag")
            {
                IsLabel = true;
            }
        }

        
    }
}
