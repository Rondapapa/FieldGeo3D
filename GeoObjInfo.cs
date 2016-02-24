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
        public SGWorld65 inSGWorld;

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


        public GeoObjInfo(string PbHander, ref SGWorld65 sgworld)
        {
            inSGWorld = sgworld;
            switch(PbHander)
            {
              	case "GeoLabel":
                    IsLabel = true;
                    GroupId = CreateGroup("标签");
                    LabelText = "LabelText";
                    FrmLabel frmTag = new FrmLabel();
                    if(frmTag.ShowDialog()==DialogResult.OK)
                    {
                        LabelText = frmTag.tbGeoLabel.Text;
                    }
                    LabelStyle = sgworld.Creator.CreateLabelStyle();
                    LabelStyle.MultilineJustification = "Center";
                    LabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    LabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    LabelStyle.TextAlignment = "Bottom, Center";
                    break;

                case "GeoPoint":
                    GroupId = CreateGroup("地质点");
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
                    break;

                case "GeoLine":
                    GroupId = CreateGroup("地质线");
                    var frmGeoObject1 = new FrmGeoObject(PbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmGeoObject1.ShowDialog() != DialogResult.OK) return;
                    Name = frmGeoObject1.ObjName;
                    var theColor1 = frmGeoObject1.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(theColor1.R, theColor1.G, theColor1.B, theColor1.A);
                    FillColor = sgworld.Creator.CreateColor(theColor1.R, theColor1.G, theColor1.B, 128);
                    break;

                case "GeoRegion":
                    GroupId = CreateGroup("地质区域");
                    var frmGeoObject2 = new FrmGeoObject(PbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmGeoObject2.ShowDialog() != DialogResult.OK) return;
                    Name = frmGeoObject2.ObjName;
                    var theColor2 = frmGeoObject2.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(theColor2.R, theColor2.G, theColor2.B, theColor2.A);
                    FillColor = sgworld.Creator.CreateColor(theColor2.R, theColor2.G, theColor2.B, 128);
                    break;
            }

        }

        private string CreateGroup(string groupName)
        {
            var gid = inSGWorld.ProjectTree.FindItem(groupName);
            if (!string.IsNullOrEmpty(gid))
            {
                return gid;
            }
            return inSGWorld.ProjectTree.CreateGroup(groupName);
        }

    }
}
