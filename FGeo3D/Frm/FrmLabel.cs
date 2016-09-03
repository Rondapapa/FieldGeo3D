using System;
using System.Windows.Forms;

namespace FGeo3D_TE.Frm
{
    public partial class FrmLabel : Form
    {
        public FrmLabel()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
