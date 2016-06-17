namespace FGeo3D_TE
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
            this.axTE3DWindow1 = new AxTerraExplorerX.AxTE3DWindow();
            this.axTEInformationWindow1 = new AxTerraExplorerX.AxTEInformationWindow();
            this.rbLog = new DevComponents.DotNetBar.RibbonBar();
            this.btnSpot = new DevComponents.DotNetBar.ButtonItem();
            this.btnBore = new DevComponents.DotNetBar.ButtonItem();
            this.btnFootrill = new DevComponents.DotNetBar.ButtonItem();
            this.btnPit = new DevComponents.DotNetBar.ButtonItem();
            this.btnWell = new DevComponents.DotNetBar.ButtonItem();
            this.btnTrench = new DevComponents.DotNetBar.ButtonItem();
            this.btnSlope = new DevComponents.DotNetBar.ButtonItem();
            this.btnCavity = new DevComponents.DotNetBar.ButtonItem();
            this.btnFoundation = new DevComponents.DotNetBar.ButtonItem();
            this.rbAnalysis = new DevComponents.DotNetBar.RibbonBar();
            this.btnBuildSurface = new DevComponents.DotNetBar.ButtonItem();
            this.btnStretchSurface = new DevComponents.DotNetBar.ButtonItem();
            this.btnBlockAnalyse = new DevComponents.DotNetBar.ButtonItem();
            this.rbData = new DevComponents.DotNetBar.RibbonBar();
            this.btnOpen = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAs = new DevComponents.DotNetBar.ButtonItem();
            this.btnConnectDB = new DevComponents.DotNetBar.ButtonItem();
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
            this.btnLine = new DevComponents.DotNetBar.ButtonItem();
            this.btnFreehandDrawing = new DevComponents.DotNetBar.ButtonItem();
            this.btnRegion = new DevComponents.DotNetBar.ButtonItem();
            this.btnDrawingComplete = new DevComponents.DotNetBar.ButtonItem();
            this.swbtnGPS = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.labelGPS = new DevComponents.DotNetBar.LabelX();
            this.btnProject = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow1)).BeginInit();
            this.gpMeasure.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // axTE3DWindow1
            // 
            this.axTE3DWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTE3DWindow1.Enabled = true;
            this.axTE3DWindow1.Location = new System.Drawing.Point(206, 94);
            this.axTE3DWindow1.Name = "axTE3DWindow1";
            this.axTE3DWindow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTE3DWindow1.OcxState")));
            this.axTE3DWindow1.Size = new System.Drawing.Size(950, 573);
            this.axTE3DWindow1.TabIndex = 1;
            // 
            // axTEInformationWindow1
            // 
            this.axTEInformationWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTEInformationWindow1.Enabled = true;
            this.axTEInformationWindow1.Location = new System.Drawing.Point(0, 94);
            this.axTEInformationWindow1.Name = "axTEInformationWindow1";
            this.axTEInformationWindow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTEInformationWindow1.OcxState")));
            this.axTEInformationWindow1.Size = new System.Drawing.Size(219, 573);
            this.axTEInformationWindow1.TabIndex = 0;
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
            this.btnSpot,
            this.btnBore,
            this.btnFootrill,
            this.btnPit,
            this.btnWell,
            this.btnTrench,
            this.btnSlope,
            this.btnCavity,
            this.btnFoundation});
            this.rbLog.Location = new System.Drawing.Point(407, 5);
            this.rbLog.Name = "rbLog";
            this.rbLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbLog.Size = new System.Drawing.Size(349, 83);
            this.rbLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbLog.TabIndex = 9;
            this.rbLog.Text = "信息编录";
            // 
            // 
            // 
            this.rbLog.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbLog.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnSpot
            // 
            this.btnSpot.Name = "btnSpot";
            this.btnSpot.SubItemsExpandWidth = 14;
            this.btnSpot.Text = "地质点";
            this.btnSpot.Click += new System.EventHandler(this.btnGeoPoint_Click);
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
            this.btnFootrill.Name = "btnFootrill";
            this.btnFootrill.SubItemsExpandWidth = 14;
            this.btnFootrill.Text = "硐探";
            this.btnFootrill.Click += new System.EventHandler(this.btnFootrill_Click);
            // 
            // btnPit
            // 
            this.btnPit.Name = "btnPit";
            this.btnPit.SubItemsExpandWidth = 14;
            this.btnPit.Text = "坑探";
            this.btnPit.Click += new System.EventHandler(this.btnPit_Click);
            // 
            // btnWell
            // 
            this.btnWell.Name = "btnWell";
            this.btnWell.SubItemsExpandWidth = 14;
            this.btnWell.Text = "井探";
            this.btnWell.Click += new System.EventHandler(this.btnWell_Click);
            // 
            // btnTrench
            // 
            this.btnTrench.Name = "btnTrench";
            this.btnTrench.SubItemsExpandWidth = 14;
            this.btnTrench.Text = "槽探";
            this.btnTrench.Click += new System.EventHandler(this.btnTrench_Click);
            // 
            // btnSlope
            // 
            this.btnSlope.Name = "btnSlope";
            this.btnSlope.SubItemsExpandWidth = 14;
            this.btnSlope.Text = "边坡";
            this.btnSlope.Click += new System.EventHandler(this.btnSlope_Click);
            // 
            // btnCavity
            // 
            this.btnCavity.Name = "btnCavity";
            this.btnCavity.SubItemsExpandWidth = 14;
            this.btnCavity.Text = "洞室";
            this.btnCavity.Click += new System.EventHandler(this.btnCavity_Click);
            // 
            // btnFoundation
            // 
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
            this.btnBuildSurface,
            this.btnStretchSurface,
            this.btnBlockAnalyse});
            this.rbAnalysis.Location = new System.Drawing.Point(1030, 5);
            this.rbAnalysis.Name = "rbAnalysis";
            this.rbAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbAnalysis.Size = new System.Drawing.Size(199, 83);
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
            // btnBuildSurface
            // 
            this.btnBuildSurface.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildSurface.Image")));
            this.btnBuildSurface.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuildSurface.Name = "btnBuildSurface";
            this.btnBuildSurface.SubItemsExpandWidth = 14;
            this.btnBuildSurface.Text = "生成界面";
            this.btnBuildSurface.Click += new System.EventHandler(this.btnBuildSurface_Click);
            // 
            // btnStretchSurface
            // 
            this.btnStretchSurface.Image = ((System.Drawing.Image)(resources.GetObject("btnStretchSurface.Image")));
            this.btnStretchSurface.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnStretchSurface.Name = "btnStretchSurface";
            this.btnStretchSurface.SubItemsExpandWidth = 14;
            this.btnStretchSurface.Text = "延伸界面";
            this.btnStretchSurface.Click += new System.EventHandler(this.btnStretchSurface_Click);
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
            this.btnSave,
            this.btnSaveAs,
            this.btnConnectDB,
            this.btnProject,
            this.btnImport});
            this.rbData.Location = new System.Drawing.Point(0, 5);
            this.rbData.Name = "rbData";
            this.rbData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbData.Size = new System.Drawing.Size(401, 83);
            this.rbData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbData.TabIndex = 7;
            this.rbData.Text = "数据来源";
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
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSave.Name = "btnSave";
            this.btnSave.SubItemsExpandWidth = 14;
            this.btnSave.Text = "保存场景";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.SubItemsExpandWidth = 14;
            this.btnSaveAs.Text = "另存场景";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
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
            this.gpMeasure.Location = new System.Drawing.Point(1162, 342);
            this.gpMeasure.Name = "gpMeasure";
            this.gpMeasure.Size = new System.Drawing.Size(71, 325);
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
            this.gpMeasure.Text = "测量工具";
            // 
            // btnTerrainArea
            // 
            this.btnTerrainArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTerrainArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTerrainArea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTerrainArea.Image = ((System.Drawing.Image)(resources.GetObject("btnTerrainArea.Image")));
            this.btnTerrainArea.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTerrainArea.Location = new System.Drawing.Point(3, 243);
            this.btnTerrainArea.Name = "btnTerrainArea";
            this.btnTerrainArea.Size = new System.Drawing.Size(61, 54);
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
            this.btnPlaneArea.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaneArea.Image")));
            this.btnPlaneArea.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPlaneArea.Location = new System.Drawing.Point(3, 183);
            this.btnPlaneArea.Name = "btnPlaneArea";
            this.btnPlaneArea.Size = new System.Drawing.Size(61, 54);
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
            this.btnVerticalDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnVerticalDistance.Image")));
            this.btnVerticalDistance.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnVerticalDistance.Location = new System.Drawing.Point(3, 123);
            this.btnVerticalDistance.Name = "btnVerticalDistance";
            this.btnVerticalDistance.Size = new System.Drawing.Size(61, 54);
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
            this.btnHorizonalDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnHorizonalDistance.Image")));
            this.btnHorizonalDistance.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHorizonalDistance.Location = new System.Drawing.Point(3, 63);
            this.btnHorizonalDistance.Name = "btnHorizonalDistance";
            this.btnHorizonalDistance.Size = new System.Drawing.Size(61, 54);
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
            this.btnAbsDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnAbsDistance.Image")));
            this.btnAbsDistance.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAbsDistance.Location = new System.Drawing.Point(3, 3);
            this.btnAbsDistance.Name = "btnAbsDistance";
            this.btnAbsDistance.Size = new System.Drawing.Size(61, 54);
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
            this.btnGPS.Location = new System.Drawing.Point(1174, 155);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(54, 59);
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
            this.btnQuery.Location = new System.Drawing.Point(1174, 220);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(54, 60);
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
            this.btnTest.Location = new System.Drawing.Point(1174, 286);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(55, 50);
            this.btnTest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "临时测试";
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
            this.btnLine,
            this.btnFreehandDrawing,
            this.btnRegion,
            this.btnDrawingComplete});
            this.btnChamber.Location = new System.Drawing.Point(762, 5);
            this.btnChamber.Name = "btnChamber";
            this.btnChamber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnChamber.Size = new System.Drawing.Size(262, 83);
            this.btnChamber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChamber.TabIndex = 8;
            this.btnChamber.Text = "几何绘制";
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
            // btnLine
            // 
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLine.Name = "btnLine";
            this.btnLine.SubItemsExpandWidth = 14;
            this.btnLine.Text = "点选地线";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnFreehandDrawing
            // 
            this.btnFreehandDrawing.Image = ((System.Drawing.Image)(resources.GetObject("btnFreehandDrawing.Image")));
            this.btnFreehandDrawing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFreehandDrawing.Name = "btnFreehandDrawing";
            this.btnFreehandDrawing.SubItemsExpandWidth = 14;
            this.btnFreehandDrawing.Text = "手绘地线";
            this.btnFreehandDrawing.Click += new System.EventHandler(this.btnFreehandDrawing_Click);
            // 
            // btnRegion
            // 
            this.btnRegion.Image = ((System.Drawing.Image)(resources.GetObject("btnRegion.Image")));
            this.btnRegion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.SubItemsExpandWidth = 14;
            this.btnRegion.Text = "点选区域";
            this.btnRegion.Click += new System.EventHandler(this.btnRegion_Click);
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
            // swbtnGPS
            // 
            // 
            // 
            // 
            this.swbtnGPS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.swbtnGPS.Location = new System.Drawing.Point(1164, 121);
            this.swbtnGPS.Name = "swbtnGPS";
            this.swbtnGPS.OffText = "指示";
            this.swbtnGPS.OnText = "跟随";
            this.swbtnGPS.Size = new System.Drawing.Size(65, 28);
            this.swbtnGPS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.swbtnGPS.TabIndex = 18;
            this.swbtnGPS.ValueChanged += new System.EventHandler(this.swbtnGPS_ValueChanged);
            // 
            // labelGPS
            // 
            // 
            // 
            // 
            this.labelGPS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelGPS.Location = new System.Drawing.Point(1165, 94);
            this.labelGPS.Name = "labelGPS";
            this.labelGPS.Size = new System.Drawing.Size(64, 23);
            this.labelGPS.TabIndex = 19;
            this.labelGPS.Text = "GPS状态";
            this.labelGPS.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnProject
            // 
            this.btnProject.Name = "btnProject";
            this.btnProject.SubItemsExpandWidth = 14;
            this.btnProject.Text = "选择工程";
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1234, 666);
            this.Controls.Add(this.labelGPS);
            this.Controls.Add(this.swbtnGPS);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gpMeasure);
            this.Controls.Add(this.btnGPS);
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
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow1)).EndInit();
            this.gpMeasure.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxTerraExplorerX.AxTEInformationWindow axTEInformationWindow1;
        private AxTerraExplorerX.AxTE3DWindow axTE3DWindow1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonBar rbLog;
        private DevComponents.DotNetBar.RibbonBar rbAnalysis;
        private DevComponents.DotNetBar.RibbonBar rbData;
        private DevComponents.DotNetBar.ButtonItem btnOpen;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnSaveAs;
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
        private DevComponents.DotNetBar.ButtonItem btnStretchSurface;
        private DevComponents.DotNetBar.ButtonItem btnBlockAnalyse;
        private DevComponents.DotNetBar.ButtonItem btnConnectDB;
        private DevComponents.DotNetBar.ButtonItem btnFootrill;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private DevComponents.DotNetBar.RibbonBar btnChamber;
        internal DevComponents.DotNetBar.ButtonItem btnLine;
        private DevComponents.DotNetBar.ButtonItem btnFreehandDrawing;
        internal DevComponents.DotNetBar.ButtonItem btnRegion;
        internal DevComponents.DotNetBar.ButtonItem btnDrawingComplete;
        private DevComponents.DotNetBar.ButtonItem btnPit;
        private DevComponents.DotNetBar.ButtonItem btnWell;
        private DevComponents.DotNetBar.ButtonItem btnTrench;
        private DevComponents.DotNetBar.ButtonItem btnSpot;
        private DevComponents.DotNetBar.Controls.SwitchButton swbtnGPS;
        private DevComponents.DotNetBar.LabelX labelGPS;
        private DevComponents.DotNetBar.ButtonItem btnSlope;
        private DevComponents.DotNetBar.ButtonItem btnCavity;
        private DevComponents.DotNetBar.ButtonItem btnFoundation;
        private DevComponents.DotNetBar.ButtonItem btnProject;
    }
}

