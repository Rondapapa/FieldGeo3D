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

            this.g = this.pictureBox.CreateGraphics();
            this.pictureBox.Paint += (o, args) =>
            {
                this.RedrawImageLines();
            };

        }



        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (this._currBitmap == null)
            {
                MessageBox.Show(@"请先获取地质图像！", @"操作流程错误");
                return;
            }
            if (this.RectifyInfo == null || !this.RectifyInfo.IsValid)
            {
                MessageBox.Show(@"请先输入校正参数");
                return;
            }
            if (this._isRectifying)
            {
                MessageBox.Show(@"请先结束校正");
                return;
            }
            if (this.btnDraw.Checked)
            {
                // 如果绘制按钮处于“按下”状态
                this.pictureBox.MouseDown -= this.PictureBoxOnMouseDown_DrawLine;
                this.btnDraw.Checked = false;
            }
            else
            {
                this._pen = new Pen(this._currColor, 2);
                this._brush = new SolidBrush(this._currColor);
                this.pictureBox.MouseDown += this.PictureBoxOnMouseDown_DrawLine;
                this.btnDraw.Checked = true;
                this._currScreenLinePoints.Clear();
                this.pictureBox.Refresh();
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
            g.FillEllipse(_brush, e.X - 5, e.Y - 5, 10, 10);
            //连线
            if (_currScreenLinePoints.Count > 1)
            {
                g.DrawLine(_pen, _currScreenLinePoints[_currScreenLinePoints.Count - 2], _currScreenLinePoints[_currScreenLinePoints.Count - 1]);
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            this._currScreenLinePoints.Clear();
            this.pictureBox.Refresh();
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
                this._isRectifying = true;
            }
            else
            {
                //点击后结束校正状态
                pictureBox.MouseDown -= PictureBoxOnMouseDown_Rectify;
                btnRectify.Text = @"开始校正";
                this._isRectifying = false;
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



        private void buttonXColor_Click(object sender, EventArgs e)
        {
            FrmColorPickerInGeoImage frmColorPickerInGeoImage = new FrmColorPickerInGeoImage();
            var dlgResult = frmColorPickerInGeoImage.ShowDialog();
            if (dlgResult != DialogResult.OK) return;
            this._currColor = frmColorPickerInGeoImage.PickedColor;
            this.labelXColor.BackColor = _currColor;
        }

        
        private void buttonXClosetRing_Click(object sender, EventArgs e)
        {
            if (this._currScreenLinePoints.Count < 3)
            {
                MessageBox.Show(@"无标记线或当前标记线数目小于2，无法形成闭合线环。");
                return;
            }
            var firstP = this._currScreenLinePoints[0];
            var lastP = this._currScreenLinePoints[this._currScreenLinePoints.Count - 1];
            double dist = Math.Sqrt(Math.Pow(firstP.X - lastP.X, 2) + Math.Pow(firstP.Y - lastP.Y, 2));
            if (dist < 0.01)
            {
                MessageBox.Show(@"当前绘制点与起点距离太小，无法形成闭合线环。");
                return;
            }
            g.DrawLine(this._pen, this._currScreenLinePoints[this._currScreenLinePoints.Count - 1], this._currScreenLinePoints[0]);
            this._currScreenLinePoints.Add(new Point(firstP.X, firstP.Y));
            this.pictureBox.MouseDown -= this.PictureBoxOnMouseDown_DrawLine;
            this.btnDraw.Checked = false;
        }


        private void FrmImageResize(object sender, EventArgs e)
        {
            this.pictureBox.Refresh();

        }

        /// <summary>
        /// 显示所有标记线
        /// </summary>
        private void RedrawImageLines()
        {
            if (this.g == null)
            {
                MessageBox.Show(@"no g"); // test
                return;
            }
            var inG = this.g;
            var color = this._currColor.IsEmpty ? Color.Black : this._currColor;
            var inPen = new Pen(color, 2);
            var inSolidBrush = new SolidBrush(color);
            foreach (var thisImageLine in _lineList)
            {
                inPen.Color = thisImageLine.Color;
                inSolidBrush.Color = thisImageLine.Color;
                foreach (var thisScreenPoint in thisImageLine.ScreenPoints)
                {

                    inG.FillEllipse(inSolidBrush, thisScreenPoint.X - 5, thisScreenPoint.Y - 5, 10, 10);
                }

                inG.DrawLines(inPen, thisImageLine.ScreenPoints.ToArray());
            }
        }
    }
}
