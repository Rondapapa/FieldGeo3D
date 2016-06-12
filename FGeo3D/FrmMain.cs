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
        private string _tProjectUrl;

        //主接口
        SGWorld66 sgworld = null;
        
        //地形多边形
        ITerrainPolygon66 _pItPolygon = null;

        //地形多段线
        ITerrainPolyline66 _pITerrainPolyline = null;
        
        //ILineString pSectionptString = null;

        //double[] arrContourMapVertices = new double[4];

        //地理地质对象管理对象-单例（还未实现）！
        private DrawingObject DrawingObj = new DrawingObject();
        private LoggingObject LoggingObj = new LoggingObject();

        //地理地质对象信息传递对象
        private DrawingObjectInfo _objInfo;

        //绘制多边形时用于判断isSimple的辅助线环
        ILineString _tempLineString;

        //当前选取对象、及其监控事件
        private IWorldPointInfo66 _cWorldPointInfo;

        /*
        public delegate void CurrrentWorldPointInfoChange(object sender, EventArgs e);
        public event CurrrentWorldPointInfoChange OnCurrentWorldPointInfoChange;
        private void WhenCurrentWorldPointInfoChange()
        {
            OnCurrentWorldPointInfoChange?.Invoke(this, null);
        }
        public IWorldPointInfo66 CurrentWorldPointInfo
        {
            get
            {
                return _cWorldPointInfo;
            }
            set
            {
                if (value != null && _cWorldPointInfo != value)
                    WhenCurrentWorldPointInfoChange();
                _cWorldPointInfo = value;
            }
        }

        public void OnCurrentWPIChange_GetPos(object sender, EventArgs e)
        {
            //x,y值信息存储在_cWorldPointInfo.Position中

            OnCurrentWorldPointInfoChange -= OnCurrentWPIChange_GetPos;
        }

        public void OnCurrentWPIChange_QueryDetail(object sender, EventArgs e)
        {
            var loggingObj = LoggingObject.LoggingObjects[_cWorldPointInfo.ObjectID] as LoggingObject;
            loggingObj?.QueryDetail();
            MessageBox.Show($"X:{_cWorldPointInfo.Position.X};Y:{_cWorldPointInfo.Position.Y}");
            OnCurrentWorldPointInfoChange -= OnCurrentWPIChange_QueryDetail;
        }
        */


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
        }

        #region 工程
        //打开
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //打开工程
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D://",
                Filter = @"TE文件(*.fly)|*.fly|TB文件(*.mpt)|*.mpt|所有文件|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            _tProjectUrl = openFileDialog.FileName;
            var bIsAsync = false;
            var tUser = string.Empty;
            var tPassword = string.Empty;
            
            sgworld.Project.Open(_tProjectUrl, bIsAsync, tUser, tPassword);

            //隐藏Skyline商标
            sgworld.Project.set_Settings("RemoveSkylineCopyright", 1);
            sgworld.Terrain.CoordinateSystem.InitLatLong();
            //初始化地形边界
            XLeft = sgworld.Terrain.Left;
            XRight = sgworld.Terrain.Right;
            YTop = sgworld.Terrain.Top;
            YBottom = sgworld.Terrain.Bottom;
            //设置窗体标题
            Text = _tProjectUrl + @" - FieldGeo3D";
        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!_tProjectUrl.EndsWith(".fly"))
                {
                    MessageBox.Show(@"要保存变更，需以.fly格式打开项目");
                    return;
                }
                sgworld.Project.Save();
                Text = _tProjectUrl + @" - FieldGeo3D";
                //MessageBox.Show(@"保存成功！");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Save_Click Exception: {ex}");
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
                _tProjectUrl = localFilePath;
                sgworld.Project.Open(_tProjectUrl);
                Text = _tProjectUrl + @" - FieldGeo3D";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save_Click Exception: {ex}");
            }
            
        }

        //连接数据库
        private void btnConnectDB_Click(object sender, EventArgs e)
        {

        }

        //导入
        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"该功能正在开发中……");
        }
        #endregion

        #region 编录
        private void btnBore_Click(object sender, EventArgs e)
        {

        }

        private void btnFootrill_Click(object sender, EventArgs e)
        {

        }

        private void btnPit_Click(object sender, EventArgs e)
        {

        }

        private void btnWell_Click(object sender, EventArgs e)
        {

        }

        private void btnTrench_Click(object sender, EventArgs e)
        {

        }

        private void btnGeoPoint_Click(object sender, EventArgs e)
        {

        }

        private void btnPhotoRecognition_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 绘图

        //private void btnLabel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HighlightButton(btnLabel);
        //        PbHander = "Label";
        //        _objInfo = new ObjectInfo(PbHander,ref sgworld);
        //        if (_objInfo.IsDrop)
        //        {
        //            ResetButton(btnLabel);
        //            return;
        //        }
        //        sgworld.OnLButtonDown += Drawing_OnLButtonDown;
        //        sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"GeometryTag_Click Exception: {ex.Message}");
        //    }
        //}

        private void btnPoint_Click(object sender, EventArgs e)
        {
            try
            {
                HighlightButton(btnPoint);
                PbHander = "Point";
                _objInfo = new DrawingObjectInfo(PbHander, ref sgworld);
                if (_objInfo.IsDrop)
                {
                    ResetButton(btnPoint);
                    return;
                }
                if(_objInfo.IsPointTakenFromMap)
                {
                    sgworld.OnLButtonDown += OnLBtnDown_Point;
                    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                }
                else
                {
                    if (_objInfo.PointPosition != null)
                    {
                        Point cGeoPoint = new Point(_objInfo, ref sgworld);  	
                    }
                    ResetButton(btnPoint); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GeoPoint_Click Exception: {ex.Message}");
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1012, 4);
            try
            {
                HighlightButton(btnLine, true);
                PbHander = "Line";
                _objInfo = new DrawingObjectInfo(PbHander, ref sgworld);
                if (_objInfo.IsDrop)
                {
                    ResetButton(btnLine, true);
                    return;
                }
                sgworld.OnLButtonDown += OnLBtnDown_Line;
                sgworld.OnRButtonDown += OnRBtnDown_DrawingComplete;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"GeometryPolygon_Click Exception: {ex.Message}");
            }
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1012, 5);
            try
            {
                HighlightButton(btnRegion, true);
                PbHander = "Region";
                _objInfo = new DrawingObjectInfo(PbHander, ref sgworld);
                if (_objInfo.IsDrop)
                {
                    ResetButton(btnRegion, true);
                    return;
                }
                sgworld.OnLButtonDown += OnLBtnDown_Region;
                sgworld.OnRButtonDown += OnRBtnDown_DrawingComplete;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"GeometryPolygon_Click Exception: {ex.Message}");
            }
        }

        private void btnFreehandDrawing_Click(object sender, EventArgs e)
        {
            try
            {
                HighlightButton(btnFreehandDrawing);
                PbHander = "FreehandDrawing";
                _objInfo = new DrawingObjectInfo(PbHander, ref sgworld);
                if (_objInfo.IsDrop)
                {
                    ResetButton(btnFreehandDrawing, true);
                    return;
                }
                sgworld.OnLButtonDown += OnLBtnDown_FreehandDrawing;
                sgworld.OnLButtonUp += FreehandDrawing_OnLButtonUp;
                sgworld.OnFrame += FreehandDrawing_OnMouseMove;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"GeometryPolygon_Click Exception: {ex.Message}");
            }
        }

        private void btnDrawingComplete_Click(object sender, EventArgs e)
        {
            DrawingComplete(PbHander);
            PbHander = "";
            IsSaved = false;
            Text = _tProjectUrl + @"* - FieldGeo3D";
        }

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

        private void btnBuildSurface_Click(object sender, EventArgs e)
        {

        }

        private void btnStretchSurface_Click(object sender, EventArgs e)
        {

        }

        private void btnBlockAnalyse_Click(object sender, EventArgs e)
        {

        }

        #endregion

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
        /// 定位(待修正GPS！！！！！)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocate_Click(object sender, EventArgs e)
        {
            
            var frmPosition = new FrmPosition(XLeft, XRight, YTop, YBottom);
            if (frmPosition.ShowDialog() != DialogResult.OK) return;
            var position = sgworld.Creator.CreatePosition(frmPosition.XLong, frmPosition.YLat, 800, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, -90, 0, 0);
            sgworld.Navigate.FlyTo(position);
        }


        private void swbtnGPS_ValueChanged(object sender, EventArgs e)
        {
            sgworld.Navigate.SetGPSMode(swbtnGPS.Value == false
                ? GPSOperationMode.GPS_MODE_FOLLOW
                : GPSOperationMode.GPS_MODE_SHOW_LOCATION_INDICATOR);
        }

        /// <summary>
        /// 定位(？？？？)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGPS_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1023, 0);
            //待修正，结合数据库！

            //挂接鼠标左键事件
            sgworld.OnLButtonDown += OnLBtnDown_GetWorldPointInfo;
            //挂接数据变化处理方法（查询数据库）
            //OnCurrentWorldPointInfoChange += OnCurrentWPIChange_QueryDetail;

        }

        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            /*
            IPosition66 p1 = sgworld.Creator.CreatePosition(412465.396283, 3264008.200115);
            IPosition66 p2 = sgworld.Creator.CreatePosition(412019.599981, 3264057.697713);
            IPosition66 p3 = sgworld.Creator.CreatePosition(412344.021811, 3263541.641142);

            IPosition66 p4 = sgworld.Creator.CreatePosition(412480.938471, 3264213.0889);
            IPosition66 p5 = sgworld.Creator.CreatePosition(412262.35476, 3263878.751618);
            IPosition66 p6 = sgworld.Creator.CreatePosition(412992.85769, 3263822.762772);

            ITerrainPolygon66 Itp1 = CreatePolygon3ps(p1, p2, p3);
            ITerrainPolygon66 Itp2 = CreatePolygon3ps(p4, p5, p6);

            bool overlaps = Itp1.Geometry.SpatialRelation.Overlaps(Itp2.Geometry);
            MessageBox.Show(@"overlaps: " + overlaps);

            IGeometry ig = Itp1.Geometry.SpatialOperator.Intersection(Itp2.Geometry);
            ITerrainPolygon66 itp3 = sgworld.Creator.CreatePolygon(ig);
            */
            
            //测试geoplane
            var p0 = new GeoPoint(415896.957085, 3269487.527959, 3157.6826, "p0");
            var p1 = new GeoPoint(416440.844915, 3270171.110581, 3316.4351, "p1");
            var p2 = new GeoPoint(416994.127891, 3270955.529197, 3404.8826, "p2");
            var p3 = new GeoPoint(417134.990163, 3271563.044139, 3582.7659, "p3");
            var p4 = new GeoPoint(417047.97109, 3272202.00806, 3525.4553, "p4");
            var p5 = new GeoPoint(416789.154441, 3273192.007297, 3103.405, "p5");
            var p6 = new GeoPoint(416129.200254, 3273107.372097, 2933.7236, "p6");

            var pList = new List<GeoPoint> {p0, p1, p2, p3, p4, p5, p6};

            var plane1 = new GeoPlane(pList);
            plane1.Draw(ref sgworld);
            plane1.Draw(ref sgworld, true);

            //测试IsSimple
            var arrP1 = new double[]
            {
                412615.291731,3269523.095953,0,
                414177.661433,3269060.668648,0,
                412365.834826,3268080.880464,0,
                413435.563589,3269818.148106,0,
                414215.54368,3269670.723062,0,
            };
            var arrP2 = new double[]
            {
                411771.724269,3269043.558136,0,
                412294.277262,3268514.991006,0,
                411507.287252,3268021.481417,0,
                411150.209789,3268490.430657,0,
            };

            bool b1IsSimple = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(arrP1).IsSimple();
            bool b2IsSimple = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(arrP2).IsSimple();

            //MessageBox.Show($"p1 simple:{b1IsSimple}, p2 simple:{b2IsSimple}");

            var tp1 = sgworld.Creator.CreatePolygonFromArray(arrP1);
            var tp2 = sgworld.Creator.CreatePolygonFromArray(arrP2);

            //测试GetWorldPosition
            //var item = GetWorldPointInfo();
            //var pos = item.Position;
            
            sgworld.OnLButtonDown += OnLBtnDown_GetWorldPointInfo;
            sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);

            //var pos = _cWorldPointInfo.Position;
            //MessageBox.Show($"X:{pos.X},Y:{pos.Y}");
            
        }

        /// <summary>
        /// 应用绘制命令，并释放鼠标和相关全局引用
        /// </summary>
        /// <param name="pbhander"></param>
        private void DrawingComplete(string pbhander)
        {

            #region 标签

            //if (pbhander == "GeoLabel")
            //{
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //}

            #endregion

            #region 点

            //if (PbHander == "GeoPoint")
            //{
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            //}

            #endregion

            #region 线

            if (pbhander == "Line" || pbhander == "FreehandDrawing")
            {
                if(pbhander == "Line")
                {
                    sgworld.OnLButtonDown -= OnLBtnDown_Line;
                }
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (_pITerrainPolyline != null)
                {
                    Line cGeoLine = new Line(_pITerrainPolyline);
                }
                _pITerrainPolyline = null;
                _objInfo = null;

                ResetButton(btnLine, true);
            }

            #endregion

            #region 区域

            if (pbhander == "Region")
            {
                sgworld.OnLButtonDown -= OnLBtnDown_Region;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (_pItPolygon != null)
                {
                    Region cGeoRegion = new Region(_pItPolygon);
                }
                _tempLineString = null;
                _pItPolygon = null;
                _objInfo = null;
                ResetButton(btnRegion, true);
            }

            #endregion

            #region 体

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
        /// <param name="flags"></param>
        /// <param name="x">鼠标坐标X</param>
        /// <param name="y">鼠标坐标Y</param>
        /// <returns></returns>
        private bool OnRBtnDown_DrawingComplete(int flags, int x, int y)
        {
            DrawingComplete(PbHander);
            sgworld.OnRButtonDown -= OnRBtnDown_DrawingComplete;
            PbHander = "";
            IsSaved = false;
            Text = _tProjectUrl + @"* - FieldGeo3D";
            return true;
        }

        private bool OnLBtnDown_GetWorldPointInfo(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);

            var loggingObj = LoggingObject.LoggingObjects[_cWorldPointInfo.ObjectID] as LoggingObject;
            loggingObj?.QueryDetail();
            MessageBox.Show($"X:{_cWorldPointInfo.Position.X};Y:{_cWorldPointInfo.Position.Y}");
            //_cWorldPointInfo改变，触发事件。(并没有触发！！！！！！！！！！！！)
            //MessageBox.Show($"X:{_cWorldPointInfo.Position.X};Y:{_cWorldPointInfo.Position.Y}");
            sgworld.OnLButtonDown -= OnLBtnDown_GetWorldPointInfo;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            _cWorldPointInfo = null;//此处不应触发事件。
            return false;
        }

        private bool OnLBtnDown_Point(int flags, int x, int y)
        {
            IWorldPointInfo66 pIwpInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN); //真实位置信息
            IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）
            if (_objInfo != null)
            {
                if (_objInfo.PointPosition == null)
                {
                    _objInfo.PointPosition = sgworld.Creator.CreatePosition(pIwpInfo.Position.X,
                        pIwpInfo.Position.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0);
                    Point cGeoPoint = new Point(_objInfo, ref sgworld);
                    sgworld.OnLButtonDown -= OnLBtnDown_Point;
                    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                }
                ResetButton(btnPoint);
                Text = _tProjectUrl + @"* - FieldGeo3D";
            }
            _objInfo = null;
            return false;
        }

        private bool OnLBtnDown_Line(int flags, int x, int y)
        {
            IWorldPointInfo66 pIwpInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN); //真实位置信息
            IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）
            if (_pITerrainPolyline == null)
            {
                var cVerticesArray = new double[] {
                        pIwpInfo.Position.X, pIwpInfo.Position.Y, pIwpInfo.Position.Distance,
                        pIwpInfo.Position.X, pIwpInfo.Position.Y, pIwpInfo.Position.Distance, };
                var cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
                var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                if (_objInfo != null)
                {
                    _pITerrainPolyline = sgworld.Creator.CreatePolyline(cLineString, _objInfo.LineColor.ToABGRColor(), eAltitudeTypeCode, _objInfo.GroupId, _objInfo.Name);
                }
            }
            else
            {
                var cLineString = _pITerrainPolyline.Geometry as ILineString;
                _pITerrainPolyline.Geometry.StartEdit();
                var dx = pIwpInfo.Position.X;
                var dy = pIwpInfo.Position.Y;
                var dz = pIwpInfo.Position.Altitude;

                cLineString?.Points.AddPoint(dx, dy, dz);
                var editedGeometry = _pITerrainPolyline.Geometry.EndEdit();
                _pITerrainPolyline.Geometry = editedGeometry;

                //MessageBox.Show(cLineString.Points.GetType().ToString());
                //sgworld.Analysis.CreateTerrainProfile(cLineString.Points);

            }
            return false;
        }

        private bool OnLBtnDown_Region(int flags, int x, int y)
        {
            IWorldPointInfo66 pIwpInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN); //真实位置信息
            IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）
            if (_pItPolygon == null)
            {
                //IGeometry cPolygonGeometry = null;
                var cVerticesArray = new double[] {
                        pIPosition.X,  pIPosition.Y,  0,
                        pIwpInfo.Position.X,  pIwpInfo.Position.Y,  pIwpInfo.Position.Altitude,
                        pIwpInfo.Position.X,  pIwpInfo.Position.Y,  pIwpInfo.Position.Altitude,
                    };

                _tempLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
                _tempLineString.StartEdit();
                _tempLineString.Points.DeletePoint(0);
                _tempLineString.EndEdit();



                var cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);
                //cPolygonGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cRing, null);

                var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                if (_objInfo != null)
                {
                    _pItPolygon = sgworld.Creator.CreatePolygon(cRing, _objInfo.LineColor.ToABGRColor(), _objInfo.FillColor.ToABGRColor(), eAltitudeTypeCode, _objInfo.GroupId, _objInfo.Name);
                }

                var polygonGeometry = _pItPolygon?.Geometry as IPolygon;
                if (polygonGeometry == null) return false;
                polygonGeometry.StartEdit();
                foreach (ILinearRing ring in polygonGeometry.Rings)
                {
                    var dx = pIwpInfo.Position.X;
                    var dy = pIwpInfo.Position.Y;
                    var dh = pIwpInfo.Position.Altitude;

                    ring.Points.AddPoint(dx, dy, dh);
                    ring.Points.DeletePoint(0);
                }
                var editedGeometry = polygonGeometry.EndEdit();
                _pItPolygon.Geometry = editedGeometry;
            }
            else
            {
                var polygonGeometry = _pItPolygon.Geometry as IPolygon;
                if (polygonGeometry == null) return false;

                polygonGeometry.StartEdit();
                foreach (ILinearRing ring in polygonGeometry.Rings)
                {
                    var dx = pIwpInfo.Position.X;
                    var dy = pIwpInfo.Position.Y;
                    var dh = pIwpInfo.Position.Altitude;
                    ring.Points.AddPoint(dx, dy, dh);

                    if (!ring.IsSimple())
                    {
                        ring.Points.DeletePoint(ring.Points.Count - 1);
                        MessageBox.Show(@"选取点无效：不能形成有效区域");
                    }

                    _tempLineString.StartEdit();
                    _tempLineString.Points.AddPoint(dx, dy, dh);
                    _tempLineString.EndEdit();

                    if (!_tempLineString.IsSimple())
                    {
                        ring.Points.DeletePoint(ring.Points.Count - 1);
                        _tempLineString.Points.DeletePoint(_tempLineString.Points.Count - 1);
                        MessageBox.Show(@"选取点无效：不能形成有效区域");
                    }
                }
                var editedGeometry = polygonGeometry.EndEdit();
                _pItPolygon.Geometry = editedGeometry;

            }
            return false;
        }

        private bool OnLBtnDown_FreehandDrawing(int flags, int x, int y)
        {
            IsFreehandDrawingMouseDown = true;
            return false;
        }

        /// <summary>
        /// 左键按下方法-废弃
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="X">鼠标坐标X</param>
        /// <param name="Y">鼠标坐标Y</param>
        /// <returns></returns>
        private bool Drawing_OnLButtonDown(int Flags, int X, int Y)
        {
            
            IWorldPointInfo66 pIwpInfo = sgworld.Window.PixelToWorld(X, Y, WorldPointType.WPT_TERRAIN); //真实位置信息
            IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）

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
        /// 左键松开方法（用于FreehandDrawing）
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool FreehandDrawing_OnLButtonUp(int flags, int x, int y)
        {
            if (PbHander == "FreehandDrawing")
            {
                IsFreehandDrawingMouseDown = false;
            }
            sgworld.OnFrame -= FreehandDrawing_OnMouseMove;
            sgworld.OnLButtonDown -= OnLBtnDown_FreehandDrawing;
            sgworld.OnLButtonUp -= FreehandDrawing_OnLButtonUp;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            
            if (_pITerrainPolyline != null)
            {
                Line cLine = new Line(_pITerrainPolyline);
            }
            _pITerrainPolyline = null;
            _objInfo = null; 
            ResetButton(btnFreehandDrawing);

            PbHander = "";
            IsSaved = false;
            Text = _tProjectUrl + @"* - FieldGeo3D";

            return true;
        }

        /// <summary>
        /// 鼠标移动方法（用于FreehandDrawing），挂接OnFrame事件
        /// </summary>
        private void FreehandDrawing_OnMouseMove()
        {
            if (PbHander != "FreehandDrawing" || !IsFreehandDrawingMouseDown) return;
            //手绘代码
            IMouseInfo66 mouseInfo = sgworld.Window.GetMouseInfo();
            IWorldPointInfo66 pIwpInfo = sgworld.Window.PixelToWorld(mouseInfo.X, mouseInfo.Y, WorldPointType.WPT_TERRAIN); 

            if (_pITerrainPolyline == null)
            {
                var cVerticesArray = new[] {
                    pIwpInfo.Position.X, pIwpInfo.Position.Y, pIwpInfo.Position.Distance,
                    pIwpInfo.Position.X, pIwpInfo.Position.Y, pIwpInfo.Position.Distance, };
                var cLineString = sgworld.Creator.GeometryCreator.CreateLineStringGeometry(cVerticesArray);
                var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                if (_objInfo != null)
                {
                    _pITerrainPolyline = sgworld.Creator.CreatePolyline(cLineString, _objInfo.LineColor.ToABGRColor(), eAltitudeTypeCode, _objInfo.GroupId, _objInfo.Name);
                }
            }
            else
            {
                var cLineString = _pITerrainPolyline.Geometry as ILineString;
                _pITerrainPolyline.Geometry.StartEdit();
                var dx = pIwpInfo.Position.X;
                var dy = pIwpInfo.Position.Y;
                var dz = pIwpInfo.Position.Altitude;

                cLineString?.Points.AddPoint(dx, dy, dz);
                var editedGeometry = _pITerrainPolyline.Geometry.EndEdit();
                _pITerrainPolyline.Geometry = editedGeometry;
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
                btnDrawingComplete.FontBold = true;
                btnDrawingComplete.ForeColor = Color.Green;
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
                btnDrawingComplete.FontBold = false;
                btnDrawingComplete.ForeColor = Color.Black;
            }
        }








        #endregion


        
    }
}
