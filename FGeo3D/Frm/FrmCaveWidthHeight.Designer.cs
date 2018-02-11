namespace FGeo3D_TE.Frm
{
    partial class FrmCaveWidthHeight
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
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable5 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer5 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.valueCaveWidth = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.valueCaveHeight = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelCaveWidth = new DevComponents.DotNetBar.LabelX();
            this.labelCaveHeight = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.keyboardControl1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.SuspendLayout();
            // 
            // valueCaveWidth
            // 
            this.valueCaveWidth.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.valueCaveWidth.Border.Class = "TextBoxBorder";
            this.valueCaveWidth.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.valueCaveWidth.DisabledBackColor = System.Drawing.Color.White;
            this.valueCaveWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.valueCaveWidth.ForeColor = System.Drawing.Color.Black;
            this.valueCaveWidth.Location = new System.Drawing.Point(93, 14);
            this.valueCaveWidth.Name = "valueCaveWidth";
            this.valueCaveWidth.PreventEnterBeep = true;
            this.valueCaveWidth.Size = new System.Drawing.Size(111, 26);
            this.valueCaveWidth.TabIndex = 0;
            // 
            // valueCaveHeight
            // 
            this.valueCaveHeight.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.valueCaveHeight.Border.Class = "TextBoxBorder";
            this.valueCaveHeight.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.valueCaveHeight.DisabledBackColor = System.Drawing.Color.White;
            this.valueCaveHeight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.valueCaveHeight.ForeColor = System.Drawing.Color.Black;
            this.valueCaveHeight.Location = new System.Drawing.Point(93, 47);
            this.valueCaveHeight.Name = "valueCaveHeight";
            this.valueCaveHeight.PreventEnterBeep = true;
            this.valueCaveHeight.Size = new System.Drawing.Size(111, 26);
            this.valueCaveHeight.TabIndex = 1;
            // 
            // labelCaveWidth
            // 
            // 
            // 
            // 
            this.labelCaveWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCaveWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCaveWidth.Location = new System.Drawing.Point(12, 17);
            this.labelCaveWidth.Name = "labelCaveWidth";
            this.labelCaveWidth.Size = new System.Drawing.Size(75, 23);
            this.labelCaveWidth.TabIndex = 2;
            this.labelCaveWidth.Text = "洞室宽度";
            // 
            // labelCaveHeight
            // 
            // 
            // 
            // 
            this.labelCaveHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCaveHeight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCaveHeight.Location = new System.Drawing.Point(12, 50);
            this.labelCaveHeight.Name = "labelCaveHeight";
            this.labelCaveHeight.Size = new System.Drawing.Size(75, 23);
            this.labelCaveHeight.TabIndex = 3;
            this.labelCaveHeight.Text = "洞室高度";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(210, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 27);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(210, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 26);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // keyboardControl1
            // 
            virtualKeyboardColorTable5.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable5.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable5.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable5.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable5.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable5.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable5.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable5.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable5.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable5.TopBarTextColor = System.Drawing.Color.White;
            this.keyboardControl1.ColorTable = virtualKeyboardColorTable5;
            this.keyboardControl1.Location = new System.Drawing.Point(2, 79);
            this.keyboardControl1.Name = "keyboardControl1";
            flatStyleRenderer5.ColorTable = virtualKeyboardColorTable5;
            flatStyleRenderer5.ForceAntiAlias = false;
            this.keyboardControl1.Renderer = flatStyleRenderer5;
            this.keyboardControl1.Size = new System.Drawing.Size(322, 250);
            this.keyboardControl1.TabIndex = 6;
            // 
            // FrmCaveWidthHeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 331);
            this.ControlBox = false;
            this.Controls.Add(this.keyboardControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelCaveHeight);
            this.Controls.Add(this.labelCaveWidth);
            this.Controls.Add(this.valueCaveHeight);
            this.Controls.Add(this.valueCaveWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCaveWidthHeight";
            this.Text = "输入洞室尺寸";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX valueCaveWidth;
        private DevComponents.DotNetBar.Controls.TextBoxX valueCaveHeight;
        private DevComponents.DotNetBar.LabelX labelCaveWidth;
        private DevComponents.DotNetBar.LabelX labelCaveHeight;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl1;
    }
}