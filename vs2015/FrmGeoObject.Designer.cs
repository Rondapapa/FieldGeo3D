namespace FGeo3D_TE
{
    partial class FrmGeoObject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGeoObject));
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.tbColor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelLineColor = new DevComponents.DotNetBar.LabelX();
            this.colorCombControl = new DevComponents.DotNetBar.ColorPickers.ColorCombControl();
            this.SuspendLayout();
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(70, 21);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(486, 29);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // labelName
            // 
            // 
            // 
            // 
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(12, 21);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 29);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "名称";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.BackColor = System.Drawing.Color.Silver;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(473, 65);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 30);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.Symbol = "58826";
            this.btnOK.SymbolColor = System.Drawing.Color.Black;
            this.btnOK.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(384, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 29);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbColor
            // 
            // 
            // 
            // 
            this.tbColor.Border.Class = "TextBoxBorder";
            this.tbColor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbColor.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbColor.Location = new System.Drawing.Point(70, 65);
            this.tbColor.Name = "tbColor";
            this.tbColor.PreventEnterBeep = true;
            this.tbColor.ReadOnly = true;
            this.tbColor.Size = new System.Drawing.Size(308, 29);
            this.tbColor.TabIndex = 3;
            this.tbColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLineColor
            // 
            // 
            // 
            // 
            this.labelLineColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLineColor.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLineColor.Location = new System.Drawing.Point(12, 65);
            this.labelLineColor.Name = "labelLineColor";
            this.labelLineColor.Size = new System.Drawing.Size(52, 29);
            this.labelLineColor.TabIndex = 2;
            this.labelLineColor.Text = "颜色";
            // 
            // colorCombControl
            // 
            this.colorCombControl.Location = new System.Drawing.Point(12, 100);
            this.colorCombControl.Name = "colorCombControl";
            this.colorCombControl.Size = new System.Drawing.Size(544, 490);
            this.colorCombControl.TabIndex = 4;
            this.colorCombControl.Text = "colorCombControl1";
            this.colorCombControl.SelectedColorChanged += new System.EventHandler(this.colorCombControl_SelectedColorChanged);
            // 
            // FrmGeoObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 567);
            this.Controls.Add(this.colorCombControl);
            this.Controls.Add(this.tbColor);
            this.Controls.Add(this.labelLineColor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGeoObject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建";
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.Controls.TextBoxX tbName;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbColor;
        private DevComponents.DotNetBar.ColorPickers.ColorCombControl colorCombControl;
        internal DevComponents.DotNetBar.LabelX labelName;
        internal DevComponents.DotNetBar.LabelX labelLineColor;
    }
}