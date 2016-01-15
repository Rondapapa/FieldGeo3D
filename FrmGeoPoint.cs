using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FGeo3D_TE
{
    public partial class FrmGeoPoint : Form
    {
        public FrmGeoPoint()
        {
            InitializeComponent();
        }

        private void btnGetFromMap_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            //MessageBox.Show(@"该功能仍在开发中");
        }
    }
}
