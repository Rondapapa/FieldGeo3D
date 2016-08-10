using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGeo3D_TE.GeoImage
{
    public partial class FrmImageLineType : Form
    {
        //地质对象类型
        public GeoType GeoType
        {
            get;
            set;
        }

        //面内延伸类型
        public StretchType StretchType { get; set; }



        public FrmImageLineType()
        {
            InitializeComponent();
        }

        private void comboBoxExGeoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxExGeoType.SelectedValue.ToString())
            {
                case "DXDM":
                    GeoType = GeoType.地形地貌;
                    break;
                case "DCYX":
                    GeoType = GeoType.地层岩性;
                    break;
                case "JGM":
                    GeoType = GeoType.结构面;
                    break;
                case "GZFD":
                    GeoType = GeoType.构造分段;
                    break;
                case "ZZ":
                    GeoType = GeoType.褶皱;
                    break;
                case "FF":
                    GeoType = GeoType.风化;
                    break;
                case "XH":
                    GeoType = GeoType.卸荷;
                    break;
                case "NSLZH":
                    GeoType = GeoType.泥石流;
                    break;
                case "HPZH":
                    GeoType = GeoType.滑坡;
                    break;
                case "BTZH":
                    GeoType = GeoType.崩塌;
                    break;
                case "RBZH":
                    GeoType = GeoType.蠕变;
                    break;
                case "QZSWKT":
                    GeoType = GeoType.潜在失稳块体;
                    break;
                case "YR":
                    GeoType = GeoType.岩溶;
                    break;
                case "DXSFD":
                    GeoType = GeoType.地下水分段;
                    break;
                case "TTFC":
                    GeoType = GeoType.土体分层;
                    break;
                case "YTFL":
                    GeoType = GeoType.岩体分类;
                    break;
                default:
                    break;
            }
        }

        private void comboBoxExStretchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxExStretchType.SelectedValue.ToString())
            {
                case "None":
                    StretchType = StretchType.无;
                    break;
                case "Triangle":
                    StretchType = StretchType.三角形延伸;
                    break;
                default:
                    break;
            }
            
        }

        private void buttonXOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
    }


}
