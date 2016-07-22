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
            this.groupPanelType = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanelType.SuspendLayout();
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
            this.tbName.Location = new System.Drawing.Point(70, 21);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(486, 29);
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
            this.labelName.Location = new System.Drawing.Point(12, 21);
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
            this.labelType.Location = new System.Drawing.Point(12, 56);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(52, 29);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "类型";
            // 
            // colorCombControl
            // 
            this.colorCombControl.Location = new System.Drawing.Point(13, 127);
            this.colorCombControl.Name = "colorCombControl";
            this.colorCombControl.Size = new System.Drawing.Size(544, 490);
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
            this.radioBtnGeometryPart.AutoSize = true;
            this.radioBtnGeometryPart.Checked = true;
            this.radioBtnGeometryPart.Font = new System.Drawing.Font("宋体", 14.25F);
            this.radioBtnGeometryPart.Location = new System.Drawing.Point(3, 3);
            this.radioBtnGeometryPart.Name = "radioBtnGeometryPart";
            this.radioBtnGeometryPart.Size = new System.Drawing.Size(103, 23);
            this.radioBtnGeometryPart.TabIndex = 5;
            this.radioBtnGeometryPart.TabStop = true;
            this.radioBtnGeometryPart.Text = "几何部件";
            this.radioBtnGeometryPart.UseVisualStyleBackColor = true;
            this.radioBtnGeometryPart.CheckedChanged += new System.EventHandler(this.radioBtnGeometryPart_CheckedChanged);
            // 
            // radioBtnJX
            // 
            this.radioBtnJX.AutoSize = true;
            this.radioBtnJX.Font = new System.Drawing.Font("宋体", 14.25F);
            this.radioBtnJX.Location = new System.Drawing.Point(112, 3);
            this.radioBtnJX.Name = "radioBtnJX";
            this.radioBtnJX.Size = new System.Drawing.Size(65, 23);
            this.radioBtnJX.TabIndex = 5;
            this.radioBtnJX.Text = "界线";
            this.radioBtnJX.UseVisualStyleBackColor = true;
            this.radioBtnJX.CheckedChanged += new System.EventHandler(this.radioBtnJX_CheckedChanged);
            // 
            // radioBtnJGM
            // 
            this.radioBtnJGM.AutoSize = true;
            this.radioBtnJGM.Font = new System.Drawing.Font("宋体", 14.25F);
            this.radioBtnJGM.Location = new System.Drawing.Point(183, 3);
            this.radioBtnJGM.Name = "radioBtnJGM";
            this.radioBtnJGM.Size = new System.Drawing.Size(84, 23);
            this.radioBtnJGM.TabIndex = 5;
            this.radioBtnJGM.Text = "结构面";
            this.radioBtnJGM.UseVisualStyleBackColor = true;
            this.radioBtnJGM.CheckedChanged += new System.EventHandler(this.radioBtnJGM_CheckedChanged);
            // 
            // groupPanelType
            // 
            this.groupPanelType.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanelType.Controls.Add(this.radioBtnGeometryPart);
            this.groupPanelType.Controls.Add(this.radioBtnJGM);
            this.groupPanelType.Controls.Add(this.radioBtnJX);
            this.groupPanelType.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanelType.DrawTitleBox = false;
            this.groupPanelType.Location = new System.Drawing.Point(70, 56);
            this.groupPanelType.Name = "groupPanelType";
            this.groupPanelType.Size = new System.Drawing.Size(486, 28);
            // 
            // 
            // 
            this.groupPanelType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanelType.Style.BackColorGradientAngle = 90;
            this.groupPanelType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanelType.Style.BorderBottomWidth = 1;
            this.groupPanelType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelType.Style.BorderLeftWidth = 1;
            this.groupPanelType.Style.BorderRightWidth = 1;
            this.groupPanelType.Style.BorderTopWidth = 1;
            this.groupPanelType.Style.CornerDiameter = 4;
            this.groupPanelType.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelType.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelType.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanelType.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelType.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelType.TabIndex = 6;
            // 
            // FrmObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 605);
            this.Controls.Add(this.groupPanelType);
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
            this.groupPanelType.ResumeLayout(false);
            this.groupPanelType.PerformLayout();
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
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelType;
    }
}