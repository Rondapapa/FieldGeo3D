using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGeo3D_TE.Frm
{
    using DevComponents.DotNetBar.Keyboard;

    public partial class FrmPlaneViaSpotOrLine : Form
    {
        public double Length;

        public double Dip;

        public double Angle;

        private double X, Y, Z;

        public Color PickedColor { get; private set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBoxDepth_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        public FrmPlaneViaSpotOrLine(string strSpotOrLine ,double x, double y, double z)
        {
            InitializeComponent();
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.textBoxX.Text = this.X.ToString();
            this.textBoxY.Text = this.Y.ToString();
            this.textBoxZ.Text = this.Z.ToString();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Invalidate();
            if (strSpotOrLine == "Line")
            {
                this.Text = @"地质线推求地质面";
                
            }
        }

        private void textBoxDip_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        private void textBoxAngle_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            FrmColorPicker frmColorPicker = new FrmColorPicker();
            var dlgResult = frmColorPicker.ShowDialog();
            if (dlgResult != DialogResult.OK) return;
            this.PickedColor = frmColorPicker.PickedColor;
            this.labelXColor.BackColor = this.PickedColor;
        }

        /// <summary>
        /// 数字小键盘
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
            kl.AddKey("-", "{SUBTRACT}");
            kl.AddLine();

            kl.AddKey("1");
            kl.AddKey("2");
            kl.AddKey("3");
            kl.AddKey("Enter", "{ENTER}", height: 21);
            kl.AddLine();

            kl.AddKey("0", width: 21);
            kl.AddKey(".");

            keyboard.Layouts.Add(kl);
            return keyboard;
        }

        private void CheckTextBoxAndEnableSave()
        {
            var isTxtBoxValueValid = double.TryParse(this.textBoxDepth.Text, out this.Length)
                && double.TryParse(this.textBoxDip.Text, out this.Dip)
                && double.TryParse(this.textBoxAngle.Text, out this.Angle);
            this.buttonOK.Enabled = isTxtBoxValueValid;
        }
    }
}
