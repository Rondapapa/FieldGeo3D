using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FGeo3D_TE.Frm;
using TerraExplorerX;

namespace FGeo3D_TE.DrawingObjs
{
    //绘制编录信息传递类
    public class DrawingObjectInfo
    {
        //
        public SGWorld66 InSgWorld;

        //是否为废弃信息
        public bool IsDrop { get; set; }

        //名称
        public string Name { get; set; }

        //ID:以此链接至ProjectTree中的Object
        public string ObjectId { get; set; }

        //对象类型
        public string ObjectType { get; set; }

        //地质对象类型(崩塌、滑坡、泥石流、结构面等)
        public string MarkerType { get; set; }

        //分组名
        public string GroupId { get; set; }

        //描述
        public string Description { get; set; }

        //关联关系列表
        public List<string> ConnObjGuids = new List<string>();

        #region 地质点数据
        public string PointId { get; set; }

        public bool IsPointTakenFromMap { get; set; }

        public IPosition66 PointPosition { get; set; }

#endregion

#region 地质体数据
        //是否有几何实体
        public bool HasGeometry { get; set; }
        //线颜色、边界颜色
        public IColor66 LineColor { get; set; }
        //填充颜色
        public IColor66 FillColor { get; set; }
#endregion

#region 标签数据
        //是否为标签
        public bool IsLabel { get; set; }

        public string LabelText { get; set; }
        //标签样式
        public ILabelStyle66 LabelStyle { get; set; }

        public IPosition66 LabelPosition { get; set; }
#endregion

        //用户数据
        public string ClientData { get; set; }

        public FrmMain FrmMain { get; set; }

        public DrawingObjectInfo(string pbHander, FrmMain frmmain, ref SGWorld66 sgworld)
            : this(pbHander, ref sgworld)
        {
            FrmMain = frmmain;
        }

        public DrawingObjectInfo(string pbHander, ref SGWorld66 sgworld)
        {
            InSgWorld = sgworld;
            IsDrop = false;
            
            switch(pbHander)
            {
              	case "Label":
                    IsLabel = true;
                    
                    LabelText = "LabelText";
                    FrmPlaneViaLine frmTag = new FrmPlaneViaLine();
                    if(frmTag.ShowDialog() == DialogResult.OK)
                    {
                        LabelText = frmTag.textBoxDepth.Text;
                    }
                    else
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("标签","");
                    LabelStyle = sgworld.Creator.CreateLabelStyle();
                    LabelStyle.MultilineJustification = "Center";
                    LabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    LabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    LabelStyle.TextAlignment = "Bottom, Center";
                    break;

                case "Point":
                    
                    var frmPoint = new FrmPoint(ref sgworld);
                    
                    var frmDialog = frmPoint.ShowDialog();
                    //frmGeoPoint.Show();

                    //选择“从地图中选取”按钮
                    switch (frmDialog)
                    {
                        case DialogResult.Yes:
                            Name = frmPoint.tbName.Text;
                            PointId = frmPoint.tbID.Text;
                            IsPointTakenFromMap = true;
                            break;
                        case DialogResult.OK:
                            Name = frmPoint.tbName.Text;
                            PointId = frmPoint.tbID.Text;
                            var dLong = Convert.ToDouble(frmPoint.tbLong.Text);
                            var dLat = Convert.ToDouble(frmPoint.tbLat.Text);
                            PointPosition = sgworld.Creator.CreatePosition(dLong, dLat, 0, AltitudeTypeCode.ATC_ON_TERRAIN,
                                0, 0, 0, 0);
                            break;
                        default:
                            IsDrop = true;
                            return;
                    }
                    GroupId = CreateGroup("点", "废");
                    break;

                case "Line":
                case "LineNew":
                    var frmLineNew = new FrmObject(pbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmLineNew.ShowDialog() != DialogResult.OK)
                    {
                        IsDrop = true;
                        return;
                    }
                    MarkerType = frmLineNew.SelectedMarkerType;
                    GroupId = CreateGroup(MarkerType, sgworld.ProjectTree.FindItem("线"));
                    sgworld.ProjectTree.ExpandGroup(GroupId, true);
                    Name = frmLineNew.ObjName;
                    var lineNewColors = frmLineNew.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(lineNewColors.R, lineNewColors.G, lineNewColors.B, lineNewColors.A);
                    FillColor = sgworld.Creator.CreateColor(lineNewColors.R, lineNewColors.G, lineNewColors.B, 128);
                    break;

                case "Region":
                case "RegionNew":
                    var frmRegion = new FrmObject(pbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmRegion.ShowDialog() != DialogResult.OK)
                    {
                        IsDrop = true;
                        return;
                    }
                    MarkerType = frmRegion.SelectedMarkerType;
                    GroupId = CreateGroup(MarkerType, sgworld.ProjectTree.FindItem("面"));
                    sgworld.ProjectTree.ExpandGroup(GroupId, true);
                    Name = frmRegion.ObjName;
                    var regionColors = frmRegion.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(regionColors.R, regionColors.G, regionColors.B, regionColors.A);
                    FillColor = sgworld.Creator.CreateColor(regionColors.R, regionColors.G, regionColors.B, 128);
                    break;

                case "FreehandDrawing":
                    
                    var frmFreehandDrawing = new FrmObject(pbHander);
                    //若不指定边界颜色，则默认为黑色
                    LineColor = sgworld.Creator.CreateColor(255, 255, 255, 255);
                    //若不指定填充颜色，则默认为半透明蓝色
                    FillColor = sgworld.Creator.CreateColor(0, 0, 255, 128);
                    if (frmFreehandDrawing.ShowDialog() != DialogResult.OK)
                    {
                        IsDrop = true;
                        return;
                    }
                    GroupId = CreateGroup("手绘线", "");
                    Name = frmFreehandDrawing.ObjName;
                    var freehandDrawingColors = frmFreehandDrawing.SelectedColor;
                    LineColor = sgworld.Creator.CreateColor(freehandDrawingColors.R, freehandDrawingColors.G, freehandDrawingColors.B, freehandDrawingColors.A);
                    FillColor = sgworld.Creator.CreateColor(freehandDrawingColors.R, freehandDrawingColors.G, freehandDrawingColors.B, 128);
                    break;
            }

        }

        private string CreateGroup(string groupName, string parentGroupId)
        {
            var gid = InSgWorld.ProjectTree.FindItem(parentGroupId + "\\" + groupName);
            if (!string.IsNullOrEmpty(gid))
            {
                return gid;
            }
            
            return InSgWorld.ProjectTree.CreateGroup(groupName, parentGroupId);
        }

    }
}
