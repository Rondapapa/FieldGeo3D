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
    public partial class FrmPosition : Form
    {
        public double XLeft { get; private set; }
        public double XRight { get; private set; }
        public double YTop { get; private set; }
        public double YBottom { get; private set; }

        public double XLong { get; private set; }
        public double YLat { get; private set; }

        public FrmPosition(double xLeft, double xRight, double yTop, double yBottom)
        {
            XLeft = xLeft;
            XRight = xRight;
            YTop = yTop;
            YBottom = yBottom;
            InitializeComponent();
            btnOK.Enabled = false;
        }

        public bool IsPosInRange(double x, double y)
        {
            return x >= XLeft && x <= XRight && y >= YBottom && y <= YTop;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            XLong = Convert.ToDouble(tbX.Text);
            YLat = Convert.ToDouble(tbY.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            if(IsPosInRange(Convert.ToDouble(tbX.Text),Convert.ToDouble(tbY.Text)))
            {
                btnOK.Enabled = true;
                btnOK.Text = @"导航至该位置";
                
            }
            else
            {
                btnOK.Enabled = false;
                btnOK.Text = @"位置超出地图范围";
                
            }
        }

        

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            if (IsPosInRange(Convert.ToDouble(tbX.Text), Convert.ToDouble(tbY.Text)))
            {
                btnOK.Enabled = true;
                btnOK.Text = @"导航至该位置";
            }
            else
            {
                btnOK.Enabled = false;
                btnOK.Text = @"位置超出地图范围";
                
            }
        }
    }
}
