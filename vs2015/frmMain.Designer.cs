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
            this.rbData = new DevComponents.DotNetBar.RibbonBar();
            this.btnBore = new DevComponents.DotNetBar.ButtonItem();
            this.btnFootrill = new DevComponents.DotNetBar.ButtonItem();
            this.rbTerrainAnalysis = new DevComponents.DotNetBar.RibbonBar();
            this.btnBuildSurface = new DevComponents.DotNetBar.ButtonItem();
            this.btnStretchSurface = new DevComponents.DotNetBar.ButtonItem();
            this.btnBlockAnalyse = new DevComponents.DotNetBar.ButtonItem();
            this.rbProject = new DevComponents.DotNetBar.RibbonBar();
            this.btnOpen = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAs = new DevComponents.DotNetBar.ButtonItem();
            this.btnConnectDB = new DevComponents.DotNetBar.ButtonItem();
            this.gpMeasure = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnTerrainArea = new DevComponents.DotNetBar.ButtonX();
            this.btnPlaneArea = new DevComponents.DotNetBar.ButtonX();
            this.btnVerticalDistance = new DevComponents.DotNetBar.ButtonX();
            this.btnHorizonalDistance = new DevComponents.DotNetBar.ButtonX();
            this.btnAbsDistance = new DevComponents.DotNetBar.ButtonX();
            this.btnLocate = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.btnTest = new DevComponents.DotNetBar.ButtonX();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            this.btnPhotoRecognition = new DevComponents.DotNetBar.ButtonItem();
            this.rbDraw = new DevComponents.DotNetBar.RibbonBar();
            this.btnPoint = new DevComponents.DotNetBar.ButtonItem();
            this.btnLine = new DevComponents.DotNetBar.ButtonItem();
            this.btnFreehandDrawing = new DevComponents.DotNetBar.ButtonItem();
            this.btnRegion = new DevComponents.DotNetBar.ButtonItem();
            this.btnDrawingApply = new DevComponents.DotNetBar.ButtonItem();
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
            this.axTE3DWindow1.Size = new System.Drawing.Size(931, 544);
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
            this.axTEInformationWindow1.Size = new System.Drawing.Size(368, 544);
            this.axTEInformationWindow1.TabIndex = 0;
            // 
            // rbData
            // 
            this.rbData.AutoOverflowEnabled = true;
            this.rbData.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbDraw.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbDraw.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbData.ContainerControlProcessDialogKey = true;
            this.rbData.DragDropSupport = true;
            this.rbData.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBore,
            this.btnFootrill,
            this.btnPhotoRecognition});
            this.rbData.Location = new System.Drawing.Point(326, 5);
            this.rbData.Name = "rbData";
            this.rbData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbData.Size = new System.Drawing.Size(189, 83);
            this.rbData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbData.TabIndex = 9;
            this.rbData.Text = "信息编录";
            // 
            // 
            // 
            this.rbDraw.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbDraw.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbDraw.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbDraw.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // 
            // 
            this.rbDraw.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnBore
            // 
            this.btnBore.Image = ((System.Drawing.Image)(resources.GetObject("btnBore.Image")));
            this.btnBore.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBore.Name = "btnBore";
            this.btnBore.SubItemsExpandWidth = 14;
            this.btnBore.Text = "新建钻孔";
            // 
            // btnFootrill
            // 
            this.btnFootrill.Name = "btnFootrill";
            this.btnFootrill.SubItemsExpandWidth = 14;
            this.btnFootrill.Text = "新建平硐";
            // 
            // rbTerrainAnalysis
            // 
            this.rbTerrainAnalysis.AutoOverflowEnabled = true;
            this.rbTerrainAnalysis.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbTerrainAnalysis.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbTerrainAnalysis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbTerrainAnalysis.ContainerControlProcessDialogKey = true;
            this.rbTerrainAnalysis.DragDropSupport = true;
            this.rbTerrainAnalysis.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBuildSurface,
            this.btnStretchSurface,
            this.btnBlockAnalyse});
            this.rbTerrainAnalysis.Location = new System.Drawing.Point(850, 5);
            this.rbTerrainAnalysis.Name = "rbTerrainAnalysis";
            this.rbTerrainAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbTerrainAnalysis.Size = new System.Drawing.Size(358, 83);
            this.rbTerrainAnalysis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbTerrainAnalysis.TabIndex = 8;
            this.rbTerrainAnalysis.Text = "分析处理";
            // 
            // 
            // 
            this.rbTerrainAnalysis.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbTerrainAnalysis.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbTerrainAnalysis.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbTerrainAnalysis.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // 
            // 
            this.rbTerrainAnalysis.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnBuildSurface
            // 
            this.btnBuildSurface.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildSurface.Image")));
            this.btnBuildSurface.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuildSurface.Name = "btnBuildSurface";
            this.btnBuildSurface.SubItemsExpandWidth = 14;
            this.btnBuildSurface.Text = "生成界面";
            // 
            // btnStretchSurface
            // 
            this.btnStretchSurface.Image = ((System.Drawing.Image)(resources.GetObject("btnStretchSurface.Image")));
            this.btnStretchSurface.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnStretchSurface.Name = "btnStretchSurface";
            this.btnStretchSurface.SubItemsExpandWidth = 14;
            this.btnStretchSurface.Text = "延伸界面";
            // 
            // btnBlockAnalyse
            // 
            this.btnBlockAnalyse.Image = ((System.Drawing.Image)(resources.GetObject("btnBlockAnalyse.Image")));
            this.btnBlockAnalyse.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBlockAnalyse.Name = "btnBlockAnalyse";
            this.btnBlockAnalyse.SubItemsExpandWidth = 14;
            this.btnBlockAnalyse.Text = "块体分析";
            // 
            // rbProject
            // 
            this.rbProject.AutoOverflowEnabled = true;
            this.rbProject.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbProject.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbProject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbProject.ContainerControlProcessDialogKey = true;
            this.rbProject.DragDropSupport = true;
            this.rbProject.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnConnectDB,
            this.btnImport});
            this.rbProject.Location = new System.Drawing.Point(0, 5);
            this.rbProject.Name = "rbProject";
            this.rbProject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbProject.Size = new System.Drawing.Size(320, 83);
            this.rbProject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbProject.TabIndex = 7;
            this.rbProject.Text = "数据来源";
            // 
            // 
            // 
            this.rbProject.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbProject.TitleStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbProject.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbProject.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbProject.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.rbProject.TitleStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            // 
            // 
            // 
            this.rbProject.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            this.gpMeasure.Location = new System.Drawing.Point(1143, 313);
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
            // btnLocate
            // 
            this.btnLocate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLocate.Image = ((System.Drawing.Image)(resources.GetObject("btnLocate.Image")));
            this.btnLocate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLocate.Location = new System.Drawing.Point(1154, 94);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(54, 59);
            this.btnLocate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLocate.TabIndex = 14;
            this.btnLocate.Text = "定位";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnQuery.Location = new System.Drawing.Point(1154, 159);
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
            this.btnTest.Location = new System.Drawing.Point(1154, 225);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(55, 50);
            this.btnTest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "临时测试";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImport.Name = "btnImport";
            this.btnImport.SubItemsExpandWidth = 14;
            this.btnImport.Text = "导入数据";
            // 
            // btnPhotoRecognition
            // 
            this.btnPhotoRecognition.Name = "btnPhotoRecognition";
            this.btnPhotoRecognition.SubItemsExpandWidth = 14;
            this.btnPhotoRecognition.Text = "图像编录";
            // 
            // rbDraw
            // 
            this.rbDraw.AutoOverflowEnabled = true;
            this.rbDraw.AutoSizeItems = false;
            // 
            // 
            // 
            this.rbDraw.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbDraw.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbDraw.ContainerControlProcessDialogKey = true;
            this.rbDraw.DragDropSupport = true;
            this.rbDraw.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPoint,
            this.btnLine,
            this.btnFreehandDrawing,
            this.btnRegion,
            this.btnDrawingApply});
            this.rbDraw.Location = new System.Drawing.Point(521, 5);
            this.rbDraw.Name = "rbDraw";
            this.rbDraw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbDraw.Size = new System.Drawing.Size(323, 83);
            this.rbDraw.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbDraw.TabIndex = 8;
            this.rbDraw.Text = "几何绘制";
            // 
            // 
            // 
            this.rbDraw.TitleStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.rbDraw.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbDraw.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbDraw.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // 
            // 
            this.rbDraw.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnPoint
            // 
            this.btnPoint.ForeColor = System.Drawing.Color.Black;
            this.btnPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnPoint.Image")));
            this.btnPoint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.SubItemsExpandWidth = 14;
            this.btnPoint.Text = "绘制地点";
            // 
            // btnLine
            // 
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLine.Name = "btnLine";
            this.btnLine.SubItemsExpandWidth = 14;
            this.btnLine.Text = "点选地线";
            // 
            // btnFreehandDrawing
            // 
            this.btnFreehandDrawing.Image = ((System.Drawing.Image)(resources.GetObject("btnFreehandDrawing.Image")));
            this.btnFreehandDrawing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFreehandDrawing.Name = "btnFreehandDrawing";
            this.btnFreehandDrawing.SubItemsExpandWidth = 14;
            this.btnFreehandDrawing.Text = "手绘地线";
            // 
            // btnRegion
            // 
            this.btnRegion.Image = ((System.Drawing.Image)(resources.GetObject("btnRegion.Image")));
            this.btnRegion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.SubItemsExpandWidth = 14;
            this.btnRegion.Text = "点选区域";
            // 
            // btnDrawingApply
            // 
            this.btnDrawingApply.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawingApply.Image")));
            this.btnDrawingApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDrawingApply.Name = "btnDrawingApply";
            this.btnDrawingApply.SubItemsExpandWidth = 14;
            this.btnDrawingApply.Text = "变更应用";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1215, 637);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gpMeasure);
            this.Controls.Add(this.btnLocate);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.rbData);
            this.Controls.Add(this.rbDraw);
            this.Controls.Add(this.rbTerrainAnalysis);
            this.Controls.Add(this.rbProject);
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
        private DevComponents.DotNetBar.RibbonBar rbData;
        private DevComponents.DotNetBar.RibbonBar rbTerrainAnalysis;
        private DevComponents.DotNetBar.RibbonBar rbProject;
        private DevComponents.DotNetBar.ButtonItem btnOpen;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnSaveAs;
        private DevComponents.DotNetBar.Controls.GroupPanel gpMeasure;
        private DevComponents.DotNetBar.ButtonX btnTerrainArea;
        private DevComponents.DotNetBar.ButtonX btnPlaneArea;
        private DevComponents.DotNetBar.ButtonX btnVerticalDistance;
        private DevComponents.DotNetBar.ButtonX btnHorizonalDistance;
        private DevComponents.DotNetBar.ButtonX btnAbsDistance;
        private DevComponents.DotNetBar.ButtonX btnLocate;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btnTest;
        private DevComponents.DotNetBar.ButtonItem btnBore;
        private DevComponents.DotNetBar.ButtonItem btnBuildSurface;
        private DevComponents.DotNetBar.ButtonItem btnStretchSurface;
        private DevComponents.DotNetBar.ButtonItem btnBlockAnalyse;
        private DevComponents.DotNetBar.ButtonItem btnConnectDB;
        private DevComponents.DotNetBar.ButtonItem btnFootrill;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private DevComponents.DotNetBar.ButtonItem btnPhotoRecognition;
        private DevComponents.DotNetBar.RibbonBar rbDraw;
        internal DevComponents.DotNetBar.ButtonItem btnPoint;
        internal DevComponents.DotNetBar.ButtonItem btnLine;
        private DevComponents.DotNetBar.ButtonItem btnFreehandDrawing;
        internal DevComponents.DotNetBar.ButtonItem btnRegion;
        internal DevComponents.DotNetBar.ButtonItem btnDrawingApply;
    }
}

