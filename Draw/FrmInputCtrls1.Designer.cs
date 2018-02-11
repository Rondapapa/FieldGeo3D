namespace Draw
{
    partial class FrmInputCtrls1
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
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable1 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer1 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.keyboardControl1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.screenX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.kwZ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelXZCoord = new DevComponents.DotNetBar.LabelX();
            this.labelXYCoord = new DevComponents.DotNetBar.LabelX();
            this.labelXXCoord = new DevComponents.DotNetBar.LabelX();
            this.labelXScreenPoint = new DevComponents.DotNetBar.LabelX();
            this.screenZ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelXWorldPoint = new DevComponents.DotNetBar.LabelX();
            this.kwY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBoxRectifyData = new System.Windows.Forms.GroupBox();
            this.kwX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.screenY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.numberOfPts = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonXSave = new DevComponents.DotNetBar.ButtonX();
            this.labelXGCPNo = new DevComponents.DotNetBar.LabelX();
            this.groupBoxRectifyData.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyboardControl1
            // 
            virtualKeyboardColorTable1.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable1.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable1.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable1.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable1.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable1.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable1.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable1.TopBarTextColor = System.Drawing.Color.White;
            this.keyboardControl1.ColorTable = virtualKeyboardColorTable1;
            this.keyboardControl1.Location = new System.Drawing.Point(12, 173);
            this.keyboardControl1.Name = "keyboardControl1";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyboardControl1.Renderer = flatStyleRenderer1;
            this.keyboardControl1.Size = new System.Drawing.Size(410, 302);
            this.keyboardControl1.TabIndex = 11;
            this.keyboardControl1.Text = "请输入真实坐标";
            // 
            // screenX
            // 
            this.screenX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.screenX.Border.Class = "TextBoxBorder";
            this.screenX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.screenX.DisabledBackColor = System.Drawing.Color.White;
            this.screenX.Font = new System.Drawing.Font("宋体", 10.5F);
            this.screenX.ForeColor = System.Drawing.Color.Black;
            this.screenX.Location = new System.Drawing.Point(105, 53);
            this.screenX.Name = "screenX";
            this.screenX.PreventEnterBeep = true;
            this.screenX.ReadOnly = true;
            this.screenX.Size = new System.Drawing.Size(96, 23);
            this.screenX.TabIndex = 2;
            // 
            // kwZ
            // 
            this.kwZ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.kwZ.Border.Class = "TextBoxBorder";
            this.kwZ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.kwZ.DisabledBackColor = System.Drawing.Color.White;
            this.kwZ.Font = new System.Drawing.Font("宋体", 10.5F);
            this.kwZ.ForeColor = System.Drawing.Color.Black;
            this.kwZ.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kwZ.Location = new System.Drawing.Point(309, 85);
            this.kwZ.Name = "kwZ";
            this.kwZ.PreventEnterBeep = true;
            this.kwZ.Size = new System.Drawing.Size(96, 23);
            this.kwZ.TabIndex = 2;
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
            // screenZ
            // 
            this.screenZ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.screenZ.Border.Class = "TextBoxBorder";
            this.screenZ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.screenZ.DisabledBackColor = System.Drawing.Color.White;
            this.screenZ.Font = new System.Drawing.Font("宋体", 10.5F);
            this.screenZ.ForeColor = System.Drawing.Color.Black;
            this.screenZ.Location = new System.Drawing.Point(309, 53);
            this.screenZ.Name = "screenZ";
            this.screenZ.PreventEnterBeep = true;
            this.screenZ.ReadOnly = true;
            this.screenZ.Size = new System.Drawing.Size(96, 23);
            this.screenZ.TabIndex = 2;
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
            // kwY
            // 
            this.kwY.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.kwY.Border.Class = "TextBoxBorder";
            this.kwY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.kwY.DisabledBackColor = System.Drawing.Color.White;
            this.kwY.Font = new System.Drawing.Font("宋体", 10.5F);
            this.kwY.ForeColor = System.Drawing.Color.Black;
            this.kwY.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kwY.Location = new System.Drawing.Point(207, 85);
            this.kwY.Name = "kwY";
            this.kwY.PreventEnterBeep = true;
            this.kwY.Size = new System.Drawing.Size(96, 23);
            this.kwY.TabIndex = 2;
            // 
            // groupBoxRectifyData
            // 
            this.groupBoxRectifyData.Controls.Add(this.screenX);
            this.groupBoxRectifyData.Controls.Add(this.kwZ);
            this.groupBoxRectifyData.Controls.Add(this.labelXZCoord);
            this.groupBoxRectifyData.Controls.Add(this.labelXYCoord);
            this.groupBoxRectifyData.Controls.Add(this.labelXXCoord);
            this.groupBoxRectifyData.Controls.Add(this.labelXScreenPoint);
            this.groupBoxRectifyData.Controls.Add(this.screenZ);
            this.groupBoxRectifyData.Controls.Add(this.labelXWorldPoint);
            this.groupBoxRectifyData.Controls.Add(this.kwY);
            this.groupBoxRectifyData.Controls.Add(this.kwX);
            this.groupBoxRectifyData.Controls.Add(this.screenY);
            this.groupBoxRectifyData.Location = new System.Drawing.Point(12, 45);
            this.groupBoxRectifyData.Name = "groupBoxRectifyData";
            this.groupBoxRectifyData.Size = new System.Drawing.Size(410, 122);
            this.groupBoxRectifyData.TabIndex = 8;
            this.groupBoxRectifyData.TabStop = false;
            this.groupBoxRectifyData.Text = "校准信息";
            // 
            // kwX
            // 
            this.kwX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.kwX.Border.Class = "TextBoxBorder";
            this.kwX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.kwX.DisabledBackColor = System.Drawing.Color.White;
            this.kwX.Font = new System.Drawing.Font("宋体", 10.5F);
            this.kwX.ForeColor = System.Drawing.Color.Black;
            this.kwX.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kwX.Location = new System.Drawing.Point(105, 85);
            this.kwX.Name = "kwX";
            this.kwX.PreventEnterBeep = true;
            this.kwX.Size = new System.Drawing.Size(96, 23);
            this.kwX.TabIndex = 2;
            // 
            // screenY
            // 
            this.screenY.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.screenY.Border.Class = "TextBoxBorder";
            this.screenY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.screenY.DisabledBackColor = System.Drawing.Color.White;
            this.screenY.Font = new System.Drawing.Font("宋体", 10.5F);
            this.screenY.ForeColor = System.Drawing.Color.Black;
            this.screenY.Location = new System.Drawing.Point(207, 53);
            this.screenY.Name = "screenY";
            this.screenY.PreventEnterBeep = true;
            this.screenY.ReadOnly = true;
            this.screenY.Size = new System.Drawing.Size(96, 23);
            this.screenY.TabIndex = 2;
            // 
            // numberOfPts
            // 
            this.numberOfPts.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.numberOfPts.Border.Class = "TextBoxBorder";
            this.numberOfPts.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numberOfPts.DisabledBackColor = System.Drawing.Color.White;
            this.numberOfPts.Font = new System.Drawing.Font("宋体", 10.5F);
            this.numberOfPts.ForeColor = System.Drawing.Color.Black;
            this.numberOfPts.Location = new System.Drawing.Point(134, 12);
            this.numberOfPts.Name = "numberOfPts";
            this.numberOfPts.PreventEnterBeep = true;
            this.numberOfPts.ReadOnly = true;
            this.numberOfPts.Size = new System.Drawing.Size(43, 23);
            this.numberOfPts.TabIndex = 7;
            this.numberOfPts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Location = new System.Drawing.Point(337, 12);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Size = new System.Drawing.Size(85, 29);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXCancel.TabIndex = 9;
            this.buttonXCancel.Text = "放弃并关闭";
            this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
            // 
            // buttonXSave
            // 
            this.buttonXSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXSave.Location = new System.Drawing.Point(219, 12);
            this.buttonXSave.Name = "buttonXSave";
            this.buttonXSave.Size = new System.Drawing.Size(85, 29);
            this.buttonXSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXSave.TabIndex = 10;
            this.buttonXSave.Text = "保存并关闭";
            this.buttonXSave.Click += new System.EventHandler(this.buttonXSave_Click);
            // 
            // labelXGCPNo
            // 
            // 
            // 
            // 
            this.labelXGCPNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXGCPNo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelXGCPNo.Location = new System.Drawing.Point(12, 12);
            this.labelXGCPNo.Name = "labelXGCPNo";
            this.labelXGCPNo.Size = new System.Drawing.Size(125, 27);
            this.labelXGCPNo.TabIndex = 6;
            this.labelXGCPNo.Text = "当前控制点编号：";
            // 
            // FrmInputCtrls1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 477);
            this.Controls.Add(this.keyboardControl1);
            this.Controls.Add(this.groupBoxRectifyData);
            this.Controls.Add(this.numberOfPts);
            this.Controls.Add(this.buttonXCancel);
            this.Controls.Add(this.buttonXSave);
            this.Controls.Add(this.labelXGCPNo);
            this.Name = "FrmInputCtrls1";
            this.Text = "输入控制点";
            this.Activated += new System.EventHandler(this.FrmInputCtrls_Activated);
            this.groupBoxRectifyData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl1;
        private DevComponents.DotNetBar.Controls.TextBoxX screenX;
        private DevComponents.DotNetBar.Controls.TextBoxX kwZ;
        private DevComponents.DotNetBar.LabelX labelXZCoord;
        private DevComponents.DotNetBar.LabelX labelXYCoord;
        private DevComponents.DotNetBar.LabelX labelXXCoord;
        private DevComponents.DotNetBar.LabelX labelXScreenPoint;
        private DevComponents.DotNetBar.Controls.TextBoxX screenZ;
        private DevComponents.DotNetBar.LabelX labelXWorldPoint;
        private DevComponents.DotNetBar.Controls.TextBoxX kwY;
        private System.Windows.Forms.GroupBox groupBoxRectifyData;
        private DevComponents.DotNetBar.Controls.TextBoxX kwX;
        private DevComponents.DotNetBar.Controls.TextBoxX screenY;
        private DevComponents.DotNetBar.Controls.TextBoxX numberOfPts;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
        private DevComponents.DotNetBar.ButtonX buttonXSave;
        private DevComponents.DotNetBar.LabelX labelXGCPNo;
    }
}