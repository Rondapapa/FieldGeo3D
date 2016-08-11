using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE.GeoImage
{
    public partial class FrmImage : Form
    {
        //数据库对象
        private YWCHEntEx db;

        //Graphics对象
        private Graphics g;

        //画笔
        private Pen _pen;
        //画刷
        private SolidBrush _brush;

        //当前处理的图像
        private Image _currImage;
        private Bitmap _currBitmap;

        //当前颜色
        private Color _currColor = Color.Black;

        //当前绘制的点集（线）
        private List<System.Drawing.Point> _currScreenLinePoints = new List<System.Drawing.Point>();

        //所有已绘制的线列表
        private List<ImageLine> _lineList = new List<ImageLine>();

        public FrmImage(ref YWCHEntEx inDb)
        {
            InitializeComponent();
            db = inDb;
        }

        public FrmImage()
        {
            InitializeComponent();
        }

        private void btnGetImageFromCamera_Click(object sender, EventArgs e)
        {
            var frmCamera = new FrmCamera();
            frmCamera.Show();
        }

        private void btnGetImageFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = @"所有图像文件|*.jpg;*.jpeg;*.bmp;*.png|Jpg|*.jpg;*.jpeg|Bmp|*.bmp|Png|*.png|所有文件|*.*",
                Title = @"载入地质图像"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            _currBitmap = new Bitmap(ofd.FileName);
            pictureBox.Image = _currBitmap;

            g = pictureBox.CreateGraphics();
            pictureBox.Paint += (o, args) =>
            {
                var inG = args.Graphics;
                var inPen = new Pen(Color.Black, 2);
                var inSolidBrush = new SolidBrush(Color.Black);
                foreach (var thisImageLine in _lineList)
                {
                    inPen.Color = thisImageLine.Color;
                    inSolidBrush.Color = thisImageLine.Color;
                    foreach (var thisScreenPoint in thisImageLine.ScreenPoints)
                    {
                        inG.DrawEllipse(inPen, thisScreenPoint.X, thisScreenPoint.Y, 5, 5);
                        inG.FillEllipse(inSolidBrush, thisScreenPoint.X - 5, thisScreenPoint.Y - 5 ,10, 10);
                    }
                    inG.DrawLines(inPen, thisImageLine.ScreenPoints.ToArray());
                    
                }
            };
        }

        private void colorPickerBtn_SelectedColorChanged(object sender, EventArgs e)
        {
            _currColor = colorPickerBtn.SelectedColor;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_currBitmap == null)
            {
                MessageBox.Show(@"请先获取地质图像！", @"操作流程错误");
                return;
            }
            _pen = new Pen(_currColor, 2);
            _brush = new SolidBrush(_currColor);
            pictureBox.MouseDown += PictureBoxOnMouseDown;
        }

        private void PictureBoxOnMouseDown(object sender, MouseEventArgs e)
        {
            _currScreenLinePoints.Add(new System.Drawing.Point(e.X, e.Y));
            
            //画点
            g.DrawEllipse(_pen, e.X, e.Y, 5, 5);
            g.FillEllipse(_brush, e.X - 5, e.Y - 5, 10, 10);
            //连线
            if (_currScreenLinePoints.Count > 1)
            {
                g.DrawLine(_pen, _currScreenLinePoints[_currScreenLinePoints.Count - 2], _currScreenLinePoints[_currScreenLinePoints.Count - 1]);
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            _currScreenLinePoints.Clear();
            pictureBox.Refresh();
        }



        private void btnDrawApply_Click(object sender, EventArgs e)
        {
            if (_currScreenLinePoints.Count == 0) return;
            var frmImageLineType = new FrmImageLineType();
            if (frmImageLineType.ShowDialog() != DialogResult.OK) return;

            var cImageLine = new ImageLine(_currScreenLinePoints)
            {
                Color = _currColor,
                GeoType = frmImageLineType.GeoType,
                StretchType = frmImageLineType.StretchType,
            };

            

            //此处应该根据地质对象类型弹出编录卡片，让用户填写编录信息，保存，并获得编录对象的Guid
            //并创建线的Ts文件和面的Ts部件

            _lineList.Add(cImageLine);
            _currScreenLinePoints.Clear();
            pictureBox.Refresh();
            pictureBox.MouseDown -= PictureBoxOnMouseDown;
        }

        private void FrmImage_Load(object sender, EventArgs e)
        {

        }
    }
}
