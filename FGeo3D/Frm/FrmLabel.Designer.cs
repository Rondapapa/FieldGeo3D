namespace FGeo3D_TE.Frm
{
    partial class FrmLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLabel));
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.tbGeoLabel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(241, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 31);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbGeoLabel
            // 
            // 
            // 
            // 
            this.tbGeoLabel.Border.Class = "TextBoxBorder";
            this.tbGeoLabel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbGeoLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbGeoLabel.Location = new System.Drawing.Point(21, 12);
            this.tbGeoLabel.Name = "tbGeoLabel";
            this.tbGeoLabel.PreventEnterBeep = true;
            this.tbGeoLabel.Size = new System.Drawing.Size(192, 31);
            this.tbGeoLabel.TabIndex = 1;
            // 
            // FrmTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 58);
            this.Controls.Add(this.tbGeoLabel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入地质标签";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOK;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbGeoLabel;
    }
}