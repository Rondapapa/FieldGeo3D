using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace FGeo3D_TE.Frm
{
    public partial class FrmColorPicker : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Color PickedColor { get; private set; }

        public FrmColorPicker()
        {
            InitializeComponent();
        }

        private void colorCombControl1_SelectedColorChanged(object sender, EventArgs e)
        {
            PickedColor = this.colorCombControl1.SelectedColor;
            DialogResult = DialogResult.OK;
        }
    }
}