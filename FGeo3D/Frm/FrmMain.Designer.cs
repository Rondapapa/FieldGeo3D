namespace FGeo3D_TE.Frm
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.rbLog = new DevComponents.DotNetBar.RibbonBar();
            this.btnBore = new DevComponents.DotNetBar.ButtonItem();
            this.btnFootrill = new DevComponents.DotNetBar.ButtonItem();
            this.btnPit = new DevComponents.DotNetBar.ButtonItem();
            this.btnWell = new DevComponents.DotNetBar.ButtonItem();
            this.btnTrench = new DevComponents.DotNetBar.ButtonItem();
            this.btnSlope = new DevComponents.DotNetBar.ButtonItem();
            this.btnCavity = new DevComponents.DotNetBar.ButtonItem();
            this.btnFoundation = new DevComponents.DotNetBar.ButtonItem();
            this.rbAnalysis = new DevComponents.DotNetBar.RibbonBar();
            this.btnPlaneViaSpot = new DevComponents.DotNetBar.ButtonItem();
            this.btnPlaneViaLine = new DevComponents.DotNetBar.ButtonItem();
            this.btnBuildSurface = new DevComponents.DotNetBar.ButtonItem();
            this.btnBlockAnalyse = new DevComponents.DotNetBar.ButtonItem();
            this.rbData = new DevComponents.DotNetBar.RibbonBar();
            this.btnOpen = new DevComponents.DotNetBar.ButtonItem();
            this.btnConnectDB = new DevComponents.DotNetBar.ButtonItem();
            this.btnConnectGPS = new DevComponents.DotNetBar.ButtonItem();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            this.gpMeasure = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnTerrainArea = new DevComponents.DotNetBar.ButtonX();
            this.btnPlaneArea = new DevComponents.DotNetBar.ButtonX();
            this.btnVerticalDistance = new DevComponents.DotNetBar.ButtonX();
            this.btnHorizonalDistance = new DevComponents.DotNetBar.ButtonX();
            this.btnAbsDistance = new DevComponents.DotNetBar.ButtonX();
            this.btnGPS = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.btnTest = new DevComponents.DotNetBar.ButtonX();
            this.btnChamber = new DevComponents.DotNetBar.RibbonBar();
            this.btnSpot = new DevComponents.DotNetBar.ButtonItem();
            this.btnLine = new DevComponents.DotNetBar.ButtonItem();
            this.btnRegion = new DevComponents.DotNetBar.ButtonItem();
            this.btnDrawingComplete = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteSpot = new DevComponents.DotNetBar.ButtonItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusSystem = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusWorkingObj = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusGPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.axTE3DWindow1 = new AxTerraExplorerX.AxTE3DWindow();
            this.axTEInformationWindow1 = new AxTerraExplorerX.AxTEInformationWindow();
            this.timerGPSReader = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.switchButtonUnderground = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.labelUnderGroundSwitch = new DevComponents.DotNetBar.LabelX();
            this.buttonXImageLogging = new DevComponents.DotNetBar.ButtonX();
            this.gpMeasure.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.OfficeMobile2014;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(71)))), ((int)(((byte)(42))))));
            // 
            // rbLog
            // 
            this.rbLog.AutoOverflowEnabled = true;
            this.rbLog.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbLog.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbLog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbLog.ContainerControlProcessDialogKey = true;
            this.rbLog.DragDropSupport = true;
            this.rbLog.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBore,
            this.btnFootrill,
            this.btnPit,
            this.btnWell,
            this.btnTrench,
            this.btnSlope,
            this.btnCavity,
            this.btnFoundation});
            this.rbLog.Location = new System.Drawing.Point(260, 5);
            this.rbLog.Name = "rbLog";
            this.rbLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbLog.Size = new System.Drawing.Size(385, 83);
            this.rbLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbLog.TabIndex = 9;
            this.rbLog.Text = "勘测编录";
            // 
            // 
            // 
            this.rbLog.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbLog.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnBore
            // 
            this.btnBore.Image = ((System.Drawing.Image)(resources.GetObject("btnBore.Image")));
            this.btnBore.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBore.Name = "btnBore";
            this.btnBore.SubItemsExpandWidth = 14;
            this.btnBore.Text = "钻探";
            this.btnBore.Click += new System.EventHandler(this.btnBore_Click);
            // 
            // btnFootrill
            // 
            this.btnFootrill.Image = ((System.Drawing.Image)(resources.GetObject("btnFootrill.Image")));
            this.btnFootrill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFootrill.Name = "btnFootrill";
            this.btnFootrill.SubItemsExpandWidth = 14;
            this.btnFootrill.Text = "硐探";
            this.btnFootrill.Click += new System.EventHandler(this.btnFootrill_Click);
            // 
            // btnPit
            // 
            this.btnPit.Image = ((System.Drawing.Image)(resources.GetObject("btnPit.Image")));
            this.btnPit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPit.Name = "btnPit";
            this.btnPit.SubItemsExpandWidth = 14;
            this.btnPit.Text = "坑探";
            this.btnPit.Click += new System.EventHandler(this.btnPit_Click);
            // 
            // btnWell
            // 
            this.btnWell.Image = ((System.Drawing.Image)(resources.GetObject("btnWell.Image")));
            this.btnWell.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnWell.Name = "btnWell";
            this.btnWell.SubItemsExpandWidth = 14;
            this.btnWell.Text = "井探";
            this.btnWell.Click += new System.EventHandler(this.btnWell_Click);
            // 
            // btnTrench
            // 
            this.btnTrench.Image = ((System.Drawing.Image)(resources.GetObject("btnTrench.Image")));
            this.btnTrench.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTrench.Name = "btnTrench";
            this.btnTrench.SubItemsExpandWidth = 14;
            this.btnTrench.Text = "槽探";
            this.btnTrench.Click += new System.EventHandler(this.btnTrench_Click);
            // 
            // btnSlope
            // 
            this.btnSlope.Image = ((System.Drawing.Image)(resources.GetObject("btnSlope.Image")));
            this.btnSlope.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSlope.Name = "btnSlope";
            this.btnSlope.SubItemsExpandWidth = 14;
            this.btnSlope.Text = "边坡";
            this.btnSlope.Click += new System.EventHandler(this.btnSlope_Click);
            // 
            // btnCavity
            // 
            this.btnCavity.Image = ((System.Drawing.Image)(resources.GetObject("btnCavity.Image")));
            this.btnCavity.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCavity.Name = "btnCavity";
            this.btnCavity.SubItemsExpandWidth = 14;
            this.btnCavity.Text = "洞室";
            this.btnCavity.Click += new System.EventHandler(this.btnCavity_Click);
            // 
            // btnFoundation
            // 
            this.btnFoundation.Image = ((System.Drawing.Image)(resources.GetObject("btnFoundation.Image")));
            this.btnFoundation.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFoundation.Name = "btnFoundation";
            this.btnFoundation.SubItemsExpandWidth = 14;
            this.btnFoundation.Text = "基础";
            this.btnFoundation.Click += new System.EventHandler(this.btnFoundation_Click);
            // 
            // rbAnalysis
            // 
            this.rbAnalysis.AutoOverflowEnabled = true;
            this.rbAnalysis.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbAnalysis.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbAnalysis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbAnalysis.ContainerControlProcessDialogKey = true;
            this.rbAnalysis.DragDropSupport = true;
            this.rbAnalysis.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPlaneViaSpot,
            this.btnPlaneViaLine,
            this.btnBuildSurface,
            this.btnBlockAnalyse});
            this.rbAnalysis.Location = new System.Drawing.Point(968, 5);
            this.rbAnalysis.Name = "rbAnalysis";
            this.rbAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbAnalysis.Size = new System.Drawing.Size(262, 83);
            this.rbAnalysis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbAnalysis.TabIndex = 8;
            this.rbAnalysis.Text = "分析处理";
            // 
            // 
            // 
            this.rbAnalysis.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbAnalysis.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbAnalysis.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAnalysis.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // 
            // 
            this.rbAnalysis.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnPlaneViaSpot
            // 
            this.btnPlaneViaSpot.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaneViaSpot.Image")));
            this.btnPlaneViaSpot.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPlaneViaSpot.Name = "btnPlaneViaSpot";
            this.btnPlaneViaSpot.SubItemsExpandWidth = 14;
            this.btnPlaneViaSpot.Text = "单点求面";
            this.btnPlaneViaSpot.Click += new System.EventHandler(this.btnPlaneViaSpot_Click);
            // 
            // btnPlaneViaLine
            // 
            this.btnPlaneViaLine.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaneViaLine.Image")));
            this.btnPlaneViaLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPlaneViaLine.Name = "btnPlaneViaLine";
            this.btnPlaneViaLine.SubItemsExpandWidth = 14;
            this.btnPlaneViaLine.Text = "地线推面";
            this.btnPlaneViaLine.Click += new System.EventHandler(this.btnPlaneViaLine_Click);
            // 
            // btnBuildSurface
            // 
            this.btnBuildSurface.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildSurface.Image")));
            this.btnBuildSurface.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuildSurface.Name = "btnBuildSurface";
            this.btnBuildSurface.SubItemsExpandWidth = 14;
            this.btnBuildSurface.Text = "拟合界面";
            this.btnBuildSurface.Click += new System.EventHandler(this.btnBuildSurface_Click);
            // 
            // btnBlockAnalyse
            // 
            this.btnBlockAnalyse.Image = ((System.Drawing.Image)(resources.GetObject("btnBlockAnalyse.Image")));
            this.btnBlockAnalyse.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBlockAnalyse.Name = "btnBlockAnalyse";
            this.btnBlockAnalyse.SubItemsExpandWidth = 14;
            this.btnBlockAnalyse.Text = "块体分析";
            this.btnBlockAnalyse.Click += new System.EventHandler(this.btnBlockAnalyse_Click);
            // 
            // rbData
            // 
            this.rbData.AutoOverflowEnabled = true;
            this.rbData.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbData.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbData.ContainerControlProcessDialogKey = true;
            this.rbData.DragDropSupport = true;
            this.rbData.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOpen,
            this.btnConnectDB,
            this.btnConnectGPS,
            this.btnImport});
            this.rbData.Location = new System.Drawing.Point(0, 5);
            this.rbData.Name = "rbData";
            this.rbData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbData.Size = new System.Drawing.Size(254, 83);
            this.rbData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbData.TabIndex = 7;
            this.rbData.Text = "工程设置";
            // 
            // 
            // 
            this.rbData.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbData.TitleStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbData.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbData.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbData.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.rbData.TitleStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            // 
            // 
            // 
            this.rbData.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnOpen
            // 
            this.btnOpen.AccessKeyEnabled = false;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.SubItemsExpandWidth = 14;
            this.btnOpen.Text = "打开场景";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Image = ((System.Drawing.Image)(resources.GetObject("btnConnectDB.Image")));
            this.btnConnectDB.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.SubItemsExpandWidth = 14;
            this.btnConnectDB.Text = "连数据库";
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // btnConnectGPS
            // 
            this.btnConnectGPS.Image = ((System.Drawing.Image)(resources.GetObject("btnConnectGPS.Image")));
            this.btnConnectGPS.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnConnectGPS.Name = "btnConnectGPS";
            this.btnConnectGPS.SubItemsExpandWidth = 14;
            this.btnConnectGPS.Text = "连接GPS";
            this.btnConnectGPS.Click += new System.EventHandler(this.btnConnectGPS_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImport.Name = "btnImport";
            this.btnImport.SubItemsExpandWidth = 14;
            this.btnImport.Text = "导入数据";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // gpMeasure
            // 
            this.gpMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMeasure.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpMeasure.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.gpMeasure.Controls.Add(this.btnTerrainArea);
            this.gpMeasure.Controls.Add(this.btnPlaneArea);
            this.gpMeasure.Controls.Add(this.btnVerticalDistance);
            this.gpMeasure.Controls.Add(this.btnHorizonalDistance);
            this.gpMeasure.Controls.Add(this.btnAbsDistance);
            this.gpMeasure.DisabledBackColor = System.Drawing.Color.Empty;
            this.gpMeasure.Location = new System.Drawing.Point(1173, 405);
            this.gpMeasure.Name = "gpMeasure";
            this.gpMeasure.Size = new System.Drawing.Size(57, 199);
            // 
            // 
            // 
            this.gpMeasure.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpMeasure.Style.BackColorGradientAngle = 90;
            this.gpMeasure.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpMeasure.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMeasure.Style.BorderBottomWidth = 1;
            this.gpMeasure.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpMeasure.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMeasure.Style.BorderLeftWidth = 1;
            this.gpMeasure.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMeasure.Style.BorderRightWidth = 1;
            this.gpMeasure.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMeasure.Style.BorderTopWidth = 1;
            this.gpMeasure.Style.CornerDiameter = 4;
            this.gpMeasure.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpMeasure.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpMeasure.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpMeasure.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpMeasure.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpMeasure.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpMeasure.TabIndex = 16;
            this.gpMeasure.Text = "测量";
            // 
            // btnTerrainArea
            // 
            this.btnTerrainArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTerrainArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTerrainArea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTerrainArea.Location = new System.Drawing.Point(0, 147);
            this.btnTerrainArea.Name = "btnTerrainArea";
            this.btnTerrainArea.Size = new System.Drawing.Size(55, 30);
            this.btnTerrainArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTerrainArea.TabIndex = 0;
            this.btnTerrainArea.Text = "地表面积";
            this.btnTerrainArea.Click += new System.EventHandler(this.btnTerrainArea_Click);
            // 
            // btnPlaneArea
            // 
            this.btnPlaneArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPlaneArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPlaneArea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlaneArea.Location = new System.Drawing.Point(0, 111);
            this.btnPlaneArea.Name = "btnPlaneArea";
            this.btnPlaneArea.Size = new System.Drawing.Size(55, 30);
            this.btnPlaneArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPlaneArea.TabIndex = 0;
            this.btnPlaneArea.Text = "平面面积";
            this.btnPlaneArea.Click += new System.EventHandler(this.btnPlaneArea_Click);
            // 
            // btnVerticalDistance
            // 
            this.btnVerticalDistance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerticalDistance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerticalDistance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVerticalDistance.Location = new System.Drawing.Point(0, 75);
            this.btnVerticalDistance.Name = "btnVerticalDistance";
            this.btnVerticalDistance.Size = new System.Drawing.Size(55, 30);
            this.btnVerticalDistance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerticalDistance.TabIndex = 0;
            this.btnVerticalDistance.Text = "垂直距离";
            this.btnVerticalDistance.Click += new System.EventHandler(this.btnVerticalDistance_Click);
            // 
            // btnHorizonalDistance
            // 
            this.btnHorizonalDistance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHorizonalDistance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHorizonalDistance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHorizonalDistance.Location = new System.Drawing.Point(0, 39);
            this.btnHorizonalDistance.Name = "btnHorizonalDistance";
            this.btnHorizonalDistance.Size = new System.Drawing.Size(55, 30);
            this.btnHorizonalDistance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHorizonalDistance.TabIndex = 0;
            this.btnHorizonalDistance.Text = "水平距离";
            this.btnHorizonalDistance.Click += new System.EventHandler(this.btnHorizonalDistance_Click);
            // 
            // btnAbsDistance
            // 
            this.btnAbsDistance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAbsDistance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAbsDistance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAbsDistance.Location = new System.Drawing.Point(0, 3);
            this.btnAbsDistance.Name = "btnAbsDistance";
            this.btnAbsDistance.Size = new System.Drawing.Size(55, 30);
            this.btnAbsDistance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAbsDistance.TabIndex = 0;
            this.btnAbsDistance.Text = "直线距离";
            this.btnAbsDistance.Click += new System.EventHandler(this.btnAbsDistance_Click);
            // 
            // btnGPS
            // 
            this.btnGPS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGPS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGPS.Image = ((System.Drawing.Image)(resources.GetObject("btnGPS.Image")));
            this.btnGPS.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGPS.Location = new System.Drawing.Point(1175, 144);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(55, 55);
            this.btnGPS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGPS.TabIndex = 14;
            this.btnGPS.Text = "定位";
            this.btnGPS.Click += new System.EventHandler(this.btnGPS_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnQuery.Location = new System.Drawing.Point(1174, 205);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(55, 55);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnTest
            // 
            this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTest.Location = new System.Drawing.Point(1173, 344);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(55, 55);
            this.btnTest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "临时测试";
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnChamber
            // 
            this.btnChamber.AutoOverflowEnabled = true;
            this.btnChamber.AutoSizeItems = false;
            // 
            // 
            // 
            this.btnChamber.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.btnChamber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnChamber.ContainerControlProcessDialogKey = true;
            this.btnChamber.DragDropSupport = true;
            this.btnChamber.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSpot,
            this.btnLine,
            this.btnRegion,
            this.btnDrawingComplete,
            this.btnDeleteSpot});
            this.btnChamber.Location = new System.Drawing.Point(651, 5);
            this.btnChamber.Name = "btnChamber";
            this.btnChamber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnChamber.Size = new System.Drawing.Size(311, 83);
            this.btnChamber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChamber.TabIndex = 8;
            this.btnChamber.Text = "绘制编录";
            // 
            // 
            // 
            this.btnChamber.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.btnChamber.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnChamber.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChamber.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // 
            // 
            this.btnChamber.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnSpot
            // 
            this.btnSpot.Image = ((System.Drawing.Image)(resources.GetObject("btnSpot.Image")));
            this.btnSpot.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSpot.Name = "btnSpot";
            this.btnSpot.SubItemsExpandWidth = 14;
            this.btnSpot.Text = "地质点";
            this.btnSpot.Click += new System.EventHandler(this.btnGeoPoint_Click);
            // 
            // btnLine
            // 
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLine.Name = "btnLine";
            this.btnLine.SubItemsExpandWidth = 14;
            this.btnLine.Text = "点选地线";
            this.btnLine.Click += new System.EventHandler(this.btnLineNew_Click);
            // 
            // btnRegion
            // 
            this.btnRegion.Image = ((System.Drawing.Image)(resources.GetObject("btnRegion.Image")));
            this.btnRegion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.SubItemsExpandWidth = 14;
            this.btnRegion.Text = "点选区域";
            this.btnRegion.Click += new System.EventHandler(this.btnRegionNew_Click);
            // 
            // btnDrawingComplete
            // 
            this.btnDrawingComplete.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawingComplete.Image")));
            this.btnDrawingComplete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDrawingComplete.Name = "btnDrawingComplete";
            this.btnDrawingComplete.SubItemsExpandWidth = 14;
            this.btnDrawingComplete.Text = "变更应用";
            this.btnDrawingComplete.Click += new System.EventHandler(this.btnDrawingComplete_Click);
            // 
            // btnDeleteSpot
            // 
            this.btnDeleteSpot.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSpot.Image")));
            this.btnDeleteSpot.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDeleteSpot.Name = "btnDeleteSpot";
            this.btnDeleteSpot.SubItemsExpandWidth = 14;
            this.btnDeleteSpot.Text = "删除对象";
            this.btnDeleteSpot.Click += new System.EventHandler(this.buttonXDeleteLoggingSpot_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusDatabase,
            this.StatusSystem,
            this.StatusWorkingObj,
            this.StatusGPS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1235, 26);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusDatabase
            // 
            this.StatusDatabase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.StatusDatabase.Name = "StatusDatabase";
            this.StatusDatabase.Size = new System.Drawing.Size(144, 21);
            this.StatusDatabase.Text = "数据库状态：【未连接】";
            // 
            // StatusSystem
            // 
            this.StatusSystem.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.StatusSystem.Name = "StatusSystem";
            this.StatusSystem.Size = new System.Drawing.Size(120, 21);
            this.StatusSystem.Text = "系统状态：【就绪】";
            // 
            // StatusWorkingObj
            // 
            this.StatusWorkingObj.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.StatusWorkingObj.Name = "StatusWorkingObj";
            this.StatusWorkingObj.Size = new System.Drawing.Size(132, 21);
            this.StatusWorkingObj.Text = "当前选定对象：【无】";
            // 
            // StatusGPS
            // 
            this.StatusGPS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.StatusGPS.Name = "StatusGPS";
            this.StatusGPS.Size = new System.Drawing.Size(131, 21);
            this.StatusGPS.Text = "GPS状态：【未连接】";
            // 
            // axTE3DWindow1
            // 
            this.axTE3DWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTE3DWindow1.Enabled = true;
            this.axTE3DWindow1.Location = new System.Drawing.Point(217, 94);
            this.axTE3DWindow1.Name = "axTE3DWindow1";
            this.axTE3DWindow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTE3DWindow1.OcxState")));
            this.axTE3DWindow1.Size = new System.Drawing.Size(950, 514);
            this.axTE3DWindow1.TabIndex = 1;
            // 
            // axTEInformationWindow1
            // 
            this.axTEInformationWindow1.Enabled = true;
            this.axTEInformationWindow1.Location = new System.Drawing.Point(0, 94);
            this.axTEInformationWindow1.Name = "axTEInformationWindow1";
            this.axTEInformationWindow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTEInformationWindow1.OcxState")));
            this.axTEInformationWindow1.Size = new System.Drawing.Size(211, 514);
            this.axTEInformationWindow1.TabIndex = 0;
            // 
            // timerGPSReader
            // 
            this.timerGPSReader.Interval = 1000;
            this.timerGPSReader.Tick += new System.EventHandler(this.timerGPSReader_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // switchButtonUnderground
            // 
            // 
            // 
            // 
            this.switchButtonUnderground.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButtonUnderground.Location = new System.Drawing.Point(1175, 115);
            this.switchButtonUnderground.Name = "switchButtonUnderground";
            this.switchButtonUnderground.OffText = "关";
            this.switchButtonUnderground.OnText = "开";
            this.switchButtonUnderground.Size = new System.Drawing.Size(55, 27);
            this.switchButtonUnderground.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButtonUnderground.SwitchClickTogglesValue = true;
            this.switchButtonUnderground.TabIndex = 21;
            this.switchButtonUnderground.ValueChanged += new System.EventHandler(this.switchButtonUnderground_ValueChanged);
            // 
            // labelUnderGroundSwitch
            // 
            // 
            // 
            // 
            this.labelUnderGroundSwitch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelUnderGroundSwitch.Location = new System.Drawing.Point(1174, 94);
            this.labelUnderGroundSwitch.Name = "labelUnderGroundSwitch";
            this.labelUnderGroundSwitch.Size = new System.Drawing.Size(56, 15);
            this.labelUnderGroundSwitch.TabIndex = 22;
            this.labelUnderGroundSwitch.Text = "地形透明";
            this.labelUnderGroundSwitch.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonXImageLogging
            // 
            this.buttonXImageLogging.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXImageLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXImageLogging.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXImageLogging.Image = ((System.Drawing.Image)(resources.GetObject("buttonXImageLogging.Image")));
            this.buttonXImageLogging.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonXImageLogging.Location = new System.Drawing.Point(1173, 266);
            this.buttonXImageLogging.Name = "buttonXImageLogging";
            this.buttonXImageLogging.Size = new System.Drawing.Size(55, 57);
            this.buttonXImageLogging.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXImageLogging.TabIndex = 13;
            this.buttonXImageLogging.Text = "图录";
            this.buttonXImageLogging.Click += new System.EventHandler(this.btnImageLogging_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1235, 633);
            this.Controls.Add(this.labelUnderGroundSwitch);
            this.Controls.Add(this.switchButtonUnderground);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gpMeasure);
            this.Controls.Add(this.btnGPS);
            this.Controls.Add(this.buttonXImageLogging);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.rbLog);
            this.Controls.Add(this.btnChamber);
            this.Controls.Add(this.rbAnalysis);
            this.Controls.Add(this.rbData);
            this.Controls.Add(this.axTE3DWindow1);
            this.Controls.Add(this.axTEInformationWindow1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FieldGeo3D";
            this.gpMeasure.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxTerraExplorerX.AxTEInformationWindow axTEInformationWindow1;
        private AxTerraExplorerX.AxTE3DWindow axTE3DWindow1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonBar rbLog;
        private DevComponents.DotNetBar.RibbonBar rbAnalysis;
        private DevComponents.DotNetBar.RibbonBar rbData;
        private DevComponents.DotNetBar.ButtonItem btnOpen;
        private DevComponents.DotNetBar.Controls.GroupPanel gpMeasure;
        private DevComponents.DotNetBar.ButtonX btnTerrainArea;
        private DevComponents.DotNetBar.ButtonX btnPlaneArea;
        private DevComponents.DotNetBar.ButtonX btnVerticalDistance;
        private DevComponents.DotNetBar.ButtonX btnHorizonalDistance;
        private DevComponents.DotNetBar.ButtonX btnAbsDistance;
        private DevComponents.DotNetBar.ButtonX btnGPS;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btnTest;
        private DevComponents.DotNetBar.ButtonItem btnBore;
        private DevComponents.DotNetBar.ButtonItem btnBuildSurface;
        private DevComponents.DotNetBar.ButtonItem btnPlaneViaSpot;
        private DevComponents.DotNetBar.ButtonItem btnBlockAnalyse;
        private DevComponents.DotNetBar.ButtonItem btnConnectDB;
        private DevComponents.DotNetBar.ButtonItem btnFootrill;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private DevComponents.DotNetBar.RibbonBar btnChamber;
        internal DevComponents.DotNetBar.ButtonItem btnLine;
        private DevComponents.DotNetBar.ButtonItem btnDeleteSpot;
        internal DevComponents.DotNetBar.ButtonItem btnRegion;
        internal DevComponents.DotNetBar.ButtonItem btnDrawingComplete;
        private DevComponents.DotNetBar.ButtonItem btnPit;
        private DevComponents.DotNetBar.ButtonItem btnWell;
        private DevComponents.DotNetBar.ButtonItem btnTrench;
        private DevComponents.DotNetBar.ButtonItem btnSlope;
        private DevComponents.DotNetBar.ButtonItem btnCavity;
        private DevComponents.DotNetBar.ButtonItem btnFoundation;
        private DevComponents.DotNetBar.ButtonItem btnConnectGPS;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusDatabase;
        private System.Windows.Forms.ToolStripStatusLabel StatusSystem;
        private System.Windows.Forms.ToolStripStatusLabel StatusGPS;
        private System.Windows.Forms.ToolStripStatusLabel StatusWorkingObj;
        private DevComponents.DotNetBar.ButtonItem btnSpot;
        private System.Windows.Forms.Timer timerGPSReader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevComponents.DotNetBar.ButtonItem btnPlaneViaLine;
        private DevComponents.DotNetBar.Controls.SwitchButton switchButtonUnderground;
        private DevComponents.DotNetBar.LabelX labelUnderGroundSwitch;
        private DevComponents.DotNetBar.ButtonX buttonXImageLogging;
    }
}

