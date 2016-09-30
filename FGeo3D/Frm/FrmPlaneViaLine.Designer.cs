namespace FGeo3D_TE.Frm
{
    partial class FrmPlaneViaLine
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
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable4 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer4 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.textBoxDepth = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXInterval = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelXDepth = new DevComponents.DotNetBar.LabelX();
            this.labelXInterval = new DevComponents.DotNetBar.LabelX();
            this.keyboardControl1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(308, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 31);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBoxDepth
            // 
            // 
            // 
            // 
            this.textBoxDepth.Border.Class = "TextBoxBorder";
            this.textBoxDepth.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDepth.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDepth.Location = new System.Drawing.Point(98, 12);
            this.textBoxDepth.Name = "textBoxDepth";
            this.textBoxDepth.PreventEnterBeep = true;
            this.textBoxDepth.Size = new System.Drawing.Size(192, 31);
            this.textBoxDepth.TabIndex = 1;
            this.textBoxDepth.TextChanged += new System.EventHandler(this.textBoxDepth_TextChanged);
            // 
            // textBoxXInterval
            // 
            // 
            // 
            // 
            this.textBoxXInterval.Border.Class = "TextBoxBorder";
            this.textBoxXInterval.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXInterval.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxXInterval.Location = new System.Drawing.Point(98, 49);
            this.textBoxXInterval.Name = "textBoxXInterval";
            this.textBoxXInterval.PreventEnterBeep = true;
            this.textBoxXInterval.Size = new System.Drawing.Size(192, 31);
            this.textBoxXInterval.TabIndex = 1;
            this.textBoxXInterval.TextChanged += new System.EventHandler(this.textBoxXInterval_TextChanged);
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXCancel.Location = new System.Drawing.Point(308, 49);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Size = new System.Drawing.Size(86, 31);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXCancel.TabIndex = 0;
            this.buttonXCancel.Text = "取消";
            this.buttonXCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelXDepth
            // 
            // 
            // 
            // 
            this.labelXDepth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXDepth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXDepth.Location = new System.Drawing.Point(12, 13);
            this.labelXDepth.Name = "labelXDepth";
            this.labelXDepth.Size = new System.Drawing.Size(80, 30);
            this.labelXDepth.TabIndex = 2;
            this.labelXDepth.Text = "中心深度";
            // 
            // labelXInterval
            // 
            // 
            // 
            // 
            this.labelXInterval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXInterval.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXInterval.Location = new System.Drawing.Point(12, 49);
            this.labelXInterval.Name = "labelXInterval";
            this.labelXInterval.Size = new System.Drawing.Size(80, 30);
            this.labelXInterval.TabIndex = 2;
            this.labelXInterval.Text = "网格间距";
            // 
            // keyboardControl1
            // 
            virtualKeyboardColorTable4.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable4.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable4.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable4.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable4.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable4.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable4.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable4.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable4.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable4.TopBarTextColor = System.Drawing.Color.White;
            this.keyboardControl1.ColorTable = virtualKeyboardColorTable4;
            this.keyboardControl1.Location = new System.Drawing.Point(12, 86);
            this.keyboardControl1.Name = "keyboardControl1";
            flatStyleRenderer4.ColorTable = virtualKeyboardColorTable4;
            flatStyleRenderer4.ForceAntiAlias = false;
            this.keyboardControl1.Renderer = flatStyleRenderer4;
            this.keyboardControl1.Size = new System.Drawing.Size(382, 334);
            this.keyboardControl1.TabIndex = 3;
            // 
            // FrmPlaneViaLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 432);
            this.Controls.Add(this.keyboardControl1);
            this.Controls.Add(this.labelXInterval);
            this.Controls.Add(this.labelXDepth);
            this.Controls.Add(this.textBoxXInterval);
            this.Controls.Add(this.textBoxDepth);
            this.Controls.Add(this.buttonXCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlaneViaLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入曲面参数";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOK;
        internal DevComponents.DotNetBar.Controls.TextBoxX textBoxDepth;
        internal DevComponents.DotNetBar.Controls.TextBoxX textBoxXInterval;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
        private DevComponents.DotNetBar.LabelX labelXDepth;
        private DevComponents.DotNetBar.LabelX labelXInterval;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl1;
    }
}