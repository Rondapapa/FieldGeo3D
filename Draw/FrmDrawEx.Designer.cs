namespace Draw
{
    partial class FrmDrawEx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.toolbar = new DevExpress.XtraBars.Bar();
            this.btnAddLine = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnBkColor = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnOK = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.toolbar,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnClose,
            this.btnBkColor,
            this.btnAddLine,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnOK,
            this.btnCancel});
            this.barManager.MaxItemId = 7;
            this.barManager.StatusBar = this.bar3;
            // 
            // toolbar
            // 
            this.toolbar.BarName = "Tools";
            this.toolbar.DockCol = 0;
            this.toolbar.DockRow = 0;
            this.toolbar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.toolbar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddLine),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBkColor),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOK),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel)});
            this.toolbar.Text = "Tools";
            // 
            // btnAddLine
            // 
            this.btnAddLine.Caption = "添加线";
            this.btnAddLine.Id = 2;
            this.btnAddLine.LargeGlyph = global::Draw.Properties.Resources.line;
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddLine_ItemClick);
            // 
            // btnBkColor
            // 
            this.btnBkColor.Caption = "背景";
            this.btnBkColor.Id = 1;
            this.btnBkColor.LargeGlyph = global::Draw.Properties.Resources.bkColor;
            this.btnBkColor.Name = "btnBkColor";
            this.btnBkColor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBkColor_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "放大";
            this.btnZoomIn.Id = 3;
            this.btnZoomIn.LargeGlyph = global::Draw.Properties.Resources.zoom_in;
            this.btnZoomIn.Name = "btnZoomIn";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "缩小";
            this.btnZoomOut.Id = 4;
            this.btnZoomOut.LargeGlyph = global::Draw.Properties.Resources.zoom_out;
            this.btnZoomOut.Name = "btnZoomOut";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "关闭";
            this.btnClose.Id = 0;
            this.btnClose.LargeGlyph = global::Draw.Properties.Resources.close;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnOK
            // 
            this.btnOK.Caption = "确定";
            this.btnOK.Id = 5;
            this.btnOK.LargeGlyph = global::Draw.Properties.Resources.ok;
            this.btnOK.Name = "btnOK";
            this.btnOK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOK_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "取消";
            this.btnCancel.Id = 6;
            this.btnCancel.LargeGlyph = global::Draw.Properties.Resources.cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(947, 83);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 478);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(947, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 83);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 395);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(947, 83);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 395);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(0, 88);
            this.pictureEdit1.MenuManager = this.barManager;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(946, 390);
            this.pictureEdit1.TabIndex = 4;
            // 
            // FrmDrawEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 501);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDrawEx";
            this.Text = "FrmDrawEx";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDrawEx_FormClosing);
            this.Resize += new System.EventHandler(this.FrmDrawEx_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar toolbar;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnClose;
        private DevExpress.XtraBars.BarLargeButtonItem btnBkColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private DevExpress.XtraBars.BarLargeButtonItem btnAddLine;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnOK;
        private DevExpress.XtraBars.BarLargeButtonItem btnCancel;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}