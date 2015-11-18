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
    public partial class frmObjProperty : Form
    {
        internal int alpha;
        internal int red;
        internal int green;
        internal int blue;


        public frmObjProperty()
        {
            InitializeComponent();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void colorComb_SelectedColorChanged(object sender, EventArgs e)
        {
            alpha = colorComb.SelectedColor.A;
            red = colorComb.SelectedColor.R;
            green = colorComb.SelectedColor.G;
            blue = colorComb.SelectedColor.B;
        }

        

        

        
    }
}
