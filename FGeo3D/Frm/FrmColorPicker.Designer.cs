namespace FGeo3D_TE.Frm
{
    partial class FrmColorPicker
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
            this.colorCombControl1 = new DevComponents.DotNetBar.ColorPickers.ColorCombControl();
            this.SuspendLayout();
            // 
            // colorCombControl1
            // 
            this.colorCombControl1.Location = new System.Drawing.Point(-4, -3);
            this.colorCombControl1.Name = "colorCombControl1";
            this.colorCombControl1.Size = new System.Drawing.Size(411, 443);
            this.colorCombControl1.TabIndex = 0;
            this.colorCombControl1.Text = "colorCombControl1";
            this.colorCombControl1.SelectedColorChanged += new System.EventHandler(this.colorCombControl1_SelectedColorChanged);
            // 
            // FrmColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 419);
            this.ControlBox = false;
            this.Controls.Add(this.colorCombControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmColorPicker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ñ¡ÔñÑÕÉ«";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ColorPickers.ColorCombControl colorCombControl1;
    }
}