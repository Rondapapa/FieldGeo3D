using System;
using System.Windows.Forms;
using TerraExplorerX;

namespace FGeo3D_TE.Frm
{
    public partial class FrmPoint : Form
    {
        private SGWorld66 sgworld;
        public bool IsGetFromMapPressed { get; private set; }

        public FrmPoint(ref SGWorld66 theSGWorld)
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
