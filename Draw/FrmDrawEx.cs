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

namespace Draw
{
    public partial class FrmDrawEx : XtraForm
    {
        public enum DrawCmd
        {
            None,
            DrawLine
        }

        // 线
        public class Lines
        {
            public List<Point> linePoints;
            public Lines()
            {
                linePoints = new List<Point>();
            }
        }

        // 存入画的所有的线
        private List<Lines> lines = new List<Lines>();


        Bitmap bmp = null;
        Graphics g_bmp = null;
        Color DrawBackColor = Color.Wheat;
        Document doc = null;
        DrawCmd drawCmd = DrawCmd.None;

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
            Line l1 = new Line(15.0F, 20.0F, 15.0F, 100.0F);
            doc.AddShape(l1);
#endif

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Close();
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

                this.doc?.Draw(this.g_bmp);
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
            if (drawCmd != DrawCmd.None)
            {
                return;
            }
            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnBkColor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            drawCmd = DrawCmd.DrawLine;
            Cursor = Cursors.Cross;
            lines.Add(new Lines());


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
            if (lines.Count > 0)
                lines.RemoveAt(lines.Count - 1);
            ReDraw();
            ExitDrawLine();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lines.Count > 0 && lines.Last().linePoints.Count < 2)
                lines.RemoveAt(lines.Count - 1);
            ExitDrawLine();
        }

        private void ExitDrawLine()
        {
            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnBkColor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            drawCmd = DrawCmd.None;
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// 重绘画板上的线
        /// </summary>
        private void ReDraw()
        {
            g_bmp.Clear(DrawBackColor);
            Invalidate();
            if (lines.Count > 0)
            {
                foreach (var item in lines)
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
            if (drawCmd == DrawCmd.DrawLine)
            {

                lines[lines.Count - 1].linePoints.Add(new Point(e.X, e.Y));
                g_bmp.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)e.X - 5, (float)e.Y - 5, 10, 10);
                if (lines[lines.Count - 1].linePoints.Count > 1)
                {
                    for (int i = 1; i < lines[lines.Count - 1].linePoints.Count; i++)
                    {
                        g_bmp.DrawLine(new Pen(Color.MediumSlateBlue, (float)2.5),
                            lines[lines.Count - 1].linePoints[i - 1].X, lines[lines.Count - 1].linePoints[i - 1].Y,
                            lines[lines.Count - 1].linePoints[i].X, lines[lines.Count - 1].linePoints[i].Y);
                    }

                }
                Refresh();
            }
        }
        /// <summary>
        /// 撤消键，用于在画图过程中对线修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drawCmd == DrawCmd.DrawLine && lines.Count > 0 && lines.Last().linePoints.Count > 0)
            {
                lines.Last().linePoints.RemoveAt(lines.Last().linePoints.Count - 1);
                if (lines.Last().linePoints.Count == 0)
                {
                    btnCancel_ItemClick(sender, e);
                }
                ReDraw();
            }
        }
    }
}
