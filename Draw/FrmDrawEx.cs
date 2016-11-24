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
        Bitmap bmp = null;
        Graphics g_bmp = null;
        Color DrawBackColor = Color.Black;
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
            Line l1 = new Line(15.0F,20.0F,15.0F,100.0F);
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
                bmp = new Bitmap(Width,Height);
                g_bmp = Graphics.FromImage(bmp);
                g_bmp.Clear(DrawBackColor);

                if (doc != null) doc.Draw(g_bmp);
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
            if(drawCmd != DrawCmd.None)
            {
                return;
            }
            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnClose.Visibility =   DevExpress.XtraBars.BarItemVisibility.Never;
            btnBkColor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomIn.Visibility =  DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnOK.Visibility =     DevExpress.XtraBars.BarItemVisibility.Always;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            drawCmd = DrawCmd.DrawLine;
            Cursor = Cursors.Cross;
        }

        private void FrmDrawEx_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExitDrawLine();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExitDrawLine();
        }

        private void ExitDrawLine()
        {
            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnBkColor.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            drawCmd = DrawCmd.None;
            Cursor = Cursors.Arrow;
        }
    }
}
