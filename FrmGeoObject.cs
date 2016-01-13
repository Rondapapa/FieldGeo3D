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
    public partial class FrmGeoObject : Form
    {
        internal string ObjName = "地质对象#";
        internal Color SelectedColor;


        public FrmGeoObject(string pbhander)
        {
            InitializeComponent();
            Init(pbhander);

        }

        private void Init(string pbhander)
        {
          	if(pbhander == "GeoLine")
          	{
          	    this.Text += "地质界线";
          	}
            if(pbhander == "GeoRegion")
            {
                this.Text += "地质区域";
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

            tbColor.Text = String.Format("红={0},绿={1},蓝={2}", SelectedColor.R, SelectedColor.G, SelectedColor.B);
            tbColor.BackColor = SelectedColor;
            tbColor.ForeColor = Color.FromArgb(SelectedColor.A, 255 - SelectedColor.R, 255 - SelectedColor.G, 255 - SelectedColor.B);
            btnOK.BackColor = Color.Chartreuse;

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ObjName = tbName.Text;
        }

        
    }
}
