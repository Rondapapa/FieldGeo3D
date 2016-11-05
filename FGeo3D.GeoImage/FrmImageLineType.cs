using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGeo3D.GeoImage
{
    using DevComponents.DotNetBar.Keyboard;

    public partial class FrmImageLineType : Form
    {
        //地质对象类型
        public string MarkerType { get; set; } = "JGM";

        //面内延伸类型
        public double StretchDepth { get; set; } = 50;



        public FrmImageLineType()
        {
            InitializeComponent();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Invalidate();
        }

        private void comboBoxExGeoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxExGeoType.SelectedItem.ToString())
            {
                case "地形地貌":
                    MarkerType = "DXDM";
                    break;
                case "地层岩性":
                    MarkerType = "DCYX";
                    break;
                case "结构面":
                    MarkerType = "JGM";
                    break;
                case "构造分段":
                    MarkerType = "GZFD";
                    break;
                case "褶皱":
                    MarkerType = "ZZ";
                    break;
                case "风化":
                    MarkerType = "FH";
                    break;
                case "卸荷":
                    MarkerType = "XH";
                    break;
                case "泥石流":
                    MarkerType = "NSL";
                    break;
                case "滑坡":
                    MarkerType = "HP";
                    break;
                case "崩塌":
                    MarkerType = "BT";
                    break;
                case "蠕变":
                    MarkerType = "RB";
                    break;
                case "潜在失稳块体":
                    MarkerType = "QZSWKT";
                    break;
                case "岩溶":
                    MarkerType = "YR";
                    break;
                case "地下水分段":
                    MarkerType = "DXSFD";
                    break;
                case "土体分层":
                    MarkerType = "TTFC";
                    break;
                case "岩体分类":
                    MarkerType = "YTFL";
                    break;
                default:
                    MarkerType = "";
                    break;
            }
            this.buttonXOK.Enabled = !string.IsNullOrEmpty(this.MarkerType);
        }

        private void buttonXOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBoxXStretchDepth_TextChanged(object sender, EventArgs e)
        {
            var input = textBoxXStretchDepth.Text;
            try
            {
                StretchDepth = Convert.ToDouble(input);
                buttonXOK.Enabled = true;
            }
            catch (Exception)
            {
                buttonXOK.Enabled = false;
                
            }
            

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

        private void labelXStretchDepth_Click(object sender, EventArgs e)
        {

        }
    }


}
