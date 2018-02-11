using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class FrmLineProperties : Form
    {
        public string MarkerType { get; set; } = "JGM";
        public FrmLineProperties()
        {
            InitializeComponent();
        }

        private void LineTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LineTypes.SelectedItem.ToString())
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
        }
    }
}
