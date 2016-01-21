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

namespace FGeo3D_TE
{
    public partial class FrmMain : Form
    {
        string tProjectUrl;
        SGWorld65 sgworld = new SGWorld65();

        

        ITerrainPolygon65 pITPolygon = null;
        ITerrainPolyline65 pITerrainPolyline = null;
        //ILineString pSectionptString = null;
        //ITerrain3DPolygon65 pIT3DPolygon = null;
        //double[] arrContourMapVertices = new double[4];
        //ObjProperty objProperty;
        private GeoObject GeoObj;
        //List<double> lArrPoints = new List<double>();
        //List<double> ListVerticsArray = new List<double>();
        
        //sgworld.OnLButtonDown += new _ISGWorld65Events_OnLButtonDownEventHandler(sgworld_OnLButtonDown);
        //sgworld.OnRButtonDown += new _ISGWorld65Events_OnRButtonDownEventHandler(sgworld_OnRButtonDown);
        
        //private struct ObjProperty
        //{
        //    public String Name;
        //    public IColor65 LineColor;
        //    public IColor65 FillColor;
        //};

        public double XLeft { get; private set; }
        public double XRight { get; private set; }
        public double YTop { get; private set; }
        public double YBottom { get; private set; }



        private string _pbhander = "";
        private bool _isPbHanderChanged = false;
        public string PbHander
        {
            get { return _pbhander; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _isPbHanderChanged = false || value != _pbhander;
                _pbhander = value;
                if (_isPbHanderChanged)
                {
                    //WhenPBHanderChange();
                }
            }
        }

        private bool _isSaved = true;
        private bool _isIsSavedChanged = false;
        public bool IsSaved
        {
            get { return _isSaved; }
            set
            {
                _isIsSavedChanged = false || value != _isSaved;
                _isSaved = value;
                if (_isIsSavedChanged)
                {
                    //WhenIsSavedChange();
                }
            }
        }

        

        public FrmMain()
        {
            InitializeComponent();
            Init();
        }

        //自定义构造函数
        private void Init()
        {
            
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
            sgworld = new SGWorld65();
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
                MessageBox.Show(@"保存成功！");
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

            //sgworld = new SGWorld65();
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
        private void btnTag_Click(object sender, EventArgs e)
        {
            //sgworld.Command.Execute(1012, 0);
            
            try
            {
                btnTag.FontBold = true;
                btnTag.ForeColor = Color.Red;
                btnTag.Checked = true;
                
                PbHander = "GeoTag";
                GeoObj = new GeoObject(PbHander, ref sgworld);
                sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                sgworld.OnRButtonDown += sgworld_OnRButtonDown;
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
                btnGeoPoint.FontBold = true;
                btnGeoPoint.ForeColor = Color.Red;
                btnGeoPoint.Checked = true;
                
                PbHander = "GeoPoint";
                GeoObj = new GeoObject(PbHander, ref sgworld) {GroupID = CreateGroup("地质点")};
                if(GeoObj.IsGeoPointTakenFromMap)
                {
                    sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                    sgworld.OnRButtonDown += sgworld_OnRButtonDown;
                    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
                }
                else
                {
                    if (GeoObj.GeoPointPos != null)
                    {
                        GeoObj.GeoPointGeometry = CreateGeoPoint(GeoObj.GeoPointPos, GeoObj.GroupID, GeoObj.Name); 	
                    }
                    btnGeoPoint.FontBold = false;
                    btnGeoPoint.ForeColor = Color.Black;
                    btnGeoPoint.Checked = false; 
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
                btnGeoLine.FontBold = true;
                btnGeoLine.ForeColor = Color.Red;
                btnGeoLine.Checked = true;
                btnDrawingApply.FontBold = true;
                btnDrawingApply.ForeColor = Color.Green;
                PbHander = "GeoLine";
                GeoObj = new GeoObject(PbHander, ref sgworld);
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
                btnGeoRegion.FontBold = true;
                btnGeoRegion.ForeColor = Color.Red;
                btnGeoRegion.Checked = true;
                btnDrawingApply.FontBold = true;
                btnDrawingApply.ForeColor = Color.Green;
                PbHander = "GeoRegion";
                GeoObj = new GeoObject(PbHander, ref sgworld);
                sgworld.OnLButtonDown += sgworld_OnLButtonDown;
                sgworld.OnRButtonDown += sgworld_OnRButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("GeometryPolygon_Click Exception: {0}", ex.Message));
            }
        }

        private void btnDrawingApply_Click(object sender, EventArgs e)
        {
            #region 地质标签
            //if (pbhander == "GeoTag")
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
            if (PbHander == "GeoLine")
            {
                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (GeoObj != null)
                {
                    GeoObj.ObjGeometry = pITerrainPolyline.Geometry;
                    GeoObj.ObjectID = pITerrainPolyline.ID;
                }
                pITerrainPolyline = null;
                GeoObj = null;

                btnGeoLine.FontBold = false;
                btnGeoLine.ForeColor = Color.Black;
                btnDrawingApply.FontBold = false;
                btnDrawingApply.ForeColor = Color.Black;
                btnGeoLine.Checked = false;
            }
            #endregion

            #region 地质区域
            if (PbHander == "GeoRegion")
            {
                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (GeoObj != null)
                {
                    GeoObj.ObjGeometry = pITPolygon.Geometry;
                    GeoObj.ObjectID = pITPolygon.ID;
                }
                pITPolygon = null;
                GeoObj = null;
                btnGeoRegion.FontBold = false;
                btnGeoRegion.ForeColor = Color.Black;
                btnDrawingApply.FontBold = false;
                btnDrawingApply.ForeColor = Color.Black;
                btnGeoRegion.Checked = false;
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
            //if (PbHander == "CreateContourMap")
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

        private void btnLocate_Click(object sender, EventArgs e)
        {
            var frmPosition = new FrmPosition(XLeft,XRight,YTop,YBottom);
            if (frmPosition.ShowDialog() != DialogResult.OK) return;
            var cPos = sgworld.Creator.CreatePosition(frmPosition.XLong, frmPosition.YLat, 800, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, -90, 0, 0);
            sgworld.Navigate.FlyTo(cPos);
        }

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
            sgworld.Command.Execute(1165, 0);
        }
        #endregion


        private void btnTest_Click(object sender, EventArgs e)
        {
            
            //MessageBox.Show(sgworld.Command.CanExecute(1149,25).ToString());
        }

        //右键 - 作废
        bool sgworld_OnRButtonDown(int Flags, int X, int Y)
        {
            #region 地质标签
            //if (pbhander == "GeoTag")
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
            if (PbHander == "GeoLine")
            {
                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (GeoObj != null)
                {
                    GeoObj.ObjGeometry = pITerrainPolyline.Geometry;
                    GeoObj.ObjectID = pITerrainPolyline.ID;
                }
                pITerrainPolyline = null;
                GeoObj = null;

                btnGeoLine.FontBold = false;
                btnGeoLine.ForeColor = Color.Black;
                btnDrawingApply.FontBold = false;
                btnDrawingApply.ForeColor = Color.Black;
                btnGeoLine.Checked = false;
            }
            #endregion

            #region 地质区域
            if (PbHander == "GeoRegion")
            {
                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (GeoObj != null)
                {
                    GeoObj.ObjGeometry = pITPolygon.Geometry;
                    GeoObj.ObjectID = pITPolygon.ID;
                }
                pITPolygon = null;
                GeoObj = null;
                btnGeoRegion.FontBold = false;
                btnGeoRegion.ForeColor = Color.Black;
                btnDrawingApply.FontBold = false;
                btnDrawingApply.ForeColor = Color.Black;
                btnGeoRegion.Checked = false;
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
            //if (PbHander == "CreateContourMap")
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

            sgworld.OnRButtonDown -= sgworld_OnRButtonDown;
            PbHander = "";
            IsSaved = false;
            Text = tProjectUrl + @"* - FieldGeo3D";
            return true;
        }

        //左键
        bool sgworld_OnLButtonDown(int Flags, int X, int Y)
        {
            
            IWorldPointInfo65 pIWPInfo = sgworld.Window.PixelToWorld(X, Y, WorldPointType.WPT_TERRAIN); //真实位置信息
            IPosition65 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN); //视点位置信息（相机位置）

            //IPosition65 r_StartPosition = null, r_LastPosition;

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
            if (PbHander == "GeoTag")
            {
                var cPos = sgworld.Creator.CreatePosition(pIWPInfo.Position.X, pIWPInfo.Position.Y, 50, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0);
                GeoObj.GroupID = CreateGroup("标签");
                GeoObj.GeoLabel = sgworld.Creator.CreateTextLabel(cPos, GeoObj.Name, GeoObj.LabelStyle, GeoObj.GroupID, "Tag:" + GeoObj.Name);
                GeoObj.ObjectID = GeoObj.GeoLabel.ID;
                sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                btnTag.Checked = false;
                btnTag.FontBold = false;
                btnTag.ForeColor = Color.Black;
                
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                Text = tProjectUrl + @"* - FieldGeo3D";
                GeoObj = null;
            }
            #endregion

            #region 创建地质点
            if (PbHander == "GeoPoint")
            {
                if (GeoObj != null)
                {
                    GeoObj.GroupID = CreateGroup("地质点");
                
                    if(GeoObj.GeoPointGeometry == null)
                    {
                        GeoObj.GeoPointGeometry = CreateGeoPoint(pIWPInfo.Position, GeoObj.GroupID, GeoObj.Name);
                        sgworld.OnLButtonDown -= sgworld_OnLButtonDown;
                        sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                    }
                    btnGeoPoint.FontBold = false;
                    btnGeoPoint.ForeColor = Color.Black;
                    btnGeoPoint.Checked = false;
                    //Thread.Sleep(500);
                    Text = tProjectUrl + @"* - FieldGeo3D";
                }
                GeoObj = null;
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
                    if (GeoObj != null)
                    {
                        GeoObj.GroupID = CreateGroup("地质界线");
                        pITerrainPolyline = sgworld.Creator.CreatePolyline(cLineString, GeoObj.LineColor.ToABGRColor(), eAltitudeTypeCode, GeoObj.GroupID, GeoObj.Name);
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
                    var cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);
                    //cPolygonGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cRing, null);
                    
                    var eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;
                    if (GeoObj != null)
                    {
                        GeoObj.GroupID = CreateGroup("地质区域");
                        pITPolygon = sgworld.Creator.CreatePolygon(cRing, GeoObj.LineColor.ToABGRColor(), GeoObj.FillColor.ToABGRColor(), eAltitudeTypeCode, GeoObj.GroupID, GeoObj.Name);
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
                    }
                    var editedGeometry = polygonGeometry.EndEdit();
                    pITPolygon.Geometry = editedGeometry;
                }
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




        #region 其他方法

        private string CreateGroup(string groupName)
        {
            var gid = sgworld.ProjectTree.FindItem(groupName);
            if (!string.IsNullOrEmpty(gid))
            {
                return gid;
            }
            return sgworld.ProjectTree.CreateGroup(groupName);
        }


        //private IPosition65 InputPosition()
        //{
        //    IPosition65 retPos = null;
        //    var frmLocation = new frmPosition();
        //    if (frmLocation.ShowDialog() != DialogResult.OK) return retPos;
        //    var dX = double.Parse(frmLocation.tbX.Text);
        //    var dY = double.Parse(frmLocation.tbY.Text);
            
        //    retPos = sgworld.Creator.CreatePosition(dX, dY, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, -90, 0, 0);
        //    return retPos;
        //}

        



        private double MaxOf2(double a, double b)
        {
            var ret = a;
            if (a < b)
            {
                ret = b;
            }
            return ret;
        }

        private double MinOf2(double a, double b)
        {
            var ret = a;
            if (a > b)
            {
                ret = b;
            }
            return ret;
        }

        private ITerrainPolygon65 CreatePolygon3ps(IPosition65 p0, IPosition65 p1, IPosition65 p2)
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
            AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_TERRAIN_RELATIVE;
            ITerrainPolygon65 retPolygon = sgworld.Creator.CreatePolygon(cPolygonGeometry, nLineColor, nFillColor, eAltitudeTypeCode, "", "test3ps");


            return retPolygon;
        }


        private ITerrainSphere65 CreateGeoPoint(IPosition65 pos, string gid, string desc)
        {
            double radius = 10;
            var Style = SphereStyle.SPHERE_NORMAL;
            var nLineColor = 0xFF00FF00;
            var nFillColor = 0xFF646464;
            var SegmentDensity = -1;
            return sgworld.Creator.CreateSphere(pos, radius, Style, nLineColor, nFillColor, SegmentDensity, gid, desc);
        }

        #endregion


    }
}
