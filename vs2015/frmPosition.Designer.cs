namespace FGeo3D_TE
{
    partial class FrmPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosition));
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX = new DevComponents.DotNetBar.LabelX();
            this.labelY = new DevComponents.DotNetBar.LabelX();
            this.tbX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(12, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(139, 31);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelX
            // 
            // 
            // 
            // 
            this.labelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX.Location = new System.Drawing.Point(12, 18);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(61, 25);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "经度";
            // 
            // labelY
            // 
            // 
            // 
            // 
            this.labelY.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelY.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelY.Location = new System.Drawing.Point(12, 54);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(61, 26);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "纬度";
            // 
            // tbX
            // 
            // 
            // 
            // 
            this.tbX.Border.Class = "TextBoxBorder";
            this.tbX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbX.Location = new System.Drawing.Point(115, 12);
            this.tbX.Name = "tbX";
            this.tbX.PreventEnterBeep = true;
            this.tbX.Size = new System.Drawing.Size(192, 31);
            this.tbX.TabIndex = 3;
            this.tbX.TextChanged += new System.EventHandler(this.tbX_TextChanged);
            // 
            // tbY
            // 
            // 
            // 
            // 
            this.tbY.Border.Class = "TextBoxBorder";
            this.tbY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbY.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbY.Location = new System.Drawing.Point(115, 49);
            this.tbY.Name = "tbY";
            this.tbY.PreventEnterBeep = true;
            this.tbY.Size = new System.Drawing.Size(192, 31);
            this.tbY.TabIndex = 4;
            this.tbY.TextChanged += new System.EventHandler(this.tbY_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(168, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 133);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入位置信息";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX;
        private DevComponents.DotNetBar.LabelX labelY;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbX;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbY;
        internal DevComponents.DotNetBar.ButtonX btnOK;
    }
}