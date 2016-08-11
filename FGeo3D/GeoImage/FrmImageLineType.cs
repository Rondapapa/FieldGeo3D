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
            switch (comboBoxExGeoType.SelectedItem.ToString())
            {
                case "地形地貌":
                    GeoType = GeoType.地形地貌;
                    break;
                case "地层岩性":
                    GeoType = GeoType.地层岩性;
                    break;
                case "结构面":
                    GeoType = GeoType.结构面;
                    break;
                case "构造分段":
                    GeoType = GeoType.构造分段;
                    break;
                case "褶皱":
                    GeoType = GeoType.褶皱;
                    break;
                case "风化":
                    GeoType = GeoType.风化;
                    break;
                case "卸荷":
                    GeoType = GeoType.卸荷;
                    break;
                case "泥石流":
                    GeoType = GeoType.泥石流;
                    break;
                case "滑坡":
                    GeoType = GeoType.滑坡;
                    break;
                case "崩塌":
                    GeoType = GeoType.崩塌;
                    break;
                case "蠕变":
                    GeoType = GeoType.蠕变;
                    break;
                case "潜在失稳块体":
                    GeoType = GeoType.潜在失稳块体;
                    break;
                case "岩溶":
                    GeoType = GeoType.岩溶;
                    break;
                case "地下水分段":
                    GeoType = GeoType.地下水分段;
                    break;
                case "土体分层":
                    GeoType = GeoType.土体分层;
                    break;
                case "岩体分类":
                    GeoType = GeoType.岩体分类;
                    break;
                default:
                    break;
            }
        }

        private void comboBoxExStretchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxExStretchType.SelectedItem.ToString())
            {
                case "无":
                    StretchType = StretchType.无;
                    break;
                case "三角形延伸":
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
