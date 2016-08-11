namespace FGeo3D_TE
{
    partial class FrmObject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObject));
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.tbColor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelType = new DevComponents.DotNetBar.LabelX();
            this.colorCombControl = new DevComponents.DotNetBar.ColorPickers.ColorCombControl();
            this.labelColor = new DevComponents.DotNetBar.LabelX();
            this.radioBtnGeometryPart = new System.Windows.Forms.RadioButton();
            this.radioBtnJX = new System.Windows.Forms.RadioButton();
            this.radioBtnJGM = new System.Windows.Forms.RadioButton();
            this.comboBoxExType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbItem_DXDM = new DevComponents.Editors.ComboItem();
            this.cbItem_DCYX = new DevComponents.Editors.ComboItem();
            this.cbItem_JGM = new DevComponents.Editors.ComboItem();
            this.cbItem_GZFD = new DevComponents.Editors.ComboItem();
            this.cbItem_ZZ = new DevComponents.Editors.ComboItem();
            this.cbItem_FH = new DevComponents.Editors.ComboItem();
            this.cbItem_XH = new DevComponents.Editors.ComboItem();
            this.cbItem_NSLZH = new DevComponents.Editors.ComboItem();
            this.cbItem_HPZH = new DevComponents.Editors.ComboItem();
            this.cbItem_BTZH = new DevComponents.Editors.ComboItem();
            this.cbItem_RBZH = new DevComponents.Editors.ComboItem();
            this.cbItem_QZSWKT = new DevComponents.Editors.ComboItem();
            this.cbItem_YR = new DevComponents.Editors.ComboItem();
            this.cbItem_DXSFD = new DevComponents.Editors.ComboItem();
            this.cbItem_TTFC = new DevComponents.Editors.ComboItem();
            this.cbItem_YTFL = new DevComponents.Editors.ComboItem();
            this.touchKeyboard = new DevComponents.DotNetBar.Keyboard.TouchKeyboard();
            this.keyboardControl = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
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
            this.tbName.Location = new System.Drawing.Point(70, 56);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(487, 29);
            this.tbName.TabIndex = 0;
            this.tbName.Click += new System.EventHandler(this.tbName_Click);
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // labelName
            // 
            // 
            // 
            // 
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(12, 56);
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
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(473, 91);
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
            this.btnCancel.Location = new System.Drawing.Point(384, 91);
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
            this.tbColor.Location = new System.Drawing.Point(70, 91);
            this.tbColor.Name = "tbColor";
            this.tbColor.PreventEnterBeep = true;
            this.tbColor.ReadOnly = true;
            this.tbColor.Size = new System.Drawing.Size(308, 29);
            this.tbColor.TabIndex = 3;
            this.tbColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelType
            // 
            // 
            // 
            // 
            this.labelType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelType.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelType.Location = new System.Drawing.Point(12, 21);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(52, 29);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "类型";
            // 
            // colorCombControl
            // 
            this.colorCombControl.Location = new System.Drawing.Point(13, 127);
            this.colorCombControl.Name = "colorCombControl";
            this.colorCombControl.Size = new System.Drawing.Size(544, 466);
            this.colorCombControl.TabIndex = 4;
            this.colorCombControl.Text = "colorCombControl1";
            this.colorCombControl.SelectedColorChanged += new System.EventHandler(this.colorCombControl_SelectedColorChanged);
            // 
            // labelColor
            // 
            // 
            // 
            // 
            this.labelColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelColor.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelColor.Location = new System.Drawing.Point(12, 91);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(52, 29);
            this.labelColor.TabIndex = 2;
            this.labelColor.Text = "颜色";
            // 
            // radioBtnGeometryPart
            // 
            this.radioBtnGeometryPart.Location = new System.Drawing.Point(0, 0);
            this.radioBtnGeometryPart.Name = "radioBtnGeometryPart";
            this.radioBtnGeometryPart.Size = new System.Drawing.Size(104, 24);
            this.radioBtnGeometryPart.TabIndex = 0;
            // 
            // radioBtnJX
            // 
            this.radioBtnJX.Location = new System.Drawing.Point(0, 0);
            this.radioBtnJX.Name = "radioBtnJX";
            this.radioBtnJX.Size = new System.Drawing.Size(104, 24);
            this.radioBtnJX.TabIndex = 0;
            // 
            // radioBtnJGM
            // 
            this.radioBtnJGM.Location = new System.Drawing.Point(0, 0);
            this.radioBtnJGM.Name = "radioBtnJGM";
            this.radioBtnJGM.Size = new System.Drawing.Size(104, 24);
            this.radioBtnJGM.TabIndex = 0;
            // 
            // comboBoxExType
            // 
            this.comboBoxExType.Font = new System.Drawing.Font("宋体", 14F);
            this.comboBoxExType.ItemHeight = 19;
            this.comboBoxExType.Items.AddRange(new object[] {
            this.cbItem_DXDM,
            this.cbItem_DCYX,
            this.cbItem_JGM,
            this.cbItem_GZFD,
            this.cbItem_ZZ,
            this.cbItem_FH,
            this.cbItem_XH,
            this.cbItem_NSLZH,
            this.cbItem_HPZH,
            this.cbItem_BTZH,
            this.cbItem_RBZH,
            this.cbItem_QZSWKT,
            this.cbItem_YR,
            this.cbItem_DXSFD,
            this.cbItem_TTFC,
            this.cbItem_YTFL});
            this.comboBoxExType.Location = new System.Drawing.Point(71, 21);
            this.comboBoxExType.Name = "comboBoxExType";
            this.comboBoxExType.Size = new System.Drawing.Size(486, 27);
            this.comboBoxExType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxExType.TabIndex = 7;
            this.comboBoxExType.SelectedIndexChanged += new System.EventHandler(this.comboBoxExType_SelectedIndexChanged);
            // 
            // cbItem_DXDM
            // 
            this.cbItem_DXDM.Text = "地形地貌";
            // 
            // cbItem_DCYX
            // 
            this.cbItem_DCYX.Text = "地层岩性";
            // 
            // cbItem_JGM
            // 
            this.cbItem_JGM.Text = "结构面";
            // 
            // cbItem_GZFD
            // 
            this.cbItem_GZFD.Text = "构造分段";
            // 
            // cbItem_ZZ
            // 
            this.cbItem_ZZ.Text = "褶皱";
            // 
            // cbItem_FH
            // 
            this.cbItem_FH.Text = "风化";
            // 
            // cbItem_XH
            // 
            this.cbItem_XH.Text = "卸荷";
            // 
            // cbItem_NSLZH
            // 
            this.cbItem_NSLZH.Text = "泥石流";
            // 
            // cbItem_HPZH
            // 
            this.cbItem_HPZH.Text = "滑坡";
            // 
            // cbItem_BTZH
            // 
            this.cbItem_BTZH.Text = "崩塌";
            // 
            // cbItem_RBZH
            // 
            this.cbItem_RBZH.Text = "蠕变";
            // 
            // cbItem_QZSWKT
            // 
            this.cbItem_QZSWKT.Text = "潜在失稳块体";
            // 
            // cbItem_YR
            // 
            this.cbItem_YR.Text = "岩溶";
            // 
            // cbItem_DXSFD
            // 
            this.cbItem_DXSFD.Text = "地下水分段";
            // 
            // cbItem_TTFC
            // 
            this.cbItem_TTFC.Text = "土体分层";
            // 
            // cbItem_YTFL
            // 
            this.cbItem_YTFL.Text = "岩体分类";
            // 
            // touchKeyboard
            // 
            this.touchKeyboard.FloatingLocation = new System.Drawing.Point(0, 0);
            this.touchKeyboard.FloatingSize = new System.Drawing.Size(740, 250);
            this.touchKeyboard.Location = new System.Drawing.Point(0, 0);
            this.touchKeyboard.Size = new System.Drawing.Size(740, 250);
            this.touchKeyboard.Text = "";
            // 
            // keyboardControl
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
            this.keyboardControl.ColorTable = virtualKeyboardColorTable1;
            this.keyboardControl.Location = new System.Drawing.Point(2, 400);
            this.keyboardControl.Name = "keyboardControl";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyboardControl.Renderer = flatStyleRenderer1;
            this.keyboardControl.Size = new System.Drawing.Size(567, 205);
            this.keyboardControl.TabIndex = 8;
            this.keyboardControl.Text = "请输入名称";
            this.keyboardControl.Visible = false;
            // 
            // FrmObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 605);
            this.Controls.Add(this.keyboardControl);
            this.Controls.Add(this.comboBoxExType);
            this.Controls.Add(this.colorCombControl);
            this.Controls.Add(this.tbColor);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmObject";
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
        internal DevComponents.DotNetBar.LabelX labelType;
        internal DevComponents.DotNetBar.LabelX labelColor;
        private System.Windows.Forms.RadioButton radioBtnGeometryPart;
        private System.Windows.Forms.RadioButton radioBtnJX;
        private System.Windows.Forms.RadioButton radioBtnJGM;
        private DevComponents.Editors.ComboItem cbItem_DCYX;
        private DevComponents.Editors.ComboItem cbItem_DXDM;
        private DevComponents.Editors.ComboItem cbItem_BTZH;
        private DevComponents.Editors.ComboItem cbItem_GZFD;
        private DevComponents.Editors.ComboItem cbItem_HPZH;
        private DevComponents.Editors.ComboItem cbItem_JGM;
        private DevComponents.Editors.ComboItem cbItem_NSLZH;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExType;
        private DevComponents.Editors.ComboItem cbItem_FH;
        private DevComponents.Editors.ComboItem cbItem_ZZ;
        private DevComponents.Editors.ComboItem cbItem_XH;
        private DevComponents.Editors.ComboItem cbItem_QZSWKT;
        private DevComponents.Editors.ComboItem cbItem_YR;
        private DevComponents.Editors.ComboItem cbItem_RBZH;
        private DevComponents.Editors.ComboItem cbItem_DXSFD;
        private DevComponents.Editors.ComboItem cbItem_TTFC;
        private DevComponents.Editors.ComboItem cbItem_YTFL;
        private DevComponents.DotNetBar.Keyboard.TouchKeyboard touchKeyboard;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl;
    }
}