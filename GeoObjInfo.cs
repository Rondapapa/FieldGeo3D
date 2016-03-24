using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerraExplorerX;

namespace FGeo3D_TE
{
    public class GeoObjInfo
    {
        //名称
        public SGWorld65 InSgWorld;

        public bool IsDrop { get; set; }

        public string Name { get; set; }
        //ID:以此链接至ProjectTree中的Object
        public string ObjectId { get; set; }
        //对象类型
        public string ObjectType { get; set; }
        //分组名
        public string GroupId { get; set; }
        //描述
        public string Description { get; set; }

#region 地质点数据
        public string PointId { get; set; }

        public bool IsGeoPointTakenFromMap { get; set; }

        public IPosition65 PointPosition { get; set; }

#endregion

#region 地质体数据
        //是否有几何实体
        public bool HasGeometry { get; set; }
        //线颜色、边界颜色
        public IColor65 LineColor { get; set; }
        //填充颜色
        public IColor65 FillColor { get; set; }
#endregion

#region 标签数据
        //是否为标签
        public bool IsLabel { get; set; }

        public string LabelText { get; set; }
        //标签样式
        public ILabelStyle65 LabelStyle { get; set; }

        public IPosition65 LabelPosition { get; set; }
#endregion

        //用户数据
        public string ClientData { get; set; }


        public GeoObjInfo(string pbHander, ref SGWorld65 sgworld)
        {
            InSgWorld = sgworld;
            IsDrop = false;
            
            switch(pbHander)
            {
              	case "GeoLabel":
                    IsLabel = true;
                    
                    LabelText = "LabelText";
                    FrmLabel frmTag = new FrmLabel();
                    if(frmTag.ShowDialog()==DialogResult.OK)
                    {
                        LabelText = frmTag.tbGeoLabel.Text;
                    }
                    else
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("标签");
                    LabelStyle = sgworld.Creator.CreateLabelStyle();
                    LabelStyle.MultilineJustification = "Center";
                    LabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    LabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    LabelStyle.TextAlignment = "Bottom, Center";
                    break;

                case "GeoPoint":
                    
                    var frmGeoPoint = new FrmGeoPoint(ref sgworld);
                    var frmDialog = frmGeoPoint.ShowDialog();
                    //frmGeoPoint.Show();

                    //选择“从地图中选取”按钮
                    if (frmDialog == DialogResult.Yes)
                    {
                        Name = frmGeoPoint.tbName.Text;
                        PointId = frmGeoPoint.tbID.Text;
                        IsGeoPointTakenFromMap = true;
                    }
                    //选择“确认坐标”按钮
                    else if (frmDialog == DialogResult.OK)
                    {
                        Name = frmGeoPoint.tbName.Text;
                        PointId = frmGeoPoint.tbID.Text;
                        var dLong = Convert.ToDouble(frmGeoPoint.tbLong.Text);
                        var dLat = Convert.ToDouble(frmGeoPoint.tbLat.Text);
                        PointPosition = sgworld.Creator.CreatePosition(dLong, dLat, 0, AltitudeTypeCode.ATC_ON_TERRAIN,
                            0, 0, 0, 0);
                    }
                    else
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("地质点");
                    break;

                case "GeoLine":
                    
                    var frmGeoLine = new FrmGeoObject(pbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmGeoLine.ShowDialog() != DialogResult.OK)
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("地质线");
                    Name = frmGeoLine.ObjName;
                    var lineColors = frmGeoLine.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(lineColors.R, lineColors.G, lineColors.B, lineColors.A);
                    FillColor = sgworld.Creator.CreateColor(lineColors.R, lineColors.G, lineColors.B, 128);
                    break;

                case "GeoRegion":
                    
                    var frmGeoRegion = new FrmGeoObject(pbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmGeoRegion.ShowDialog() != DialogResult.OK)
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("地质区域");
                    Name = frmGeoRegion.ObjName;
                    var regionColors = frmGeoRegion.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(regionColors.R, regionColors.G, regionColors.B, regionColors.A);
                    FillColor = sgworld.Creator.CreateColor(regionColors.R, regionColors.G, regionColors.B, 128);
                    break;

                case "FreehandDrawing":
                    
                    var frmGeoFreehandDrawing = new FrmGeoObject(pbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmGeoFreehandDrawing.ShowDialog() != DialogResult.OK)
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("地质线");
                    Name = frmGeoFreehandDrawing.ObjName;
                    var freehandDrawingColors = frmGeoFreehandDrawing.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(freehandDrawingColors.R, freehandDrawingColors.G, freehandDrawingColors.B, freehandDrawingColors.A);
                    FillColor = sgworld.Creator.CreateColor(freehandDrawingColors.R, freehandDrawingColors.G, freehandDrawingColors.B, 128);
                    break;
            }

        }

        private string CreateGroup(string groupName)
        {
            var gid = InSgWorld.ProjectTree.FindItem(groupName);
            if (!string.IsNullOrEmpty(gid))
            {
                return gid;
            }
            return InSgWorld.ProjectTree.CreateGroup(groupName);
        }

    }
}
