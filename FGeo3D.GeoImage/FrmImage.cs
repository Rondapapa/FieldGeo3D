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
using MathNet.Spatial.Euclidean;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D.GeoImage
{
    using FGeo3D_TE.Frm;

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
        private Bitmap _currBitmap;

        //当前颜色
        private Color _currColor = Color.Black;

        //当前绘制的点集（线）
        private List<System.Drawing.Point> _currScreenLinePoints = new List<System.Drawing.Point>();

        //所有已绘制的线列表
        private List<ImageLine> _lineList = new List<ImageLine>();

        //校正信息，包含数据与模型。当RectifyDatas不为空时，说明校正信息有效
        internal RectifyInfo RectifyInfo;

        private bool _isRectifying = false;

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
                        //inG.DrawEllipse(inPen, thisScreenPoint.X, thisScreenPoint.Y, 5, 5);
                        inG.FillEllipse(inSolidBrush, thisScreenPoint.X - 5, thisScreenPoint.Y - 5 ,10, 10);
                    }
                    inG.DrawLines(inPen, thisImageLine.ScreenPoints.ToArray());
                    
                }
            };
        }



        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_currBitmap == null)
            {
                MessageBox.Show(@"请先获取地质图像！", @"操作流程错误");
                return;
            }
            if (btnDraw.Checked)
            {
                pictureBox.MouseDown -= PictureBoxOnMouseDown_DrawLine;
                btnDraw.Checked = false;
            }
            else
            {
                _pen = new Pen(_currColor, 2);
                _brush = new SolidBrush(_currColor);
                pictureBox.MouseDown += PictureBoxOnMouseDown_DrawLine;
                btnDraw.Checked = true;
            }
            
        }

        private void PictureBoxOnMouseDown_DrawLine(object sender, MouseEventArgs e)
        {
            if (RectifyInfo == null)
            {
                MessageBox.Show(@"请先输入校正参数");
                return;
            }
            _currScreenLinePoints.Add(new System.Drawing.Point(e.X, e.Y));
            
            //画点
            //g.DrawEllipse(_pen, e.X, e.Y, 5, 5);
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
            if (RectifyInfo == null)
            {
                MessageBox.Show(@"尚未校正");
                return;
            }
            if (_currScreenLinePoints.Count == 0) return;
            var frmImageLineType = new FrmImageLineType();
            if (frmImageLineType.ShowDialog() != DialogResult.OK) return;
            pictureBox.MouseDown -= PictureBoxOnMouseDown_DrawLine;
            btnDraw.Checked = false;

            //创建ImageLine对象，内部存储线部件和对应的面部件
            var cImageLine = new ImageLine(_currScreenLinePoints)
            {
                Color = _currColor,
                MarkerType = frmImageLineType.MarkerType,
                StretchDepth = frmImageLineType.StretchDepth,
            };

            cImageLine.ScreenPoints2Dto3D();
            cImageLine.Rectify(RectifyInfo.RectifyModelWdX, RectifyInfo.RectifyModelWdY, RectifyInfo.RectifyModelWdZ, RectifyInfo.RectifyModelWdReal);
            
            //将ImageLine存入数据库
            if (cImageLine.Store(ref db))
            {
                MessageBox.Show(@"保存成功！", @"二维图像存储");
                _lineList.Add(cImageLine);
            }
            else
            {
                MessageBox.Show(@"保存失败！", @"二维图像存储");
            }    
            _currScreenLinePoints.Clear();
            pictureBox.Refresh();
        }

        private void FrmImage_Load(object sender, EventArgs e)
        {

        }

        private void btnRectify_Click(object sender, EventArgs e)
        {
            //判断是否载入图片
            if (_currBitmap == null)
            {
                MessageBox.Show(@"请先载入图像。", @"操作失败");
                return;
            }
            
            
            
            //屏幕上画点，获取该点的屏幕坐标
            if (_isRectifying == false)
            {
                if (RectifyInfo != null)
                {
                    var dlgResult = MessageBox.Show(@"已存在校正数据，是否将其覆盖？", @"校正提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No) return;
                }
                //点击后进入校正状态
                RectifyInfo = new RectifyInfo();
                pictureBox.MouseDown += PictureBoxOnMouseDown_Rectify;
                btnRectify.Text = @"结束校正";
                _isRectifying = true;
            }
            else
            {
                //点击后结束校正状态
                pictureBox.MouseDown -= PictureBoxOnMouseDown_Rectify;
                btnRectify.Text = @"开始校正";
                _isRectifying = false;
                RectifyInfo.CalculateRectification();

                
                pictureBox.Refresh();
            }
            


            
        }

        private void PictureBoxOnMouseDown_Rectify(object sender, MouseEventArgs e)
        {
           

            var frmRectify = new FrmRectification(RectifyInfo.RectifyDatas.Count, e.X, e.Y);
            var frmDlgResult = frmRectify.ShowDialog();
            if (frmDlgResult == DialogResult.OK)
            {
                //记录校正点对
                RectifyInfo.RectifyDatas.Add(frmRectify.ScPoint, frmRectify.WdPoint);

                //画图
                Pen pen = new Pen(Color.Red);
                Brush brush = new SolidBrush(Color.Red);
                Font font = new Font(FontFamily.GenericMonospace, 15);

                g.DrawEllipse(pen, e.X - 9, e.Y - 9, 18, 18);
                g.FillEllipse(brush, e.X - 4, e.Y - 4, 8, 8);
                g.DrawString((RectifyInfo.RectifyDatas.Count).ToString(), font, brush, e.X, e.Y);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void buttonXColor_Click(object sender, EventArgs e)
        {
            FrmColorPickerInGeoImage frmColorPickerInGeoImage = new FrmColorPickerInGeoImage();
            var dlgResult = frmColorPickerInGeoImage.ShowDialog();
            if (dlgResult != DialogResult.OK) return;
            this._currColor = frmColorPickerInGeoImage.PickedColor;
            this.labelXColor.BackColor = _currColor;
        }
    }
}
