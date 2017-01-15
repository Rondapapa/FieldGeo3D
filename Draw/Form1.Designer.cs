namespace WindowsFormsApplication12
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable1 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer1 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.keyboardControl1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.touchKeyboard1 = new DevComponents.DotNetBar.Keyboard.TouchKeyboard();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeight = 30;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.trend,
            this.dip});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX1.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.dataGridViewX1.Location = new System.Drawing.Point(319, 205);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(217, 266);
            this.dataGridViewX1.TabIndex = 1;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // number
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.number.DefaultCellStyle = dataGridViewCellStyle2;
            this.number.HeaderText = "编号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // trend
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trend.DefaultCellStyle = dataGridViewCellStyle3;
            this.trend.HeaderText = "倾向";
            this.trend.Name = "trend";
            this.trend.ReadOnly = true;
            this.trend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dip
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dip.DefaultCellStyle = dataGridViewCellStyle4;
            this.dip.HeaderText = "倾角";
            this.dip.Name = "dip";
            this.dip.ReadOnly = true;
            this.dip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(6, 40);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 31);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "倾向";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(6, 77);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(46, 31);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "倾角";
            // 
            // textBoxX4
            // 
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX4.Location = new System.Drawing.Point(68, 77);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.PreventEnterBeep = true;
            this.textBoxX4.Size = new System.Drawing.Size(145, 31);
            this.textBoxX4.TabIndex = 6;
            this.textBoxX4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxX4.Click += new System.EventHandler(this.textBoxX4_Click);
            this.textBoxX4.TextChanged += new System.EventHandler(this.textBoxX4_TextChanged);
            this.textBoxX4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX4_KeyDown);
            // 
            // textBoxX5
            // 
            // 
            // 
            // 
            this.textBoxX5.Border.Class = "TextBoxBorder";
            this.textBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX5.Location = new System.Drawing.Point(68, 40);
            this.textBoxX5.Name = "textBoxX5";
            this.textBoxX5.PreventEnterBeep = true;
            this.textBoxX5.Size = new System.Drawing.Size(145, 31);
            this.textBoxX5.TabIndex = 7;
            this.textBoxX5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxX5.CommandKeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX5_CommandKeyDown);
            this.textBoxX5.AcceptsTabChanged += new System.EventHandler(this.textBoxX5_AcceptsTabChanged);
            this.textBoxX5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxX5_MouseClick);
            this.textBoxX5.CursorChanged += new System.EventHandler(this.textBoxX5_CursorChanged);
            this.textBoxX5.TextChanged += new System.EventHandler(this.textBoxX5_TextChanged);
            this.textBoxX5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX5_KeyDown);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX1.Location = new System.Drawing.Point(319, 502);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(216, 58);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 8;
            this.buttonX1.Text = "开始分析";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.buttonX7);
            this.panelEx1.Controls.Add(this.buttonX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.textBoxX5);
            this.panelEx1.Controls.Add(this.textBoxX4);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(319, 12);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(216, 150);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 10;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(69, 44);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(38, 22);
            this.labelX4.TabIndex = 34;
            this.labelX4.Text = "NE";
            this.labelX4.CursorChanged += new System.EventHandler(this.labelX4_CursorChanged);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.AutoSize = true;
            this.buttonX2.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX2.Location = new System.Drawing.Point(4, 3);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(103, 31);
            this.buttonX2.TabIndex = 8;
            this.buttonX2.Text = "临空面";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX7.Location = new System.Drawing.Point(4, 114);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(209, 31);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.TabIndex = 33;
            this.buttonX7.Text = "重置";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX3.Location = new System.Drawing.Point(110, 3);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(103, 31);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 9;
            this.buttonX3.Text = "结构面";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX4.Location = new System.Drawing.Point(429, 168);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(106, 31);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 10;
            this.buttonX4.Text = "删除";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX5.Location = new System.Drawing.Point(319, 168);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(106, 31);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX5.TabIndex = 14;
            this.buttonX5.Text = "确定";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.keyboardControl1);
            this.panelEx2.Controls.Add(this.buttonX6);
            this.panelEx2.Controls.Add(this.textBoxX1);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(12, 320);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(300, 240);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 29;
            this.panelEx2.Text = "panelEx2";
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
            this.keyboardControl1.Location = new System.Drawing.Point(0, -1);
            this.keyboardControl1.Name = "keyboardControl1";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyboardControl1.Renderer = flatStyleRenderer1;
            this.keyboardControl1.Size = new System.Drawing.Size(300, 241);
            this.keyboardControl1.TabIndex = 0;
            this.keyboardControl1.Text = "keyboardControl1";
            this.keyboardControl1.Visible = false;
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX6.Location = new System.Drawing.Point(222, 4);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(75, 23);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 2;
            this.buttonX6.Text = "导出";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX1.Location = new System.Drawing.Point(4, 33);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(293, 204);
            this.textBoxX1.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(135, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "分析报告";
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX8.Location = new System.Drawing.Point(319, 465);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.Size = new System.Drawing.Size(217, 31);
            this.buttonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX8.TabIndex = 2;
            this.buttonX8.Text = "刷新";
            this.buttonX8.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX8.Click += new System.EventHandler(this.buttonX8_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this.panelEx1;
            this.highlighter1.CustomHighlightColors = new System.Drawing.Color[] {
        System.Drawing.Color.Yellow};
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MintCream;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Enabled = false;
            this.highlighter1.SetHighlightOnFocus(this.pictureBox1, true);
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Layout += new System.Windows.Forms.LayoutEventHandler(this.pictureBox1_Layout);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // touchKeyboard1
            // 
            this.touchKeyboard1.FloatingLocation = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.FloatingSize = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.Size = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 572);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX8);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dataGridViewX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "块体分析";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX5;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX buttonX8;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.Keyboard.TouchKeyboard touchKeyboard1;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl keyboardControl1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn trend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dip;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

