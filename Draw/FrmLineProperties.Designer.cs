namespace Draw
{
    partial class FrmLineProperties
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
            this.LineTypes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbItem_DXDM = new DevComponents.Editors.ComboItem();
            this.cbItem_DCYX = new DevComponents.Editors.ComboItem();
            this.cbItem_JGM = new DevComponents.Editors.ComboItem();
            this.cbItem_GZFD = new DevComponents.Editors.ComboItem();
            this.cbItem_ZZ = new DevComponents.Editors.ComboItem();
            this.cbItem_FH = new DevComponents.Editors.ComboItem();
            this.cbItem_XH = new DevComponents.Editors.ComboItem();
            this.cbItem_NSL = new DevComponents.Editors.ComboItem();
            this.cbItem_HP = new DevComponents.Editors.ComboItem();
            this.cbItem_BT = new DevComponents.Editors.ComboItem();
            this.cbItem_RB = new DevComponents.Editors.ComboItem();
            this.cbItem_QZSWKT = new DevComponents.Editors.ComboItem();
            this.cbItem_YR = new DevComponents.Editors.ComboItem();
            this.cbItem_DXSFD = new DevComponents.Editors.ComboItem();
            this.cbItem_TTFC = new DevComponents.Editors.ComboItem();
            this.cbItem_YTFL = new DevComponents.Editors.ComboItem();
            this.labelType = new DevComponents.DotNetBar.LabelX();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.keyboardControl = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.SuspendLayout();
            // 
            // LineTypes
            // 
            this.LineTypes.Font = new System.Drawing.Font("宋体", 14F);
            this.LineTypes.ForeColor = System.Drawing.Color.Black;
            this.LineTypes.ItemHeight = 19;
            this.LineTypes.Items.AddRange(new object[] {
            this.cbItem_DXDM,
            this.cbItem_DCYX,
            this.cbItem_JGM,
            this.cbItem_GZFD,
            this.cbItem_ZZ,
            this.cbItem_FH,
            this.cbItem_XH,
            this.cbItem_NSL,
            this.cbItem_HP,
            this.cbItem_BT,
            this.cbItem_RB,
            this.cbItem_QZSWKT,
            this.cbItem_YR,
            this.cbItem_DXSFD,
            this.cbItem_TTFC,
            this.cbItem_YTFL});
            this.LineTypes.Location = new System.Drawing.Point(69, 13);
            this.LineTypes.Name = "LineTypes";
            this.LineTypes.Size = new System.Drawing.Size(210, 27);
            this.LineTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LineTypes.TabIndex = 16;
            this.LineTypes.SelectedIndexChanged += new System.EventHandler(this.LineTypes_SelectedIndexChanged);
            // 
            // cbItem_DXDM
            // 
            this.cbItem_DXDM.Text = "地形地貌";
            this.cbItem_DXDM.Value = "DXDM";
            // 
            // cbItem_DCYX
            // 
            this.cbItem_DCYX.Text = "地层岩性";
            this.cbItem_DCYX.Value = "DCYX";
            // 
            // cbItem_JGM
            // 
            this.cbItem_JGM.Text = "结构面";
            this.cbItem_JGM.Value = "JGM";
            // 
            // cbItem_GZFD
            // 
            this.cbItem_GZFD.Text = "构造分段";
            this.cbItem_GZFD.Value = "GZFD";
            // 
            // cbItem_ZZ
            // 
            this.cbItem_ZZ.Text = "褶皱";
            this.cbItem_ZZ.Value = "ZZ";
            // 
            // cbItem_FH
            // 
            this.cbItem_FH.Text = "风化";
            this.cbItem_FH.Value = "FH";
            // 
            // cbItem_XH
            // 
            this.cbItem_XH.Text = "卸荷";
            this.cbItem_XH.Value = "XH";
            // 
            // cbItem_NSL
            // 
            this.cbItem_NSL.Text = "泥石流";
            this.cbItem_NSL.Value = "NSL";
            // 
            // cbItem_HP
            // 
            this.cbItem_HP.Text = "滑坡";
            this.cbItem_HP.Value = "HP";
            // 
            // cbItem_BT
            // 
            this.cbItem_BT.Text = "崩塌";
            this.cbItem_BT.Value = "BT";
            // 
            // cbItem_RB
            // 
            this.cbItem_RB.Text = "蠕变";
            this.cbItem_RB.Value = "RB";
            // 
            // cbItem_QZSWKT
            // 
            this.cbItem_QZSWKT.Text = "潜在失稳块体";
            this.cbItem_QZSWKT.Value = "QZSWKT";
            // 
            // cbItem_YR
            // 
            this.cbItem_YR.Text = "岩溶";
            this.cbItem_YR.Value = "YR";
            // 
            // cbItem_DXSFD
            // 
            this.cbItem_DXSFD.Text = "地下水分段";
            this.cbItem_DXSFD.Value = "DXSFD";
            // 
            // cbItem_TTFC
            // 
            this.cbItem_TTFC.Text = "土体分层";
            this.cbItem_TTFC.Value = "TTFC";
            // 
            // cbItem_YTFL
            // 
            this.cbItem_YTFL.Text = "岩体分类";
            this.cbItem_YTFL.Value = "YTFL";
            // 
            // labelType
            // 
            // 
            // 
            // 
            this.labelType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelType.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelType.Location = new System.Drawing.Point(10, 13);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(52, 29);
            this.labelType.TabIndex = 12;
            this.labelType.Text = "类型";
            // 
            // labelName
            // 
            // 
            // 
            // 
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(10, 48);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 29);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "名称";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(12, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 29);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.BackColor = System.Drawing.Color.Silver;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(151, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 30);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.Symbol = "58826";
            this.btnOK.SymbolColor = System.Drawing.Color.Black;
            this.btnOK.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.DisabledBackColor = System.Drawing.Color.White;
            this.tbName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(68, 48);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(211, 29);
            this.tbName.TabIndex = 8;
            // 
            // keyboardControl
            // 
            this.keyboardControl.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.keyboardControl.Location = new System.Drawing.Point(-139, 120);
            this.keyboardControl.Name = "keyboardControl";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyboardControl.Renderer = flatStyleRenderer1;
            this.keyboardControl.Size = new System.Drawing.Size(570, 205);
            this.keyboardControl.TabIndex = 17;
            this.keyboardControl.Text = "请输入名称";
            // 
            // FrmLineProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 326);
            this.Controls.Add(this.keyboardControl);
            this.Controls.Add(this.LineTypes);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbName);
            this.Name = "FrmLineProperties";
            this.Text = "新建地线";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx LineTypes;
        internal DevComponents.Editors.ComboItem cbItem_DXDM;
        internal DevComponents.Editors.ComboItem cbItem_DCYX;
        internal DevComponents.Editors.ComboItem cbItem_JGM;
        internal DevComponents.Editors.ComboItem cbItem_GZFD;
        internal DevComponents.Editors.ComboItem cbItem_ZZ;
        internal DevComponents.Editors.ComboItem cbItem_FH;
        internal DevComponents.Editors.ComboItem cbItem_XH;
        internal DevComponents.Editors.ComboItem cbItem_NSL;
        internal DevComponents.Editors.ComboItem cbItem_HP;
        internal DevComponents.Editors.ComboItem cbItem_BT;
        internal DevComponents.Editors.ComboItem cbItem_RB;
        internal DevComponents.Editors.ComboItem cbItem_QZSWKT;
        internal DevComponents.Editors.ComboItem cbItem_YR;
        internal DevComponents.Editors.ComboItem cbItem_DXSFD;
        internal DevComponents.Editors.ComboItem cbItem_TTFC;
        internal DevComponents.Editors.ComboItem cbItem_YTFL;
        internal DevComponents.DotNetBar.LabelX labelType;
        internal DevComponents.DotNetBar.LabelX labelName;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        internal DevComponents.DotNetBar.Controls.TextBoxX tbName;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl;
    }
}