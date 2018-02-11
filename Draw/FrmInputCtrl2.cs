using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using GeoIM.CHIDI.DZ.BLL.Geometry;
using MathNet.Spatial.Euclidean;
using GeoIM.CHIDI.DZ.COM;

namespace Draw
{
    public partial class FrmInputCtrl2 : Form
    {
        public FrmInputCtrl2(List<Point3D> controlPtsKW, PointF pScreen, sg_Vector3[] pKW)
        {
            InitializeComponent();
            screenX.Text = pScreen.X.ToString();
            screenY.Text = pScreen.Y.ToString();
            screenZ.Text = "0";
            numberOfPts.Text = (controlPtsKW.Count + 1).ToString();
            numberOfPts.Enabled = false;

            ctrl1X.Text = pKW[0].x.ToString(); ctrl1Y.Text = pKW[0].y.ToString(); ctrl1Z.Text = pKW[0].z.ToString();
            ctrl2X.Text = pKW[1].x.ToString(); ctrl2Y.Text = pKW[1].y.ToString(); ctrl2Z.Text = pKW[1].z.ToString();
            ctrl3X.Text = pKW[2].x.ToString(); ctrl3Y.Text = pKW[2].y.ToString(); ctrl3Z.Text = pKW[2].z.ToString();



            foreach (var item in controlPtsKW)
            {
                for (int i = 0; i < pKW.Count(); i++)
                {
                    double difference = Math.Abs(pKW[i].x - item.X) + Math.Abs(pKW[i].y - item.Y) + Math.Abs(pKW[i].z - item.Z);
                    if (difference < 0.05)
                    {
                        cannotChoose.Add(i);
                    }
                }
            }
            cannotChoose.Sort();
            if (cannotChoose.Count > 0)
            {
                for (int j = cannotChoose.Count - 1; j >= 0; j--)
                {
                    chooseCtrlPts.Nodes.RemoveAt((int)cannotChoose[j]);
                }
            }



            pKWInThis = pKW;
        }

        private sg_Vector3[] pKWInThis;
        public sg_Vector3 ctrlPtsKW = null;
        private ArrayList cannotChoose = new ArrayList();

        private void chooseCtrlPts_SelectionChanged(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            if (chooseCtrlPts.Text == "控制点1")
            {

            }
        }

        private void buttonXSave_Click(object sender, EventArgs e)
        {

            if (chooseCtrlPts.Text == "控制点1")
            {
                ctrlPtsKW = new sg_Vector3(pKWInThis[0].x, pKWInThis[0].y, pKWInThis[0].z);
                DialogResult = DialogResult.OK;
            }
            else if (chooseCtrlPts.Text == "控制点2")
            {
                ctrlPtsKW = new sg_Vector3(pKWInThis[1].x, pKWInThis[1].y, pKWInThis[1].z);
                DialogResult = DialogResult.OK;
            }
            else if (chooseCtrlPts.Text == "控制点3")
            {
                ctrlPtsKW = new sg_Vector3(pKWInThis[2].x, pKWInThis[2].y, pKWInThis[2].z);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择控制点");
                return;
            }
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
