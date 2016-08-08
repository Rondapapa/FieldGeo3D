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
        internal string SelectedType;
        
        

        public FrmObject(string pbhander)
        {
            InitializeComponent();
            Init(pbhander);
            
        }

        private void Init(string pbhander)
        {
          	if(pbhander == "Line" || pbhander == "LineNew")
          	{
          	    Text += @"地质界线";
          	}
            if(pbhander == "Region")
            {
                Text += @"地质区域";
            }
            if(pbhander == "FreehandDrawing")
            {
                Text += @"手绘地质界线";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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



        private void comboBoxExType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            SelectedType = comboBoxExType.SelectedItem.ToString();
            comboBoxExType.Text = SelectedType;
            
            //comboBoxExType.SelectedText = SelectedType;
            //if (SelectedType == "几何部件")
            //{
            //    tbName.Enabled = true;
            //    colorCombControl.Enabled = true;
            //}
            //else
            //{
            //    tbName.Enabled = false;
            //    colorCombControl.Enabled = false;
            //}
        }
    }
}
