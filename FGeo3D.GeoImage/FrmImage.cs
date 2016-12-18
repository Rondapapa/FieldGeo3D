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
        private readonly List<System.Drawing.Point> _currScreenLinePoints = new List<System.Drawing.Point>();

        //所有已绘制的线列表
        private readonly List<ImageLine> _lineList = new List<ImageLine>();

        //所有校正点列表
        private List<System.Drawing.Point> _rectifyScreenPoints = new List<Point>();

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


        /// <summary>
        /// 显示所有标记线
        /// </summary>
        private void RedrawImageLines(Graphics inG)
        {
            
            var color = this._currColor.IsEmpty ? Color.Black : this._currColor;
            var inPen = new Pen(color, 2);
            var inSolidBrush = new SolidBrush(color);
            foreach (var thisImageLine in this._lineList)
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

        /// <summary>
        /// 绘制当前所操作的标记线
        /// </summary>
        /// <param name="inG">
        /// Graphics
        /// </param>
        private void RedrawCurrLine(Graphics inG)
        {
            var color = this._currColor.IsEmpty ? Color.Black : this._currColor;
            var inPen = new Pen(color, 2);
            var inSolidBrush = new SolidBrush(color);

            foreach (var thisScreenPoint in this._currScreenLinePoints)
            {
                inG.FillEllipse(inSolidBrush, thisScreenPoint.X - 5, thisScreenPoint.Y - 5, 10, 10);
            }
            if (this._currScreenLinePoints.Count > 1)
            {
                inG.DrawLines(inPen, this._currScreenLinePoints.ToArray());
            }


        }

        /// <summary>
        /// 重绘校正点
        /// </summary>
        /// <param name="inG"></param>
        private void RedrawRectifyPoint(Graphics inG)
        {
            //画图
            Pen pen = new Pen(Color.Red);
            Brush brush = new SolidBrush(Color.Red);
            Font font = new Font(FontFamily.GenericMonospace, 15);
            int count = 1;
            foreach (var rectScPoint in this._rectifyScreenPoints)
            {
                
                inG.DrawEllipse(pen, rectScPoint.X - 9, rectScPoint.Y - 9, 18, 18);
                inG.FillEllipse(brush, rectScPoint.X - 4, rectScPoint.Y - 4, 8, 8);
                inG.DrawString((count++).ToString(), font, brush, rectScPoint.X, rectScPoint.Y);
            }
        }

        /// <summary>
        /// 绘制像素网格，以表明已经校正过
        /// </summary>
        /// <param name="inG"></param>
        private void RedrawPixelGrid(Graphics inG, int width, int height, int w, int h)
        {
            var gridPen = new Pen(Color.FromArgb(100, 176, 196, 222)) { Width = (float)0.5 };

            Point p1 = new Point();
            Point p2 = new Point();

            p1.X = 0;
            p2.X = width;
            for (int y = 0; y <= height; y += h)
            {
                p1.Y = y;
                p2.Y = y;
                inG.DrawLine(gridPen, p1, p2);
            }

            p1.Y = 0;
            p2.Y = height;
            for (int x = 0; x <= width; x += w)
            {
                p1.X = x;
                p2.X = x;
                inG.DrawLine(gridPen, p1, p2);
            }
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            this.RedrawImageLines(e.Graphics);
            this.RedrawCurrLine(e.Graphics);
            this.RedrawRectifyPoint(e.Graphics);
            if (this._currBitmap != null && !this._isRectifying && this.RectifyInfo != null && this.RectifyInfo.IsValid)
            {
                int width = this.pictureBox.Width;
                int height = this.pictureBox.Height;
                int w = 10;
                int h = 10;
                this.RedrawPixelGrid(e.Graphics, width, height, w, h);
            }
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
            this.pictureBox.Paint += this.OnPaint;

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
            this._currScreenLinePoints.Add(new System.Drawing.Point(e.X, e.Y));
            this.pictureBox.Refresh();
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
                    var dlgResult = MessageBox.Show(
                        @"已存在校正数据，是否将其覆盖？",
                        @"校正提示",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No) return;
                }
                //点击后进入校正状态
                RectifyInfo = new RectifyInfo();
                pictureBox.MouseDown += PictureBoxOnMouseDown_Rectify;
                this.btnRectify.Text = @"校正中，点击此处结束校正";
                this._isRectifying = true;
            }
            else
            {
                //点击后结束校正状态
                
                
                bool isRectified = this.RectifyInfo.CalculateRectification();
                if (isRectified)
                {
                    // 校正成功
                    this._isRectifying = false;
                    this.pictureBox.MouseDown -= PictureBoxOnMouseDown_Rectify;
                    this.btnRectify.Text = @"开始校正";
                    this._rectifyScreenPoints.Clear();
                }
                else
                {
                    // 校正失败（不足三个点）

                }

                this.pictureBox.Refresh();
            }
            


            
        }

        private void PictureBoxOnMouseDown_Rectify(object sender, MouseEventArgs e)
        {
           

            var frmRectify = new FrmRectification(this.RectifyInfo.RectifyDatas.Count, e.X, e.Y);
            var frmDlgResult = frmRectify.ShowDialog();
            if (frmDlgResult == DialogResult.OK)
            {
                // 记录校正点对
                this.RectifyInfo.RectifyDatas.Add(frmRectify.ScPoint, frmRectify.WdPoint);
                this._rectifyScreenPoints.Add(frmRectify.ScPoint);
                this.pictureBox.Refresh();
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

            // g.DrawLine(this._pen, this._currScreenLinePoints[this._currScreenLinePoints.Count - 1], this._currScreenLinePoints[0]);
            this._currScreenLinePoints.Add(new Point(firstP.X, firstP.Y));
            pictureBox.Refresh();
            this.pictureBox.MouseDown -= this.PictureBoxOnMouseDown_DrawLine;
            this.btnDraw.Checked = false;
        }


        private void FrmImageResize(object sender, EventArgs e)
        {
            this.pictureBox.Refresh();

        }

    }
}
