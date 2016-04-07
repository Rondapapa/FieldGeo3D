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
    public partial class FrmGeoPoint : Form
    {
        private SGWorld66 sgworld;
        public bool IsGetFromMapPressed { get; private set; }

        public FrmGeoPoint(ref SGWorld66 theSGWorld)
        {
            InitializeComponent();
            sgworld = theSGWorld;
        }

        private void btnGetFromMap_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            //Hide();
            //IsGetFromMapPressed = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            //MessageBox.Show(@"该功能仍在开发中");
        }
    }
}
