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
            this.cbItem_GeoPart = new DevComponents.Editors.ComboItem();
            this.cbItem_DXM = new DevComponents.Editors.ComboItem();
            this.cbItem_BT = new DevComponents.Editors.ComboItem();
            this.cbItem_GZD = new DevComponents.Editors.ComboItem();
            this.cbItem_HP = new DevComponents.Editors.ComboItem();
            this.cbItem_JGM = new DevComponents.Editors.ComboItem();
            this.cbItem_NSL = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Enabled = false;
            this.tbName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(70, 56);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(487, 29);
            this.tbName.TabIndex = 0;
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
            this.colorCombControl.Enabled = false;
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
            this.comboBoxExType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExType.Font = new System.Drawing.Font("宋体", 14.25F);
            this.comboBoxExType.FormattingEnabled = true;
            this.comboBoxExType.ItemHeight = 23;
            this.comboBoxExType.Items.AddRange(new object[] {
            this.cbItem_GeoPart,
            this.cbItem_DXM,
            this.cbItem_BT,
            this.cbItem_GZD,
            this.cbItem_HP,
            this.cbItem_JGM,
            this.cbItem_NSL});
            this.comboBoxExType.Location = new System.Drawing.Point(71, 21);
            this.comboBoxExType.Name = "comboBoxExType";
            this.comboBoxExType.Size = new System.Drawing.Size(486, 29);
            this.comboBoxExType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxExType.TabIndex = 7;
            this.comboBoxExType.SelectedIndexChanged += new System.EventHandler(this.comboBoxExType_SelectedIndexChanged);
            // 
            // cbItem_GeoPart
            // 
            this.cbItem_GeoPart.Text = "几何部件";
            // 
            // cbItem_DXM
            // 
            this.cbItem_DXM.Text = "界线";
            // 
            // cbItem_BT
            // 
            this.cbItem_BT.Text = "崩塌";
            // 
            // cbItem_GZD
            // 
            this.cbItem_GZD.Text = "构造带";
            // 
            // cbItem_HP
            // 
            this.cbItem_HP.Text = "滑坡";
            // 
            // cbItem_JGM
            // 
            this.cbItem_JGM.Text = "结构面";
            // 
            // cbItem_NSL
            // 
            this.cbItem_NSL.Text = "泥石流";
            // 
            // FrmObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 605);
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
        private DevComponents.Editors.ComboItem cbItem_GeoPart;
        private DevComponents.Editors.ComboItem cbItem_DXM;
        private DevComponents.Editors.ComboItem cbItem_BT;
        private DevComponents.Editors.ComboItem cbItem_GZD;
        private DevComponents.Editors.ComboItem cbItem_HP;
        private DevComponents.Editors.ComboItem cbItem_JGM;
        private DevComponents.Editors.ComboItem cbItem_NSL;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExType;
    }
}