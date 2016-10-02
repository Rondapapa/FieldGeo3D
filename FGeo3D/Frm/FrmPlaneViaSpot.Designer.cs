namespace FGeo3D_TE.Frm
{
    partial class FrmPlaneViaSpot
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
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable7 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer7 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX = new DevComponents.DotNetBar.LabelX();
            this.textBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelY = new DevComponents.DotNetBar.LabelX();
            this.textBoxY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelZ = new DevComponents.DotNetBar.LabelX();
            this.textBoxZ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelDepth = new DevComponents.DotNetBar.LabelX();
            this.textBoxDepth = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelDip = new DevComponents.DotNetBar.LabelX();
            this.textBoxDip = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelAngle = new DevComponents.DotNetBar.LabelX();
            this.textBoxAngle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.keyboardControl1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.textBoxZ);
            this.groupPanel1.Controls.Add(this.labelZ);
            this.groupPanel1.Controls.Add(this.textBoxY);
            this.groupPanel1.Controls.Add(this.labelY);
            this.groupPanel1.Controls.Add(this.textBoxDepth);
            this.groupPanel1.Controls.Add(this.textBoxX);
            this.groupPanel1.Controls.Add(this.labelDepth);
            this.groupPanel1.Controls.Add(this.labelX);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(153, 159);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "地质点";
            // 
            // labelX
            // 
            this.labelX.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX.Location = new System.Drawing.Point(7, 12);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(21, 21);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "X";
            this.labelX.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxX
            // 
            // 
            // 
            // 
            this.textBoxX.Border.Class = "TextBoxBorder";
            this.textBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX.Location = new System.Drawing.Point(34, 12);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.PreventEnterBeep = true;
            this.textBoxX.ReadOnly = true;
            this.textBoxX.Size = new System.Drawing.Size(104, 23);
            this.textBoxX.TabIndex = 1;
            // 
            // labelY
            // 
            this.labelY.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelY.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelY.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelY.Location = new System.Drawing.Point(7, 41);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(21, 21);
            this.labelY.TabIndex = 0;
            this.labelY.Text = "Y";
            this.labelY.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxY
            // 
            // 
            // 
            // 
            this.textBoxY.Border.Class = "TextBoxBorder";
            this.textBoxY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxY.Location = new System.Drawing.Point(34, 41);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.PreventEnterBeep = true;
            this.textBoxY.ReadOnly = true;
            this.textBoxY.Size = new System.Drawing.Size(104, 23);
            this.textBoxY.TabIndex = 1;
            // 
            // labelZ
            // 
            this.labelZ.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelZ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelZ.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZ.Location = new System.Drawing.Point(7, 70);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(21, 21);
            this.labelZ.TabIndex = 0;
            this.labelZ.Text = "Z";
            this.labelZ.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxZ
            // 
            // 
            // 
            // 
            this.textBoxZ.Border.Class = "TextBoxBorder";
            this.textBoxZ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxZ.Location = new System.Drawing.Point(34, 70);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.PreventEnterBeep = true;
            this.textBoxZ.ReadOnly = true;
            this.textBoxZ.Size = new System.Drawing.Size(104, 23);
            this.textBoxZ.TabIndex = 1;
            // 
            // labelDepth
            // 
            this.labelDepth.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDepth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDepth.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDepth.Location = new System.Drawing.Point(7, 99);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(48, 23);
            this.labelDepth.TabIndex = 0;
            this.labelDepth.Text = "深度";
            this.labelDepth.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxDepth
            // 
            // 
            // 
            // 
            this.textBoxDepth.Border.Class = "TextBoxBorder";
            this.textBoxDepth.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDepth.Location = new System.Drawing.Point(61, 99);
            this.textBoxDepth.Name = "textBoxDepth";
            this.textBoxDepth.PreventEnterBeep = true;
            this.textBoxDepth.Size = new System.Drawing.Size(77, 23);
            this.textBoxDepth.TabIndex = 1;
            this.textBoxDepth.Text = "0";
            this.textBoxDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDepth.TextChanged += new System.EventHandler(this.textBoxDepth_TextChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.textBoxAngle);
            this.groupPanel2.Controls.Add(this.labelAngle);
            this.groupPanel2.Controls.Add(this.textBoxDip);
            this.groupPanel2.Controls.Add(this.labelDip);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupPanel2.Location = new System.Drawing.Point(171, 12);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(192, 95);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "产状";
            // 
            // labelDip
            // 
            this.labelDip.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDip.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDip.Location = new System.Drawing.Point(7, 12);
            this.labelDip.Name = "labelDip";
            this.labelDip.Size = new System.Drawing.Size(46, 23);
            this.labelDip.TabIndex = 0;
            this.labelDip.Text = "倾向";
            this.labelDip.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxDip
            // 
            // 
            // 
            // 
            this.textBoxDip.Border.Class = "TextBoxBorder";
            this.textBoxDip.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDip.Location = new System.Drawing.Point(61, 12);
            this.textBoxDip.Name = "textBoxDip";
            this.textBoxDip.PreventEnterBeep = true;
            this.textBoxDip.Size = new System.Drawing.Size(104, 23);
            this.textBoxDip.TabIndex = 1;
            this.textBoxDip.Text = "0";
            this.textBoxDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDip.TextChanged += new System.EventHandler(this.textBoxDip_TextChanged);
            // 
            // labelAngle
            // 
            this.labelAngle.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelAngle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelAngle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAngle.Location = new System.Drawing.Point(7, 41);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(46, 23);
            this.labelAngle.TabIndex = 0;
            this.labelAngle.Text = "倾角";
            this.labelAngle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxAngle
            // 
            // 
            // 
            // 
            this.textBoxAngle.Border.Class = "TextBoxBorder";
            this.textBoxAngle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxAngle.Location = new System.Drawing.Point(61, 41);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.PreventEnterBeep = true;
            this.textBoxAngle.Size = new System.Drawing.Size(104, 23);
            this.textBoxAngle.TabIndex = 1;
            this.textBoxAngle.Text = "0";
            this.textBoxAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAngle.TextChanged += new System.EventHandler(this.textBoxAngle_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(171, 134);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 34);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.Location = new System.Drawing.Point(273, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 34);
            this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // keyboardControl1
            // 
            virtualKeyboardColorTable7.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable7.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable7.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable7.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable7.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable7.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable7.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable7.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable7.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable7.TopBarTextColor = System.Drawing.Color.White;
            this.keyboardControl1.ColorTable = virtualKeyboardColorTable7;
            this.keyboardControl1.Location = new System.Drawing.Point(5, 177);
            this.keyboardControl1.Name = "keyboardControl1";
            flatStyleRenderer7.ColorTable = virtualKeyboardColorTable7;
            flatStyleRenderer7.ForceAntiAlias = false;
            this.keyboardControl1.Renderer = flatStyleRenderer7;
            this.keyboardControl1.Size = new System.Drawing.Size(358, 330);
            this.keyboardControl1.TabIndex = 3;
            // 
            // FrmPlaneViaSpot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 512);
            this.Controls.Add(this.keyboardControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlaneViaSpot";
            this.Text = "地质点推求地质面";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxZ;
        private DevComponents.DotNetBar.LabelX labelZ;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxY;
        private DevComponents.DotNetBar.LabelX labelY;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxDepth;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX;
        private DevComponents.DotNetBar.LabelX labelDepth;
        private DevComponents.DotNetBar.LabelX labelX;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxAngle;
        private DevComponents.DotNetBar.LabelX labelAngle;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxDip;
        private DevComponents.DotNetBar.LabelX labelDip;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl1;
    }
}