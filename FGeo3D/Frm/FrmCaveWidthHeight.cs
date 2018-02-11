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

namespace FGeo3D_TE.Frm
{
    public partial class FrmCaveWidthHeight : Form
    {
        public FrmCaveWidthHeight()
        {
            InitializeComponent();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
        }

        public double caveWidth;
        public double caveHeight;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                caveWidth = double.Parse(valueCaveWidth.Text);
                caveHeight = double.Parse(valueCaveHeight.Text);
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("输入的数字格式不正确");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
