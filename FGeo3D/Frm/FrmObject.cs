using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerraExplorerX;

namespace FGeo3D_TE
{
    public partial class FrmObject : Form
    {
        internal string ObjName = "地质对象#";
        internal Color SelectedColor;
        internal string Type = "几何部件";

        public FrmObject(string pbhander)
        {
            InitializeComponent();
            Init(pbhander);

        }

        private void Init(string pbhander)
        {
          	if(pbhander == "GeoLine")
          	{
          	    this.Text += @"地质界线";
          	}
            if(pbhander == "GeoRegion")
            {
                this.Text += @"地质区域";
            }
            if(pbhander == "FreehandDrawing")
            {
                this.Text += @"手绘地质界线";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void colorCombControl_SelectedColorChanged(object sender, EventArgs e)
        {
            SelectedColor = colorCombControl.SelectedColor;

            tbColor.Text = $"红={SelectedColor.R},绿={SelectedColor.G},蓝={SelectedColor.B}";
            tbColor.BackColor = SelectedColor;
            tbColor.ForeColor = Color.FromArgb(SelectedColor.A, 255 - SelectedColor.R, 255 - SelectedColor.G, 255 - SelectedColor.B);
            btnOK.BackColor = Color.Chartreuse;

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ObjName = tbName.Text;
        }

        private void radioBtnGeometryPart_CheckedChanged(object sender, EventArgs e)
        {
            Type = "几何部件";
        }

        private void radioBtnJX_CheckedChanged(object sender, EventArgs e)
        {
            Type = "界线";
        }

        private void radioBtnJGM_CheckedChanged(object sender, EventArgs e)
        {
            Type = "结构面";
        }
    }
}
