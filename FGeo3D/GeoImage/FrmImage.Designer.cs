namespace FGeo3D_TE.GeoImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImage));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnGetImageFromCamera = new DevComponents.DotNetBar.ButtonX();
            this.btnDraw = new DevComponents.DotNetBar.ButtonX();
            this.colorPickerBtn = new DevComponents.DotNetBar.ColorPickerButton();
            this.btnDrawApply = new DevComponents.DotNetBar.ButtonX();
            this.btnRectify = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnGetImageFromFile = new DevComponents.DotNetBar.ButtonX();
            this.btnErase = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(91, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(924, 597);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnGetImageFromCamera
            // 
            this.btnGetImageFromCamera.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetImageFromCamera.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetImageFromCamera.Image = ((System.Drawing.Image)(resources.GetObject("btnGetImageFromCamera.Image")));
            this.btnGetImageFromCamera.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGetImageFromCamera.Location = new System.Drawing.Point(6, 12);
            this.btnGetImageFromCamera.Name = "btnGetImageFromCamera";
            this.btnGetImageFromCamera.Size = new System.Drawing.Size(75, 75);
            this.btnGetImageFromCamera.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetImageFromCamera.TabIndex = 1;
            this.btnGetImageFromCamera.Text = "拍摄图像";
            this.btnGetImageFromCamera.Click += new System.EventHandler(this.btnGetImageFromCamera_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDraw.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnDraw.Image")));
            this.btnDraw.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDraw.Location = new System.Drawing.Point(6, 205);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 75);
            this.btnDraw.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "绘制标记";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // colorPickerBtn
            // 
            this.colorPickerBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.colorPickerBtn.BackColor = System.Drawing.SystemColors.Control;
            this.colorPickerBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.colorPickerBtn.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerBtn.Image")));
            this.colorPickerBtn.Location = new System.Drawing.Point(6, 176);
            this.colorPickerBtn.Name = "colorPickerBtn";
            this.colorPickerBtn.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.colorPickerBtn.Size = new System.Drawing.Size(75, 23);
            this.colorPickerBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colorPickerBtn.TabIndex = 3;
            this.colorPickerBtn.Text = "颜色";
            this.colorPickerBtn.SelectedColorChanged += new System.EventHandler(this.colorPickerBtn_SelectedColorChanged);
            // 
            // btnDrawApply
            // 
            this.btnDrawApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrawApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDrawApply.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawApply.Image")));
            this.btnDrawApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDrawApply.Location = new System.Drawing.Point(6, 372);
            this.btnDrawApply.Name = "btnDrawApply";
            this.btnDrawApply.Size = new System.Drawing.Size(75, 75);
            this.btnDrawApply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrawApply.TabIndex = 4;
            this.btnDrawApply.Text = "确认绘制";
            this.btnDrawApply.Click += new System.EventHandler(this.btnDrawApply_Click);
            // 
            // btnRectify
            // 
            this.btnRectify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRectify.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRectify.Location = new System.Drawing.Point(6, 453);
            this.btnRectify.Name = "btnRectify";
            this.btnRectify.Size = new System.Drawing.Size(75, 75);
            this.btnRectify.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRectify.TabIndex = 5;
            this.btnRectify.Text = "校正纠偏";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSave.Location = new System.Drawing.Point(6, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 75);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存编录";
            // 
            // btnGetImageFromFile
            // 
            this.btnGetImageFromFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetImageFromFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetImageFromFile.Image = ((System.Drawing.Image)(resources.GetObject("btnGetImageFromFile.Image")));
            this.btnGetImageFromFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGetImageFromFile.Location = new System.Drawing.Point(6, 95);
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
            this.btnErase.Location = new System.Drawing.Point(6, 287);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 75);
            this.btnErase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnErase.TabIndex = 7;
            this.btnErase.Text = "擦除标记";
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // FrmImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 616);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRectify);
            this.Controls.Add(this.btnDrawApply);
            this.Controls.Add(this.colorPickerBtn);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnGetImageFromFile);
            this.Controls.Add(this.btnGetImageFromCamera);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImage";
            this.Text = "地质图像编录";
            this.Load += new System.EventHandler(this.FrmImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private DevComponents.DotNetBar.ButtonX btnGetImageFromCamera;
        private DevComponents.DotNetBar.ButtonX btnDraw;
        private DevComponents.DotNetBar.ColorPickerButton colorPickerBtn;
        private DevComponents.DotNetBar.ButtonX btnDrawApply;
        private DevComponents.DotNetBar.ButtonX btnRectify;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnGetImageFromFile;
        private DevComponents.DotNetBar.ButtonX btnErase;
    }
}