using System;
using System.Windows.Forms;

namespace FGeo3D_TE.Frm
{
    using DevComponents.DotNetBar.Keyboard;

    public partial class FrmPlaneViaRing : Form
    {
        /// <summary>
        /// Gets the depth.
        /// </summary>
        public double depth;

        /// <summary>
        /// Gets the interval.
        /// </summary>
        public double interval;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmPlaneViaRing"/> class.
        /// </summary>
        public FrmPlaneViaRing()
        {
            InitializeComponent();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Invalidate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void textBoxDepth_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        

        private void textBoxXInterval_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxAndEnableSave();
        }

        private void CheckTextBoxAndEnableSave()
        {
            var isTxtBoxValueValid = double.TryParse(this.textBoxDepth.Text, out this.depth)
                && double.TryParse(this.textBoxXInterval.Text, out this.interval);
            this.btnOK.Enabled = isTxtBoxValueValid;
        }
    }
}
