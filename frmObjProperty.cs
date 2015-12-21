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
        internal int lineAlpha;
        internal int lineRed;
        internal int lineGreen;
        internal int lineBlue;
        internal int fillAlpha;
        internal int fillRed;
        internal int fillGreen;
        internal int fillBlue;

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

        private void btnGetLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                lineAlpha = color.A;
                lineRed = color.R;
                lineGreen = color.G;
                lineBlue = color.B;
                tbLineColor.Text = String.Format("A={0},B={1},G={2},R={3}", lineAlpha, lineBlue, lineGreen, lineRed);
                tbLineColor.BackColor = color;
                tbLineColor.ForeColor = Color.FromArgb(lineAlpha, 255 - lineRed, 255 - lineGreen, 255 - lineBlue);
            }
        }

        private void buttonGetFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                fillAlpha = color.A;
                fillRed = color.R;
                fillGreen = color.G;
                fillBlue = color.B;
                tbFillColor.Text = String.Format("A={0},B={1},G={2},R={3}", fillAlpha, fillBlue, fillGreen, fillRed);
                tbFillColor.BackColor = color;
                tbFillColor.ForeColor = Color.FromArgb(fillAlpha, 255 - fillRed, 255 - fillGreen, 255 - fillBlue);
            }
        }

        
    }
}
