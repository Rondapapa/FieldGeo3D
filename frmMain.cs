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

namespace FGeo3D_TE
{
    public partial class frmMain : Form
    {
        string tProjectUrl;
        SGWorld65 sgworld = null;

        private String pbhander = "";
        private Boolean isPBHanderChanged = false;
        public String PBHander
        {
            get { return pbhander; }
            set
            {
                isPBHanderChanged = false;
                if (value != pbhander)
                {
                    isPBHanderChanged = true;
                }
                pbhander = value;
                if (isPBHanderChanged)
                {
                    //WhenPBHanderChange();
                }
            }
        }

        private Boolean isSaved = true;
        private Boolean isIsSavedChanged = false;
        public Boolean IsSaved
        {
            get { return isSaved; }
            set
            {
                isIsSavedChanged = false;
                if (value != isSaved)
                {
                    isIsSavedChanged = true;
                }
                isSaved = value;
                if (isIsSavedChanged)
                {
                    //WhenIsSavedChange();
                }
            }
        }

        //ITerrainPolygon65 pITPolygon = null;
        //ITerrainPolyline65 pITerrainPolyline = null;
        //ILineString pSectionptString = null;
        //ITerrain3DPolygon65 pIT3DPolygon = null;
        //double[] arrContourMapVertices = new double[4];
        //string gpgid;
        //ObjProperty objProperty;
        //List<double> lArrPoints = new List<double>();
        //List<double> ListVerticsArray = new List<double>();

        public frmMain()
        {
            InitializeComponent();
            Init();
            
        }

        private void Init()
        {
          	sgworld = new SGWorld65();
            //sgworld.OnLButtonDown += new _ISGWorld66Events_OnLButtonDownEventHandler(sgworld_OnLButtonDown);
            //sgworld.OnRButtonDown += new _ISGWorld66Events_OnRButtonDownEventHandler(sgworld_OnRButtonDown);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            // 设置工程中open 方法的参数
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D://";
            openFileDialog.Filter = "TE文件(*.fly)|*.fly|TB文件(*.mpt)|*.mpt|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tProjectUrl = openFileDialog.FileName;
                bool bIsAsync = false;
                string tUser = String.Empty;
                string tPassword = String.Empty;
                //MessageBox.Show(tProjectUrl);
                sgworld = new SGWorld65();
                sgworld.Project.Open(tProjectUrl, bIsAsync, tUser, tPassword);
                this.Text = tProjectUrl + " - FieldGeo3D";
                sgworld.CoordServices.SourceCoordinateSystem.InitLatLong();
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            try
            {
                sgworld.Project.Save();
                this.Text = tProjectUrl + " - FieldGeo3D";
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                tMsg = ex.Message;
                MessageBox.Show("Save_Click Exception: {0}", tMsg);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TE文件(*.fly)|*.fly";
            saveFileDialog.Title = "另存为";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                string localFilePath = saveFileDialog.FileName.ToString();

                //获取文件名，不带路径  
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

                //sgworld = new SGWorld65();
                sgworld.Project.SaveAs(fileNameExt);
                //sgworld.ProjectTree.SaveAsFly(fileNameExt, gpgid);

                //string path = "C:\\Users\\lmc\\AppData\\Roaming\\Skyline\\TerraExplorer\\" + fileNameExt;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Skyline\\TerraExplorer\\" + fileNameExt;
                try
                {
                    if (!File.Exists(path))
                    {
                        // This statement ensures that the file is created,
                        // but the handle is not kept.
                        using (FileStream fs = File.Create(path)) { }
                    }

                    // Ensure that the target does not exist.
                    if (File.Exists(localFilePath))
                        File.Delete(localFilePath);

                    // Move the file.
                    File.Move(path, localFilePath);

                    //打开另存后的工程文件
                    /*tProjectUrl = localFilePath;
                    sgworld.Project.Open(tProjectUrl);
                    this.Text = tProjectUrl + " - FieldGeo3D";*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString());
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
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能正在开发中……");
        }

        private void btnTag_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1012, 0);
            //string tMsg = String.Empty;
            //try
            //{
            //    pbhander = "GeoTag";
            //    objProperty = InputObjProperty(pbhander);
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            //}
            //catch (Exception ex)
            //{
            //    tMsg = String.Format("GeometryTag_Click Exception: {0}", ex.Message);
            //    MessageBox.Show(tMsg);
            //}
        }

        private void btnGeoPoint_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            try
            {
                PBHander = "GeoPoint";
                sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            }
            catch (Exception ex)
            {
                tMsg = String.Format("GeoPoint_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }

        private void btnGeoLine_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1012, 4);
            //string tMsg = String.Empty;
            //try
            //{
            //    pbhander = "GeoPolyline";
            //    objProperty = InputObjProperty(pbhander);
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            //}

            //catch (Exception ex)
            //{
            //    tMsg = String.Format("GeometryPolygon_Click Exception: {0}", ex.Message);
            //    MessageBox.Show(tMsg);
            //}
        }

        private void btnGeoRegion_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1012, 5);
            //string tMsg = String.Empty;
            //try
            //{
            //    pbhander = "GeoPolygon";
            //    objProperty = InputObjProperty(pbhander);
            //    sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
            //}

            //catch (Exception ex)
            //{
            //    tMsg = String.Format("GeometryPolygon_Click Exception: {0}", ex.Message);
            //    MessageBox.Show(tMsg);
            //}
        }

        //private void btnGeoLineFreehand_Click(object sender, EventArgs e)
        //{
        //    sgworld.Command.Execute(1149, 25);
        //}

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

        private void btnLocate_Click(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            sgworld.Command.Execute(1023, 0);
        }

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

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sgworld.Command.CanExecute(1149,25).ToString());
        }



    }
}
