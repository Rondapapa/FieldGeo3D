namespace FGeo3D_TE.Frm
{
    partial class FrmPoint
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
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelID = new DevComponents.DotNetBar.LabelX();
            this.tbID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelLocation = new DevComponents.DotNetBar.LabelX();
            this.btnGetFromMap = new DevComponents.DotNetBar.ButtonX();
            this.labelUseLatLong = new DevComponents.DotNetBar.LabelX();
            this.tbLong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbLat = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelName
            // 
            // 
            // 
            // 
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(12, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(54, 27);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "名称";
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(72, 53);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(263, 29);
            this.tbName.TabIndex = 1;
            // 
            // labelID
            // 
            // 
            // 
            // 
            this.labelID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelID.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelID.Location = new System.Drawing.Point(12, 12);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(54, 27);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "编号";
            // 
            // tbID
            // 
            // 
            // 
            // 
            this.tbID.Border.Class = "TextBoxBorder";
            this.tbID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbID.Location = new System.Drawing.Point(72, 10);
            this.tbID.Name = "tbID";
            this.tbID.PreventEnterBeep = true;
            this.tbID.Size = new System.Drawing.Size(263, 29);
            this.tbID.TabIndex = 1;
            // 
            // labelLocation
            // 
            // 
            // 
            // 
            this.labelLocation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLocation.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLocation.Location = new System.Drawing.Point(12, 101);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(54, 27);
            this.labelLocation.TabIndex = 0;
            this.labelLocation.Text = "位置";
            // 
            // btnGetFromMap
            // 
            this.btnGetFromMap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetFromMap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetFromMap.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetFromMap.Location = new System.Drawing.Point(72, 101);
            this.btnGetFromMap.Name = "btnGetFromMap";
            this.btnGetFromMap.Size = new System.Drawing.Size(134, 27);
            this.btnGetFromMap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetFromMap.TabIndex = 2;
            this.btnGetFromMap.Text = "在地图中选取";
            this.btnGetFromMap.Click += new System.EventHandler(this.btnGetFromMap_Click);
            // 
            // labelUseLatLong
            // 
            // 
            // 
            // 
            this.labelUseLatLong.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelUseLatLong.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUseLatLong.Location = new System.Drawing.Point(224, 101);
            this.labelUseLatLong.Name = "labelUseLatLong";
            this.labelUseLatLong.Size = new System.Drawing.Size(111, 27);
            this.labelUseLatLong.TabIndex = 0;
            this.labelUseLatLong.Text = "或输入坐标信息";
            // 
            // tbLong
            // 
            // 
            // 
            // 
            this.tbLong.Border.Class = "TextBoxBorder";
            this.tbLong.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbLong.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLong.Location = new System.Drawing.Point(115, 143);
            this.tbLong.Name = "tbLong";
            this.tbLong.PreventEnterBeep = true;
            this.tbLong.Size = new System.Drawing.Size(208, 29);
            this.tbLong.TabIndex = 1;
            // 
            // tbLat
            // 
            // 
            // 
            // 
            this.tbLat.Border.Class = "TextBoxBorder";
            this.tbLat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbLat.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLat.Location = new System.Drawing.Point(115, 178);
            this.tbLat.Name = "tbLat";
            this.tbLat.PreventEnterBeep = true;
            this.tbLat.Size = new System.Drawing.Size(208, 29);
            this.tbLat.TabIndex = 1;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(72, 145);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(37, 27);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "经度";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(72, 180);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(37, 27);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "纬度";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOK.Location = new System.Drawing.Point(189, 215);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(134, 27);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "确认坐标";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FrmPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 252);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.btnGetFromMap);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbLat);
            this.Controls.Add(this.tbLong);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelUseLatLong);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelName);
            this.Name = "FrmPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入地质点信息";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelName;
        private DevComponents.DotNetBar.LabelX labelID;
        private DevComponents.DotNetBar.LabelX labelLocation;
        private DevComponents.DotNetBar.ButtonX btnGetFromMap;
        private DevComponents.DotNetBar.LabelX labelUseLatLong;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbName;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbID;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbLong;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbLat;
    }
}