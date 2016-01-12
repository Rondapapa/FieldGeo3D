namespace FGeo3D_TE
{
    partial class frmObjProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObjProperty));
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.btnGetLineColor = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.tbLineColor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnGetFillColor = new DevComponents.DotNetBar.ButtonX();
            this.tbFillColor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelLineColor = new DevComponents.DotNetBar.LabelX();
            this.labelFillColor = new DevComponents.DotNetBar.LabelX();
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
            this.tbName.Location = new System.Drawing.Point(127, 21);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(404, 29);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "地质对象名称";
            // 
            // labelName
            // 
            // 
            // 
            // 
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(12, 21);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(109, 29);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "对象名称";
            // 
            // btnGetLineColor
            // 
            this.btnGetLineColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetLineColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetLineColor.Location = new System.Drawing.Point(433, 65);
            this.btnGetLineColor.Name = "btnGetLineColor";
            this.btnGetLineColor.Size = new System.Drawing.Size(98, 29);
            this.btnGetLineColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetLineColor.TabIndex = 1;
            this.btnGetLineColor.Text = "取色";
            this.btnGetLineColor.Click += new System.EventHandler(this.btnGetLineColor_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(104, 159);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 38);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(304, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 38);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbLineColor
            // 
            // 
            // 
            // 
            this.tbLineColor.Border.Class = "TextBoxBorder";
            this.tbLineColor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbLineColor.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLineColor.Location = new System.Drawing.Point(127, 65);
            this.tbLineColor.Name = "tbLineColor";
            this.tbLineColor.PreventEnterBeep = true;
            this.tbLineColor.ReadOnly = true;
            this.tbLineColor.Size = new System.Drawing.Size(289, 29);
            this.tbLineColor.TabIndex = 3;
            this.tbLineColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGetFillColor
            // 
            this.btnGetFillColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetFillColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetFillColor.Location = new System.Drawing.Point(433, 110);
            this.btnGetFillColor.Name = "btnGetFillColor";
            this.btnGetFillColor.Size = new System.Drawing.Size(98, 29);
            this.btnGetFillColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetFillColor.TabIndex = 1;
            this.btnGetFillColor.Text = "取色";
            this.btnGetFillColor.Click += new System.EventHandler(this.buttonGetFillColor_Click);
            // 
            // tbFillColor
            // 
            // 
            // 
            // 
            this.tbFillColor.Border.Class = "TextBoxBorder";
            this.tbFillColor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbFillColor.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFillColor.Location = new System.Drawing.Point(127, 110);
            this.tbFillColor.Name = "tbFillColor";
            this.tbFillColor.PreventEnterBeep = true;
            this.tbFillColor.ReadOnly = true;
            this.tbFillColor.Size = new System.Drawing.Size(289, 29);
            this.tbFillColor.TabIndex = 3;
            this.tbFillColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLineColor
            // 
            // 
            // 
            // 
            this.labelLineColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLineColor.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLineColor.Location = new System.Drawing.Point(12, 65);
            this.labelLineColor.Name = "labelLineColor";
            this.labelLineColor.Size = new System.Drawing.Size(109, 29);
            this.labelLineColor.TabIndex = 2;
            this.labelLineColor.Text = "边界颜色";
            // 
            // labelFillColor
            // 
            // 
            // 
            // 
            this.labelFillColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelFillColor.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFillColor.Location = new System.Drawing.Point(12, 110);
            this.labelFillColor.Name = "labelFillColor";
            this.labelFillColor.Size = new System.Drawing.Size(109, 29);
            this.labelFillColor.TabIndex = 2;
            this.labelFillColor.Text = "填充颜色";
            // 
            // frmObjProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 219);
            this.Controls.Add(this.tbFillColor);
            this.Controls.Add(this.tbLineColor);
            this.Controls.Add(this.labelFillColor);
            this.Controls.Add(this.labelLineColor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnGetFillColor);
            this.Controls.Add(this.btnGetLineColor);
            this.Controls.Add(this.tbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObjProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地质对象名称及颜色";
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.Controls.TextBoxX tbName;
        private DevComponents.DotNetBar.LabelX labelName;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbLineColor;
        internal DevComponents.DotNetBar.ButtonX btnGetLineColor;
        internal DevComponents.DotNetBar.ButtonX btnGetFillColor;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbFillColor;
        private DevComponents.DotNetBar.LabelX labelLineColor;
        private DevComponents.DotNetBar.LabelX labelFillColor;
    }
}