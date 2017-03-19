using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D.GeoCurvedSurface
{
    using DevComponents.DotNetBar;

    using FGeo3D.GeoObj;
    using FGeo3D.GoCAD;
    using FGeo3D.LoggingObj;

    using GeoIM.CHIDI.DZ.COM;

    using MathNet.Spatial.Euclidean;

    using TerraExplorerX;

    using Plane = System.Numerics.Plane;

    public partial class FrmCurvedSurfaceBuilder : Form
    {
        //地质对象信息字典
        private Dictionary<string, LoggingObject> loggingObjectsDict;

        //选定的地质对象信息列表
        private HashSet<LoggingObject> selectedObjsSet = new HashSet<LoggingObject>();
        
        //Marker列表
        private HashSet<string> markerSet = new HashSet<string>();

        //UseFor列表
        private HashSet<string> useforSet = new HashSet<string>();

        //目标marker点集！！！！！
        private List<Point> targetMarkersList;

        private YWCHEntEx db;
        private SGWorld66 sgworld;
        
        /// <summary>
        /// 影响半径
        /// </summary>
        public double ShapeRadium { get; private set; }

        /// <summary>
        /// 网格长度
        /// </summary>
        public double GridEdgeLength { get; private set; }

        /// <summary>
        /// 产状半径
        /// </summary>
        public double AttitudeLength { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCurvedSurfaceBuilder"/> class.
        /// </summary>
        /// <param name="objsDict">
        /// The objs dict.
        /// </param>
        /// <param name="sgworld">
        /// The sgworld.
        /// </param>
        public FrmCurvedSurfaceBuilder(Dictionary<string, LoggingObject> objsDict, ref SGWorld66 sgworld, ref YWCHEntEx db)
        {
            this.InitializeComponent();
            this.loggingObjectsDict = objsDict;

            foreach (var kvLoggingObj in this.loggingObjectsDict)
            {
                this.listBoxAdvGeoObjs.Items.Add(kvLoggingObj.Value.Name);
            }
            this.sgworld = sgworld;
            CurveAlgorithm.sgworld = sgworld;
            this.db = db;
        }


        private void buttonXSave_Click(object sender, EventArgs e)
        {

        }


        private void listBoxAdvGeoObjs_ItemCheck(object sender, DevComponents.DotNetBar.ListBoxAdvItemCheckEventArgs e)
        {
            this.selectedObjsSet.Clear();
            foreach (var item in this.listBoxAdvGeoObjs.CheckedItems)
            {
                var loggingObj = this.GetLoggingObjectByName(item.Text);
                if (!this.selectedObjsSet.Contains(loggingObj) && loggingObj != null)
                {
                    this.selectedObjsSet.Add(loggingObj);
                }
            }

            //显示Marker类型的列表框
            this.markerSet.Clear();
            foreach (var item in this.selectedObjsSet)
            {
                var markerTypeList = item.GetMarkerTypeList();
                foreach (var markerType in markerTypeList)
                {
                    this.markerSet.Add(markerType);
                }
            }

            listBoxAdvMarkerType.Items.Clear();
            foreach (var markerType in this.markerSet)
            {
                this.listBoxAdvMarkerType.Items.Add(markerType);
            }

            if (this.useforSet.Count > 0)
            {
                this.useforSet.Clear();
                this.listBoxAdvUseFor.Items.Clear();
            }
  
        }


        private LoggingObject GetLoggingObjectByName(string name)
        {
            foreach (var kvLoggingObj in this.loggingObjectsDict)
            {
                if (name == kvLoggingObj.Value.Name)
                    return kvLoggingObj.Value;
            }
            return null;
        }


        private void buttonXGeoObjAllSel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBoxAdvGeoObjs.Items.Count; ++i)
            {
                this.listBoxAdvGeoObjs.SetItemCheckState(i, CheckState.Checked);
            }
            
        }

        private void buttonXGeoObjAllDesel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBoxAdvGeoObjs.Items.Count; ++i)
            {
                this.listBoxAdvGeoObjs.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAdvMarkerType_ItemClick(object sender, EventArgs e)
        {
            var selectedMarkerType = this.listBoxAdvMarkerType.SelectedItems[0].Text;

            this.useforSet.Clear();
            foreach (var selectedObj in this.selectedObjsSet)
            {
                var useForSet = selectedObj.GetUseForSetByMarkerType(selectedMarkerType);
                foreach (var usefor in useForSet)
                {
                    this.useforSet.Add(usefor);
                }
                
            }

            this.listBoxAdvUseFor.Items.Clear();
            foreach (var usefor in this.useforSet)
            {
                this.listBoxAdvUseFor.Items.Add(usefor);
            }
            

        }


        private void listBoxAdvMarkerType_ItemRemoved(object sender, DevComponents.DotNetBar.ItemRemovedEventArgs e)
        {
            if (listBoxAdvMarkerType.SelectedItems.Count > 0)
            {
                var selectedMarkerType = this.listBoxAdvMarkerType.SelectedItems[0].Text;

                this.useforSet.Clear();
                foreach (var selectedObj in this.selectedObjsSet)
                {
                    var useForSet = selectedObj.GetUseForSetByMarkerType(selectedMarkerType);
                    foreach (var usefor in useForSet)
                    {
                        this.useforSet.Add(usefor);
                    }

                }
            }

            this.listBoxAdvUseFor.Items.Clear();
            foreach (var usefor in this.useforSet)
            {
                this.listBoxAdvUseFor.Items.Add(usefor);
            }
        }


        private void listBoxAdvUseFor_ItemClick(object sender, EventArgs e)
        {
            var selectedMarkerType = this.listBoxAdvMarkerType.SelectedItems[0].Text;
            var selectedUseFor = this.listBoxAdvUseFor.SelectedItems[0].Text;
            this.targetMarkersList = Extractor.GetPointListOf(this.selectedObjsSet, selectedMarkerType, selectedUseFor);
            this.textBoxXCPCount.Text = this.targetMarkersList.Count.ToString();
        }

        /// <summary>
        /// 计算 AttitudeLength 和 ShapeRadium
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXCalculate_Click(object sender, EventArgs e)
        {
            double meanDist = CurveAlgorithm.MeanDistanceOfPoints(this.targetMarkersList);
            this.doubleInputAttitudeLength.Value = meanDist;
            this.doubleInputShapeRadium.Value = meanDist;
        }


        /// <summary>
        /// 生成曲面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXBuild_Click(object sender, EventArgs e)
        {
            double attitudeL = this.doubleInputAttitudeLength.Value;
            double shapeR = this.doubleInputShapeRadium.Value;
            
            // 生成产状数据集
            double nx = 0.0, ny = 0.0, nz = 0.0;
            List<Point> sourceAttitudePoints = new List<Point>(this.targetMarkersList.Count * 4);
            foreach (var marker in this.targetMarkersList)
            {
                nx += Math.Sin(marker.MyDip * Math.PI / 180) * Math.Sin(marker.MyAngle * Math.PI / 180)
                      / this.targetMarkersList.Count;
                ny += Math.Cos(marker.MyDip * Math.PI / 180) * Math.Sin(marker.MyAngle * Math.PI / 180)
                      / this.targetMarkersList.Count;
                nz += Math.Cos(marker.MyAngle * Math.PI / 180) / this.targetMarkersList.Count;


                double dx = -Math.Tan(marker.MyAngle * Math.PI / 180) * Math.Cos(marker.MyDip * Math.PI / 180);
                double dy = -Math.Tan(marker.MyAngle * Math.PI / 180) * Math.Sin(marker.MyDip * Math.PI / 180);
                Point northPoint = new Point(
                    marker.X,
                    marker.Y + attitudeL,
                    marker.Z + dy * attitudeL);
                Point southPoint = new Point(
                    marker.X,
                    marker.Y - attitudeL,
                    marker.Z - dy * attitudeL);
                Point eastPoint = new Point(
                    marker.X + attitudeL,
                    marker.Y,
                    marker.Z + dx * attitudeL);
                Point westPoint = new Point(
                    marker.X - attitudeL,
                    marker.Y,
                    marker.Z - dx * attitudeL);

                sourceAttitudePoints.AddRange(new[] { northPoint, southPoint, eastPoint, westPoint });
            }

            Point middlePoint = CurveAlgorithm.MiddlePointOfPoints(this.targetMarkersList);
            
            // 平均产状平面
            Vector3D n = new Vector3D(nx, ny, nz);
            var plane = new MathNet.Spatial.Euclidean.Plane(
                new Point3D(middlePoint.X, middlePoint.Y, middlePoint.Z),
                n.Normalize());

            double a0 = -plane.D / plane.C;
            double a1 = -plane.A / plane.C;
            double a2 = -plane.B / plane.C;

            // 插值点数据集
            List<Point> sourcePoints = new List<Point>(this.targetMarkersList);
            sourcePoints.AddRange(sourceAttitudePoints);
            
            SurfaceEquation surfaceEquation = new SurfaceEquation(a0, a1, a2, sourcePoints, shapeR);

            // 确定曲面区域
            List<Point> edgePoints = CurveAlgorithm.GetEdgePoints(sourcePoints, this.GridEdgeLength);

            // 区域内插加密点 GeoHelper.InsertPointsInPolygon
            List<Point> pointsList = GeoHelper.InsertPointsInPolygon(edgePoints, this.GridEdgeLength);

            // 生成网格 Triangulations
            Triangulations tris = new Triangulations(pointsList, new List<Point>());

            // 计算插值 SurfaceMesh
            tris.MeshSurface(surfaceEquation);

            // 绘制曲面 
            IColor66 fillColor = this.sgworld.Creator.CreateColor(128, 128, 128, 128);




            IColor66 lineColor = this.sgworld.Creator.CreateColor(255, 255, 255, 0);

            var parentGid = GeoHelper.CreateGroup("产状地质曲面", ref this.sgworld);

            

            Facet facet = new Facet(ref this.sgworld, tris.TsData, "Test", parentGid, lineColor, fillColor);
             facet.DrawFacet();
            // 保存三角网结果
            TsFile ts = new TsFile(
                tris.TsData,
                "TSurf",
                "M",
                "JGM",
                "Name",
                new List<string>());
            ts.WriteTsFile();
            ts.UpdateTsFile(ref this.db);

            ToastNotification.Show(this, "曲面模型已保存为模型部件", 2500, eToastPosition.MiddleCenter);
        }

        private void doubleInputAttitudeLength_ValueChanged(object sender, EventArgs e)
        {
            this.AttitudeLength = this.doubleInputAttitudeLength.Value;
        }

        private void doubleInputShapeRadium_ValueChanged(object sender, EventArgs e)
        {
            this.ShapeRadium = this.doubleInputShapeRadium.Value;
        }

        private void doubleInputGridEdgeLength_ValueChanged(object sender, EventArgs e)
        {
            this.GridEdgeLength = this.doubleInputGridEdgeLength.Value;
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
