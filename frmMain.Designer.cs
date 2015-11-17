namespace FGeo3D_TE
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnOpen = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAs = new DevComponents.DotNetBar.ButtonItem();
            this.btnLocateTo = new DevComponents.DotNetBar.ButtonItem();
            this.btnGetPos = new DevComponents.DotNetBar.ButtonItem();
            this.btnGeoTag = new DevComponents.DotNetBar.ButtonItem();
            this.btnGeoPoint = new DevComponents.DotNetBar.ButtonItem();
            this.btnGeoLine = new DevComponents.DotNetBar.ButtonItem();
            this.btnGeoArea = new DevComponents.DotNetBar.ButtonItem();
            this.btnGeoPolygon3D = new DevComponents.DotNetBar.ButtonItem();
            this.btnTerrainProfile = new DevComponents.DotNetBar.ButtonItem();
            this.btnContourMap = new DevComponents.DotNetBar.ButtonItem();
            this.btnTest = new DevComponents.DotNetBar.ButtonItem();
            this.axTE3DWindow1 = new AxTerraExplorerX.AxTE3DWindow();
            this.axTEInformationWindow1 = new AxTerraExplorerX.AxTEInformationWindow();
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnLocateTo,
            this.btnGetPos,
            this.btnGeoTag,
            this.btnGeoPoint,
            this.btnGeoLine,
            this.btnGeoArea,
            this.btnGeoPolygon3D,
            this.btnTerrainProfile,
            this.btnContourMap,
            this.btnTest});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 1);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1051, 59);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 3;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.SubItemsExpandWidth = 14;
            this.btnOpen.Text = "打开工程";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSave.Name = "btnSave";
            this.btnSave.SubItemsExpandWidth = 14;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.SubItemsExpandWidth = 14;
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnLocateTo
            // 
            this.btnLocateTo.Image = ((System.Drawing.Image)(resources.GetObject("btnLocateTo.Image")));
            this.btnLocateTo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLocateTo.Name = "btnLocateTo";
            this.btnLocateTo.SubItemsExpandWidth = 14;
            this.btnLocateTo.Text = "定位至";
            this.btnLocateTo.Click += new System.EventHandler(this.btnLocateTo_Click);
            // 
            // btnGetPos
            // 
            this.btnGetPos.Image = ((System.Drawing.Image)(resources.GetObject("btnGetPos.Image")));
            this.btnGetPos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGetPos.Name = "btnGetPos";
            this.btnGetPos.SubItemsExpandWidth = 14;
            this.btnGetPos.Text = "获取位置";
            this.btnGetPos.Click += new System.EventHandler(this.btnGetPos_Click);
            // 
            // btnGeoTag
            // 
            this.btnGeoTag.Image = ((System.Drawing.Image)(resources.GetObject("btnGeoTag.Image")));
            this.btnGeoTag.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGeoTag.Name = "btnGeoTag";
            this.btnGeoTag.SubItemsExpandWidth = 14;
            this.btnGeoTag.Text = "地质标签";
            this.btnGeoTag.Click += new System.EventHandler(this.btnGeoTag_Click);
            // 
            // btnGeoPoint
            // 
            this.btnGeoPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnGeoPoint.Image")));
            this.btnGeoPoint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGeoPoint.Name = "btnGeoPoint";
            this.btnGeoPoint.SubItemsExpandWidth = 14;
            this.btnGeoPoint.Text = "地质点";
            this.btnGeoPoint.Click += new System.EventHandler(this.btnGeoPoint_Click);
            // 
            // btnGeoLine
            // 
            this.btnGeoLine.Image = ((System.Drawing.Image)(resources.GetObject("btnGeoLine.Image")));
            this.btnGeoLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGeoLine.Name = "btnGeoLine";
            this.btnGeoLine.SubItemsExpandWidth = 14;
            this.btnGeoLine.Text = "地质界线";
            this.btnGeoLine.Click += new System.EventHandler(this.btnGeoLine_Click);
            // 
            // btnGeoArea
            // 
            this.btnGeoArea.Image = ((System.Drawing.Image)(resources.GetObject("btnGeoArea.Image")));
            this.btnGeoArea.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGeoArea.Name = "btnGeoArea";
            this.btnGeoArea.SubItemsExpandWidth = 14;
            this.btnGeoArea.Text = "地质界面";
            this.btnGeoArea.Click += new System.EventHandler(this.btnGeoArea_Click);
            // 
            // btnGeoPolygon3D
            // 
            this.btnGeoPolygon3D.Image = ((System.Drawing.Image)(resources.GetObject("btnGeoPolygon3D.Image")));
            this.btnGeoPolygon3D.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGeoPolygon3D.Name = "btnGeoPolygon3D";
            this.btnGeoPolygon3D.SubItemsExpandWidth = 14;
            this.btnGeoPolygon3D.Text = "地质块体";
            this.btnGeoPolygon3D.Click += new System.EventHandler(this.btnGeoPolygon3D_Click);
            // 
            // btnTerrainProfile
            // 
            this.btnTerrainProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnTerrainProfile.Image")));
            this.btnTerrainProfile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTerrainProfile.Name = "btnTerrainProfile";
            this.btnTerrainProfile.SubItemsExpandWidth = 14;
            this.btnTerrainProfile.Text = "地形剖面";
            this.btnTerrainProfile.Click += new System.EventHandler(this.btnTerrainProfile_Click);
            // 
            // btnContourMap
            // 
            this.btnContourMap.Image = ((System.Drawing.Image)(resources.GetObject("btnContourMap.Image")));
            this.btnContourMap.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnContourMap.Name = "btnContourMap";
            this.btnContourMap.SubItemsExpandWidth = 14;
            this.btnContourMap.Text = "画等高线";
            this.btnContourMap.Click += new System.EventHandler(this.btnContourMap_Click);
            // 
            // btnTest
            // 
            this.btnTest.Name = "btnTest";
            this.btnTest.SubItemsExpandWidth = 14;
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // axTE3DWindow1
            // 
            this.axTE3DWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axTE3DWindow1.Enabled = true;
            this.axTE3DWindow1.Location = new System.Drawing.Point(206, 58);
            this.axTE3DWindow1.Name = "axTE3DWindow1";
            this.axTE3DWindow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTE3DWindow1.OcxState")));
            this.axTE3DWindow1.Size = new System.Drawing.Size(845, 515);
            this.axTE3DWindow1.TabIndex = 1;
            // 
            // axTEInformationWindow1
            // 
            this.axTEInformationWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axTEInformationWindow1.Enabled = true;
            this.axTEInformationWindow1.Location = new System.Drawing.Point(0, 58);
            this.axTEInformationWindow1.Name = "axTEInformationWindow1";
            this.axTEInformationWindow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTEInformationWindow1.OcxState")));
            this.axTEInformationWindow1.Size = new System.Drawing.Size(204, 515);
            this.axTEInformationWindow1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1051, 572);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.axTE3DWindow1);
            this.Controls.Add(this.axTEInformationWindow1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FieldGeo3D";
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxTerraExplorerX.AxTEInformationWindow axTEInformationWindow1;
        private AxTerraExplorerX.AxTE3DWindow axTE3DWindow1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnOpen;
        private DevComponents.DotNetBar.ButtonItem btnGeoArea;
        private DevComponents.DotNetBar.ButtonItem btnGeoLine;
        private DevComponents.DotNetBar.ButtonItem btnGeoTag;
        private DevComponents.DotNetBar.ButtonItem btnTerrainProfile;
        private DevComponents.DotNetBar.ButtonItem btnGeoPolygon3D;
        private DevComponents.DotNetBar.ButtonItem btnGeoPoint;
        private DevComponents.DotNetBar.ButtonItem btnLocateTo;
        private DevComponents.DotNetBar.ButtonItem btnGetPos;
        private DevComponents.DotNetBar.ButtonItem btnContourMap;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnSaveAs;
        private DevComponents.DotNetBar.ButtonItem btnTest;
    }
}

