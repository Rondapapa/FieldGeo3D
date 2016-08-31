namespace FGeo3D_TE.GeoImage
{
    partial class FrmRectification
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
            this.labelXGCPNo = new DevComponents.DotNetBar.LabelX();
            this.labelXScreenPoint = new DevComponents.DotNetBar.LabelX();
            this.labelXWorldPoint = new DevComponents.DotNetBar.LabelX();
            this.textBoxXSPX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXSPY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXSPZ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXWPX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXWPY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXWPZ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBoxRectifyData = new System.Windows.Forms.GroupBox();
            this.labelXZCoord = new DevComponents.DotNetBar.LabelX();
            this.labelXYCoord = new DevComponents.DotNetBar.LabelX();
            this.labelXXCoord = new DevComponents.DotNetBar.LabelX();
            this.buttonXSave = new DevComponents.DotNetBar.ButtonX();
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.textBoxXGCPNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBoxRectifyData.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelXGCPNo
            // 
            // 
            // 
            // 
            this.labelXGCPNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXGCPNo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelXGCPNo.Location = new System.Drawing.Point(12, 8);
            this.labelXGCPNo.Name = "labelXGCPNo";
            this.labelXGCPNo.Size = new System.Drawing.Size(125, 27);
            this.labelXGCPNo.TabIndex = 0;
            this.labelXGCPNo.Text = "当前控制点编号：";
            // 
            // labelXScreenPoint
            // 
            // 
            // 
            // 
            this.labelXScreenPoint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXScreenPoint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelXScreenPoint.Location = new System.Drawing.Point(11, 52);
            this.labelXScreenPoint.Name = "labelXScreenPoint";
            this.labelXScreenPoint.Size = new System.Drawing.Size(83, 27);
            this.labelXScreenPoint.TabIndex = 0;
            this.labelXScreenPoint.Text = "屏幕坐标：";
            // 
            // labelXWorldPoint
            // 
            // 
            // 
            // 
            this.labelXWorldPoint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXWorldPoint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelXWorldPoint.Location = new System.Drawing.Point(11, 85);
            this.labelXWorldPoint.Name = "labelXWorldPoint";
            this.labelXWorldPoint.Size = new System.Drawing.Size(83, 27);
            this.labelXWorldPoint.TabIndex = 0;
            this.labelXWorldPoint.Text = "真实坐标：";
            // 
            // textBoxXSPX
            // 
            // 
            // 
            // 
            this.textBoxXSPX.Border.Class = "TextBoxBorder";
            this.textBoxXSPX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXSPX.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXSPX.Location = new System.Drawing.Point(105, 53);
            this.textBoxXSPX.Name = "textBoxXSPX";
            this.textBoxXSPX.PreventEnterBeep = true;
            this.textBoxXSPX.ReadOnly = true;
            this.textBoxXSPX.Size = new System.Drawing.Size(96, 23);
            this.textBoxXSPX.TabIndex = 2;
            // 
            // textBoxXSPY
            // 
            // 
            // 
            // 
            this.textBoxXSPY.Border.Class = "TextBoxBorder";
            this.textBoxXSPY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXSPY.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXSPY.Location = new System.Drawing.Point(207, 53);
            this.textBoxXSPY.Name = "textBoxXSPY";
            this.textBoxXSPY.PreventEnterBeep = true;
            this.textBoxXSPY.ReadOnly = true;
            this.textBoxXSPY.Size = new System.Drawing.Size(96, 23);
            this.textBoxXSPY.TabIndex = 2;
            // 
            // textBoxXSPZ
            // 
            // 
            // 
            // 
            this.textBoxXSPZ.Border.Class = "TextBoxBorder";
            this.textBoxXSPZ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXSPZ.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXSPZ.Location = new System.Drawing.Point(309, 53);
            this.textBoxXSPZ.Name = "textBoxXSPZ";
            this.textBoxXSPZ.PreventEnterBeep = true;
            this.textBoxXSPZ.ReadOnly = true;
            this.textBoxXSPZ.Size = new System.Drawing.Size(96, 23);
            this.textBoxXSPZ.TabIndex = 2;
            // 
            // textBoxXWPX
            // 
            // 
            // 
            // 
            this.textBoxXWPX.Border.Class = "TextBoxBorder";
            this.textBoxXWPX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXWPX.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXWPX.Location = new System.Drawing.Point(105, 85);
            this.textBoxXWPX.Name = "textBoxXWPX";
            this.textBoxXWPX.PreventEnterBeep = true;
            this.textBoxXWPX.Size = new System.Drawing.Size(96, 23);
            this.textBoxXWPX.TabIndex = 2;
            this.textBoxXWPX.TextChanged += new System.EventHandler(this.textBoxXWPX_TextChanged);
            // 
            // textBoxXWPY
            // 
            // 
            // 
            // 
            this.textBoxXWPY.Border.Class = "TextBoxBorder";
            this.textBoxXWPY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXWPY.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXWPY.Location = new System.Drawing.Point(207, 85);
            this.textBoxXWPY.Name = "textBoxXWPY";
            this.textBoxXWPY.PreventEnterBeep = true;
            this.textBoxXWPY.Size = new System.Drawing.Size(96, 23);
            this.textBoxXWPY.TabIndex = 2;
            this.textBoxXWPY.TextChanged += new System.EventHandler(this.textBoxXWPY_TextChanged);
            // 
            // textBoxXWPZ
            // 
            // 
            // 
            // 
            this.textBoxXWPZ.Border.Class = "TextBoxBorder";
            this.textBoxXWPZ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXWPZ.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXWPZ.Location = new System.Drawing.Point(309, 85);
            this.textBoxXWPZ.Name = "textBoxXWPZ";
            this.textBoxXWPZ.PreventEnterBeep = true;
            this.textBoxXWPZ.Size = new System.Drawing.Size(96, 23);
            this.textBoxXWPZ.TabIndex = 2;
            this.textBoxXWPZ.TextChanged += new System.EventHandler(this.textBoxXWPZ_TextChanged);
            // 
            // groupBoxRectifyData
            // 
            this.groupBoxRectifyData.Controls.Add(this.textBoxXSPX);
            this.groupBoxRectifyData.Controls.Add(this.textBoxXWPZ);
            this.groupBoxRectifyData.Controls.Add(this.labelXZCoord);
            this.groupBoxRectifyData.Controls.Add(this.labelXYCoord);
            this.groupBoxRectifyData.Controls.Add(this.labelXXCoord);
            this.groupBoxRectifyData.Controls.Add(this.labelXScreenPoint);
            this.groupBoxRectifyData.Controls.Add(this.textBoxXSPZ);
            this.groupBoxRectifyData.Controls.Add(this.labelXWorldPoint);
            this.groupBoxRectifyData.Controls.Add(this.textBoxXWPY);
            this.groupBoxRectifyData.Controls.Add(this.textBoxXWPX);
            this.groupBoxRectifyData.Controls.Add(this.textBoxXSPY);
            this.groupBoxRectifyData.Location = new System.Drawing.Point(12, 41);
            this.groupBoxRectifyData.Name = "groupBoxRectifyData";
            this.groupBoxRectifyData.Size = new System.Drawing.Size(410, 122);
            this.groupBoxRectifyData.TabIndex = 3;
            this.groupBoxRectifyData.TabStop = false;
            this.groupBoxRectifyData.Text = "校准信息";
            // 
            // labelXZCoord
            // 
            // 
            // 
            // 
            this.labelXZCoord.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXZCoord.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelXZCoord.Location = new System.Drawing.Point(309, 20);
            this.labelXZCoord.Name = "labelXZCoord";
            this.labelXZCoord.Size = new System.Drawing.Size(96, 27);
            this.labelXZCoord.TabIndex = 0;
            this.labelXZCoord.Text = "Z";
            this.labelXZCoord.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelXYCoord
            // 
            // 
            // 
            // 
            this.labelXYCoord.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXYCoord.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelXYCoord.Location = new System.Drawing.Point(207, 20);
            this.labelXYCoord.Name = "labelXYCoord";
            this.labelXYCoord.Size = new System.Drawing.Size(96, 27);
            this.labelXYCoord.TabIndex = 0;
            this.labelXYCoord.Text = "Y";
            this.labelXYCoord.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelXXCoord
            // 
            // 
            // 
            // 
            this.labelXXCoord.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXXCoord.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXXCoord.Location = new System.Drawing.Point(105, 20);
            this.labelXXCoord.Name = "labelXXCoord";
            this.labelXXCoord.Size = new System.Drawing.Size(96, 27);
            this.labelXXCoord.TabIndex = 0;
            this.labelXXCoord.Text = "X";
            this.labelXXCoord.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonXSave
            // 
            this.buttonXSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXSave.Enabled = false;
            this.buttonXSave.Location = new System.Drawing.Point(106, 177);
            this.buttonXSave.Name = "buttonXSave";
            this.buttonXSave.Size = new System.Drawing.Size(85, 29);
            this.buttonXSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXSave.TabIndex = 4;
            this.buttonXSave.Text = "保存并关闭";
            this.buttonXSave.Click += new System.EventHandler(this.buttonXSave_Click);
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Location = new System.Drawing.Point(261, 177);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Size = new System.Drawing.Size(85, 29);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXCancel.TabIndex = 4;
            this.buttonXCancel.Text = "放弃并关闭";
            this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
            // 
            // textBoxXGCPNo
            // 
            // 
            // 
            // 
            this.textBoxXGCPNo.Border.Class = "TextBoxBorder";
            this.textBoxXGCPNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXGCPNo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxXGCPNo.Location = new System.Drawing.Point(134, 8);
            this.textBoxXGCPNo.Name = "textBoxXGCPNo";
            this.textBoxXGCPNo.PreventEnterBeep = true;
            this.textBoxXGCPNo.ReadOnly = true;
            this.textBoxXGCPNo.Size = new System.Drawing.Size(43, 23);
            this.textBoxXGCPNo.TabIndex = 2;
            this.textBoxXGCPNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmRectification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 218);
            this.Controls.Add(this.textBoxXGCPNo);
            this.Controls.Add(this.buttonXCancel);
            this.Controls.Add(this.buttonXSave);
            this.Controls.Add(this.groupBoxRectifyData);
            this.Controls.Add(this.labelXGCPNo);
            this.Name = "FrmRectification";
            this.Text = "校准控制";
            this.groupBoxRectifyData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelXGCPNo;
        private DevComponents.DotNetBar.LabelX labelXScreenPoint;
        private DevComponents.DotNetBar.LabelX labelXWorldPoint;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXSPX;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXSPY;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXSPZ;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXWPX;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXWPY;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXWPZ;
        private System.Windows.Forms.GroupBox groupBoxRectifyData;
        private DevComponents.DotNetBar.LabelX labelXZCoord;
        private DevComponents.DotNetBar.LabelX labelXYCoord;
        private DevComponents.DotNetBar.LabelX labelXXCoord;
        private DevComponents.DotNetBar.ButtonX buttonXSave;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXGCPNo;
    }
}