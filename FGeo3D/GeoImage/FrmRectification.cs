using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Spatial.Euclidean;

namespace FGeo3D_TE.GeoImage
{
    public partial class FrmRectification : Form
    {
        //屏幕点坐标对
        public System.Drawing.Point ScPoint { get; set; }

        //真实点坐标对
        public Point3D WdPoint { get; set; }

        //临时存值
        private double _outWdPointX, _outWdPointY, _outWdPointZ;

        public FrmRectification(int GCPNo, int scX, int scY)
        {
            InitializeComponent();
            ScPoint = new System.Drawing.Point(scX, scY);
            textBoxXGCPNo.Text = (GCPNo + 1).ToString();
            textBoxXSPX.Text = scX.ToString();
            textBoxXSPY.Text = scY.ToString();
            textBoxXSPZ.Text = @"0";
        }

        private void buttonXSave_Click(object sender, EventArgs e)
        {
            WdPoint = new Point3D(_outWdPointX, _outWdPointY, _outWdPointZ);
            DialogResult = DialogResult.OK;
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBoxXWPX_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        private void textBoxXWPY_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        private void textBoxXWPZ_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        /// <summary>
        /// 检查真实点的坐标是否有效，若有效，则激活Save按钮
        /// </summary>
        private void CheckTextBoxAndEnableSave()
        {
            var isWdPointTextAvailable = double.TryParse(textBoxXWPX.Text, out _outWdPointX) 
                && double.TryParse(textBoxXWPY.Text, out _outWdPointY) 
                && double.TryParse(textBoxXWPZ.Text, out _outWdPointZ);
            buttonXSave.Enabled = isWdPointTextAvailable;
        }
    }
}
