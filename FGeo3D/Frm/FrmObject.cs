using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.Keyboard;

namespace FGeo3D_TE.Frm
{
    public partial class FrmObject : Form
    {
        internal string ObjName = "地质对象#";
        internal Color SelectedColor;
        internal string SelectedMarkerType;
        
        

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
            if(pbhander == "Region" || pbhander == "RegionNew")
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

            comboBoxExType.Text = comboBoxExType.SelectedItem.ToString();
            switch (comboBoxExType.Text)
            {
                case "地形地貌":
                    SelectedMarkerType = "DXDM";
                    break;
                case "地层岩性":
                    SelectedMarkerType = "DCYX";
                    break;
                case "构造分段":
                    SelectedMarkerType = "GZFD";
                    break;
                case "褶皱":
                    SelectedMarkerType = "ZZ";
                    break;
                case "风化":
                    SelectedMarkerType = "FH";
                    break;
                case "卸荷":
                    SelectedMarkerType = "XH";
                    break;
                case "泥石流":
                    SelectedMarkerType = "NSL";
                    break;
                case "滑坡":
                    SelectedMarkerType = "HP";
                    break;
                case "崩塌":
                    SelectedMarkerType = "BT";
                    break;
                case "蠕变":
                    SelectedMarkerType = "RB";
                    break;
                case "岩溶":
                    SelectedMarkerType = "YR";
                    break;
                case "地下水分段":
                    SelectedMarkerType = "DXSFD";
                    break;
                case "土体分层":
                    SelectedMarkerType = "TTFC";
                    break;
                case "岩体分类":
                    SelectedMarkerType = "YTFL";
                    break;
                case "结构面":
                    SelectedMarkerType = "JGM";
                    break;
            }


        }

        private void tbName_Click(object sender, EventArgs e)
        {
            
            touchKeyboard.ShowKeyboard(keyboardControl, TouchKeyboardStyle.Inline);
        }
    }
}
