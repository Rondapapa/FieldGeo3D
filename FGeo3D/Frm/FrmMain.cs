using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using FGeo3D.GeoImage;
using FGeo3D.GPS;
using FGeo3D_TE.DrawingObjs;
using GeoIM.CHIDI.DZ.Util.Common;
using YWCH.CHIDI.DZ.COM.Skyline;
using FGeo3D.LoggingObj;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;
using Stereonet;

namespace FGeo3D_TE.Frm
{
    using Draw;

    using FGeo3D.GeoCurvedSurface;
    using FGeo3D.GeoObj;
    using FGeo3D.GoCAD;

    using MIConvexHull;

    public enum MouseEventFlags
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        Wheel = 0x0800,
        Absolute = 0x8000
    }

    public partial class FrmMain : Form
    {

        // Skyline
        SGWorld66 sgworld = null;

        // 数据库
        YWCHEntEx db = null;

        #region 全局变量域

        // 工程目录
        private string _tProjectUrl;

        // 数据库连接
        private bool _isDbConnected = false;

        // 模型路径
        string _modelPath;

        // 模型Guid
        private string _modelGuid;

        // 当前选定的工作对象Guid
        private string _currWorkingObjGuid;

        // 地形多边形
        ITerrainPolygon66 _pItPolygon = null;

        // 地形多段线
        ITerrainPolyline66 _pITerrainPolyline = null;

        // GPS控制器对象
        Controller _gpsController;

        // 地理地质对象信息传递对象
        private DrawingObjectInfo _objInfo;

        // 绘制多边形时用于判断isSimple的辅助线环
        ILineString _tempLineString;

        // 当前选取对象、及其监控事件
        private IWorldPointInfo66 _cWorldPointInfo;

        // 地形上下左右位置
        public double XLeft { get; private set; }
        public double XRight { get; private set; }
        public double YTop { get; private set; }
        public double YBottom { get; private set; }

        // 地形多边形
        public ITerrainPolygon66 TerrainPolygon { get; private set; }

        // 块体分析 边坡起点ID
        private string _startOfStereonet = "";
        IWorldPointInfo66 firstPoint = null;
        List<Point> vertexOfStereonet = new List<Point>();
        private List<Stereonet.FrmStereonet.DataFromMain> selectedPointInStereonet = new List<FrmStereonet.DataFromMain>();


        // 鼠标状态
        public string PbHander { get; private set; }

        // 保存状态（暂时没用到）
        public bool IsSaved { get; set; }

        // 手绘鼠标是否按下状态
        public bool IsFreehandDrawingMouseDown { get; set; }

        // 点
        public string PointGroupId { get; set; }

        // 线
        public string LineGroupId { get; set; }

        // 面
        public string RegionGroupId { get; set; }
        #endregion

        public FrmMain()
        {
            InitializeComponent();
            Init();
        }

        // 自定义构造函数
        private void Init()
        {
            sgworld = new SGWorld66();
            db = new YWCHEntEx();
            components = new Container();
            _gpsController = new Controller(components);
        }

        #region 工程
        // 打开
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // 打开工程
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

            // 隐藏Skyline商标
            sgworld.Project.set_Settings("RemoveSkylineCopyright", 1);

            // 地下模式， 默认关闭
            sgworld.Navigate.UndergroundMode = false;

            // 初始化地形边界
            XLeft = sgworld.Terrain.Left;
            XRight = sgworld.Terrain.Right;
            YTop = sgworld.Terrain.Top;
            YBottom = sgworld.Terrain.Bottom;

            // 设置窗体标题
            Text = _tProjectUrl + @" - FieldGeo3D";



            // 设置地图中心为兴趣点，导航至此
            var centerPos = sgworld.Creator.CreatePosition((XLeft + XRight) / 2, (YTop + YBottom) / 2, 0,
                AltitudeTypeCode.ATC_ON_TERRAIN, 0, -75, 0, 10000);

            var centerLocation = sgworld.Creator.CreateLocation(centerPos, sgworld.ProjectTree.RootID, "初始视角");
            sgworld.Navigate.FlyTo(centerLocation, ActionCode.AC_FLYTO);

            PointGroupId = sgworld.ProjectTree.CreateGroup("点");
            LineGroupId = sgworld.ProjectTree.CreateGroup("线");
            RegionGroupId = sgworld.ProjectTree.CreateGroup("区域");
            sgworld.ProjectTree.ExpandGroup(PointGroupId, true);
            sgworld.ProjectTree.ExpandGroup(LineGroupId, true);
            sgworld.ProjectTree.ExpandGroup(RegionGroupId, true);


            // 创建地形面的多边形（用于地形面求交）
            double[] terrainPolygonVertices = new[] { XLeft, YTop, 0, XRight, YTop, 0, XRight, YBottom, 0, XLeft, YBottom, 0 };
            IColor66 lineColor = this.sgworld.Creator.CreateColor(0, 0, 0, 0);
            IColor66 fillColor = this.sgworld.Creator.CreateColor(0, 0, 0, 0);
            this.TerrainPolygon = this.sgworld.Creator.CreatePolygonFromArray(
                terrainPolygonVertices,
                lineColor,
                fillColor,
                AltitudeTypeCode.ATC_ON_TERRAIN,
                this.sgworld.ProjectTree.HiddenGroupID,
                this.sgworld.ProjectTree.HiddenGroupName);


            // 设置CPU节能
            // this.sgworld.Application.CPUSaveMode = true;
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
            // 获得文件路径  
            var localFilePath = saveFileDialog.FileName;

            // 获取文件名，不带路径  
            var fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            // sgworld = new SGWorld66();
            sgworld.Project.SaveAs(fileNameExt);

            // sgworld.ProjectTree.SaveAsFly(fileNameExt, gpgid);

            // string path = "C:\\Users\\lmc\\AppData\\Roaming\\Skyline\\TerraExplorer\\" + fileNameExt;
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

                // 打开另存后的工程文件
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
            // 登录、选择工程阶段
            _isDbConnected = db.SkyLogin();
            if (!_isDbConnected) return;
            // 创建模型
            _modelPath = db.SkyOpenOrNewModal();
            _modelGuid = db.SkyModelGuid;
            Text = db.GCName + @" - FieldGeo3D";
            StatusDatabase.Text = $"数据库状态：【已连接】|工程：{db.GCName}";
        }


        //选择工程
        private void btnProject_Click(object sender, EventArgs e)
        {
            if (_isDbConnected)
            {
                db.SkySelectProject();
            }
            else
            {
                MessageBox.Show(@"请先登录数据库，再选择工程阶段！", @"选择工程阶段失败");
            }
        }

        //连接GPS
        private void btnConnectGPS_Click(object sender, EventArgs e)
        {
            // 若GPS串口还未打开
            if (!_gpsController.IsComOpen)
            {
                // 搜索串口，打开
                string ospResult = _gpsController.OpenSerialPort();

                // 若打开串口失败
                if (!string.IsNullOrEmpty(ospResult))
                {
#if DEBUG
                    // 测试专用
                    MessageBox.Show(ospResult, @"[调试模式]GPS连接失败");
#endif

                    // 若没有打开串口，则提示，并返回；
                    ToastNotification.Show(this, "未找到GPS设备，请检查。", 2500, eToastPosition.MiddleCenter);
                    return;
                }
            }
            ToastNotification.Show(this, "GPS设备连接成功", 2500, eToastPosition.MiddleCenter);
        }



        //导入
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            double xOffset = double.Parse(this.db.SkyXZBPYL);
            double yOffset = double.Parse(this.db.SkyYZBPYL);

            //弹出数据库筛选面板
            //导入相关数据
            var objs = db.SkyGetData();
            if (objs.Count == 0) return;
            for (var index = 0; index < objs.Count; index++)
            {
                var thisObj = objs.GetObjData(index);



                if (LoggingObject.DictOfLoggingObjects.ContainsKey(thisObj.Guid))
                    continue;
                var cType = thisObj.Type;
                switch (cType)
                {
                    case "钻探编录":
                        var thisBore = new LoggingBore(thisObj, ref sgworld, xOffset, yOffset);

                        break;
                    case "硐探编录":
                        var thisFootrill = new LoggingFootrill(thisObj, ref sgworld, xOffset, yOffset);

                        break;
                    case "坑探编录":
                        var thisPit = new LoggingPit(thisObj, ref sgworld, xOffset, yOffset);

                        break;
                    case "井探编录":
                        var thisWell = new LoggingWell(thisObj, ref sgworld, xOffset, yOffset);

                        break;
                    case "槽探编录":
                        var thisTrench = new LoggingTrench(thisObj, ref sgworld, xOffset, yOffset);

                        break;
                    case "边坡编录":
                        var thisSlope = new LoggingSlope(thisObj, ref sgworld);

                        break;
                    case "洞室编录":
                        var thisCavity = new LoggingCavity(thisObj, ref sgworld);

                        break;
                    case "基础编录":
                        var thisFoundation = new LoggingFoundation(thisObj, ref sgworld);

                        break;
                    case "地质点":
                        var thisSpot = new LoggingSpot(thisObj, ref sgworld);

                        break;
                }
            }
        }
        #endregion

        #region 编录
        private void btnBore_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【钻探编录】";
                ToastNotification.Show(this, "开始编录钻探对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingBore;

            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }
        }

        private void btnFootrill_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【硐探编录】";
                ToastNotification.Show(this, "开始编录硐探对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingFootrill;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }

        private void btnPit_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【坑探编录】";
                ToastNotification.Show(this, "开始编录坑探对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingPit;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }

        private void btnWell_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【井探编录】";
                ToastNotification.Show(this, "开始编录井探对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingWell;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }

        private void btnTrench_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【槽探编录】";
                ToastNotification.Show(this, "开始编录槽探对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingTrench;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }



        private void btnSlope_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【边坡编录】";
                ToastNotification.Show(this, "开始编录边坡对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingSlope;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }


        }

        private void btnCavity_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【洞室编录】";
                ToastNotification.Show(this, "开始编录洞室对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingCavity;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }

        private void btnFoundation_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【基坑编录】";
                ToastNotification.Show(this, "开始编录基坑对象");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingFoundation;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

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

        /*
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
        */
        private void btnGeoPoint_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                StatusSystem.Text = @"系统状态：【地质点编录】";
                ToastNotification.Show(this, "开始编录地质点");
                sgworld.OnLButtonDown += OnLBtnDown_LoggingSpot;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }


        private void btnSelectWorkingObj_Click(object sender, EventArgs e)
        {
            StatusSystem.Text = @"系统状态：【选择工作对象】";
            sgworld.OnLButtonDown += OnLBtnDown_SelectWorkingObj;
            sgworld.OnRButtonDown += OnRBtnDown_SelectWorkingObj;
            sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
        }

        private void btnImageLogging_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            this.StatusSystem.Text = @"系统状态：【图像编录】";
            var frmImage = new FrmImage(ref this.db);
            frmImage.ShowDialog();
            this.StatusSystem.Text = @"系统状态：【就绪】";
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_currWorkingObjGuid))
            //{
            //    MessageBox.Show(@"请先选择工作对象。", @"工作对象未选定");
            //    return;
            //}
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
                sgworld.OnLButtonDown += OnLBtnDown_LineNew;
                sgworld.OnRButtonDown += OnRBtnDown_DrawingComplete;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"GeometryPolygon_Click Exception: {ex.Message}");
            }
        }

        private void btnLineNew_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                HighlightButton(btnLine, true); // 仍然使用原按钮

                PbHander = "LineNew";
                _objInfo = new DrawingObjectInfo(PbHander, ref sgworld);
                if (_objInfo.IsDrop)
                {
                    ResetButton(btnLine, true); // 仍然使用原按钮
                    return;
                }
                StatusSystem.Text = @"系统状态：【绘制界线】";
                ToastNotification.Show(this, "开始绘制地质界线");
                sgworld.OnLButtonDown += OnLBtnDown_LineNew;
                sgworld.OnRButtonDown += OnRBtnDown_DrawingComplete;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }

        private void btnRegionNew_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                HighlightButton(btnRegion, true);//仍然使用原按钮

                PbHander = "RegionNew";
                _objInfo = new DrawingObjectInfo(PbHander, ref sgworld);
                if (_objInfo.IsDrop)
                {
                    ResetButton(btnRegion, true);//仍然使用原按钮
                    return;
                }
                StatusSystem.Text = @"系统状态：【绘制区域】";
                ToastNotification.Show(this, "开始绘制地形区域");
                sgworld.OnLButtonDown += OnLBtnDown_RegionNew;
                sgworld.OnRButtonDown += OnRBtnDown_DrawingComplete;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            }

        }


        private void btnRegion_Click(object sender, EventArgs e)
        {

        }



        private void btnFreehandDrawing_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawingComplete_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }


            DrawingComplete(PbHander);
            PbHander = string.Empty;
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
            try
            {
                sgworld.Command.Execute(1040, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
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



        private void btnBestPath_Click(object sender, EventArgs e)
        {
            try
            {
                sgworld.Command.Execute(1042, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }

        private void btnBuildSurface_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("功能尚在开发中");
            //return;

            try
            {
                FrmCurvedSurfaceBuilder frmSurfaceBuilder = new FrmCurvedSurfaceBuilder(LoggingObject.DictOfLoggingObjects, ref this.sgworld, ref this.db);
                frmSurfaceBuilder.Show();
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }



        private void btnBlockAnalyse_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("功能尚在开发中");
            //return;


            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            //}
        }

        #endregion

        #region 测量
        private void btnAbsDistance_Click(object sender, EventArgs e)
        {

            try
            {
                ToastNotification.Show(this, "测量直线距离, 结束测量请【单击鼠标右键】或【触控笔长按屏幕】", 2500, eToastPosition.MiddleCenter);
                sgworld.Command.Execute(1035, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }

        }

        private void btnHorizonalDistance_Click(object sender, EventArgs e)
        {
            try
            {
                ToastNotification.Show(this, "测量水平距离, 结束测量请【单击鼠标右键】或【触控笔长按屏幕】", 2500, eToastPosition.MiddleCenter);
                sgworld.Command.Execute(1034, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }

        private void btnVerticalDistance_Click(object sender, EventArgs e)
        {
            try
            {
                ToastNotification.Show(this, "测量垂直距离, 结束测量请【单击鼠标右键】或【触控笔长按屏幕】", 2500, eToastPosition.MiddleCenter);
                sgworld.Command.Execute(1036, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }

        private void btnPlaneArea_Click(object sender, EventArgs e)
        {
            try
            {
                ToastNotification.Show(this, "测量平面距离, 结束测量请【单击鼠标右键】或【触控笔长按屏幕】", 2500, eToastPosition.MiddleCenter);
                sgworld.Command.Execute(1037, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }

        private void btnTerrainArea_Click(object sender, EventArgs e)
        {
            try
            {
                ToastNotification.Show(this, "测量地形面积, 结束测量请【单击鼠标右键】或【触控笔长按屏幕】", 2500, eToastPosition.MiddleCenter);
                sgworld.Command.Execute(1165, 0);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }

        private void btnXFinishMeasure_Click(object sender, EventArgs e)
        {
            StatusSystem.Text = @"系统状态：【就绪】";
            ToastNotification.Show(this, "结束测量");


            //激活右键
            mouse_event((int)(MouseEventFlags.Absolute | MouseEventFlags.RightDown | MouseEventFlags.RightUp),
                Screen.PrimaryScreen.WorkingArea.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Width / 2, 0, 0);

            //try
            //{
            //    sgworld.Command.Execute(1021, 0);
            //    sgworld.Command.Execute(1021, 0);
            //}
            //catch (Exception ex)
            //{
            //    ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message);
            //}
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



        /// <summary>
        /// GPS定位(？？？？)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGPS_Click(object sender, EventArgs e)
        {


            //若GPS串口还未打开
            if (!_gpsController.IsComOpen)
            {
                ToastNotification.Show(this, "请先连接GPS", 2500, eToastPosition.MiddleCenter);
                return;
            }

            //反复读取串口，直到获得有效坐标数据，或超时
            string rdResult;
            _gpsController.TimeCountDown = new TimeSpan(0, 0, 5);  //设置5秒倒计时 
            timerGPSReader.Interval = 1000;

            timerGPSReader.Start();
            while (!string.IsNullOrEmpty(rdResult = _gpsController.ReadData()) || _gpsController.TimeCountDown.TotalSeconds > 0)
            {

                ToastNotification.Show(this, $"正在读取GPS串口数据...{_gpsController.TimeCountDown.TotalSeconds}", 2500, eToastPosition.MiddleCenter);

            }
            timerGPSReader.Stop();

            //如果5秒后仍读到非坐标数据，则提示，退出。
            if (!string.IsNullOrEmpty(rdResult))
            {
                ToastNotification.Show(this, $"GPS数据读取失败，串口返回非坐标数据:{rdResult}", 2500, eToastPosition.MiddleCenter);
                return;
            }

            var gpsX = _gpsController.GetCoordX(); //注意坐标偏移！！！！还未修正！！！！！
            var gpsY = _gpsController.GetCoordY();
            var gpsZ = _gpsController.GetCoordZ();

            // 测试专用
            //double testX = 413988.472639;
            //double testY = 3276102.503443;

            IPosition66 gpsPos = sgworld.Creator.CreatePosition(gpsX, gpsY, gpsZ);
            try
            {
                sgworld.Navigate.SetGPSMode(GPSOperationMode.GPS_MODE_SHOW_LOCATION_INDICATOR);
                sgworld.Navigate.SetGPSPosition(gpsPos);
                ToastNotification.Show(this, "GPS定位完成！");
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
                StatusSystem.Text = @"系统状态：【就绪】";
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }


            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                //挂接鼠标左键事件
                sgworld.OnLButtonDown += OnLBtnDown_Query;

                StatusSystem.Text = @"系统状态：【查询地质对象】";
                ToastNotification.Show(this, "查询地质对象：请拾取地质对象的图例或标签", 2500, eToastPosition.MiddleCenter);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
                StatusSystem.Text = @"系统状态：【就绪】";
            }

        }

        private void buttonXDeleteLoggingSpot_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                //挂接事件
                sgworld.OnLButtonDown += OnLBtnDown_DeleteLoggingSpot;

                StatusSystem.Text = @"系统状态：【删除地质点】";
                ToastNotification.Show(this, "删除地质点：请拾取地质对象的图例或标签", 2500, eToastPosition.MiddleCenter);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
                StatusSystem.Text = @"系统状态：【就绪】";
            }

        }

        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            double[] arrVertex = new double[]
              { 414466.533102, 3260935.85838, 4172.5599,
                413061.904645, 3260585.222671, 3710.7415,
                412897.0397, 3259937.098646, 3813.1575,
                414475.296055, 3259947.378596, 4534.5262
              };


            double[] arrVertex2 = new double[]
              { 413188.001354, 3261117.79563, 0,
                414341.166902, 3258997.637746, 0,
                414618.314284, 3260857.812753, 0
              };

            var pol1 = this.sgworld.Creator.CreatePolygonFromArray(
                arrVertex, -16711936, -10197916,
                AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
                string.Empty, "TestSurface1");

            var pol2 = this.sgworld.Creator.CreatePolygonFromArray(
                arrVertex2, -16711936, -10197916,
                AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
                string.Empty, "TestSurface2");


            var p1g = pol1.Geometry;
            var p2g = pol2.Geometry;

            try
            {
                var intersec = p1g.SpatialOperator.Intersection(p2g);
                var line = this.sgworld.Creator.CreatePolyline(intersec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



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

            ////测试geoplane
            //var p0 = new Point(415896.957085, 3269487.527959, 3157.6826);
            //var p1 = new Point(416440.844915, 3270171.110581, 3316.4351);
            //var p2 = new Point(416994.127891, 3270955.529197, 3404.8826);
            //var p3 = new Point(417134.990163, 3271563.044139, 3582.7659);
            //var p4 = new Point(417047.97109, 3272202.00806, 3525.4553);
            //var p5 = new Point(416789.154441, 3273192.007297, 3103.405);
            //var p6 = new Point(416129.200254, 3273107.372097, 2933.7236);

            //var pList = new List<Point> {p0, p1, p2, p3, p4, p5, p6};



            ////测试IsSimple
            //var arrP1 = new double[]
            //{
            //    412615.291731,3269523.095953,0,
            //    414177.661433,3269060.668648,0,
            //    412365.834826,3268080.880464,0,
            //    413435.563589,3269818.148106,0,
            //    414215.54368,3269670.723062,0,
            //};
            //var arrP2 = new double[]
            //{
            //    411771.724269,3269043.558136,0,
            //    412294.277262,3268514.991006,0,
            //    411507.287252,3268021.481417,0,
            //    411150.209789,3268490.430657,0,
            //};
            //db.SkyGetData().GetObjData(0).MarkersNO1.GetMarker(0).

            ////测试TsFile
            //var testTsData = new TsData();
            ////   testTsData.VerticesList.Add()
            //Point p1 = new Point(100, 200, 300);
            //Point p2 = new Point(200, 300, 600);
            //Point p3 = new Point(150, 280, 500);
            //testTsData.VerticesList.Add(p1);
            //testTsData.VerticesList.Add(p2);
            //testTsData.VerticesList.Add(p3);
            //var trgl1 = new TriLink
            //{
            //    VertexA = 2,
            //    VertexB = 1,
            //    VertexC = 3
            //};
            //testTsData.TriLinksList.Add(trgl1);
            ////   testTsData.TriLinksList.Add();
            //var testTsType = "Surface";

            //var testTsFile = new TsFile(testTsData, testTsType);

            //testTsFile.WriteTsFile();

        }

        /// <summary>
        /// WinAPI模拟鼠标事件
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);


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
                if (pbhander == "Line")
                {
                    sgworld.OnLButtonDown -= OnLBtnDown_Line;
                }
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (_pITerrainPolyline != null)
                {
                    var cLabelStyle = sgworld.Creator.CreateLabelStyle();
                    cLabelStyle.MultilineJustification = "Center";
                    cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    cLabelStyle.TextAlignment = "Bottom, Center";
                    var cLabel = sgworld.Creator.CreateTextLabel(_pITerrainPolyline.Position, _objInfo.Name, cLabelStyle,
                        sgworld.ProjectTree.HiddenGroupID, string.Empty);
                    var cLine = new DrawingLine(_pITerrainPolyline, cLabel, _objInfo.MarkerType, new List<string>());
                    //cLine.Store(_currWorkingObjGuid, ref db);
                }
                _pITerrainPolyline = null;
                _objInfo = null;

                ResetButton(btnLine, true);

            }

            if (pbhander == "LineNew")
            {
                sgworld.OnLButtonDown -= OnLBtnDown_LineNew;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                if (_pITerrainPolyline != null)
                {
                    var cLabelStyle = sgworld.Creator.CreateLabelStyle();
                    cLabelStyle.MultilineJustification = "Center";
                    cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    cLabelStyle.TextAlignment = "Bottom, Center";
                    var cLabel = sgworld.Creator.CreateTextLabel(_pITerrainPolyline.Position, _objInfo.Name, cLabelStyle,
                        sgworld.ProjectTree.HiddenGroupID, string.Empty);

                    //删除冗余点
                    var cLineString = _pITerrainPolyline.Geometry as ILineString;
                    _pITerrainPolyline.Geometry.StartEdit();
                    cLineString?.Points.DeletePoint(0);//?
                    var editedGeometry = _pITerrainPolyline.Geometry.EndEdit();
                    _pITerrainPolyline.Geometry = editedGeometry;

                    //保存
                    var cLine = new DrawingLine(_pITerrainPolyline, cLabel, _objInfo.MarkerType, _objInfo.ConnObjGuids);
                    if (!DrawingObject.DictOfSkyIdDrawingObjects.ContainsKey(cLine.SkyID))
                    {
                        DrawingObject.DictOfSkyIdDrawingObjects.Add(cLine.SkyID, cLine);
                    }
                    if (!DrawingObject.DictOfSkyIdDrawingObjects.ContainsKey(cLine.LabelID))
                    {
                        DrawingObject.DictOfSkyIdDrawingObjects.Add(cLine.LabelID, cLine);
                    }

                    //cLine.Store(_currWorkingObjGuid, ref db);
                }
                _pITerrainPolyline = null;
                _objInfo = null;

                ResetButton(btnLine, true);

            }

            #endregion

            #region 区域

            if (pbhander == "RegionNew")
            {
                sgworld.OnLButtonDown -= OnLBtnDown_RegionNew;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                if (_pItPolygon != null)
                {
                    var cLabelStyle = sgworld.Creator.CreateLabelStyle();
                    cLabelStyle.MultilineJustification = "Center";
                    cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    cLabelStyle.TextAlignment = "Bottom, Center";
                    var cLabel = sgworld.Creator.CreateTextLabel(_pItPolygon.Position, _objInfo.Name, cLabelStyle, sgworld.ProjectTree.HiddenGroupID, string.Empty);

                    //删除两个冗余点
                    var polygonGeometry = _pItPolygon.Geometry as IPolygon;
                    _pItPolygon.Geometry.StartEdit();
                    foreach (ILinearRing ring in polygonGeometry.Rings)
                    {

                        ring?.Points.DeletePoint(0);
                        ring?.Points.DeletePoint(1);
                        //ring.Points.DeletePoint(0);
                    }

                    //结束编辑，保存polygon
                    var editedGeometry = polygonGeometry.EndEdit();
                    _pItPolygon.Geometry = editedGeometry;

                    //保存
                    var cRegion = new DrawingLine(_pItPolygon, cLabel, _objInfo.MarkerType, _objInfo.ConnObjGuids);
                    //cRegion.Store(_currWorkingObjGuid, ref db);
                    if (!DrawingObject.DictOfSkyIdDrawingObjects.ContainsKey(cRegion.SkyID))
                    {
                        DrawingObject.DictOfSkyIdDrawingObjects.Add(cRegion.SkyID, cRegion);
                    }
                    if (!DrawingObject.DictOfSkyIdDrawingObjects.ContainsKey(cRegion.LabelID))
                    {
                        DrawingObject.DictOfSkyIdDrawingObjects.Add(cRegion.LabelID, cRegion);
                    }
                }
                _pItPolygon = null;
                _objInfo = null;

                ResetButton(btnRegion, true);

            }


            if (pbhander == "Region")
            {
                sgworld.OnLButtonDown -= OnLBtnDown_Region;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                if (_pItPolygon != null)
                {
                    var cLabelStyle = sgworld.Creator.CreateLabelStyle();
                    cLabelStyle.MultilineJustification = "Center";
                    cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                    cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                    cLabelStyle.TextAlignment = "Bottom, Center";
                    if (_objInfo != null)
                    {
                        var cLabel = sgworld.Creator.CreateTextLabel(_pItPolygon.Position, _objInfo.Name, cLabelStyle,
                            sgworld.ProjectTree.HiddenGroupID, string.Empty);
                        var cRegion = new DrawingRegion(_pItPolygon, cLabel, _objInfo.MarkerType, _objInfo.ConnObjGuids);
                        cRegion.Store(_currWorkingObjGuid, ref db);
                    }
                }
                _tempLineString = null;
                _pItPolygon = null;
                _objInfo = null;
                ResetButton(btnRegion, true);
            }

            #endregion

            #region 块体分析

            if (pbhander == "Stereonet")
            {
                
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                sgworld.OnLButtonDown -= OnLBtnDown_Stereonet;
                ResetButton(btnStereonet, true);
                foreach (var item in LoggingObject.DictOfLoggingObjects)
                {
                    if (item.Value.Type.ToString() == "Spot")
                    {
                        Point tempPoint = new Point(item.Value.Markers01.GetMarker(0).X,
                            item.Value.Markers01.GetMarker(0).Y, item.Value.Markers01.GetMarker(0).Z);
                        // 如果这个数据点在多边形内，则传入产状列表
                        if (GeoHelper.IsPointInPolygon(vertexOfStereonet, tempPoint))
                            selectedPointInStereonet.Add(
                                new FrmStereonet.DataFromMain(item.Value.Markers01.GetMarker(0).Dip,
                                    item.Value.Markers01.GetMarker(0).Angle));
                    }
                }
                vertexOfStereonet.Clear();
                Stereonet.FrmStereonet newStereonet = new FrmStereonet(selectedPointInStereonet);
                newStereonet.Show();
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
            if (PbHander == "Stereonet" && _pItPolygon!=null)
            {
                sgworld.ProjectTree.DeleteItem(_startOfStereonet);
                sgworld.ProjectTree.DeleteItem(_pItPolygon.ID);
                string str = _cWorldPointInfo.ObjectID;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                sgworld.OnLButtonDown -= OnLBtnDown_Stereonet;
                _pItPolygon = null;
            }
            DrawingComplete(PbHander);
            if (PbHander == "LineNew")
            {
                sgworld.OnLButtonDown -= OnLBtnDown_LineNew;
            }
            if (PbHander == "RegionNew")
            {
                sgworld.OnLButtonDown -= OnLBtnDown_RegionNew;
            }


            StatusSystem.Text = @"系统状态：【就绪】";
            sgworld.OnRButtonDown -= OnRBtnDown_DrawingComplete;
            PbHander = string.Empty;
            IsSaved = false;
            Text = db.GCName + @"* - FieldGeo3D";
            return true;
        }

        /// <summary>
        /// 地质点
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingSpot(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingSpot;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {

                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingSpotGuid = db.SkyFrmSJLYEdit("DZD", kzdList);

            var thisLoggingSpot = db.SkyGetGeoDataList(thisLoggingSpotGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingSpot == null)
            {
                return true;
            }
            var thisSpot = new LoggingSpot(thisLoggingSpot, ref sgworld);
            return true;
        }

        /// <summary>
        /// 钻探
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingBore(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingBore;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingBoreGuid = db.SkyFrmSJLYEdit("ZT", kzdList);

            var thisLoggingBore = db.SkyGetGeoDataList(thisLoggingBoreGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingBore == null)
            {
                return true;
            }
            var thisBore = new LoggingBore(thisLoggingBore, ref sgworld);
            return true;
        }

        /// <summary>
        /// 硐探
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingFootrill(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingFootrill;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingFootrillGuid = db.SkyFrmSJLYEdit("DT", kzdList);

            var thisLoggingFootrill = db.SkyGetGeoDataList(thisLoggingFootrillGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingFootrill == null)
            {
                return true;
            }
            var thisFootrill = new LoggingFootrill(thisLoggingFootrill, ref sgworld);
            return true;
        }

        /// <summary>
        /// 坑探
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingPit(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingPit;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingPitGuid = db.SkyFrmSJLYEdit("KT", kzdList);

            var thisLoggingPit = db.SkyGetGeoDataList(thisLoggingPitGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingPit == null)
                return true;
            var thisPit = new LoggingPit(thisLoggingPit, ref sgworld);
            return true;
        }

        /// <summary>
        /// 井探
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingWell(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingWell;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingWellGuid = db.SkyFrmSJLYEdit("JT", kzdList);

            var thisLoggingWell = db.SkyGetGeoDataList(thisLoggingWellGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingWell == null)
                return true;
            var thisWell = new LoggingWell(thisLoggingWell, ref sgworld);

            return true;
        }

        /// <summary>
        /// 槽探
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingTrench(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingTrench;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingTrenchGuid = db.SkyFrmSJLYEdit("CT", kzdList);

            var thisLoggingTrench = db.SkyGetGeoDataList(thisLoggingTrenchGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingTrench == null)
                return true;
            var thisTrench = new LoggingTrench(thisLoggingTrench, ref sgworld);

            return true;
        }

        /// <summary>
        /// 边坡
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingSlope(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingSlope;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingSlopeGuid = db.SkyFrmSJLYEdit("BPBL", kzdList);

            var thisLoggingSlope = db.SkyGetGeoDataList(thisLoggingSlopeGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingSlope == null)
                return true;
            var thisSlope = new LoggingSlope(thisLoggingSlope, ref sgworld);

            return true;
        }

        /// <summary>
        /// 洞室
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingCavity(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingCavity;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };
            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingCavityGuid = db.SkyFrmSJLYEdit("DSBL", kzdList);

            var thisLoggingCavity = db.SkyGetGeoDataList(thisLoggingCavityGuid).GetObjData(0);
            StatusSystem.Text = @"系统状态：【就绪】";
            if (thisLoggingCavity == null)
                return true;
            var thisCavity = new LoggingCavity(thisLoggingCavity, ref sgworld);

            return true;
        }

        /// <summary>
        /// 基础
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_LoggingFoundation(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
            sgworld.OnLButtonDown -= OnLBtnDown_LoggingFoundation;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            var top = new DMarker
            {
                X = _cWorldPointInfo.Position.X,
                Y = _cWorldPointInfo.Position.Y,
                Z = _cWorldPointInfo.Position.Altitude,
                SD = 0,
                DZDXLX = "KZD"
            };

            var bottom = top;
            _cWorldPointInfo = null;
            var kzdList = new List<DMarker> { top, bottom };

            var thisLoggingFoundationGuid = db.SkyFrmSJLYEdit("JKBL", kzdList);

            var thisLoggingFoundation = db.SkyGetGeoDataList(thisLoggingFoundationGuid).GetObjData(0);
            if (thisLoggingFoundation == null)
                return true;
            var thisFoundation = new LoggingFoundation(thisLoggingFoundation, ref sgworld);
            StatusSystem.Text = @"系统状态：【就绪】";
            return true;
        }

        private bool OnLBtnDown_LineNew(int flags, int x, int y)
        {
            var pointList = new List<double>();

            if (_pITerrainPolyline == null)
            {
                //第一次点击
                _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);

                if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
                {
                    //假如不捕捉地质点
                    _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_TERRAIN);
                    pointList.Add(_cWorldPointInfo.Position.X);
                    pointList.Add(_cWorldPointInfo.Position.Y);
                    pointList.Add(_cWorldPointInfo.Position.Altitude);
                    pointList.Add(_cWorldPointInfo.Position.X);
                    pointList.Add(_cWorldPointInfo.Position.Y);
                    pointList.Add(_cWorldPointInfo.Position.Altitude);
                    _pITerrainPolyline = sgworld.Creator.CreatePolylineFromArray(pointList.ToArray(), _objInfo.LineColor.ToABGRColor(), AltitudeTypeCode.ATC_ON_TERRAIN, _objInfo.GroupId, _objInfo.Name);
                    sgworld.ProjectTree.ExpandGroup(_objInfo.GroupId, true);
                    _pITerrainPolyline.LineStyle.Width = 7.0;
                }
                else
                {
                    //捕捉地质点

                    var thisGuid = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];
                    _objInfo.ConnObjGuids.Add(thisGuid);

                    //这个很消耗性能。
                    //思考是否另建hash表，存储对应guid和点位置的对应关系，不通过数据库拿值。（在add DictOfSkyIdGuid同时，add几何点位置）
                    var thisObjPoint = LoggingObject.DictOfLoggingObjects[thisGuid].Top;

                    pointList.Add(thisObjPoint.X);
                    pointList.Add(thisObjPoint.Y);
                    pointList.Add(thisObjPoint.Z);
                    pointList.Add(thisObjPoint.X);
                    pointList.Add(thisObjPoint.Y);
                    pointList.Add(thisObjPoint.Z);
                    _pITerrainPolyline = sgworld.Creator.CreatePolylineFromArray(
                        pointList.ToArray(),
                        _objInfo.LineColor.ToABGRColor(),
                        AltitudeTypeCode.ATC_ON_TERRAIN,
                        _objInfo.GroupId,
                        this._objInfo.MarkerType + _objInfo.Name);
                    sgworld.ProjectTree.ExpandGroup(_objInfo.GroupId, true);
                    _pITerrainPolyline.LineStyle.Width = -3.0;
                }
            }

            else
            {
                //非第一次点击
                double dx, dy, dz;
                var cLineString = _pITerrainPolyline.Geometry as ILineString;
                _pITerrainPolyline.Geometry.StartEdit();
                _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);


                if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
                {
                    //不捕捉地质点
                    dx = _cWorldPointInfo.Position.X;
                    dy = _cWorldPointInfo.Position.Y;
                    dz = _cWorldPointInfo.Position.Altitude;
                }
                else
                {
                    //捕捉地质点
                    var thisGuid = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];
                    _objInfo.ConnObjGuids.Add(thisGuid);
                    var thisObjPoint = LoggingObject.DictOfLoggingObjects[thisGuid].Top;
                    dx = thisObjPoint.X;
                    dy = thisObjPoint.Y;
                    dz = thisObjPoint.Z;
                }
                cLineString?.Points.AddPoint(dx, dy, dz);
                var editedGeometry = _pITerrainPolyline.Geometry.EndEdit();
                _pITerrainPolyline.Geometry = editedGeometry;
            }
            return false;
        }


        /// <summary>
        /// 画区域
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_RegionNew(int flags, int x, int y)
        {
            var pointList = new List<double>();
            if (_pItPolygon == null)
            {
                //第一次画线
                _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);

                if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
                {
                    MessageBox.Show(@"请点击地质点的文字标签。", @"地质点捕捉失败");
                    return false;
                }
                var thisGuid = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];
                _objInfo.ConnObjGuids.Add(thisGuid);

                var thisObjPoint = LoggingObject.DictOfLoggingObjects[thisGuid].Top;

                pointList.Add(thisObjPoint.X);
                pointList.Add(thisObjPoint.Y);
                pointList.Add(thisObjPoint.Z);

                pointList.Add(thisObjPoint.X);
                pointList.Add(thisObjPoint.Y);
                pointList.Add(thisObjPoint.Z);

                pointList.Add(thisObjPoint.X);
                pointList.Add(thisObjPoint.Y);
                pointList.Add(thisObjPoint.Z);

                pointList.Add(thisObjPoint.X);
                pointList.Add(thisObjPoint.Y);
                pointList.Add(thisObjPoint.Z);

                _pItPolygon = sgworld.Creator.CreatePolygonFromArray(
                    pointList.ToArray(),
                    _objInfo.LineColor.ToABGRColor(),
                    _objInfo.FillColor.ToABGRColor(),
                    AltitudeTypeCode.ATC_ON_TERRAIN,
                    _objInfo.GroupId,
                    this._objInfo.MarkerType + _objInfo.Name);
                sgworld.ProjectTree.ExpandGroup(_objInfo.GroupId, true);
                _pItPolygon.LineStyle.Width = 7.0;
            }
            else
            {
                //非第一次画线
                var polygonGeometry = _pItPolygon.Geometry as IPolygon;
                if (polygonGeometry == null) return false;

                //捕捉地质点，获取坐标
                _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);
                if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
                {
                    MessageBox.Show(@"请点击地质点的文字标签。", @"地质点捕捉失败");
                    return false;
                }
                var thisGuid = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];
                _objInfo.ConnObjGuids.Add(thisGuid);
                var thisObjPoint = LoggingObject.DictOfLoggingObjects[thisGuid].Top;

                //开始编辑polygon
                polygonGeometry.StartEdit();
                foreach (ILinearRing ring in polygonGeometry.Rings)
                {
                    var dx = thisObjPoint.X;
                    var dy = thisObjPoint.Y;
                    var dz = thisObjPoint.Z;
                    ring.Points.AddPoint(dx, dy, dz);
                    //ring.Points.DeletePoint(0);
                }

                //结束编辑，保存polygon
                var editedGeometry = polygonGeometry.EndEdit();
                _pItPolygon.Geometry = editedGeometry;

            }
            return false;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_Query(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);
            if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
            {
                ToastNotification.Show(this, "未能查询到您所选取的地质对象。请选取地质对象的文字标签！", 2500, eToastPosition.MiddleCenter);
                _cWorldPointInfo = null;
                sgworld.OnLButtonDown -= OnLBtnDown_Query;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";

                return true;
            }
            var thisGuid = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];

            db.SkyFrmSJLYEdit(db.SkyGetSJLYMDL(thisGuid).SJLYLXID, new List<DMarker>(), thisGuid);

            IObjDataList abc = db.SkyGetGeoDataList(thisGuid);
            string str = abc.GetObjData(0).Type;
            _cWorldPointInfo = null;
            sgworld.OnLButtonDown -= OnLBtnDown_Query;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            StatusSystem.Text = @"系统状态：【就绪】";
            return true;
        }

        private bool OnLBtnDown_DeleteLoggingSpot(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);
            if (LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
            {

                var guidToBeDeleted = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];

                LoggingObject.DictOfLoggingObjects[guidToBeDeleted].Erase(ref sgworld);
                // 询问是否删除数据库中对应记录？
                var dlgResult = MessageBoxEx.Show("是否删除数据库对应记录？", "警告", MessageBoxButtons.YesNo);
                if (dlgResult == DialogResult.Yes)
                {
                    db.SkyDeleteSjly(guidToBeDeleted);
                }

            }
            else if (DrawingObject.DictOfSkyIdDrawingObjects.ContainsKey(this._cWorldPointInfo.ObjectID))
            {
                var guidToBeDeleted = DrawingObject.DictOfSkyIdDrawingObjects[_cWorldPointInfo.ObjectID].Guid;

                DrawingObject.DictOfSkyIdDrawingObjects[_cWorldPointInfo.ObjectID].Erase(ref this.sgworld);


            }
            else
            {
                MessageBoxEx.Show(@"当前选择无效，请选择地质点的文字标签！", @"删除地质对象失败");
            }

            sgworld.OnLButtonDown -= OnLBtnDown_DeleteLoggingSpot;
            this._cWorldPointInfo = null;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            StatusSystem.Text = @"系统状态：【就绪】";
            return true;


        }

        /// <summary>
        /// 选择当前工作对象（数据来源类型）
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool OnLBtnDown_SelectWorkingObj(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);
            if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(_cWorldPointInfo.ObjectID))
            {
                MessageBox.Show(@"当前选择无效，请选择地质对象文字标签！", @"选择地质对象失败");
                sgworld.OnLButtonDown -= OnLBtnDown_SelectWorkingObj;
                sgworld.OnRButtonDown -= OnRBtnDown_SelectWorkingObj;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                return true;
            }
            if (_currWorkingObjGuid != null)
            {
                if (LoggingObject.DictOfLoggingObjects.ContainsKey(_currWorkingObjGuid))
                {
                    LoggingObject.DictOfLoggingObjects[_currWorkingObjGuid].ResetLabel(ref sgworld);
                }
                StatusWorkingObj.Text = @"当前选定对象：【选定中】";
                _currWorkingObjGuid = null;
            }
            _currWorkingObjGuid = LoggingObject.DictOfSkyIdGuid[_cWorldPointInfo.ObjectID];
            StatusWorkingObj.Text = $"当前选定对象：【类型代号：{db.SkyGetSJLYMDL(_currWorkingObjGuid).SJLYLXID}；编号：{db.SkyGetSJLYMDL(_currWorkingObjGuid).BH}】";
            LoggingObject.DictOfLoggingObjects[_currWorkingObjGuid].HighlightLabel(ref sgworld);

            sgworld.OnLButtonDown -= OnLBtnDown_SelectWorkingObj;
            sgworld.OnRButtonDown -= OnRBtnDown_SelectWorkingObj;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            StatusSystem.Text = @"系统状态：【就绪】";
            return true;
        }

        private void ResetSelectWorkingObj()
        {
            StatusWorkingObj.Text = @"当前选定对象：【无】";
            if (!string.IsNullOrEmpty(_currWorkingObjGuid))
            {
                if (LoggingObject.DictOfLoggingObjects.ContainsKey(_currWorkingObjGuid))
                {
                    LoggingObject.DictOfLoggingObjects[_currWorkingObjGuid].ResetLabel(ref sgworld);
                }
                _currWorkingObjGuid = null;
            }

            sgworld.OnLButtonDown -= OnLBtnDown_SelectWorkingObj;
            sgworld.OnRButtonDown -= OnRBtnDown_SelectWorkingObj;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            StatusSystem.Text = @"系统状态：【就绪】";
        }

        private bool OnRBtnDown_SelectWorkingObj(int flags, int x, int y)
        {
            ResetSelectWorkingObj();
            return true;
        }

        /*
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
        */

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
                var cLabelStyle = sgworld.Creator.CreateLabelStyle();
                cLabelStyle.MultilineJustification = "Center";
                cLabelStyle.LineColor = sgworld.Creator.CreateColor(0, 0, 0, 255);
                cLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
                cLabelStyle.TextAlignment = "Bottom, Center";
                var cLabel = sgworld.Creator.CreateTextLabel(_pITerrainPolyline.Position, _objInfo.Name, cLabelStyle,
                    sgworld.ProjectTree.HiddenGroupID, string.Empty);
                var cLine = new DrawingLine(_pITerrainPolyline, cLabel, _objInfo.MarkerType, new List<string>());
                cLine.Store(_currWorkingObjGuid, ref db);
            }
            _pITerrainPolyline = null;
            _objInfo = null;
            ResetButton(btnDeleteSpot);

            PbHander = string.Empty;
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
            if (isBtnDrawingApplyUsed)
            {
                btnDrawingComplete.FontBold = false;
                btnDrawingComplete.ForeColor = Color.Black;
            }
        }






        #endregion

        private void timerGPSReader_Tick(object sender, EventArgs e)
        {
            _gpsController.TimeCountDown = _gpsController.TimeCountDown.Subtract(new TimeSpan(0, 0, 1));
        }


        private void btnPlaneViaSpot_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                HighlightButton(this.btnPlaneViaSpot, true);

                StatusSystem.Text = @"系统状态：【地点推面】";
                ToastNotification.Show(this, "请选择地质曲面的基点", 2500, eToastPosition.MiddleCenter);
                sgworld.OnLButtonDown += OnLBtnDown_PlaneViaSpot;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }


        private bool OnLBtnDown_PlaneViaSpot(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);

            // 
            if (!LoggingObject.DictOfSkyIdGuid.ContainsKey(this._cWorldPointInfo.ObjectID))
            {
                ToastNotification.Show(this, "未能获取到您所选取的地质点。请选取地质点的文字标签！", 2500, eToastPosition.MiddleCenter);
                _cWorldPointInfo = null;
                sgworld.OnLButtonDown -= OnLBtnDown_PlaneViaSpot;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                ResetButton(this.btnPlaneViaSpot);
                return true;
            }

            var thisGuid = LoggingObject.DictOfSkyIdGuid[this._cWorldPointInfo.ObjectID];
            var thisLoggingObj = LoggingObject.DictOfLoggingObjects[thisGuid];
            Point rootPoint = new Point(thisLoggingObj.Top);
            FrmPlaneViaSpotOrLine frmPlaneViaSpot = new FrmPlaneViaSpotOrLine("Spot", rootPoint.X, rootPoint.Y, rootPoint.Z);
            DialogResult dlgResult = frmPlaneViaSpot.ShowDialog();
            if (dlgResult != DialogResult.OK)
            {
                _cWorldPointInfo = null;
                sgworld.OnLButtonDown -= OnLBtnDown_PlaneViaSpot;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                ResetButton(this.btnPlaneViaSpot);
                return true;
            }

            Plane plane = new Plane(rootPoint, 0, frmPlaneViaSpot.Dip, frmPlaneViaSpot.Angle, thisLoggingObj.Name); // 默认深度为0

            IColor66 lineColor = this.sgworld.Creator.CreateColor();
            IColor66 fillColor = this.sgworld.Creator.CreateColor(
                frmPlaneViaSpot.PickedColor.R,
                frmPlaneViaSpot.PickedColor.G,
                frmPlaneViaSpot.PickedColor.B,
                128);

            // 需要做投影圆的判断！？！？

            plane.DrawOnSkyline(
                ref this.sgworld,
                frmPlaneViaSpot.Length * Math.Sqrt(2),
                frmPlaneViaSpot.Length * Math.Sqrt(2),
                lineColor,
                fillColor);

            //IGeometry pGeo = plane.skyPlane.Geometry;
            //IGeometry tGeo = TerrainPolygon.Geometry;

            //try
            //{
            //    IGeometry intersecGeo = pGeo.SpatialOperator.Intersection(tGeo);
            //    if (intersecGeo == null) MessageBox.Show("空");
            //    MessageBox.Show(intersecGeo.GeometryTypeStr);
            //    string s = intersecGeo.Wks.ExportToWKT();
            //    MessageBox.Show(s);
            //    var intersecPoints = this.sgworld.Creator.CreatePolygon(intersecGeo);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            _cWorldPointInfo = null;
            sgworld.OnLButtonDown -= OnLBtnDown_PlaneViaSpot;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            StatusSystem.Text = @"系统状态：【就绪】";
            ResetButton(this.btnPlaneViaSpot);
            return true;

        }

        private void btnPlaneViaLine_Click(object sender, EventArgs e)
        {
            if (!this._isDbConnected)
            {
                ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.MiddleCenter);
                return;
            }

            try
            {
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                HighlightButton(this.btnPlaneViaLine, true);

                StatusSystem.Text = @"系统状态：【地线推面】";
                ToastNotification.Show(this, "请选择地质曲面的基线", 2500, eToastPosition.MiddleCenter);
                sgworld.OnLButtonDown += OnLBtnDown_PlaneViaLine;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }
        }


        /// <summary>
        /// 块体分析 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStereonet_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("是否圈选边坡", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //if (!_isDbConnected)
                //{
                //    ToastNotification.Show(this, "请先连接数据库", 2500, eToastPosition.BottomCenter);
                //    return;
                //}
                try
                {
                    selectedPointInStereonet = new List<FrmStereonet.DataFromMain>();
                    sgworld.Window.SetInputMode((MouseInputMode.MI_COM_CLIENT));
                    HighlightButton(btnStereonet, true);
                    PbHander = "Stereonet";
                    StatusSystem.Text = @"系统状态：【块体分析】";
                    ToastNotification.Show(this, "请选择待分析区域", 2500, eToastPosition.MiddleCenter);
                    sgworld.OnLButtonDown += OnLBtnDown_Stereonet;
                }
                catch (Exception ex)
                {
                    ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500,
                        eToastPosition.MiddleCenter);
                }
            }
            else if (dr == DialogResult.No)
            {
                Stereonet.FrmStereonet newStereonet = new FrmStereonet();
                newStereonet.Show();
            }

        }


        private bool OnLBtnDown_Stereonet(int flags, int x, int y)
        {
            var pointList = new List<double>();
            

          
            if (_pItPolygon == null)
            {
                _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);
                vertexOfStereonet.Add(new Point(_cWorldPointInfo.Position.X, _cWorldPointInfo.Position.Y, 0)); // 加到边坡顶点列表

                firstPoint = _cWorldPointInfo;
                _startOfStereonet = firstPoint.ObjectID;



                pointList.Add(firstPoint.Position.X);
                pointList.Add(_cWorldPointInfo.Position.Y);
                pointList.Add(_cWorldPointInfo.Position.Altitude);

                pointList.Add(_cWorldPointInfo.Position.X);
                pointList.Add(_cWorldPointInfo.Position.Y);
                pointList.Add(_cWorldPointInfo.Position.Altitude);

                pointList.Add(_cWorldPointInfo.Position.X);
                pointList.Add(_cWorldPointInfo.Position.Y);
                pointList.Add(_cWorldPointInfo.Position.Altitude);

                pointList.Add(_cWorldPointInfo.Position.X);
                pointList.Add(_cWorldPointInfo.Position.Y);
                pointList.Add(_cWorldPointInfo.Position.Altitude);


                _pItPolygon = sgworld.Creator.CreatePolygonFromArray(
                    pointList.ToArray(),
                   sgworld.Creator.CreateColor(255, 255, 255, 255).ToABGRColor(),
                    sgworld.Creator.CreateColor(0, 0, 255, 128).ToABGRColor(),
                    AltitudeTypeCode.ATC_ON_TERRAIN, "", sgworld.ProjectTree.HiddenGroupID);

                _pItPolygon.LineStyle.Width = 7.0;

                //给第一个点设标志
                IPosition66 cPos = sgworld.Creator.CreatePosition(_cWorldPointInfo.Position.X, _cWorldPointInfo.Position.Y, _cWorldPointInfo.Position.Altitude, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE);

                //绘制旗子
                var imageFileName = Path.Combine(Directory.GetCurrentDirectory(), "flag.png");

                var flag = sgworld.Creator.CreateImageLabel(cPos, imageFileName, null, sgworld.ProjectTree.HiddenGroupID, null);
                _startOfStereonet = flag.ID;

            }
            else
            {
                //非第一次画线
                var polygonGeometry = _pItPolygon.Geometry as IPolygon;
                
                if (polygonGeometry == null) return false;

                //捕捉地质点，获取坐标
                _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_LABEL);

                vertexOfStereonet.Add(new Point(_cWorldPointInfo.Position.X, _cWorldPointInfo.Position.Y, 0));  // 加到边坡顶点列表


                if (_startOfStereonet == _cWorldPointInfo.ObjectID)          // 捕捉地质点要通过 ID
                {
                   
                    sgworld.ProjectTree.DeleteItem(_cWorldPointInfo.ObjectID);
                    sgworld.ProjectTree.DeleteItem(_pItPolygon.ID);
                    string str = _cWorldPointInfo.ObjectID;
                    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                    sgworld.OnLButtonDown -= OnLBtnDown_Stereonet;
                    _pItPolygon = null;
                    DrawingComplete(PbHander);
                }
                else
                {
                    //开始编辑polygon
                    polygonGeometry.StartEdit();
                    foreach (ILinearRing ring in polygonGeometry.Rings)
                    {
                        var dx = _cWorldPointInfo.Position.X;
                        var dy = _cWorldPointInfo.Position.Y;
                        var dz = _cWorldPointInfo.Position.Altitude;
                        ring.Points.AddPoint(dx, dy, dz);
                    }

                    //结束编辑，保存polygon
                    var editedGeometry = polygonGeometry.EndEdit();
                   
                    _pItPolygon.Geometry = editedGeometry;
                }
            }
            return false;

        }

        private bool OnLBtnDown_PlaneViaLine(int flags, int x, int y)
        {
            _cWorldPointInfo = sgworld.Window.PixelToWorld(x, y, WorldPointType.WPT_DEFAULT);


            // 若捕捉失败
            if (!DrawingObject.DictOfSkyIdDrawingObjects.ContainsKey(_cWorldPointInfo.ObjectID))
            {
                ToastNotification.Show(this, "未能获取到您所选取的地质线。请选取地质对象的本体或文字标签！", 2500, eToastPosition.MiddleCenter);
                _cWorldPointInfo = null;
                sgworld.OnLButtonDown -= OnLBtnDown_PlaneViaLine;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                StatusSystem.Text = @"系统状态：【就绪】";
                ResetButton(this.btnPlaneViaLine);
                return true;
            }

            var thisDrawingObj = DrawingObject.DictOfSkyIdDrawingObjects[this._cWorldPointInfo.ObjectID];

            var thisDrawingLine = thisDrawingObj as DrawingLine;
            if (thisDrawingLine != null)
            {
                List<Point> vertexList = thisDrawingLine.GetPointsList();
                List<Point> pointsList;
                // 判断线是否闭合
                if (thisDrawingLine.IsRing())
                {
                    // 若是闭合线环

                    // 弹出窗口，输入中心深度和网格密度
                    FrmPlaneViaRing frmPlaneViaLine = new FrmPlaneViaRing();
                    var frmDialogResult = frmPlaneViaLine.ShowDialog();
                    if (frmDialogResult != DialogResult.OK)
                    {
                        return true;
                    }
                    double depth = frmPlaneViaLine.depth;
                    double interval = frmPlaneViaLine.interval;

                    // 在线环内加密点
                    pointsList = GeoHelper.InsertPointsInPolygon(vertexList, interval);

                    // 划分三角网，插值函数，插值得到Z
                    Triangulations tris = new Triangulations(pointsList, vertexList);


                    CurveAlgorithm.sgworld = this.sgworld;


                    StatusSystem.Text = @"系统状态：【计算曲面中...】";


                    tris.MeshRing(depth, CurveAlgorithm.CalcZinPlaneViaRing);

                    StatusSystem.Text = @"系统状态：【绘制曲面中...】";

                    // 绘制曲面
                    IColor66 fillColor = this.sgworld.Creator.CreateColor(
                        frmPlaneViaLine.PickedColor.R,
                        frmPlaneViaLine.PickedColor.G,
                        frmPlaneViaLine.PickedColor.B,
                        128);
                    IColor66 lineColor = this.sgworld.Creator.CreateColor(255, 255, 255, 0);

                    var parentGid = GeoHelper.CreateGroup("闭合地质曲面", ref this.sgworld);

                    Facet facet = new Facet(ref this.sgworld, tris.TsData, thisDrawingObj.Name, parentGid, lineColor, fillColor);
                    facet.DrawFacet();              // 优化速度！

                    StatusSystem.Text = @"系统状态：【曲面绘制完毕】";

                    // 保存三角网结果
                    TsFile ts = new TsFile(tris.TsData, "TSurf", "M", thisDrawingObj.MarkerType, thisDrawingObj.Name, thisDrawingObj.ConnObjGuids);
                    ts.WriteTsFile();
                    ts.UpdateTsFile(ref this.db);

                    ToastNotification.Show(this, "曲面模型已保存为模型部件", 2500, eToastPosition.MiddleCenter);
                }
                else
                {
                    // 开放线
                    Point midPoint = thisDrawingLine.MidPoint();
                    List<Point> terrainPointsList = thisDrawingLine.GetPointsList();
                    FrmPlaneViaSpotOrLine frmPlaneViaLine = new FrmPlaneViaSpotOrLine("Line", midPoint.X, midPoint.Y, midPoint.Z);
                    var frmDialogResult = frmPlaneViaLine.ShowDialog();
                    if (frmDialogResult != DialogResult.OK)
                    {
                        return true;
                    }

                    double length = frmPlaneViaLine.Length;
                    double dip = frmPlaneViaLine.Dip;
                    double angle = frmPlaneViaLine.Angle;
                    double deltaX = length * Math.Sin(dip * Math.PI / 180);
                    double deltaY = length * Math.Cos(dip * Math.PI / 180);
                    double deltaZ = -length * Math.Tan(angle * Math.PI / 180);

                    List<Point> undergroundPointsList = new List<Point>(terrainPointsList.Capacity);
                    foreach (var tp in terrainPointsList)
                    {
                        Point up = new Point(tp.X + deltaX, tp.Y + deltaY, tp.Z + deltaZ);
                        undergroundPointsList.Add(up);
                    }

                    IColor66 color = this.sgworld.Creator.CreateColor(
                        frmPlaneViaLine.PickedColor.R,
                        frmPlaneViaLine.PickedColor.G,
                        frmPlaneViaLine.PickedColor.B,
                        128);

                    var parentGid = GeoHelper.CreateGroup("产状平面", ref sgworld);
                    var gid = this.sgworld.ProjectTree.CreateLockedGroup(thisDrawingLine.Name, parentGid);

                    for (int i = 0; i < terrainPointsList.Count - 1; ++i)
                    {
                        List<double> verticesList = new List<double>();
                        verticesList.AddRange(
                            new[] { terrainPointsList[i].X, terrainPointsList[i].Y, terrainPointsList[i].Z });
                        verticesList.AddRange(
                            new[] { terrainPointsList[i + 1].X, terrainPointsList[i + 1].Y, terrainPointsList[i + 1].Z });
                        verticesList.AddRange(
                            new[] { undergroundPointsList[i + 1].X, undergroundPointsList[i + 1].Y, undergroundPointsList[i + 1].Z });
                        verticesList.AddRange(
                            new[] { undergroundPointsList[i].X, undergroundPointsList[i].Y, undergroundPointsList[i].Z });

                        this.sgworld.Creator.CreatePolygonFromArray(verticesList.ToArray(), color, color, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE, gid, "产状面#" + i);
                    }

                }
            }

            _cWorldPointInfo = null;
            sgworld.OnLButtonDown -= OnLBtnDown_PlaneViaLine;
            sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
            StatusSystem.Text = @"系统状态：【就绪】";
            ResetButton(this.btnPlaneViaLine);
            return true;
        }

        private void switchButtonUnderground_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                sgworld.Navigate.UndergroundMode = this.switchButtonUnderground.Value;
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, ex.Message == "MPT not loaded" ? "请先打开三维地形场景" : ex.Message, 2500, eToastPosition.MiddleCenter);
            }

        }

        private void buttonXSlopeDrawing_Click(object sender, EventArgs e)
        {
            drawParameter para = new drawParameter();

            FrmDrawEx frmDrawEx = new FrmDrawEx();
            var drawDlg = frmDrawEx.ShowDialog();
        }


    }
}
