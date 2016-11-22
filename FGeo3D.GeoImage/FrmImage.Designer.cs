namespace FGeo3D.GeoImage
{
    partial class FrmImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImage));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnDraw = new DevComponents.DotNetBar.ButtonX();
            this.btnDrawApply = new DevComponents.DotNetBar.ButtonX();
            this.btnRectify = new DevComponents.DotNetBar.ButtonX();
            this.btnGetImageFromFile = new DevComponents.DotNetBar.ButtonX();
            this.btnErase = new DevComponents.DotNetBar.ButtonX();
            this.labelXColor = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonXColor = new DevComponents.DotNetBar.ButtonX();
            this.buttonXClosetRing = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(87, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(924, 591);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDraw.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnDraw.Image")));
            this.btnDraw.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDraw.Location = new System.Drawing.Point(6, 285);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 75);
            this.btnDraw.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "绘制标记";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnDrawApply
            // 
            this.btnDrawApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrawApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDrawApply.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawApply.Image")));
            this.btnDrawApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDrawApply.Location = new System.Drawing.Point(6, 528);
            this.btnDrawApply.Name = "btnDrawApply";
            this.btnDrawApply.Size = new System.Drawing.Size(75, 75);
            this.btnDrawApply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrawApply.TabIndex = 4;
            this.btnDrawApply.Text = "保存标记";
            this.btnDrawApply.Click += new System.EventHandler(this.btnDrawApply_Click);
            // 
            // btnRectify
            // 
            this.btnRectify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRectify.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRectify.Image = ((System.Drawing.Image)(resources.GetObject("btnRectify.Image")));
            this.btnRectify.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRectify.Location = new System.Drawing.Point(6, 93);
            this.btnRectify.Name = "btnRectify";
            this.btnRectify.Size = new System.Drawing.Size(75, 75);
            this.btnRectify.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnRectify.TabIndex = 5;
            this.btnRectify.Text = "开始校正";
            this.btnRectify.Click += new System.EventHandler(this.btnRectify_Click);
            // 
            // btnGetImageFromFile
            // 
            this.btnGetImageFromFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetImageFromFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetImageFromFile.Image = ((System.Drawing.Image)(resources.GetObject("btnGetImageFromFile.Image")));
            this.btnGetImageFromFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGetImageFromFile.Location = new System.Drawing.Point(6, 12);
            this.btnGetImageFromFile.Name = "btnGetImageFromFile";
            this.btnGetImageFromFile.Size = new System.Drawing.Size(75, 75);
            this.btnGetImageFromFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetImageFromFile.TabIndex = 1;
            this.btnGetImageFromFile.Text = "载入图像";
            this.btnGetImageFromFile.Click += new System.EventHandler(this.btnGetImageFromFile_Click);
            // 
            // btnErase
            // 
            this.btnErase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnErase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnErase.Image = ((System.Drawing.Image)(resources.GetObject("btnErase.Image")));
            this.btnErase.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnErase.Location = new System.Drawing.Point(6, 366);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 75);
            this.btnErase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnErase.TabIndex = 7;
            this.btnErase.Text = "擦除标记";
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // labelXColor
            // 
            // 
            // 
            // 
            this.labelXColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXColor.Location = new System.Drawing.Point(6, 256);
            this.labelXColor.Name = "labelXColor";
            this.labelXColor.Size = new System.Drawing.Size(75, 23);
            this.labelXColor.TabIndex = 9;
            this.labelXColor.Text = "当前颜色";
            this.labelXColor.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.OfficeMobile2014;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(71)))), ((int)(((byte)(42))))));
            // 
            // buttonXColor
            // 
            this.buttonXColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXColor.Image = ((System.Drawing.Image)(resources.GetObject("buttonXColor.Image")));
            this.buttonXColor.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonXColor.Location = new System.Drawing.Point(6, 174);
            this.buttonXColor.Name = "buttonXColor";
            this.buttonXColor.Size = new System.Drawing.Size(75, 76);
            this.buttonXColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXColor.TabIndex = 10;
            this.buttonXColor.Text = "选择颜色";
            this.buttonXColor.Click += new System.EventHandler(this.buttonXColor_Click);
            // 
            // buttonXClosetRing
            // 
            this.buttonXClosetRing.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXClosetRing.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXClosetRing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonXClosetRing.Location = new System.Drawing.Point(6, 447);
            this.buttonXClosetRing.Name = "buttonXClosetRing";
            this.buttonXClosetRing.Size = new System.Drawing.Size(75, 75);
            this.buttonXClosetRing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXClosetRing.TabIndex = 7;
            this.buttonXClosetRing.Text = "封闭标记";
            this.buttonXClosetRing.Click += new System.EventHandler(this.buttonXClosetRing_Click);
            // 
            // FrmImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 610);
            this.Controls.Add(this.buttonXColor);
            this.Controls.Add(this.labelXColor);
            this.Controls.Add(this.buttonXClosetRing);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.btnRectify);
            this.Controls.Add(this.btnDrawApply);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnGetImageFromFile);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmImage";
            this.Text = "地质图像编录";
            this.Load += new System.EventHandler(this.FrmImage_Load);
            this.Resize += new System.EventHandler(this.FrmImageResize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private DevComponents.DotNetBar.ButtonX btnDraw;
        private DevComponents.DotNetBar.ButtonX btnDrawApply;
        private DevComponents.DotNetBar.ButtonX btnRectify;
        private DevComponents.DotNetBar.ButtonX btnGetImageFromFile;
        private DevComponents.DotNetBar.ButtonX btnErase;
        private DevComponents.DotNetBar.LabelX labelXColor;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX buttonXColor;
        private DevComponents.DotNetBar.ButtonX buttonXClosetRing;
    }
}