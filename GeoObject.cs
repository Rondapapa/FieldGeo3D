using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
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

        public bool IsGeoPointTakenFromMap { get; set; }

        public IPosition65 GeoPointPos { get; set; }

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


        public GeoObject(string pbhander, ref SGWorld65 sgworld)
        {
            ObjectType = pbhander;
            Name = "未命名地质对象";
            
            switch (pbhander)
            {
                case "GeoPoint":
                    IsGeoPoint = true; 
                    var frmGeoPoint = new FrmGeoPoint();
                
                    //选择“从地图中选取”按钮
                    if(frmGeoPoint.ShowDialog() == DialogResult.Yes)
                    {
                        Name = frmGeoPoint.tbName.Text;
                        ObjectID = frmGeoPoint.tbID.Text;
                        IsGeoPointTakenFromMap = true;
                    }
                    //选择“确认坐标”按钮
                    else if(frmGeoPoint.ShowDialog() == DialogResult.OK)
                    {
                        Name = frmGeoPoint.tbName.Text;
                        ObjectID = frmGeoPoint.tbID.Text;
                        var dLong = Convert.ToDouble(frmGeoPoint.tbLong.Text);
                        var dLat = Convert.ToDouble(frmGeoPoint.tbLat.Text);
                        GeoPointPos = sgworld.Creator.CreatePosition(dLong, dLat, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0);
                    }
                    break;

                case "GeoTag":
                    IsLabel = true;
                    var frmTag = new FrmTag();
                    if (frmTag.ShowDialog() == DialogResult.OK)
                    {
                        Name = frmTag.tbGeoTag.Text;
                    }
                    LabelStyle = sgworld.Creator.CreateLabelStyle();
                    LabelStyle.MultilineJustification = "Center";
                    LabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    LabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    LabelStyle.TextAlignment = "Bottom, Center";
                    break;

                default:
                    HasGeometry = true;
                    var frmGeoObject = new FrmGeoObject(pbhander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmGeoObject.ShowDialog() != DialogResult.OK) return;
                    Name = frmGeoObject.ObjName;
                    var color = frmGeoObject.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(color.R, color.G, color.B, color.A);
                    FillColor = sgworld.Creator.CreateColor(color.R, color.G, color.B, 128);
                    break;
            }
        }




        
    }
}
