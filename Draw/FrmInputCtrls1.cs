using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar.Keyboard;
using GeoIM.CHIDI.DZ.COM;

using GeoIM.CHIDI.DZ.BLL.Geometry;
namespace Draw
{
    public partial class FrmInputCtrls1 : Form
    {
        public FrmInputCtrls1(int number,PointF p)
        {
            InitializeComponent();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            screenX.Text = p.X.ToString();
            screenY.Text = p.Y.ToString();
            screenZ.Text = "0";
            numberOfPts.Text = number.ToString();
            numberOfPts.Enabled = false;
        }


        public sg_Vector3 ctrlPtsKW =null;

        private void buttonXSave_Click(object sender, EventArgs e)
        {
            try
            {
                ctrlPtsKW = new sg_Vector3(double.Parse(kwX.Text.ToString()), double.Parse(kwY.Text.ToString()), double.Parse(kwZ.Text.ToString()));
                this.DialogResult = DialogResult.OK;
                

            }
            catch
            {
                MessageBox.Show("数字格式不正确");
                return;
            }
            
        }


        /// <summary>
        /// 重构虚拟键盘
        /// </summary>
        /// <returns></returns>
        private Keyboard CreateNumericKeyboard()
        {
            Keyboard keyboard = new Keyboard();

            LinearKeyboardLayout kl = new LinearKeyboardLayout();

            kl.AddKey("7");
            kl.AddKey("8");
            kl.AddKey("9");
            kl.AddKey("退格", "{BACKSPACE}");
            kl.AddLine();

            kl.AddKey("4");
            kl.AddKey("5");
            kl.AddKey("6");
            //   kl.AddKey("-", "{SUBTRACT}");
            kl.AddKey("-", "{Subtract}", height: 32);
            kl.AddLine();

            kl.AddKey("1");
            kl.AddKey("2");
            kl.AddKey("3");

            kl.AddLine();

            kl.AddKey("0", width: 21);
            kl.AddKey(".");

            keyboard.Layouts.Add(kl);
            return keyboard;
        }


        ///// <summary>
        ///// 检查真实点的坐标是否有效，若有效，则激活Save按钮
        ///// </summary>
        //private void CheckTextBoxAndEnableSave()
        //{
        //    var isWdPointTextAvailable = double.TryParse(kwX.Text, out ctrlPtsKW.x)
        //        && double.TryParse(kwY.Text, out _outWdPointY)
        //        && double.TryParse(kwZ.Text, out _outWdPointZ);
        //    buttonXSave.Enabled = isWdPointTextAvailable;
        //}


        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }

        private void FrmInputCtrls_Activated(object sender, EventArgs e)
        {
            kwX.Focus();
        }
    }
}
