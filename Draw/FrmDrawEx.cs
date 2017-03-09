using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using Draw.Drawing;
using GeoIM.CHIDI.DZ.BLL.Geometry;

namespace Draw
{
    public partial class FrmDrawEx : XtraForm
    {
        public enum DrawCmd
        {
            None,
            DrawLine
        }

        // 像素坐标对应的 线
        public class ScreenLine
        {
            public List<Point> linePoints = new List<Point>();
        }
        private List<ScreenLine> screenLines = new List<ScreenLine>(); // 存放画板上的线

        private List<Line> localLines = new List<Line>();         //存放 转化成的局部坐标对应的线


        Bitmap bmp = null;
        Graphics g_bmp = null;
        private Color DrawBackColor = Color.Wheat;



        Document doc = null;
        DrawCmd drawCmd = DrawCmd.None;
        private bool zooming = false;             // 判断是否在进行缩放
        private bool dragPictrue = false;         // 判断是否在拖拽
        private Point startMove;                  // 记录拖拽起始时鼠标的位置
        private double widthHeightRatio = 6;     //  宽高比，就从控制点推出的包络矩形中求出，在 document 中，测试暂设 6
        private float widthScreen;               // 画板的宽度 ，边缘宽度约为 17，需减掉                                               
        private float heightScreen;              // 画板高度，边缘高度 59 需减掉

        public FrmDrawEx()
        {
            InitializeComponent();
        }

        public FrmDrawEx(drawParameter para)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint, true);
            Text = para.SJLYLXMC;
            doc = new Document(para);

#if DEBUG
            //Line l1 = new Line(15.0F, 20.0F, 15.0F, 100.0F);
            //doc.AddShape(l1);
#endif

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rst = MessageBox.Show("是否保存测绘?", "提示", MessageBoxButtons.YesNoCancel);
            // 选择是，则保存
            if (rst == DialogResult.Yes)
            {
                for (int i = 0; i < screenLines.Count; i++)
                {
                    // 由于还有传入 para ，这段先注释掉
                    //localLines.Add(new Line()); 
                    //for (int j = 0; j < screenLines[i].linePoints.Count; j++)
                    //{
                    //    localLines[i].linePoints.Add(Trans_XSToJB(screenLines[i].linePoints[j]));   // 将屏幕坐标转换成局部坐标，存入列表
                       
                    //}
                    //doc.AddLine(localLines[i]);       //   在doc 中添加线
                }
                Close();
            }
            else if (rst == DialogResult.No)
            {
                Close();
            }
            else if (rst == DialogResult.Cancel)
            {

            }


        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        private void DrawImg()
        {
            if (g_bmp == null)
            {
                bmp = new Bitmap(Width, Height);
                g_bmp = Graphics.FromImage(bmp);
                g_bmp.Clear(DrawBackColor);


        //        this.doc?.Draw(this.g_bmp);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (g == null) return;
            DrawImg();

            if (g_bmp != null)
            {
                g.DrawImage((Image)bmp, 0, 0);

            }
        }

        private void FrmDrawEx_Resize(object sender, EventArgs e)
        {
            g_bmp = null;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (drawCmd == DrawCmd.DrawLine)
            {
                int x = e.X;
                int y = e.Y;
            }
        }

        private void btnBkColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            colorDialog.ShowDialog();
            Color newBkColor = colorDialog.Color;
            if (newBkColor != DrawBackColor)
            {
                DrawBackColor = newBkColor;
                g_bmp = null;
                Invalidate();
            }
        }

        private void btnAddLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReDraw();
            btnPanorama_ItemClick(sender, e);

            if (drawCmd != DrawCmd.None)
            {
                return;
            }
            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnBkColor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPanorama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            drawCmd = DrawCmd.DrawLine;
            Cursor = Cursors.Cross;
            screenLines.Add(new ScreenLine());
            statusStrip1.Visible = true;


        }

        private void FrmDrawEx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.drawCmd != null && this.doc != null)
            {
                if (drawCmd == DrawCmd.DrawLine)
                {
                    MessageBox.Show("现在还不能关闭");
                    e.Cancel = true;
                    return;
                }
                if (doc.IsChanged)
                {
                    MessageBox.Show("有未保存的修改，是否保存");
                }
            }

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (screenLines.Count > 0)
                screenLines.RemoveAt(screenLines.Count - 1);
            ReDraw();
            ExitDrawLine();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (screenLines.Count > 0 && screenLines.Last().linePoints.Count < 2)
                screenLines.RemoveAt(screenLines.Count - 1);
            ExitDrawLine();

        }

        private void ExitDrawLine()
        {
            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnBkColor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPanorama.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            statusStrip1.Visible = false;

            valueX.Text = "";
            valueY.Text = "";
            drawCmd = DrawCmd.None;
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// 重绘画板上的线
        /// </summary>
        private void ReDraw()
        {
            g_bmp.Clear(DrawBackColor);

            // 绘制包络矩形
            widthScreen = Width - 17;        // 画板的宽度 ，边缘宽度约为 17，需减掉                                               
            heightScreen = Height - toolbar.Size.Height - statusStrip1.Height - 59;    // 画板高度，边缘高度 59 需减掉
            if (widthHeightRatio >= widthScreen / heightScreen)
            {
                float recWidth = widthScreen;
                float recHeight = (float)(widthScreen / widthHeightRatio);
                g_bmp.DrawRectangle(new Pen(Color.Black, 3), 0, toolbar.Size.Height + heightScreen / 2 - recHeight / 2, recWidth, recHeight);
            }
            else if (widthHeightRatio < widthScreen / heightScreen)
            {
                float recWidth = (float)(heightScreen * widthHeightRatio);
                float recHeight = heightScreen;
                g_bmp.DrawRectangle(new Pen(Color.Black, 3), widthScreen / 2 - recWidth / 2, toolbar.Size.Height + 2, recWidth, recHeight);
            }

            Invalidate();

            // 画线
            if (screenLines.Count > 0)
            {
                foreach (var item in screenLines)
                {
                    g_bmp.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)item.linePoints[0].X - 5, (float)item.linePoints[0].Y - 5, 10, 10);
                    for (int i = 1; i < item.linePoints.Count; i++)
                    {
                        g_bmp.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)item.linePoints[i].X - 5, (float)item.linePoints[i].Y - 5, 10, 10);
                        g_bmp.DrawLine(new Pen(Color.MediumSlateBlue, (float)2.5),
                            item.linePoints[i - 1].X, item.linePoints[i - 1].Y,
                            item.linePoints[i].X, item.linePoints[i].Y);
                    }
                }
            }
        }

        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDrawEx_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawCmd == DrawCmd.DrawLine && !zooming)
            {
                screenLines[screenLines.Count - 1].linePoints.Add(new Point(e.X, e.Y));
                ReDraw();
            }
            if (zooming)
            {
                dragPictrue = true;
                startMove = Cursor.Position;
            }
        }
        /// <summary>
        /// 撤消键，用于在画图过程中对线修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drawCmd == DrawCmd.DrawLine && screenLines.Count > 0 && screenLines.Last().linePoints.Count > 0)
            {
                screenLines.Last().linePoints.RemoveAt(screenLines.Last().linePoints.Count - 1);     // 每次撤消该拆线的最后一个点
                if (screenLines.Last().linePoints.Count == 0)
                {
                    btnCancel_ItemClick(sender, e);
                }
                ReDraw();

            }
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drawCmd == DrawCmd.None)
            {
                g_bmp.ScaleTransform((float)1.25, (float)1.25); // 放大 1.25 倍
                zooming = true;
                ReDraw();
            }
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drawCmd == DrawCmd.None)
            {
                g_bmp.ScaleTransform((float)0.8, (float)0.8); // 缩小为原来的 1/1.25=0.8
                zooming = true;
                ReDraw();
            }
        }

        // 用于移动画面
        private void FrmDrawEx_MouseUp(object sender, MouseEventArgs e)
        {
            if (zooming)
            {

                startMove = new Point();
                ReDraw();
                dragPictrue = false;
            }

        }

        /// <summary>
        /// 用于放大缩小操作后，恢复图形原貌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanorama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (zooming)
            {
                g_bmp.ResetTransform();
                zooming = false;
                ReDraw();

            }
        }

        private void FrmDrawEx_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// 放大或缩小过程中，用鼠标拖动图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDrawEx_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragPictrue)
            {
                float px = Cursor.Position.X - startMove.X;
                float py = Cursor.Position.Y - startMove.Y;
                g_bmp.TranslateTransform(px, py);
                startMove = Cursor.Position;
                ReDraw();
            }
            if (!dragPictrue && drawCmd == DrawCmd.DrawLine)
            {
                valueX.Text = e.X.ToString();
                valueY.Text = e.Y.ToString();
            }
        }

        /// <summary>
        /// 像素坐标转成局部坐标
        /// </summary>
        /// <param name="p">像素坐标</param>
        /// <returns></returns>
        private sg_Vector3 Trans_XSToJB(Point p)
        {
            double jBx = p.X*doc.recWidth/widthScreen;
            double jBy = (p.Y - toolbar.Size.Height)*doc.recHeight/heightScreen;
            sg_Vector3 jB=new sg_Vector3(jBx,jBy,0);
            return jB;
        }

    }
}
