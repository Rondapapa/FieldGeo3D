using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerraExplorerX;
using System.IO;
using System.Threading;
using OSGeo.GDAL;
using DevComponents.DotNetBar;

namespace FGeo3D_TE
{
    public partial class FrmMain : Form
    {
        //工程目录
        string tProjectUrl;

        //主接口
        SGWorld66 sgworld = null;

        //地形多边形
        ITerrainPolygon66 pITPolygon = null;

        //地形多段线
        ITerrainPolyline66 pITerrainPolyline = null;
        
        //ILineString pSectionptString = null;

        //double[] arrContourMapVertices = new double[4];

        //地理地质对象管理对象-单例（还未实现）！
        private GeoObj GeoObj = new GeoObj();

        //地理地质对象信息传递对象
        private GeoObjInfo GeoObjInfo;

        //绘制多边形时用于判断isSimple的辅助线环
        ILineString tempLineString;

        //List<double> lArrPoints = new List<double>();
        //List<double> ListVerticsArray = new List<double>();
        
        //窗口上下左右位置
        public double XLeft { get; private set; }
        public double XRight { get; private set; }
        public double YTop { get; private set; }
        public double YBottom { get; private set; }
        
        //鼠标状态
        public string PbHander { get; private set; }

        //保存状态（暂时没用到）
        public bool IsSaved { get; set; }

        //手绘鼠标是否按下状态
        public bool IsFreehandDrawingMouseDown { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            Init();
        }

        //自定义构造函数
        private void Init()
        {
            sgworld = new SGWorld66();
            //sgworld.CoordServices.SourceCoordinateSystem.InitLatLong();
        }

        #region 工程
        //打开
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            // 设置工程中open 方法的参数
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D://",
                Filter = @"TE文件(*.fly)|*.fly|TB文件(*.mpt)|*.mpt|所有文件|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            tProjectUrl = openFileDialog.FileName;
            var bIsAsync = false;
            var tUser = string.Empty;
            var tPassword = string.Empty;
            //MessageBox.Show(tProjectUrl);
            sgworld = new SGWorld66();
            sgworld.Project.Open(tProjectUrl, bIsAsync, tUser, tPassword);


            sgworld.Project.set_Settings("RemoveSkylineCopyright", 1);
            sgworld.Terrain.CoordinateSystem.InitLatLong();

            XLeft = sgworld.Terrain.Left;
            XRight = sgworld.Terrain.Right;
            YTop = sgworld.Terrain.Top;
            YBottom = sgworld.Terrain.Bottom;

            Text = tProjectUrl + @" - FieldGeo3D";

            //string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);
            /*string tProjectUrl = Path.Combine("E:\\Skyline_codes\\楞古库区地质灾害信息系统-北科大\\DATA\\default.FLY");
            bool bIsAsync = false;
            string tUser = String.Empty;
            string tPassword = String.Empty;

            // 实例化 Terra Explorer Globe 使用project 接口
            try
            {
                SGWorld61 sgworld = new SGWorld61();
                sgworld.Project.Open(tProjectUrl, bIsAsync, tUser, tPassword);
            }
            catch (Exception ex)
            {
                tMsg = String.Format("OpenProjectButton_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }*/
        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                sgworld.Project.Save();
                Text = tProjectUrl + @" - FieldGeo3D";
                //MessageBox.Show(@"保存成功！");
            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Save_Click Exception: {0}", ex));
            }
        }

        //另存为
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"TE文件(*.fly)|*.fly",
                Title = @"另存为",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            //获得文件路径  
            var localFilePath = saveFileDialog.FileName;

            //获取文件名，不带路径  
            var fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            //sgworld = new SGWorld66();
            sgworld.Project.SaveAs(fileNameExt);
            //sgworld.ProjectTree.SaveAsFly(fileNameExt, gpgid);

            //string path = "C:\\Users\\lmc\\AppData\\Roaming\\Skyline\\TerraExplorer\\" + fileNameExt;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Skyline\\TerraExplorer\\" + fileNameExt;
            try
            {
                if (!File.Exists(path))
                {
                    // This statement ensures that the file is created,
                    // but the handle is not kept.
                    File.Create(path);
                }

                // Ensure that the target does not exist.
                if (File.Exists(localFilePath))
                    File.Delete(localFilePath);

                // Move the file.
                File.Move(path, localFilePath);

                //打开另存后的工程文件
                tProjectUrl = localFilePath;
                sgworld.Project.Open(tProjectUrl);
                Text = tProjectUrl + @" - FieldGeo3D";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Save_Click Exception: {0}", ex));
            }
            /*
                string sSaveName = InputSaveName();
                string s = sgworld.Project.SaveAs(sSaveName);
                MessageBox.Show(s);
                frmDir frmDir = new frmDir();
                frmDir.tbPath.Text = s;
                //System.Diagnostics.Process.Start(@"explorer %APPDATA\Skyline\TerraExplorer%");
                */
        }

        //导入
        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"该功能正在开发中……");
        }
        #endregion

        #region 绘录
        private void btnLabel_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1012, 0);
            
            try
            {
                HighlightButton(btnLabel);
                PbHander = "GeoLabel";
                GeoObjInfo = new GeoObjInfo(PbHander,ref sgworld);
                if (GeoObjInfo.IsDrop)
                {
                    ResetButton(btnLabel);
                    return;
                }
                sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("GeometryTag_Click Exception: {0}", ex.Message));
            }
        }

        private void btnGeoPoint_Click(object sender, EventArgs e)
        {
            try
            {
                HighlightButton(btnGeoPoint);
                PbHander = "GeoPoint";
                GeoObjInfo = new GeoObjInfo(PbHander, ref sgworld);
                if (GeoObjInfo.IsDrop)
                {
                    ResetButton(btnGeoPoint);
                    return;
                }
                if(GeoObjInfo.IsGeoPointTakenFromMap)
                {
                    sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                }
                else
                {
                    if (GeoObjInfo.PointPosition != null)
                    {
                        GeoPoint cGeoPoint = new GeoPoint(GeoObjInfo, ref sgworld);  	
                    }
                    ResetButton(btnGeoPoint); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("GeoPoint_Click Exception: {0}", ex.Message));
            }
        }

        private void btnGeoLine_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1012, 4);
            try
            {
                HighlightButton(btnGeoLine, true);
                PbHander = "GeoLine";
                GeoObjInfo = new GeoObjInfo(PbHander, ref sgworld);
                if (GeoObjInfo.IsDrop)
                {
                    ResetButton(btnGeoLine, true);
                    return;
                }
                sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                sgworld.OnRButtonDown += sgworld_OnRButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("GeometryPolygon_Click Exception: {0}", ex.Message));
            }
        }

        private void btnGeoRegion_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1012, 5);
            try
            {
                HighlightButton(btnGeoRegion, true);
                PbHander = "GeoRegion";
                GeoObjInfo = new GeoObjInfo(PbHander, ref sgworld);
                if (GeoObjInfo.IsDrop)
                {
                    ResetButton(btnGeoRegion, true);
                    return;
                }
                sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                sgworld.OnRButtonDown += sgworld_OnRButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("GeometryPolygon_Click Exception: {0}", ex.Message));
            }
        }

        private void btnFreehandDrawing_Click(object sender, EventArgs e)
        {
            try
            {
                HighlightButton(btnFreehandDrawing);
                PbHander = "FreehandDrawing";
                GeoObjInfo = new GeoObjInfo(PbHander, ref sgworld);
                if (GeoObjInfo.IsDrop)
                {
                    ResetButton(btnFreehandDrawing, true);
                    return;
                }
                sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                sgworld.OnLButtonUp += sgworld_OnLButtonUp;
                sgworld.OnFrame += sgworld_OnMouseMove;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("GeometryPolygon_Click Exception: {0}", ex.Message));
            }
        }


        private void btnDrawingApply_Click(object sender, EventArgs e)
        {
            Apply(PbHander);
            PbHander = "";
            IsSaved = false;
            Text = tProjectUrl + @"* - FieldGeo3D";
        }



        //Freehand Drawing - 不可用！
        //private void btnGeoLineFreehand_Click(object sender, EventArgs e)
        //{
        //    sgworld.Command.Execute(1149, 25);
        //}
        #endregion

        #region 分析
        private void btnTerrainProfile_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1043, 0);
            //string tMsg = String.Empty;
            //try
            //{
            //    pbhander = "TerrainProfile";
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            //}
            //catch (Exception ex)
            //{
            //    tMsg = String.Format("TerrainProfile_Click Exception: {0}", ex.Message);
            //    MessageBox.Show(tMsg);
            //}
        }

        private void btnContourMap_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1040, 0);
            //string tMsg = String.Empty;
            //try
            //{
            //    pbhander = "CreateContourMap";
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            //}
            //catch (Exception ex)
            //{
            //    tMsg = ex.Message;
            //    MessageBox.Show("CreateContourMap_Click Exception: {0}", tMsg);
            //}
        }

        private void btnSlope_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1092, 0);
        }

        private void btnBestPath_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1042, 0);
        }
        #endregion

        /// <summary>
        /// 定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocate_Click(object sender, EventArgs e)
        {
            var frmPosition = new FrmPosition(XLeft,XRight,YTop,YBottom);
            if (frmPosition.ShowDialog() != DialogResult.OK) return;
            var cPos = sgworld.Creator.CreatePosition(frmPosition.XLong, frmPosition.YLat, 800, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, -90, 0, 0);
            sgworld.Navigate.FlyTo(cPos);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1023, 0);
        }

        #region 测量
        private void btnAbsDistance_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1035, 0);
        }

        private void btnHorizonalDistance_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1034, 0);
        }

        private void btnVerticalDistance_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1036, 0);
        }

        private void btnPlaneArea_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1037, 0);
        }

        private void btnTerrainArea_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1166, 0);
        }
        #endregion

        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            IPosition66 p1 = sgworld.Creator.CreatePosition(412465.396283, 3264008.200115);
            IPosition66 p2 = sgworld.Creator.CreatePosition(412019.599981, 3264057.697713);
            IPosition66 p3 = sgworld.Creator.CreatePosition(412344.021811, 3263541.641142);

            IPosition66 p4 = sgworld.Creator.CreatePosition(412480.938471, 3264213.0889);
            IPosition66 p5 = sgworld.Creator.CreatePosition(412262.35476, 3263878.751618);
            IPosition66 p6 = sgworld.Creator.CreatePosition(412992.85769, 3263822.762772);

            ITerrainPolygon66 Itp1 = CreatePolygon3ps(p1, p2, p3);
            ITerrainPolygon66 Itp2 = CreatePolygon3ps(p4, p5, p6);

            bool overlaps = Itp1.Geometry.SpatialRelation.Overlaps(Itp2.Geometry);
            MessageBox.Show("overlaps: " + overlaps);

            IGeometry ig = Itp1.Geometry.SpatialOperator.Intersection(Itp2.Geometry);
            ITerrainPolygon66 itp3 = sgworld.Creator.CreatePolygon(ig);

            //MessageBox.Show(sgworld.Command.CanExecute(1149,25).ToString());
        }

        
        /// <summary>
        /// 应用绘制命令，并释放鼠标和相关全局引用
        /// </summary>
        /// <param name="pbhander"></param>
        private void Apply(string pbhander)
        {
            #region 地质标签

            //if (pbhander == "GeoLabel")
            //{
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //}

            #endregion

            #region 地质点

            //if (PbHander == "GeoPoint")
            //{
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //}

            #endregion

            #region 地质线

            if (pbhander == "GeoLine" || pbhander == "FreehandDrawing")
            {
                if(pbhander == "GeoLine")
                {
                    sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                }
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (pITerrainPolyline != null)
                {
                    GeoLine cGeoPoint = new GeoLine(pITerrainPolyline);
                }
                pITerrainPolyline = null;
                GeoObjInfo = null;

                ResetButton(btnGeoLine, true);
            }

            #endregion

            #region 地质区域

            if (pbhander == "GeoRegion")
            {
                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (pITPolygon != null)
                {
                    GeoRegion cGeoRegion = new GeoRegion(pITPolygon);
                }
                tempLineString = null;
                pITPolygon = null;
                GeoObjInfo = null;
                ResetButton(btnGeoRegion, true);
            }

            #endregion

            #region 地质体3D

            //if (pbhander == "GeoRegion3D")
            //{
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //    pIT3DPolygon = null;
            //}

            #endregion

            #region 地形剖面

            //if (pbhander == "TerrainProfile")
            //{
            //    //MessageBox.Show(pSectionptString.Points.Count.ToString());
            //    //double[,] arrPoints = new double[pSectionptString.Points.Count, 2];
            //    double[] arrPoints = new double[(pSectionptString.Points.Count - 1) * 2];

            //    int j = 0;
            //    for (int i = 1; i < pSectionptString.Points.Count; i++)
            //    {
            //        IPoint pt = pSectionptString.Points[i] as IPoint;
            //        arrPoints[j] = pt.X;
            //        arrPoints[j+1] = pt.Y;
            //        j = j + 2 ;
            //    }

            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //    pITerrainPolyline = null;
            //    sgworld.Analysis.CreateTerrainProfile(arrPoints);
            //    pSectionptString = null;
            //}

            #endregion

            #region 等高线

            //if (pbhander == "CreateContourMap")
            //{
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //    sgworld.Creator.DeleteObject(pITContourMapRectangle.ID);
            //    double upperLeftX = MinOf2(arrContourMapVertices[0], arrContourMapVertices[2]);
            //    double upperLeftY = MinOf2(arrContourMapVertices[1], arrContourMapVertices[3]);
            //    double lowerRightX = MaxOf2(arrContourMapVertices[0], arrContourMapVertices[2]);
            //    double lowerRightY = MaxOf2(arrContourMapVertices[1], arrContourMapVertices[3]);
            //    var s = sgworld.Analysis.CreateContourMap(upperLeftX, upperLeftY, lowerRightX, lowerRightY, ContourDisplayStyle.CDS_CONTOUR_STYLE_LINES_AND_COLORS, "", "", "等高线");
            //    for (int idx = 0; idx < 4; idx++)
            //    {
            //        arrContourMapVertices[idx] = 0;
            //    }
            //    pITContourMapRectangle = null;
            //}

            #endregion
        }

        /// <summary>
        /// 右键按下方法
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="X">鼠标坐标X</param>
        /// <param name="Y">鼠标坐标Y</param>
        /// <returns></returns>
        bool sgworld_OnRButtonDown(int Flags, int X, int Y)
        {
            Apply(PbHander);
            sgworld.OnRButtonDown -= sgworld_OnRButtonDown;
            PbHander = "";
            IsSaved = false;
            Text = tProjectUrl + @"* - FieldGeo3D";
            return true;
        }

        /// <summary>
        /// 左键按下方法
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="X">鼠标坐标X</param>
        /// <param name="Y">鼠标坐标Y</param>
        /// <returns></returns>
        bool sgworld_OnLButtonDown(int Flags, int X, int Y)
        {
            
            IWorldPointInfo66 pIWPInfo = sgworld.Window.PixelToWorld(X, Y, WorldPointType.WPT_TERRAIN); //真实位置信息
            IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）

            //IPosition66 r_StartPosition = null, r_LastPosition;

            #region 获取位置
            //if (PbHander == "GetPos")
            //{
            //    var cPos = pIWPInfo.Position;
            //    var frmPosition = new frmPosition
            //    {
            //        Text = @"选中位置信息如下：",
            //        btnOK = {Text = @"导航至该位置"},
            //        tbX = {Text = cPos.X.ToString()},
            //        tbY = {Text = cPos.Y.ToString()},
                    
            //    };
            //    if (frmPosition.ShowDialog() == DialogResult.OK)
            //    {
            //        var dX = double.Parse(frmPosition.tbX.Text);
            //        var dY = double.Parse(frmPosition.tbY.Text);
                    
            //        var cPosView = sgworld.Creator.CreatePosition(cPos.X, cPos.Y, 1200, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, -90, 0, 0);
            //        sgworld.Navigate.FlyTo(cPosView);
            //    }
            //    //else
            //    //{
            //    //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //    //}


            //}
            #endregion

            #region 创建地质标签
            //创建地质标签
            if (PbHander == "GeoLabel")
            {
                GeoObjInfo.LabelPosition = sgworld.Creator.CreatePosition(pIWPInfo.Position.X, pIWPInfo.Position.Y, 50, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0);

                GeoLabel cGeoLabel = new GeoLabel(GeoObjInfo, ref sgworld);

                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                ResetButton(btnLabel);

                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                Text = tProjectUrl + @"* - FieldGeo3D";
                GeoObjInfo = null;
            }
            #endregion

            #region 创建地质点
            //创建地质点
            if (PbHander == "GeoPoint")
            {
                if (GeoObjInfo != null)
                {
                    if(GeoObjInfo.PointPosition == null)
                    {
                        GeoObjInfo.PointPosition = sgworld.Creator.CreatePosition(pIWPInfo.Position.X,
                            pIWPInfo.Position.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0);
                        GeoPoint cGeoPoint = new GeoPoint(GeoObjInfo, ref sgworld);
                        sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                        sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                    }
                    ResetButton(btnGeoPoint);
                    //Thread.Sleep(500);
                    Text = tProjectUrl + @"* - FieldGeo3D";
                }
                GeoObjInfo = null;
            }
            #endregion

            #region 创建地质界线
            //创建2D地质线
            if (PbHander == "GeoLine")
            {
                if (pITerrainPolyline == null)
                {
                    var cVerticesArray = new double[] {
                        pIWPInfo.Position.X, pIWPInfo.Position.Y, pIWPInfo.Position.Distance,
                        pIWPInfo.Position.X, pIWPInfo.Position.Y, pIWPInfo.Position.Distance, };
                    var cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
                    var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                    if (GeoObjInfo != null)
                    {
                        pITerrainPolyline = sgworld.Creator.CreatePolyline(cLineString, GeoObjInfo.LineColor.ToABGRColor(), eAltitudeTypeCode, GeoObjInfo.GroupId, GeoObjInfo.Name);
                    }
                }
                else
                {
                    var cLineString = pITerrainPolyline.Geometry as ILineString;
                    pITerrainPolyline.Geometry.StartEdit();
                    var dx = pIWPInfo.Position.X;
                    var dy = pIWPInfo.Position.Y;
                    var dz = pIWPInfo.Position.Altitude;
                    
                    if (cLineString != null) cLineString.Points.AddPoint(dx, dy, dz);
                    var editedGeometry = pITerrainPolyline.Geometry.EndEdit();
                    pITerrainPolyline.Geometry = editedGeometry;

                    //MessageBox.Show(cLineString.Points.GetType().ToString());
                    //sgworld.Analysis.CreateTerrainProfile(cLineString.Points);

                }


            }
            #endregion

            #region 创建地质区域
            //创建2D地质面
            if (PbHander == "GeoRegion")
            {
                if (pITPolygon == null)
                {
                    //IGeometry cPolygonGeometry = null;
                    var cVerticesArray = new double[] {
                        pIPosition.X,  pIPosition.Y,  0, 
                        pIWPInfo.Position.X,  pIWPInfo.Position.Y,  pIWPInfo.Position.Altitude,  
                        pIWPInfo.Position.X,  pIWPInfo.Position.Y,  pIWPInfo.Position.Altitude,                         
                    };

                    tempLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
                    tempLineString.StartEdit();
                    tempLineString.Points.DeletePoint(0);
                    tempLineString.EndEdit();
                    

                    var cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);
                    //cPolygonGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cRing, null);
                    
                    var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                    if (GeoObjInfo != null)
                    {
                        pITPolygon = sgworld.Creator.CreatePolygon(cRing, GeoObjInfo.LineColor.ToABGRColor(), GeoObjInfo.FillColor.ToABGRColor(), eAltitudeTypeCode, GeoObjInfo.GroupId, GeoObjInfo.Name);
                    }

                    if (pITPolygon == null) return false;
                    var polygonGeometry = pITPolygon.Geometry as IPolygon;
                    if (polygonGeometry == null) return false;
                    polygonGeometry.StartEdit();
                    foreach (ILinearRing ring in polygonGeometry.Rings)
                    {
                        var dx = pIWPInfo.Position.X;
                        var dy = pIWPInfo.Position.Y;
                        var dh = pIWPInfo.Position.Altitude;

                        ring.Points.AddPoint(dx, dy, dh);
                        ring.Points.DeletePoint(0);
                    }
                    var editedGeometry = polygonGeometry.EndEdit();
                    pITPolygon.Geometry = editedGeometry;
                }
                else
                {
                    var polygonGeometry = pITPolygon.Geometry as IPolygon;
                    if (polygonGeometry == null) return false;
                   
                    polygonGeometry.StartEdit();
                    foreach (ILinearRing ring in polygonGeometry.Rings)
                    {
                        var dx = pIWPInfo.Position.X;
                        var dy = pIWPInfo.Position.Y;
                        var dh = pIWPInfo.Position.Altitude;
                        ring.Points.AddPoint(dx, dy, dh);
                        tempLineString.StartEdit();
                        tempLineString.Points.AddPoint(dx, dy, dh);
                        tempLineString.EndEdit();

                        if (!tempLineString.IsSimple())
                        {
                            ring.Points.DeletePoint(ring.Points.Count - 1);
                            tempLineString.Points.DeletePoint(tempLineString.Points.Count - 1);
                            MessageBox.Show(@"选取点无效：不能形成有效区域");
                        }
                    }
                    var editedGeometry = polygonGeometry.EndEdit();
                    pITPolygon.Geometry = editedGeometry;
                    //pITPolygon.set_ClientData("Test Namespace","Guess Test");
                    
                }
            }
            #endregion

            #region 手绘地质界线
            if (PbHander == "FreehandDrawing")
            {
                IsFreehandDrawingMouseDown = true;
            }
            #endregion

            #region 创建地形剖面
            //创建地形剖面
            //if (pbhander == "TerrainProfile")
            //{
            //    if (pITerrainPolyline == null)
            //    {
            //        double[] cVerticesArray = null;
            //        cVerticesArray = new double[] {
            //            pIWPInfo.Position.X,pIWPInfo.Position.Y,pIWPInfo.Position.Distance,
            //            pIWPInfo.Position.X,pIWPInfo.Position.Y,pIWPInfo.Position.Distance, };

            //        ILineString cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
            //        uint nLineColor = 0xFF00FF00;
            //        AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
            //        gpgid = CreateGroup("地质剖面线");
            //        pITerrainPolyline = sgworld.Creator.CreatePolyline(cLineString, nLineColor, eAltitudeTypeCode, gpgid, "1#剖面线");


            //    }
            //    else
            //    {
            //        pSectionptString = pITerrainPolyline.Geometry as ILineString;
            //        pITerrainPolyline.Geometry.StartEdit();
            //        double dx = pIWPInfo.Position.X;
            //        double dy = pIWPInfo.Position.Y;
            //        double dh = pIWPInfo.Position.Distance;
            //        pSectionptString.Points.AddPoint(dx, dy, dh);
            //        IGeometry editedGeometry = pITerrainPolyline.Geometry.EndEdit();
            //        pITerrainPolyline.Geometry = editedGeometry;
            //        pSectionptString = pITerrainPolyline.Geometry as ILineString;
            //    }
            //}
            #endregion

            #region 创建地质界面3D
            //if (pbhander == "GeoRegion3D")
            //{
            //    if (pIT3DPolygon == null)
            //    {
            //        ILinearRing cRing = null;
            //        //IGeometry cPolygonGeometry = null;
            //        double[] cVerticesArray = null;
            //        cVerticesArray = new double[] {
            //            pIPosition.X,  pIPosition.Y,  0, 
            //            pIWPInfo.Position.X,  pIWPInfo.Position.Y,  pIWPInfo.Position.Altitude,  
            //            pIWPInfo.Position.X,  pIWPInfo.Position.Y,  pIWPInfo.Position.Altitude,                         
            //                };
            //        cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);
            //        //cPolygonGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cRing, null);


            //        AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
            //        gpgid = CreateGroup("地质区域三维体");
            //        pIT3DPolygon = sgworld.Creator.Create3DPolygon(cRing, 200.0, objProperty.LineColor.ToABGRColor(), objProperty.FillColor.ToABGRColor(), eAltitudeTypeCode, gpgid, objProperty.Name);

            //        IPolygon polygonGeometry = pIT3DPolygon.Geometry as IPolygon;
            //        polygonGeometry.StartEdit();
            //        foreach (ILinearRing ring in polygonGeometry.Rings)
            //        {
            //            double dx = pIWPInfo.Position.X;
            //            double dy = pIWPInfo.Position.Y;
            //            double dh = pIWPInfo.Position.Altitude;

            //            ring.Points.AddPoint(dx, dy, dh);
            //            ring.Points.DeletePoint(0);
            //        }
            //        IGeometry editedGeometry = polygonGeometry.EndEdit();
            //        pIT3DPolygon.Geometry = editedGeometry;
            //    }
            //    else
            //    {
            //        IPolygon polygonGeometry = pIT3DPolygon.Geometry as IPolygon;
            //        polygonGeometry.StartEdit();
            //        foreach (ILinearRing ring in polygonGeometry.Rings)
            //        {
            //            double dx = pIWPInfo.Position.X;
            //            double dy = pIWPInfo.Position.Y;
            //            double dh = pIWPInfo.Position.Altitude;
            //            ring.Points.AddPoint(dx, dy, dh);
            //        }
            //        IGeometry editedGeometry = polygonGeometry.EndEdit();
            //        pIT3DPolygon.Geometry = editedGeometry;
            //    }
            //}
            #endregion

            #region 创建等高线
            //if (pbhander == "CreateContourMap")
            //{
            //    if (arrContourMapVertices[0] == 0)
            //    {
            //        arrContourMapVertices[0] = pIWPInfo.Position.X;
            //        arrContourMapVertices[1] = pIWPInfo.Position.Y;
            //        ILinearRing cContourMapRing = null;
            //        double[] cContourMapVerticesArray = new double[]{
            //            pIPosition.X, pIPosition.Y, 0,
            //            arrContourMapVertices[0], arrContourMapVertices[1], 0,
            //            arrContourMapVertices[0], arrContourMapVertices[1], 0,
            //        };
            //        cContourMapRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cContourMapRing);
            //        AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;

            //        pITContourMapRectangle = sgworld.Creator.CreatePolygon(cContourMapRing, -16711936, -10197936, eAltitudeTypeCode, "", "");

            //        //contourMapRecGeometry = pITContourMapRectangle.Geometry as IPolygon;
            //        /*
            //        contourMapRecGeometry.StartEdit();
            //        foreach (ILinearRing ring in contourMapRecGeometry.Rings)
            //        {
            //            double dx = arrContourMapVertices[0];
            //            double dy = arrContourMapVertices[1];
            //            double dh = pIWPInfo.Position.Altitude;
            //            ring.Points.AddPoint(dx, dy, dh);
            //            //ring.Points.DeletePoint(0);
            //        }
            //        IGeometry editedGeometry = contourMapRecGeometry.EndEdit();
            //        pITContourMapRectangle.Geometry = editedGeometry;
            //        */
            //    }
            //    else
            //    {
            //        arrContourMapVertices[2] = pIWPInfo.Position.X;
            //        arrContourMapVertices[3] = pIWPInfo.Position.Y;

            //        sgworld.Creator.DeleteObject(pITContourMapRectangle.ID);

            //        ILinearRing cContourMapRing = null;
            //        double[] cContourMapVerticesArray = new double[]{
            //            arrContourMapVertices[0], arrContourMapVertices[1], 0,
            //            arrContourMapVertices[0], arrContourMapVertices[3], 0,
            //            arrContourMapVertices[2], arrContourMapVertices[3], 0,
            //            arrContourMapVertices[2], arrContourMapVertices[1], 0,
            //        };
            //        cContourMapRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cContourMapRing);
            //        AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;

            //        pITContourMapRectangle = sgworld.Creator.CreatePolygon(cContourMapRing, -16711936, -10197936, eAltitudeTypeCode, "", "");
            //        contourMapRecGeometry = pITContourMapRectangle.Geometry as IPolygon;
            //        contourMapRecGeometry.StartEdit();
            //        ILinearRing ring = contourMapRecGeometry.ExteriorRing;
            //        ring.Points.AddPoint(arrContourMapVertices[0], arrContourMapVertices[1], 0);
            //        ring.Points.AddPoint(arrContourMapVertices[0], arrContourMapVertices[3], 0);
            //        ring.Points.AddPoint(arrContourMapVertices[2], arrContourMapVertices[3], 0);
            //        ring.Points.AddPoint(arrContourMapVertices[2], arrContourMapVertices[1], 0);
            //        IGeometry editedGeometry = contourMapRecGeometry.EndEdit();
            //        pITContourMapRectangle.Geometry = editedGeometry;
            //        /*
            //        contourMapRecGeometry = pITContourMapRectangle.Geometry as IPolygon;
            //        contourMapRecGeometry.StartEdit();
            //        ILinearRing ring = contourMapRecGeometry.ExteriorRing;
            //        double dx = arrContourMapVertices[2];
            //        double dy = arrContourMapVertices[3];
            //        double dh = pIWPInfo.Position.Altitude;
            //        ring.Points.AddPoint(arrContourMapVertices[0], arrContourMapVertices[1], dh);
            //        ring.Points.AddPoint(dx, arrContourMapVertices[1], dh);
            //        ring.Points.AddPoint(dx, dy, dh);
            //        ring.Points.AddPoint(arrContourMapVertices[0], dy, dh);
            //        IGeometry editedGeometry = contourMapRecGeometry.EndEdit();
            //        pITContourMapRectangle.Geometry = editedGeometry;
            //        */
            //    }

            //}
            #endregion

            return false;
        }

        /// <summary>
        /// 左键松开方法
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        bool sgworld_OnLButtonUp(int Flags, int X, int Y)
        {
            if (PbHander == "FreehandDrawing")
            {
                IsFreehandDrawingMouseDown = false;
            }
            sgworld.OnFrame -= sgworld_OnMouseMove;
            sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
            sgworld.OnLButtonUp -= sgworld_OnLButtonUp;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            
            if (pITerrainPolyline != null)
            {
                GeoLine cGeoPoint = new GeoLine(pITerrainPolyline);
            }
            pITerrainPolyline = null;
            GeoObjInfo = null;
            ResetButton(btnFreehandDrawing);

            PbHander = "";
            IsSaved = false;
            Text = tProjectUrl + @"* - FieldGeo3D";

            return true;
        }

        /// <summary>
        /// 鼠标移动方法，用于挂接OnFrame事件
        /// </summary>
        void sgworld_OnMouseMove()
        {
          	if(PbHander == "FreehandDrawing" && IsFreehandDrawingMouseDown)
            {
                //手绘代码
                IMouseInfo66 mouseInfo = sgworld.Window.GetMouseInfo();
                IWorldPointInfo66 pIWPInfo = sgworld.Window.PixelToWorld(mouseInfo.X, mouseInfo.Y, WorldPointType.WPT_TERRAIN); //真实位置信息
                IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）

                if (pITerrainPolyline == null)
                {
                    var cVerticesArray = new double[] {
                        pIWPInfo.Position.X, pIWPInfo.Position.Y, pIWPInfo.Position.Distance,
                        pIWPInfo.Position.X, pIWPInfo.Position.Y, pIWPInfo.Position.Distance, };
                    var cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
                    var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                    if (GeoObjInfo != null)
                    {
                        pITerrainPolyline = sgworld.Creator.CreatePolyline(cLineString, GeoObjInfo.LineColor.ToABGRColor(), eAltitudeTypeCode, GeoObjInfo.GroupId, GeoObjInfo.Name);
                    }
                }
                else
                {
                    var cLineString = pITerrainPolyline.Geometry as ILineString;
                    pITerrainPolyline.Geometry.StartEdit();
                    var dx = pIWPInfo.Position.X;
                    var dy = pIWPInfo.Position.Y;
                    var dz = pIWPInfo.Position.Altitude;

                    if (cLineString != null) cLineString.Points.AddPoint(dx, dy, dz);
                    var editedGeometry = pITerrainPolyline.Geometry.EndEdit();
                    pITerrainPolyline.Geometry = editedGeometry;
                }
            }
        }

        #region 其他方法

        /*
        private IPosition66 InputPosition()
        {
            IPosition66 retPos = null;
            var frmLocation = new frmPosition();
            if (frmLocation.ShowDialog() != DialogResult.OK) return retPos;
            var dX = double.Parse(frmLocation.tbX.Text);
            var dY = double.Parse(frmLocation.tbY.Text);

            retPos = sgworld.Creator.CreatePosition(dX, dY, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, -90, 0, 0);
            return retPos;
        }
        */

        /// <summary>
        /// 高亮按钮
        /// </summary>
        /// <param name="btn">按钮控件</param>
        /// <param name="isBtnDrawingApplyUsed">是否关联“应用更改”按钮</param>
        private void HighlightButton(ButtonItem btn, bool isBtnDrawingApplyUsed = false)
        {
            btn.FontBold = true;
            btn.ForeColor = Color.Red;
            btn.Checked = true;
            if (isBtnDrawingApplyUsed)
            {
                btnDrawingApply.FontBold = true;
                btnDrawingApply.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// 复位按钮
        /// </summary>
        /// <param name="btn">按钮控件</param>
        /// <param name="isBtnDrawingApplyUsed">是否关联“应用更改”按钮</param>
        private void ResetButton(ButtonItem btn, bool isBtnDrawingApplyUsed = false)
        {
            btn.FontBold = false;
            btn.ForeColor = Color.Black;
            btn.Checked = false;
            if(isBtnDrawingApplyUsed)
            {
                btnDrawingApply.FontBold = false;
                btnDrawingApply.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 三点成面
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private ITerrainPolygon66 CreatePolygon3ps(IPosition66 p0, IPosition66 p1, IPosition66 p2)
        {
            double[] cVerticesArray = new double[] {
                p0.X, p0.Y, p0.Altitude,
                p1.X, p1.Y, p1.Altitude,
                p2.X, p2.Y, p2.Altitude,
            };
            ILinearRing cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);
            IGeometry cPolygonGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cRing, null);
            uint nLineColor = 0xFF00FF00; // Abgr value -> solid green
            uint nFillColor = 0x7FFF0000; // Abgr value -> 50% transparent blue
            //AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_TERRAIN_RELATIVE;
            AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
            ITerrainPolygon66 retPolygon = sgworld.Creator.CreatePolygon(cPolygonGeometry, nLineColor, nFillColor, eAltitudeTypeCode, "", "test3ps");


            return retPolygon;
        }

        #endregion




    }
}
