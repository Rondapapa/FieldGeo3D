namespace Stereonet
{
    partial class FrmStereonet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable1 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer1 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStereonet));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelInfoInput = new DevComponents.DotNetBar.PanelEx();
            this.labelNE = new DevComponents.DotNetBar.LabelX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.textBoxDip = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxTrend = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lableTrend = new DevComponents.DotNetBar.LabelX();
            this.btnStructural = new DevComponents.DotNetBar.ButtonX();
            this.btnFreeFace = new DevComponents.DotNetBar.ButtonX();
            this.panelReport = new DevComponents.DotNetBar.PanelEx();
            this.keyboardControl1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.textBoxReport = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelReport = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.attitudeInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFresh = new DevComponents.DotNetBar.ButtonX();
            this.btnAnalysis = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.touchKeyboard1 = new DevComponents.DotNetBar.Keyboard.TouchKeyboard();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInfoInput.SuspendLayout();
            this.panelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attitudeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MintCream;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            // 
            // panelInfoInput
            // 
            this.panelInfoInput.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelInfoInput.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.panelInfoInput.Controls.Add(this.labelNE);
            this.panelInfoInput.Controls.Add(this.btnReset);
            this.panelInfoInput.Controls.Add(this.textBoxDip);
            this.panelInfoInput.Controls.Add(this.textBoxTrend);
            this.panelInfoInput.Controls.Add(this.labelX1);
            this.panelInfoInput.Controls.Add(this.lableTrend);
            this.panelInfoInput.Controls.Add(this.btnStructural);
            this.panelInfoInput.Controls.Add(this.btnFreeFace);
            this.panelInfoInput.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelInfoInput.Location = new System.Drawing.Point(320, 13);
            this.panelInfoInput.Name = "panelInfoInput";
            this.panelInfoInput.Size = new System.Drawing.Size(216, 150);
            this.panelInfoInput.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelInfoInput.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelInfoInput.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelInfoInput.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelInfoInput.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelInfoInput.Style.GradientAngle = 90;
            this.panelInfoInput.TabIndex = 1;
            // 
            // labelNE
            // 
            this.labelNE.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelNE.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNE.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNE.Location = new System.Drawing.Point(70, 46);
            this.labelNE.Name = "labelNE";
            this.labelNE.Size = new System.Drawing.Size(38, 19);
            this.labelNE.TabIndex = 7;
            this.labelNE.Text = "NE";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(4, 114);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(209, 31);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // textBoxDip
            // 
            this.textBoxDip.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxDip.Border.Class = "TextBoxBorder";
            this.textBoxDip.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDip.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxDip.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDip.ForeColor = System.Drawing.Color.Black;
            this.textBoxDip.Location = new System.Drawing.Point(68, 78);
            this.textBoxDip.Name = "textBoxDip";
            this.textBoxDip.PreventEnterBeep = true;
            this.textBoxDip.Size = new System.Drawing.Size(145, 31);
            this.textBoxDip.TabIndex = 5;
            this.textBoxDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxDip_MouseClick);
            this.textBoxDip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDip_KeyDown);
            // 
            // textBoxTrend
            // 
            this.textBoxTrend.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxTrend.Border.Class = "TextBoxBorder";
            this.textBoxTrend.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxTrend.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxTrend.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTrend.ForeColor = System.Drawing.Color.Black;
            this.textBoxTrend.Location = new System.Drawing.Point(68, 40);
            this.textBoxTrend.Name = "textBoxTrend";
            this.textBoxTrend.PreventEnterBeep = true;
            this.textBoxTrend.Size = new System.Drawing.Size(145, 31);
            this.textBoxTrend.TabIndex = 4;
            this.textBoxTrend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTrend.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTrend_MouseClick);
            this.textBoxTrend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTrend_KeyDown);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(6, 78);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(46, 31);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "倾角";
            // 
            // lableTrend
            // 
            // 
            // 
            // 
            this.lableTrend.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lableTrend.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lableTrend.Location = new System.Drawing.Point(6, 40);
            this.lableTrend.Name = "lableTrend";
            this.lableTrend.Size = new System.Drawing.Size(46, 31);
            this.lableTrend.TabIndex = 2;
            this.lableTrend.Text = "倾向";
            // 
            // btnStructural
            // 
            this.btnStructural.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStructural.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStructural.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStructural.Location = new System.Drawing.Point(110, 4);
            this.btnStructural.Name = "btnStructural";
            this.btnStructural.Size = new System.Drawing.Size(103, 31);
            this.btnStructural.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnStructural.TabIndex = 1;
            this.btnStructural.Text = "结构面";
            this.btnStructural.Click += new System.EventHandler(this.btnStructural_Click);
            // 
            // btnFreeFace
            // 
            this.btnFreeFace.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFreeFace.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFreeFace.FocusCuesEnabled = false;
            this.btnFreeFace.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFreeFace.Location = new System.Drawing.Point(4, 4);
            this.btnFreeFace.Name = "btnFreeFace";
            this.btnFreeFace.Size = new System.Drawing.Size(103, 31);
            this.btnFreeFace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFreeFace.TabIndex = 0;
            this.btnFreeFace.Text = "临空面";
            this.btnFreeFace.Click += new System.EventHandler(this.btnFreeFace_Click);
            // 
            // panelReport
            // 
            this.panelReport.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelReport.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelReport.Controls.Add(this.keyboardControl1);
            this.panelReport.Controls.Add(this.btnExport);
            this.panelReport.Controls.Add(this.textBoxReport);
            this.panelReport.Controls.Add(this.labelReport);
            this.panelReport.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelReport.Location = new System.Drawing.Point(12, 320);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(300, 240);
            this.panelReport.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelReport.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelReport.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelReport.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelReport.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelReport.Style.GradientAngle = 90;
            this.panelReport.TabIndex = 5;
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
            this.keyboardControl1.Location = new System.Drawing.Point(1, -3);
            this.keyboardControl1.Name = "keyboardControl1";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyboardControl1.Renderer = flatStyleRenderer1;
            this.keyboardControl1.Size = new System.Drawing.Size(300, 240);
            this.keyboardControl1.TabIndex = 3;
            this.keyboardControl1.Text = "keyboardControl1";
            this.keyboardControl1.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(221, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // textBoxReport
            // 
            this.textBoxReport.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxReport.Border.Class = "TextBoxBorder";
            this.textBoxReport.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxReport.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxReport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxReport.ForeColor = System.Drawing.Color.Black;
            this.textBoxReport.Location = new System.Drawing.Point(4, 33);
            this.textBoxReport.Multiline = true;
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.PreventEnterBeep = true;
            this.textBoxReport.Size = new System.Drawing.Size(293, 204);
            this.textBoxReport.TabIndex = 1;
            // 
            // labelReport
            // 
            // 
            // 
            // 
            this.labelReport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelReport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReport.Location = new System.Drawing.Point(3, 3);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(135, 23);
            this.labelReport.TabIndex = 0;
            this.labelReport.Text = "分析报告";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(320, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 31);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(433, 170);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(103, 31);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // attitudeInfo
            // 
            this.attitudeInfo.AllowUserToResizeColumns = false;
            this.attitudeInfo.AllowUserToResizeRows = false;
            this.attitudeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attitudeInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.attitudeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.attitudeInfo.ColumnHeadersHeight = 30;
            this.attitudeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.attitudeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.trend,
            this.dip});
            this.attitudeInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.attitudeInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.attitudeInfo.EnableHeadersVisualStyles = false;
            this.attitudeInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.attitudeInfo.HighlightSelectedColumnHeaders = false;
            this.attitudeInfo.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.attitudeInfo.Location = new System.Drawing.Point(320, 208);
            this.attitudeInfo.MultiSelect = false;
            this.attitudeInfo.Name = "attitudeInfo";
            this.attitudeInfo.RowHeadersVisible = false;
            this.attitudeInfo.RowTemplate.Height = 23;
            this.attitudeInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.attitudeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.attitudeInfo.Size = new System.Drawing.Size(216, 266);
            this.attitudeInfo.TabIndex = 11;
            this.attitudeInfo.SelectionChanged += new System.EventHandler(this.attitudeInfo_SelectionChanged);
            // 
            // number
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.number.DefaultCellStyle = dataGridViewCellStyle2;
            this.number.HeaderText = "编号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // trend
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trend.DefaultCellStyle = dataGridViewCellStyle3;
            this.trend.HeaderText = "倾向";
            this.trend.Name = "trend";
            this.trend.ReadOnly = true;
            this.trend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dip
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dip.DefaultCellStyle = dataGridViewCellStyle4;
            this.dip.HeaderText = "倾角";
            this.dip.Name = "dip";
            this.dip.ReadOnly = true;
            this.dip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // btnFresh
            // 
            this.btnFresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFresh.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFresh.Location = new System.Drawing.Point(320, 465);
            this.btnFresh.Name = "btnFresh";
            this.btnFresh.Size = new System.Drawing.Size(216, 31);
            this.btnFresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFresh.TabIndex = 12;
            this.btnFresh.Text = "刷新";
            this.btnFresh.Click += new System.EventHandler(this.btnFresh_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAnalysis.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAnalysis.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAnalysis.Location = new System.Drawing.Point(320, 503);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(216, 57);
            this.btnAnalysis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAnalysis.TabIndex = 13;
            this.btnAnalysis.Text = "开始分析";
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this.panelInfoInput;
            // 
            // touchKeyboard1
            // 
            this.touchKeyboard1.FloatingLocation = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.FloatingSize = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.Size = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Text = "";
            // 
            // FrmStereonet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 572);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.btnFresh);
            this.Controls.Add(this.attitudeInfo);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panelInfoInput);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStereonet";
            this.Text = "块体分析";
            this.Load += new System.EventHandler(this.FrmStereonet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInfoInput.ResumeLayout(false);
            this.panelReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attitudeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.PanelEx panelInfoInput;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lableTrend;
        private DevComponents.DotNetBar.ButtonX btnStructural;
        private DevComponents.DotNetBar.ButtonX btnFreeFace;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxDip;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxTrend;
        private DevComponents.DotNetBar.PanelEx panelReport;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxReport;
        private DevComponents.DotNetBar.LabelX labelReport;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.Controls.DataGridViewX attitudeInfo;
        private DevComponents.DotNetBar.ButtonX btnFresh;
        private DevComponents.DotNetBar.ButtonX btnAnalysis;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Keyboard.TouchKeyboard touchKeyboard1;
        private DevComponents.DotNetBar.LabelX labelNE;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn trend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dip;
    }
}

