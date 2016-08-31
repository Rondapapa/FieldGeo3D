namespace FGeo3D_TE.GeoImage
{
    partial class FrmImageLineType
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
            this.comboBoxExGeoType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem_DXDM = new DevComponents.Editors.ComboItem();
            this.comboItem_DCYX = new DevComponents.Editors.ComboItem();
            this.comboItem_JGM = new DevComponents.Editors.ComboItem();
            this.comboItem_GZFD = new DevComponents.Editors.ComboItem();
            this.comboItem_ZZ = new DevComponents.Editors.ComboItem();
            this.comboItem_FH = new DevComponents.Editors.ComboItem();
            this.comboItem_XH = new DevComponents.Editors.ComboItem();
            this.comboItem_NSLZH = new DevComponents.Editors.ComboItem();
            this.comboItem_HPZH = new DevComponents.Editors.ComboItem();
            this.comboItem_BTZH = new DevComponents.Editors.ComboItem();
            this.comboItem_RBZH = new DevComponents.Editors.ComboItem();
            this.comboItem_QZSWKT = new DevComponents.Editors.ComboItem();
            this.comboItem_YR = new DevComponents.Editors.ComboItem();
            this.comboItem_DXSFD = new DevComponents.Editors.ComboItem();
            this.comboItem_TTFC = new DevComponents.Editors.ComboItem();
            this.comboItem_YTFL = new DevComponents.Editors.ComboItem();
            this.labelXGeoType = new DevComponents.DotNetBar.LabelX();
            this.labelXStretchDepth = new DevComponents.DotNetBar.LabelX();
            this.buttonXOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.textBoxXStretchDepth = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // comboBoxExGeoType
            // 
            this.comboBoxExGeoType.DisplayMember = "Text";
            this.comboBoxExGeoType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExGeoType.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBoxExGeoType.FormattingEnabled = true;
            this.comboBoxExGeoType.ItemHeight = 20;
            this.comboBoxExGeoType.Items.AddRange(new object[] {
            this.comboItem_DXDM,
            this.comboItem_DCYX,
            this.comboItem_JGM,
            this.comboItem_GZFD,
            this.comboItem_ZZ,
            this.comboItem_FH,
            this.comboItem_XH,
            this.comboItem_NSLZH,
            this.comboItem_HPZH,
            this.comboItem_BTZH,
            this.comboItem_RBZH,
            this.comboItem_QZSWKT,
            this.comboItem_YR,
            this.comboItem_DXSFD,
            this.comboItem_TTFC,
            this.comboItem_YTFL});
            this.comboBoxExGeoType.Location = new System.Drawing.Point(135, 12);
            this.comboBoxExGeoType.Name = "comboBoxExGeoType";
            this.comboBoxExGeoType.Size = new System.Drawing.Size(264, 26);
            this.comboBoxExGeoType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxExGeoType.TabIndex = 0;
            this.comboBoxExGeoType.SelectedIndexChanged += new System.EventHandler(this.comboBoxExGeoType_SelectedIndexChanged);
            // 
            // comboItem_DXDM
            // 
            this.comboItem_DXDM.Text = "地形地貌";
            this.comboItem_DXDM.Value = "DXDM";
            // 
            // comboItem_DCYX
            // 
            this.comboItem_DCYX.Text = "地层岩性";
            this.comboItem_DCYX.Value = "DCYX";
            // 
            // comboItem_JGM
            // 
            this.comboItem_JGM.Text = "结构面";
            this.comboItem_JGM.Value = "JGM";
            // 
            // comboItem_GZFD
            // 
            this.comboItem_GZFD.Text = "构造分段";
            this.comboItem_GZFD.Value = "GZFD";
            // 
            // comboItem_ZZ
            // 
            this.comboItem_ZZ.Text = "褶皱";
            this.comboItem_ZZ.Value = "ZZ";
            // 
            // comboItem_FH
            // 
            this.comboItem_FH.Text = "风化";
            this.comboItem_FH.Value = "FH";
            // 
            // comboItem_XH
            // 
            this.comboItem_XH.Text = "卸荷";
            this.comboItem_XH.Value = "XH";
            // 
            // comboItem_NSLZH
            // 
            this.comboItem_NSLZH.Text = "泥石流";
            this.comboItem_NSLZH.Value = "NSLZH";
            // 
            // comboItem_HPZH
            // 
            this.comboItem_HPZH.Text = "滑坡";
            this.comboItem_HPZH.Value = "HPZH";
            // 
            // comboItem_BTZH
            // 
            this.comboItem_BTZH.Text = "崩塌";
            this.comboItem_BTZH.Value = "BTZH";
            // 
            // comboItem_RBZH
            // 
            this.comboItem_RBZH.Text = "蠕变";
            this.comboItem_RBZH.Value = "RBZH";
            // 
            // comboItem_QZSWKT
            // 
            this.comboItem_QZSWKT.Text = "潜在失稳块体";
            this.comboItem_QZSWKT.Value = "QZSWKT";
            // 
            // comboItem_YR
            // 
            this.comboItem_YR.Text = "岩溶";
            this.comboItem_YR.Value = "YR";
            // 
            // comboItem_DXSFD
            // 
            this.comboItem_DXSFD.Text = "地下水分段";
            this.comboItem_DXSFD.Value = "DXSFD";
            // 
            // comboItem_TTFC
            // 
            this.comboItem_TTFC.Text = "土体分层";
            this.comboItem_TTFC.Value = "TTFC";
            // 
            // comboItem_YTFL
            // 
            this.comboItem_YTFL.Text = "岩体分类";
            this.comboItem_YTFL.Value = "YTFL";
            // 
            // labelXGeoType
            // 
            // 
            // 
            // 
            this.labelXGeoType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXGeoType.Font = new System.Drawing.Font("宋体", 12F);
            this.labelXGeoType.Location = new System.Drawing.Point(12, 12);
            this.labelXGeoType.Name = "labelXGeoType";
            this.labelXGeoType.Size = new System.Drawing.Size(117, 26);
            this.labelXGeoType.TabIndex = 1;
            this.labelXGeoType.Text = "地质对象类型";
            // 
            // labelXStretchDepth
            // 
            // 
            // 
            // 
            this.labelXStretchDepth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXStretchDepth.Font = new System.Drawing.Font("宋体", 12F);
            this.labelXStretchDepth.Location = new System.Drawing.Point(12, 60);
            this.labelXStretchDepth.Name = "labelXStretchDepth";
            this.labelXStretchDepth.Size = new System.Drawing.Size(117, 26);
            this.labelXStretchDepth.TabIndex = 2;
            this.labelXStretchDepth.Text = "延伸深度(米)";
            // 
            // buttonXOK
            // 
            this.buttonXOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXOK.Font = new System.Drawing.Font("宋体", 11F);
            this.buttonXOK.Location = new System.Drawing.Point(241, 60);
            this.buttonXOK.Name = "buttonXOK";
            this.buttonXOK.Size = new System.Drawing.Size(76, 26);
            this.buttonXOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXOK.TabIndex = 3;
            this.buttonXOK.Text = "确认";
            this.buttonXOK.Click += new System.EventHandler(this.buttonXOK_Click);
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Font = new System.Drawing.Font("宋体", 11F);
            this.buttonXCancel.Location = new System.Drawing.Point(323, 60);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Size = new System.Drawing.Size(76, 26);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXCancel.TabIndex = 3;
            this.buttonXCancel.Text = "取消";
            this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
            // 
            // textBoxXStretchDepth
            // 
            // 
            // 
            // 
            this.textBoxXStretchDepth.Border.Class = "TextBoxBorder";
            this.textBoxXStretchDepth.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXStretchDepth.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxXStretchDepth.Location = new System.Drawing.Point(135, 60);
            this.textBoxXStretchDepth.Name = "textBoxXStretchDepth";
            this.textBoxXStretchDepth.PreventEnterBeep = true;
            this.textBoxXStretchDepth.Size = new System.Drawing.Size(90, 26);
            this.textBoxXStretchDepth.TabIndex = 4;
            this.textBoxXStretchDepth.Text = "50";
            this.textBoxXStretchDepth.TextChanged += new System.EventHandler(this.textBoxXStretchDepth_TextChanged);
            // 
            // FrmImageLineType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 102);
            this.Controls.Add(this.textBoxXStretchDepth);
            this.Controls.Add(this.buttonXCancel);
            this.Controls.Add(this.buttonXOK);
            this.Controls.Add(this.labelXStretchDepth);
            this.Controls.Add(this.labelXGeoType);
            this.Controls.Add(this.comboBoxExGeoType);
            this.Name = "FrmImageLineType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择标记线的保存类型";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExGeoType;
        private DevComponents.DotNetBar.LabelX labelXGeoType;
        private DevComponents.DotNetBar.LabelX labelXStretchDepth;
        private DevComponents.DotNetBar.ButtonX buttonXOK;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
        private DevComponents.Editors.ComboItem comboItem_DXDM;
        private DevComponents.Editors.ComboItem comboItem_DCYX;
        private DevComponents.Editors.ComboItem comboItem_JGM;
        private DevComponents.Editors.ComboItem comboItem_GZFD;
        private DevComponents.Editors.ComboItem comboItem_ZZ;
        private DevComponents.Editors.ComboItem comboItem_FH;
        private DevComponents.Editors.ComboItem comboItem_XH;
        private DevComponents.Editors.ComboItem comboItem_NSLZH;
        private DevComponents.Editors.ComboItem comboItem_HPZH;
        private DevComponents.Editors.ComboItem comboItem_BTZH;
        private DevComponents.Editors.ComboItem comboItem_RBZH;
        private DevComponents.Editors.ComboItem comboItem_QZSWKT;
        private DevComponents.Editors.ComboItem comboItem_YR;
        private DevComponents.Editors.ComboItem comboItem_DXSFD;
        private DevComponents.Editors.ComboItem comboItem_TTFC;
        private DevComponents.Editors.ComboItem comboItem_YTFL;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXStretchDepth;
    }
}