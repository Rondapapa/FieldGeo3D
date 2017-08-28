using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Keyboard;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Spatial.Euclidean;


namespace Stereonet
{

    public partial class FrmStereonet : Form
    {
        
        int numOfA = 0;
        int numOfB = 0;
        int totalRecord = 0;
        const float R = 130;
        LongtitudeCircle BaseCircle = new LongtitudeCircle("BaseCircle", 0, 0, R);
        string typeOfArc = null;
        DataGridViewRow tempPlane = null;
        string tempType = null;
        List<LongtitudeCircle> listOfCircle = new List<LongtitudeCircle>();// 存放圆，对应结构面
        List<Point> listOfPoint = new List<Point>(); //存放点，对应结构面交线
        List<DataFromMain> theDataFromMain = new List<DataFromMain>();

        public FrmStereonet()
        {
            InitializeComponent();
        }

        public FrmStereonet(List<DataFromMain> ld)
        {
            InitializeComponent();

            theDataFromMain = ld;
        }

        private void FrmStereonet_Load(object sender, EventArgs e)
        {
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Text = "";
            keyboardControl1.Invalidate();

            attitudeInfo.Rows.Add(9);
            attitudeInfo.ClearSelection();


            Graphics g = pictureBox1.CreateGraphics();
            if (theDataFromMain.Count > 0)
            {
                for (int i = 0; i < theDataFromMain.Count; i++)
                {
                    typeOfArc = btnFreeFace.Name;
                    textBoxTrend.Text = theDataFromMain[i].Dip.ToString();
                    textBoxDip.Text = theDataFromMain[i].Angle.ToString();
                    btnOK_Click(sender, e);
                }
            }
        }


        /// <summary>
        /// 重构虚拟键盘
        /// </summary>
        /// <returns></returns>
        private Keyboard CreateNumericKeyboard()
        {
            Keyboard keyboard = new Keyboard();

            LinearKeyboardLayout kl = new LinearKeyboardLayout();

            kl.AddKey("7");
            kl.AddKey("8");
            kl.AddKey("9");
            kl.AddKey("退格", "{BACKSPACE}");
            kl.AddLine();

            kl.AddKey("4");
            kl.AddKey("5");
            kl.AddKey("6");
            //   kl.AddKey("-", "{SUBTRACT}");
            kl.AddKey("Tab", "{Enter}", height: 32);
            kl.AddLine();

            kl.AddKey("1");
            kl.AddKey("2");
            kl.AddKey("3");

            kl.AddLine();

            kl.AddKey("0", width: 21);
            kl.AddKey(".");

            keyboard.Layouts.Add(kl);
            return keyboard;
        }

        /// <summary>
        /// 刷新表格及输入面板
        /// 
        /// </summary>
        public void FreshMethod()
        {
            attitudeInfo.ClearSelection();
            typeOfArc = null;
            highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            textBoxDip.Text = "";
            textBoxTrend.Text = "";
            tempPlane = null; tempType = null;
        }

        /// <summary>
        /// 排序，每次添加新产状后用到
        /// </summary>
        public void SortMethod()
        {
            int numOfEmpty = 0;
            for (int p = attitudeInfo.Rows.Count - 2; p >= totalRecord; p--)
            {
                attitudeInfo.Rows.RemoveAt(p);
                numOfEmpty++;
            }
            attitudeInfo.Sort(attitudeInfo.Columns[0], ListSortDirection.Ascending);
            attitudeInfo.Rows.Add(numOfEmpty);
        }

        /// <summary>
        /// 点
        /// </summary>
        public class Point
        {
            public string Name { get; set; }    // 命名  
            public double X { get; set; }         // 横坐标
            public double Y { get; set; }         // 纵坐标
            public double alpha;             //  对应倾向
            public double beta;              //  对应倾角
            public LongtitudeCircle C1 { get; set; }    // 相交面1
            public LongtitudeCircle C2 { get; set; }   // 相交面2

            public Point() { }
            public Point(double x, double y)
            {
                X = x; Y = y;

                beta = 90 - 2 * Math.Atan(Math.Sqrt(X * X + Y * Y) / R) * 180 / Math.PI;

                if (Y >= 0 && X > 0)
                    alpha = 90 + Math.Atan(Y / X) * 180 / Math.PI;
                else if (Y >= 0 && X == 0)
                    alpha = 180;
                else if (Y >= 0 && X < 0)
                    alpha = 270 + Math.Atan(Y / X) * 180 / Math.PI;
                else if (Y < 0 && X < 0)
                    alpha = 270 + Math.Atan(Y / X) * 180 / Math.PI;
                else if (Y < 0 && X == 0)
                    alpha = 0;
                else if (Y < 0 && X > 0)
                    alpha = 90 + Math.Atan(Y / X) * 180 / Math.PI;
            }
            // 判断该点与组成该点的两个圆的中点的关系
            public Point RiskAttitude;

            public void FindRisk()
            {
                Vector2D p1 = new Vector2D(this.C1.Mid[0], this.C1.Mid[1]);
                Vector2D p2 = new Vector2D(this.C2.Mid[0], this.C2.Mid[1]);
                Vector2D p3 = new Vector2D(this.X, this.Y);
                p1 = p1.Normalize();
                p2 = p2.Normalize();
                p3 = p3.Normalize();
                if (p1.IsParallelTo(p3, 1E-4) || p2.IsParallelTo(p3, 1E-4))
                {
                    RiskAttitude = this;
                }
                else if (p1.Subtract(p3).AngleTo(p3.Subtract(p2)).Degrees < 90)
                {
                    RiskAttitude = this;
                }
                else if (p1.Subtract(p2).AngleTo(p2.Subtract(p3)).Degrees<90)
                {
                    RiskAttitude = new Point(this.C2.Mid[0], this.C2.Mid[1]);
                }
                else if (p2.Subtract(p1).AngleTo(p1.Subtract(p3)).Degrees<90)
                {
                    RiskAttitude = new Point(this.C1.Mid[0], this.C1.Mid[1]);
                }


            }

        }

        /// <summary>
        /// 主程序中的数据以这种类型导入该子程序
        /// </summary>
        public class DataFromMain
        {
            public double Dip { get; set; }           // 倾向
            public double Angle { set; get; }        // 倾角

            public DataFromMain(double dip, double angle)
            {
                Dip = dip;
                Angle = angle;
            }
        }


        /// <summary>
        /// 大圆
        /// </summary>
        public class LongtitudeCircle
        {
            public double X0 { get; set; }
            public double Y0 { get; set; }
            public double R { get; set; }
            public double Trend { set; get; }
            public double Dip { set; get; }
            public string Name { get; set; }
            public double[] Mid = new double[2];                     // 用于求大圆弧的中点
            public LongtitudeCircle(string name, double x, double y, double r)
            {
                Name = name;
                X0 = x;
                Y0 = y;
                R = r;
                if (x * x + y * y > 0)
                {
                    if (PointWithCircle(new Point(x + r*x*Math.Sqrt(1 / (x * x + y * y)), y + y*r*Math.Sqrt(1/ (x * x + y * y))),
                            new LongtitudeCircle("", 0, 0, 130)) == "inCircle")
                    {
                        Mid[0] = x + r*x*Math.Sqrt(1/ (x * x + y * y)); Mid[1] = y + y*r*Math.Sqrt(1 / (x * x + y * y));
                    }
                    else if (PointWithCircle(new Point(x - r * x *Math.Sqrt(1 / (x * x + y * y)), y - y*r * Math.Sqrt(1/ (x * x + y * y))),
                                 new LongtitudeCircle("", 0, 0, 130)) == "inCircle")
                    {
                        Mid[0] = x - r * x *Math.Sqrt(1 / (x * x + y * y)); Mid[1] = y -r * y* Math.Sqrt(1 / (x * x + y * y));
                    }

                }
            }
            public LongtitudeCircle() { }

            public LongtitudeCircle(double a, double b) { }
        }

        /// <summary>
        /// 三点定圆
        /// </summary>
        /// <param name="x0"></param>圆心横坐标
        /// <param name="y0"></param>圆心纵坐标
        /// <param name="r"></param>经向大圆半径
        /// <param name="p1"></param>第一个点
        /// <param name="p2"></param>第二个点
        /// <param name="p3"></param>第三个点
        void CenterAndR(out double x0, out double y0, out double r, Point p1, Point p2, Point p3)
        {
            var m1 = DenseMatrix.OfArray(new double[,] { { 2 * (p2.X - p1.X), 2 * (p2.Y - p1.Y) }, { 2 * (p3.X - p1.X), 2 * (p3.Y - p1.Y) } });
            var m2 = DenseVector.OfArray(new double[] { p1.X * p1.X + p1.Y * p1.Y - p2.X * p2.X - p2.Y * p2.Y, p1.X * p1.X + p1.Y * p1.Y - p3.X * p3.X - p3.Y * p3.Y });
            var center = new DenseVector(2);
            var m3 = -m1.Inverse();
            m3.Multiply(m2, center);
            double radius = Math.Sqrt((p1.X - center[0]) * (p1.X - center[0]) + (p1.Y - center[1]) * (p1.Y - center[1]));
            x0 = center[0]; y0 = center[1]; r = radius;
        }

        /// <summary>
        /// 判断是否有交点
        /// 
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        bool HaveIntersection(LongtitudeCircle c1, LongtitudeCircle c2)
        {
            double x1 = c1.X0, y1 = c1.Y0, r1 = c1.R;
            double x2 = c2.X0, y2 = c2.Y0, r2 = c2.R;

            double k1 = 2 * (y1 - y2), k2 = 2 * (x1 - x2), M = x1 * x1 - x2 * x2 - (y1 - y2) * (y1 - y2) - r1 * r1 + r2 * r2;
            double a = k1 * k1 + k2 * k2, b = -2 * (x1 * k1 * k1 + k2 * M), c = k1 * k1 * x1 * x1 + M * M - r1 * r1 * k1 * k1;
            if (b * b - 4 * a * c <= 1E-10)
                return false;
            return true;
        }

        /// <summary>
        /// 求交点
        /// 
        /// </summary>
        /// <param name="c1">第一个圆</param>
        /// <param name="c2">第二个圆</param>
        /// <returns></returns>
        Point FindIntersection(LongtitudeCircle c1, LongtitudeCircle c2)
        {
            Point p1, p2;
            double x1 = c1.X0, y1 = c1.Y0, r1 = c1.R;
            double x2 = c2.X0, y2 = c2.Y0, r2 = c2.R;


            double k1 = 2 * (y1 - y2), k2 = 2 * (x1 - x2), M = x1 * x1 - x2 * x2 - (y1 - y2) * (y1 - y2) - r1 * r1 + r2 * r2;
            double a = k1 * k1 + k2 * k2, b = -2 * (x1 * k1 * k1 + k2 * M), c = k1 * k1 * x1 * x1 + M * M - r1 * r1 * k1 * k1;

            p1 = new Point((-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a), 0);
            p2 = new Point((-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a), 0);

            // 1、 y1 不可能等于 y2, x1 也不可等于x2
            // 2、 只可能有一个交点
            p1.Y = -(r1 * r1 - r2 * r2 - x1 * x1 + x2 * x2 - y1 * y1 + y2 * y2 + 2 * p1.X * (x1 - x2)) / 2 / (y1 - y2);
            p2.Y = -(r1 * r1 - r2 * r2 - x1 * x1 + x2 * x2 - y1 * y1 + y2 * y2 + 2 * p2.X * (x1 - x2)) / 2 / (y1 - y2);
            p1 = new Point(p1.X, p1.Y);
            p2 = new Point(p2.X, p2.Y);
            if (PointWithCircle(p1, BaseCircle) == "inCircle")
                return p1;
            if (PointWithCircle(p2, BaseCircle) == "inCircle")
                return p2;
            return null;
        }


        /// <summary>
        /// 判断点与圆的关系
        /// </summary>
        /// <param name="p">点</param>
        /// <param name="lc">经向大圆</param>
        /// <returns></returns>
        static string PointWithCircle(Point p, LongtitudeCircle lc)
        {
            string str = "";
            if ((p.X - lc.X0) * (p.X - lc.X0) + (p.Y - lc.Y0) * (p.Y - lc.Y0) - lc.R * lc.R < -1E-8)
                str = "inCircle";
            else if ((p.X - lc.X0) * (p.X - lc.X0) + (p.Y - lc.Y0) * (p.Y - lc.Y0) - lc.R * lc.R > 1E-8)
                str = "outCircle";
            else
                str = "onCircle";
            return str;
        }



        /// <summary>
        /// 画 面 
        /// </summary>
        void DrawPlanes(out LongtitudeCircle newCircle, Graphics g, DataGridViewRow row, Pen p)
        {
            string name = row.Cells[0].Value.ToString();
            double trend = double.Parse(row.Cells[1].Value.ToString());
            trend = trend * Math.PI / 180;
            double dip = double.Parse(row.Cells[2].Value.ToString());
            dip = dip * Math.PI / 180;
            Point newp1 = new Point(-R * Math.Cos(trend), -R * Math.Sin(trend));
            Point newp2 = new Point(R * Math.Cos(trend), R * Math.Sin(trend));
            double d = R * Math.Tan(Math.PI / 4 - dip / 2);

            Point newp3 = new Point(d * Math.Sin(trend), -d * Math.Cos(trend));

            double x0, y0, r;

            // 三点定圆
            CenterAndR(out x0, out y0, out r, newp1, newp2, newp3);

            // 存入经向大圆临时列表
            newCircle = new LongtitudeCircle(name, x0, y0, r);
            newCircle.Trend = trend * 180 / Math.PI;
            newCircle.Dip = dip * 180 / Math.PI;

            double theta = Math.Asin(R / r); theta = theta * 180 / Math.PI;  // 大圆对应的圆心角的一半
            double gama = Math.Atan(Math.Sqrt(y0 * y0 / x0 / x0)); gama = gama * 180 / Math.PI;

            // 画大圆弧
            if (trend <= Math.PI / 2)
                g.DrawArc(p, (float)(148 + x0 - r), (float)(150 + y0 - r), (float)(2 * r), (float)(2 * r), (float)(-theta - gama), (float)(2 * theta));
            else if (trend > Math.PI / 2 && trend <= Math.PI)
                g.DrawArc(p, (float)(148 + x0 - r), (float)(150 + y0 - r), (float)(2 * r), (float)(2 * r), (float)(gama - theta), (float)(2 * theta));
            else if (trend > Math.PI && trend <= Math.PI * 1.5)
                g.DrawArc(p, (float)(148 + x0 - r), (float)(150 + y0 - r), (float)(2 * r), (float)(2 * r), (float)((180 - gama) - theta), (float)(2 * theta));
            else
                g.DrawArc(p, (float)(148 + x0 - r), (float)(150 + y0 - r), (float)(2 * r), (float)(2 * r), (float)(gama + 180 - theta), (float)(2 * theta));

        }

        /// <summary>
        /// 重画所有面
        /// </summary>
        void ReDraw()
        {

            pictureBox1.Invalidate();
            pictureBox1.Update();
            Graphics g = pictureBox1.CreateGraphics();
            LongtitudeCircle tempCirle = new LongtitudeCircle();
            for (int i = 0; i < listOfCircle.Count; i++)
            {
                if (attitudeInfo.Rows[i].Cells[0].Value.ToString().Substring(0, 1) == "A")
                    DrawPlanes(out tempCirle, g, attitudeInfo.Rows[i], new Pen(Color.MidnightBlue, 1));
                else
                    DrawPlanes(out tempCirle, g, attitudeInfo.Rows[i], new Pen(Color.HotPink, 1));
            }
            if (listOfPoint.Count > 0)
            {
                int pointR = 3;
                for (int j = 0; j < listOfPoint.Count; j++)
                    g.FillEllipse(Brushes.Black, (float)(listOfPoint[j].X + 148 - pointR), (float)(listOfPoint[j].Y + 150 - pointR), (float)(pointR * 2), (float)(pointR * 2));
            }
            g.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);
        }

        /// <summary>
        /// 临空面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFreeFace_Click(object sender, EventArgs e)
        {
            btnFreeFace.FocusCuesEnabled = true;
            highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            typeOfArc = btnFreeFace.Name;
        }

        /// <summary>
        /// 倾向 文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTrend_MouseClick(object sender, MouseEventArgs e)
        {
            keyboardControl1.Visible = true;
        }

        /// <summary>
        /// 倾角 文本框
        /// 编写有错误，dip 意思也是倾向。倾角为 angle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDip_MouseClick(object sender, MouseEventArgs e)
        {
            keyboardControl1.Visible = true;
        }


        private void btnStructural_Click(object sender, EventArgs e)
        {
            highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            typeOfArc = btnStructural.Name;
        }

        /// <summary>
        /// 重置键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            textBoxDip.Text = "";
            textBoxTrend.Text = "";
        }

        /// <summary>
        /// 确定键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (textBoxTrend.Text != "" && (double.Parse(textBoxTrend.Text) > 360 || double.Parse(textBoxTrend.Text) < -360))
            { FreshMethod(); return; }
            if (textBoxDip.Text != "" && (double.Parse(textBoxDip.Text) >= 90 || double.Parse(textBoxDip.Text) < 0))
            { FreshMethod(); return; }

            // 某一个类型面的数目
            int planeNum = 0;

            // 有没有选中某一行
            if (tempPlane != null && textBoxDip.Text != "" && textBoxDip.Text != "")
            {
                // 在list中找到这一行
                for (int i = 0; i < listOfCircle.Count; i++)
                {
                    if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString() == listOfCircle[i].Name)
                        listOfCircle.RemoveAt(i);
                }
                int p = attitudeInfo.SelectedRows[0].Index;
                //选中的行有没有改结构面类型
                if (tempType == typeOfArc)
                {
                    attitudeInfo.Rows[p].Cells[1].Value = double.Parse(double.Parse(textBoxTrend.Text).ToString("#0.0"));
                    attitudeInfo.Rows[p].Cells[2].Value = double.Parse(double.Parse(textBoxDip.Text).ToString("#0.0"));
                }
                else if (tempType != typeOfArc)
                {
                    planeNum = (tempType == btnFreeFace.Name) ? ++numOfB : ++numOfA;
                    string aOrB = (tempType == btnFreeFace.Name) ? "B_" : "A_";

                    attitudeInfo.Rows[p].Cells[0].Value = String.Format(aOrB + planeNum.ToString());
                    attitudeInfo.Rows[p].Cells[1].Value = double.Parse(double.Parse(textBoxTrend.Text).ToString("#0.0"));
                    attitudeInfo.Rows[p].Cells[2].Value = double.Parse(double.Parse(textBoxDip.Text).ToString("#0.0"));
                }
                LongtitudeCircle newCircle;
                DrawPlanes(out newCircle, g, attitudeInfo.Rows[p], new Pen(Color.Red, 1));
                listOfCircle.Add(newCircle);

            }
            // 没有选中的行，就加新行
            else if (typeOfArc != null && textBoxDip.Text != "" && textBoxTrend.Text != "")
            {
                totalRecord++;
                planeNum = (typeOfArc == btnFreeFace.Name) ? ++numOfA : ++numOfB;
                string aOrB = (typeOfArc == btnFreeFace.Name) ? "A_" : "B_";
                attitudeInfo.Rows[totalRecord - 1].Cells[0].Value = String.Format(aOrB + planeNum.ToString());
                attitudeInfo.Rows[totalRecord - 1].Cells[1].Value = double.Parse(double.Parse(textBoxTrend.Text).ToString("#0.0"));
                attitudeInfo.Rows[totalRecord - 1].Cells[2].Value = double.Parse(double.Parse(textBoxDip.Text).ToString("#0.0"));

                // 有新面，立即画出来
                LongtitudeCircle newCircle;
                DrawPlanes(out newCircle, g, attitudeInfo.Rows[totalRecord - 1], new Pen(Color.Red));
                listOfCircle.Add(newCircle);
            }

            // 每次添加完就排序
            if (totalRecord > 1)
                SortMethod();
            if (attitudeInfo.Rows.Count - totalRecord == 1)
                attitudeInfo.Rows.Add(1);
            ReDraw();
            FreshMethod();

        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (totalRecord > 0)
            {
                if (attitudeInfo.SelectedRows.Count > 0)
                {
                    if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "A")
                    {
                        totalRecord--;
                        try
                        {
                            int a = attitudeInfo.SelectedRows[0].Index;                                          // 如果要删的行是该类的最后一行，则该类的数量减一
                            if (attitudeInfo.Rows[a + 1].IsNewRow || (attitudeInfo.Rows[a + 1].Cells[0].Value != null && attitudeInfo.Rows[a + 1].Cells[0].Value.ToString().Substring(0, 1) != "A"))
                                numOfA--;
                        }
                        finally { }

                    }
                    else if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "B")
                    {
                        totalRecord--;
                        try
                        {
                            int a = attitudeInfo.SelectedRows[0].Index;
                            if (attitudeInfo.Rows[a + 1].IsNewRow || (attitudeInfo.Rows[a + 1].Cells[0].Value != null && attitudeInfo.Rows[a + 1].Cells[0].Value.ToString().Substring(0, 1) != "B"))
                                numOfB--;
                        }
                        finally { }
                    }

                    // 在list 中删除
                    for (int i = 0; i < listOfCircle.Count; i++)
                    {
                        if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString() == listOfCircle[i].Name)
                            listOfCircle.RemoveAt(i);
                    }
                }
                if (attitudeInfo.SelectedRows.Count > 0)
                    attitudeInfo.Rows.Remove(attitudeInfo.SelectedRows[0]);
                if (attitudeInfo.Rows.Count < 11)
                    attitudeInfo.Rows.Add(11 - attitudeInfo.Rows.Count);

                FreshMethod();
            }
        }

        /// <summary>
        /// 选择产状信息，用于编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attitudeInfo_SelectionChanged(object sender, EventArgs e)
        {

            ReDraw();
            if (attitudeInfo.SelectedRows.Count > 0)
                if (attitudeInfo.SelectedRows[0].Cells[0].Value != null)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    LongtitudeCircle tempCircle = new LongtitudeCircle();

                    if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "A")
                    {
                        typeOfArc = btnFreeFace.Name;
                        highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
                        highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                        textBoxTrend.Text = attitudeInfo.SelectedRows[0].Cells[1].Value.ToString();
                        textBoxDip.Text = attitudeInfo.SelectedRows[0].Cells[2].Value.ToString();

                        DrawPlanes(out tempCircle, g, attitudeInfo.SelectedRows[0], new Pen(Color.Gold, 2));
                        g.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);
                    }
                    else if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "B")
                    {
                        typeOfArc = btnStructural.Name;
                        highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
                        highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                        textBoxTrend.Text = attitudeInfo.SelectedRows[0].Cells[1].Value.ToString();
                        textBoxDip.Text = attitudeInfo.SelectedRows[0].Cells[2].Value.ToString();

                        DrawPlanes(out tempCircle, g, attitudeInfo.SelectedRows[0], new Pen(Color.Gold, 2));
                        g.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);
                    }
                    else if (attitudeInfo.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "L")
                    {
                        // 选择点时，输入面板清空
                        typeOfArc = null;
                        highlighter1.SetHighlightColor(btnFreeFace, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                        highlighter1.SetHighlightColor(btnStructural, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                        textBoxDip.Text = "";
                        textBoxTrend.Text = "";
                        tempPlane = null; tempType = null;

                        int pointR = 4;
                        for (int i = 0; i < listOfPoint.Count; i++)
                        {
                            if (listOfPoint[i].Name == attitudeInfo.SelectedRows[0].Cells[0].Value.ToString())
                                g.FillEllipse(Brushes.OliveDrab, (float)(listOfPoint[i].X + 148 - pointR), (float)(listOfPoint[i].Y + 150 - pointR), (float)(pointR * 2), (float)(pointR * 2));
                        }
                    }
                    tempPlane = attitudeInfo.SelectedRows[0];
                    tempType = typeOfArc;
                }
                else
                    attitudeInfo.ClearSelection();
        }

        /// <summary>
        /// 刷新键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFresh_Click(object sender, EventArgs e)
        {
            FreshMethod();
        }

        /// <summary>
        /// 开始分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            // 分析前清理 临时列表

            for (int k = totalRecord; k < totalRecord + listOfPoint.Count; k++)
            {
                attitudeInfo.Rows[k].Cells[0].Value = null;
                attitudeInfo.Rows[k].Cells[1].Value = null;
                attitudeInfo.Rows[k].Cells[2].Value = null;
            }
            //把之前的计算点清除
            listOfPoint.Clear();

            // 计算交点
            if (listOfCircle.Count > 0)
                for (int i = 0; i < listOfCircle.Count - 1; i++)
                {
                    for (int j = i + 1; j < listOfCircle.Count; j++)
                    {
                        Point intersection = new Point();
                        if (HaveIntersection(listOfCircle[i], listOfCircle[j]))
                        {
                            intersection = FindIntersection(listOfCircle[i], listOfCircle[j]);
                        }

                        // 如果在圆内有交点，则存入交点临时列表，并画出
                        if (intersection != null && (intersection.X != 0 && intersection.Y != 0))
                        {
                            intersection.C1 = listOfCircle[i];
                            intersection.C2 = listOfCircle[j];
                            listOfPoint.Add(intersection);
                        }
                    }
                }
            // 画所有 的圆和交点
            ReDraw();
            // 在列表中显示生成的交点
            if (listOfPoint.Count > 0)
            {
                int tot = totalRecord;
                for (int k = 0; k < listOfPoint.Count; k++)
                {
                    attitudeInfo.Rows[tot].Cells[0].Value = String.Format("L_" + (k + 1).ToString());
                    attitudeInfo.Rows[tot].Cells[1].Value = float.Parse(listOfPoint[k].alpha.ToString("#0.0"));
                    attitudeInfo.Rows[tot].Cells[2].Value = float.Parse(listOfPoint[k].beta.ToString("#0.0"));
                    attitudeInfo.Rows.Add(1);
                    // 在列表中给点加名字
                    listOfPoint[k].Name = String.Format("L_" + (k + 1).ToString());
                    tot++;
                }
            }

            if (totalRecord > 0)
            {
                // 生成分析报告
                textBoxReport.Text = "";
                textBoxReport.Text += "（一）产状面：\r\n";
                for (int i = 0; i < totalRecord; i++)
                {
                    textBoxReport.Text += "  " + attitudeInfo.Rows[i].Cells[0].Value + "(NE " +
                                          attitudeInfo.Rows[i].Cells[1].Value + ", " +
                                          attitudeInfo.Rows[i].Cells[2].Value + ")\r\n";
                }

                textBoxReport.Text += "（二）交线情况：\r\n";
                foreach (Point p in listOfPoint)
                    textBoxReport.Text += "  " + p.Name.ToString() + ":(" + p.C1.Name + "," + p.C2.Name +
                        ")(NE " + p.alpha.ToString("#0.0") + ", " + p.beta.ToString("#0.0") + ")\r\n";
            }
            else
                textBoxReport.Text = "";

            // 判断边坡结构类型，按类型判断稳定性状态 

            string typeOfSlope = "";
            string stateOfStable = "";
            string riskLine = "";

            var listOfA = from item in listOfCircle                  // 提取A类面
                          where item.Name.ToString().Substring(0, 1) == "A"
                          select item;
            listOfA = listOfA.ToList();
            var listOfB = from item in listOfCircle                  // 提取B类面
                          where item.Name.ToString().Substring(0, 1) == "B"
                          select item;
            listOfB = listOfB.ToList();

            //  一、分析边坡类型：层状、块状
            if (listOfA.Count() == 1 && listOfCircle.Count == 2)
                typeOfSlope = "层状结构";                                        // 双滑面边坡
            else if (listOfCircle.Count > 2)            // 两组结构面与坡面走向斜交
                typeOfSlope = "块状结构";


            // 分析层状边坡，共6种情况
            if (typeOfSlope == "层状结构")
            {
                if (Math.Abs((listOfCircle[0].Trend - listOfCircle[1].Trend)) < 0.01)
                {

                    if (listOfA.ElementAt(0).Dip > listOfB.ElementAt(0).Dip)
                    {
                        stateOfStable = "外倾结构面倾角小于坡面倾角：不稳定，易滑动。";
                        riskLine = "  (NE " +
                                   double.Parse(double.Parse(listOfB.ElementAt(0).Trend.ToString()).ToString("#0.0")) +
                                   ", " +
                                   double.Parse(double.Parse(listOfB.ElementAt(0).Dip.ToString()).ToString("#0.0")) + ")";

                    }
                    else if (Math.Abs(listOfA.ElementAt(0).Dip - listOfB.ElementAt(0).Dip) < 0.01)
                    {
                        stateOfStable = "外倾结构面倾角等于坡面倾角，边坡处于基本稳定状态。";
                    }
                    else
                    {
                        stateOfStable = "外倾结构面倾角大于坡面倾角，边坡滑动可能性较小，但可能沿软弱结构面产生深层滑动。";
                    }
                }
                else if (Math.Abs(Math.Abs(listOfCircle[0].Trend - listOfCircle[1].Trend) - 180) < 0.01)
                {
                    stateOfStable = "结构面内倾，边坡处于稳定状态，滑动可能小";
                }
                else if (Math.Abs(listOfB.ElementAt(0).Trend - listOfA.ElementAt(0).Trend) > 40)
                {
                    stateOfStable = "斜交夹角大于40度，一般较稳定，坚硬岩层滑动可能性小。";
                }
                else
                {
                    stateOfStable = "斜交夹角小于等于40度，边坡不很稳定，可能产生局部滑动。";
                    riskLine = "  (NE " +
                                  double.Parse(double.Parse(listOfB.ElementAt(0).Trend.ToString()).ToString("#0.0")) +
                                  ", " +
                                  double.Parse(double.Parse(listOfB.ElementAt(0).Dip.ToString()).ToString("#0.0")) + ")";

                }
            }

            // 二、分析 三个面的 块状边坡，共9种情况
            else if (typeOfSlope == "块状结构" && listOfCircle.Count == 3 && listOfA.Count() == 1)
            {
                AnalysisOf3Planes(out stateOfStable, out riskLine, listOfA.ElementAt(0), listOfB.ElementAt(0), listOfB.ElementAt(1));
            }

            // 三、分析四个面的块状边坡，其中坡面有2个，共5种情况
            else if (typeOfSlope == "块状结构" && listOfCircle.Count == 4 && listOfA.Count() == 2)
            {
                AnalysisOf4Planes(out stateOfStable, out riskLine, listOfA.ElementAt(0), listOfA.ElementAt(1), listOfB.ElementAt(0),
                    listOfB.ElementAt(1));
            }

            // 四、分析四个及四个以上的面，共5种情况
            else if (typeOfSlope == "块状结构" && listOfA.Count() == 1 && listOfCircle.Count >= 4) //  1个坡面，3个或3个以上的结构面
            {
                var keyPoint = from item in listOfPoint        // 找风险点
                               where (item.C1.Name.ToString().Substring(0, 1) == "B" && item.C2.Name.ToString().Substring(0, 1) == "B" && PointWithCircle(item, listOfA.ElementAt(0)) == "outCircle")
                               select item;
                if (keyPoint.Count() == 0)
                {
                    stateOfStable = "所有结构面组合的交线的倾角都比坡面倾角大，边坡较稳定。";
                }
                else
                {
                    stateOfStable = "结构面组合的交线的倾角比坡面倾角小，边坡可能沿交线滑动。";
                    for (int i = 0; i < keyPoint.Count(); i++)
                    {
                        keyPoint.ElementAt(i).FindRisk();
                        riskLine += "  (NE " +
                               double.Parse(double.Parse(keyPoint.ElementAt(i).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                               ", " +
                               double.Parse(double.Parse(keyPoint.ElementAt(i).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")\r\n";
                    }
                }
            }
            else if (typeOfSlope == "块状结构" && listOfCircle.Count > 4 && listOfA.Count() == 2)
            {
                LongtitudeCircle maxSlope = listOfA.ElementAt(0).Dip > listOfA.ElementAt(1).Dip ? listOfA.ElementAt(0) : listOfA.ElementAt(1);   // 倾角大，对应的大圆也大
                LongtitudeCircle minSlope = listOfA.ElementAt(0).Dip < listOfA.ElementAt(1).Dip ? listOfA.ElementAt(0) : listOfA.ElementAt(1);

                var keyPoint1 = from item in listOfPoint        // 找风险点
                                where (item.C1.Name.ToString().Substring(0, 1) == "B" && item.C2.Name.ToString().Substring(0, 1) == "B" && PointWithCircle(item, minSlope) == "outCircle")
                                select item;
                var keyPoint2 = from item in listOfPoint
                                where (item.C1.Name.ToString().Substring(0, 1) == "B" && item.C2.Name.ToString().Substring(0, 1) == "B" &&
                                 PointWithCircle(item, maxSlope) == "outCircle")
                                select item;
                if (keyPoint1.Count() == 0 && keyPoint2.Count() == 0)
                {
                    stateOfStable = "所有结构面组合的交线的倾角都比坡面倾角大，边坡较稳定。";
                }
                else if (keyPoint2.Count() != 0 && keyPoint1.Count() == 0)
                {
                    stateOfStable = "结构面组合交线的倾角比其中一坡面的倾角小，比另一个的倾角大，边坡较不稳定，可能沿交线滑动。";
                    for (int i = 0; i < keyPoint2.Count(); i++)
                    {
                        keyPoint2.ElementAt(i).FindRisk();
                        riskLine += "  (NE " +
                              double.Parse(double.Parse(keyPoint2.ElementAt(i).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                              ", " +
                              double.Parse(double.Parse(keyPoint2.ElementAt(i).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")\r\n";
                    }
                }
                else
                {
                    stateOfStable = "结构面组合的交线的倾角比坡面倾角小，边坡可能沿交线滑动。";
                    for (int i = 0; i < keyPoint1.Count(); i++)
                    {
                        keyPoint1.ElementAt(i).FindRisk();
                        riskLine +=  "  (NE " +
                              double.Parse(double.Parse(keyPoint1.ElementAt(i).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                              ", " +
                              double.Parse(double.Parse(keyPoint1.ElementAt(i).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")\r\n";
                    }
                }

            }


            textBoxReport.Text += "（三）边坡结构类型：  ";
            if (typeOfSlope != "")
                textBoxReport.Text += typeOfSlope.ToString() + "\r\n";

            textBoxReport.Text += "（四）稳定状态：\r\n";
            if (stateOfStable != "")
                textBoxReport.Text += "  " + stateOfStable.ToString() + "\r\n";

            textBoxReport.Text += "（五）可能滑动方向：\r\n";
            if (riskLine != "")
                textBoxReport.Text += riskLine;

        }

        /// <summary>
        /// 分析1个坡面、2个结构面时的稳定状态
        /// </summary>
        /// <param name="stateOfStable"></param>
        /// <param name="isStable"></param>
        /// <param name="A"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        void AnalysisOf3Planes(out string stateOfStable, out string riskLine, LongtitudeCircle A, LongtitudeCircle B1, LongtitudeCircle B2)
        {

            // 双滑面双分为：两组结构面与坡面走向基本一致、两组结构面与坡面走向斜交
            string _stateOfStable = "";
            string _riskLine = "";
            var p = from item in listOfPoint                                                             // 从交点列表 中找出两个结构面的交点
                    where (item.C1.Name.ToString().Substring(0, 1) == "B" && item.C2.Name.ToString().Substring(0, 1) == "B")
                    select item;

            List<LongtitudeCircle> nq = new List<LongtitudeCircle>();  // 内倾的结构面
            List<LongtitudeCircle> wq = new List<LongtitudeCircle>();   // 外倾的结构面
            List<LongtitudeCircle> nNorW = new List<LongtitudeCircle>();  // 即不算内倾也不算外倾

            foreach (LongtitudeCircle item in new LongtitudeCircle[] { B1, B2 })
            {
                if (Math.Abs(item.Trend - A.Trend) < 0.01)
                    wq.Add(item);
                else if (Math.Abs(item.Trend - A.Trend) > 135)            // 规定与边坡夹角超过 135 度为内倾
                    nq.Add(item);
                else
                    nNorW.Add(item);
            }

            //   两组结构面与坡面走向基本一致
            if (nq.Count == 1 && wq.Count == 1)                            // 一组外倾，一组内倾
            {
                if (wq[0].Dip >= A.Dip)
                {
                    _stateOfStable = "一组外倾，一组内倾，外倾结构面倾角大于坡面倾角，边坡可能产生深层滑动，内倾结构面倾角越小越易滑动。"; // 这是不稳定状态怎么写 ？？？

                }
                else
                {
                    _stateOfStable = "一组外倾，一组内倾，外倾结构面倾角小于坡面倾角，边坡可能沿交线滑动。";
                    _riskLine = "  (NE " +                                                                                // 和外倾面产状一致
                                 double.Parse(double.Parse(wq[0].Trend.ToString()).ToString("#0.0")) +
                                 ", " +
                                 double.Parse(double.Parse(wq[0].Dip.ToString()).ToString("#0.0")) + ")";

                }
            }
            else if (wq.Count == 1 && Math.Abs(nNorW[0].Trend - A.Trend) < 45) // 一组外倾，且另一组与边坡相差在 45 度内，算两组外倾
            {
                _stateOfStable = "两组外倾，且外倾结构面倾角小于坡面倾角，边坡较破碎，易滑动。";
                if (p.ElementAt(0) != null)
                {
                    p.ElementAt(0).FindRisk();
                    _riskLine = "  (NE " +                                                                                // 和外倾面产状一致
                                double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                                ", " +
                                double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")";
                }
            }
            else if (wq.Count == 2)                                    // 两组外倾
            {
                if (wq[0].Dip > A.Dip && wq[1].Dip > A.Dip)
                {
                    _stateOfStable = "两组外倾，且外倾结构面倾角大于坡面倾角，边坡较稳定，但可能产生深层滑动。";
                }
                else
                {
                    _stateOfStable = "两组外倾，且外倾结构面倾角小于等于坡面倾角，边坡不稳定，可能沿交线滑动。";
                    _riskLine = "  (NE " +                                                                                // 和外倾面产状一致
                                 double.Parse(double.Parse(wq[0].Trend.ToString()).ToString("#0.0")) +
                                 ", " +
                                 double.Parse(double.Parse(wq[0].Dip.ToString()).ToString("#0.0")) + ")";
                }
            }
            else if (nq.Count == 2 && ((Math.Abs(Math.Abs(nq[0].Trend - A.Trend) - 180) < 0.01) ||
                                       (Math.Abs(Math.Abs(nq[1].Trend - A.Trend) - 180) < 0.01)))
            // 无外倾，两组内倾，两组内倾且有一组与边坡差180度
            {
                _stateOfStable = "两组内倾，边坡较稳定，坚硬岩层滑动可能性较小。";
            }

            // 两组结构面与坡面走向斜交
            else
            {
                if (p.ElementAt(0) != null)
                {
                    Point keypoint = p.ElementAt(0) as Point;
                    if (Math.Abs(keypoint.alpha - A.Trend) > 90)
                    {
                        _stateOfStable = "结构面倾线倾向与坡面相反，边坡稳定，滑动可能性较小。";
                    }
                    else if (PointWithCircle(keypoint, A) == "inCircle")
                    {
                        _stateOfStable = "结构面交线倾向与坡面相同，倾角大于坡面角，边坡无滑动临空面，滑动可能性较小。";
                    }
                    else
                    {
                        _stateOfStable = "结构面交线倾向与坡面相同，倾角小于等于坡面角，边坡可能沿交线方向滑动。";
                        p.ElementAt(0).FindRisk();
                        _riskLine = "  (NE " +
                               double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                               ", " +
                               double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")";
                    }
                }
            }
            stateOfStable = _stateOfStable;
            riskLine = _riskLine;

        }

        /// <summary>
        /// 分析2个坡面、2个结构面时的稳定状态
        /// </summary>
        /// <param name="stateOfStable"></param>
        /// <param name="isStable"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        void AnalysisOf4Planes(out string stateOfStable, out string riskLine, LongtitudeCircle A1, LongtitudeCircle A2, LongtitudeCircle B1, LongtitudeCircle B2)
        {
            string _stateOfStable = "";
            string _riskLine = "";
            if (Math.Abs(A1.Trend - A2.Trend) < 1E-10)  // 要求两个边坡的倾向是相同的
            {
                var p = from item in listOfPoint        // 在交点列表中找出结构面的交点
                        where (item.C1.Name.ToString().Substring(0, 1) == "B" && item.C2.Name.ToString().Substring(0, 1) == "B")
                        select item;
                LongtitudeCircle minSlope = A1.Dip > A2.Dip ? A1 : A2;
                LongtitudeCircle maxSlope = A1.Dip < A2.Dip ? A1 : A2;

                if (p.ElementAt(0) != null)
                {
                    Point keyPoint = p.ElementAt(0) as Point;
                    if (PointWithCircle(keyPoint, minSlope) == "inCircle" && Math.Abs(keyPoint.alpha - minSlope.Trend) > 90)
                    {
                        _stateOfStable = "结构面组合切割体为内倾，边坡非常稳定。";
                    }
                    else if (PointWithCircle(keyPoint, minSlope) == "inCircle" &&
                             Math.Abs(keyPoint.alpha - minSlope.Trend) <= 90)
                    {
                        _stateOfStable = "结构面组合交线的倾向与边坡倾向相对一致，且倾角大于坡面倾角，边坡稳定。";
                    }
                    else if (PointWithCircle(keyPoint, minSlope) == "onCircle")
                    {
                        _stateOfStable = "结构面组合交线的倾角等于坡面的倾角，边坡基本稳定。";
                    }
                    else if (PointWithCircle(keyPoint, minSlope) == "outCircle" &&
                             PointWithCircle(keyPoint, maxSlope) == "inCircle")
                    {
                        _stateOfStable =
                              "结构面组合交线的倾角比其中一坡面的倾角小，比另一个的倾角大。如果交线在边坡面和坡顶面上都有出露，边坡处于不稳定状态；" +
                              "如果结构面组合交线在坡顶面上的出露距离很远，以致交线未在开挖坡面上出露而插入坡下，则以边坡处于较稳定状态。";
                        p.ElementAt(0).FindRisk();
                        _riskLine = "  (NE " +
                                double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                                ", " +
                                double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")";
                    }
                    else
                    {
                        _stateOfStable = "结构面组合交线倾角比坡面倾角小，如果存在纵向切割面，则易于产生滑动；" +
                            "如果交线在坡顶上没有出露点，且在坡顶面上没有纵向（边坡走向）切割面的情况下，边坡能处于稳定状态。";
                        p.ElementAt(0).FindRisk();
                        _riskLine = "  (NE " +
                                double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.alpha.ToString()).ToString("#0.0")) +
                                ", " +
                                double.Parse(double.Parse(p.ElementAt(0).RiskAttitude.beta.ToString()).ToString("#0.0")) + ")";
                    }
                }

            }
            stateOfStable = _stateOfStable;
            riskLine = _riskLine;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "文本文件(*.txt)|*.txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.AppendText(file.FileName);
                sw.Write(textBoxReport.Text);
                sw.Flush();
                sw.Close();
            }
        }

        private void textBoxTrend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBoxDip.Focus();
        }

        private void textBoxDip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBoxTrend.Focus();
        }

        /// <summary>
        /// 初始化图板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DebuggerStepThrough]
        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {


            //for (int i = 0; i < theDataFromMain.Count; i++)
            //{
            //    LongtitudeCircle newCircle;
            //    DrawPlanes(out newCircle, e.Graphics, attitudeInfo.Rows[i], new Pen(Color.Red));
            //    listOfCircle.Add(newCircle);

            //}

            Point p1 = new Point(0, -R);
            Point p2 = new Point(0, R);
            for (int theta = 10; theta < 90; theta += 10)
            {

                double a, b, r, ra;

                // 绘制左半部分
                Point p3 = new Point(-R * Math.Tan((90 - theta) * Math.PI / 2 / 180), 0);
                CenterAndR(out a, out b, out r, p1, p2, p3);
                e.Graphics.DrawArc(new Pen(Color.LightGray), (float)(148 + p3.X), (float)(150 - r), (float)(r * 2), (float)(2 * r), (float)(180 - Math.Asin(R / r) * 180 / (float)Math.PI), 2 * (float)Math.Asin(R / r) * 180 / (float)Math.PI);

                // 绘制右半部分
                Point p4 = new Point(R * Math.Tan((90 - theta) * Math.PI / 2 / 180), 0);
                CenterAndR(out a, out b, out ra, p1, p2, p4);
                e.Graphics.DrawArc(new Pen(Color.LightGray), (float)(148 + a - ra), (float)(150 - ra), (float)(ra * 2), (float)(2 * ra), -(float)Math.Asin(130 / ra) * 180 / (float)Math.PI, 2 * (float)Math.Asin(R / ra) * 180 / (float)Math.PI);

                // 绘制纬线部分
                double rOfLatitude = R / Math.Tan(theta * Math.PI / 180);
                e.Graphics.DrawArc(new Pen(Color.LightGray), (float)(148 - rOfLatitude), (float)(150 - rOfLatitude - R / Math.Sin(theta * Math.PI / 180)), (float)(2 * rOfLatitude), (float)(2 * rOfLatitude), 90 - theta, 2 * theta);
                e.Graphics.DrawArc(new Pen(Color.LightGray), (float)(148 - rOfLatitude), (float)(150 - rOfLatitude + R / Math.Sin(theta * Math.PI / 180)), (float)(2 * rOfLatitude), (float)(2 * rOfLatitude), 270 - theta, 2 * theta);

            }
            // 绘制横竖中心线
            e.Graphics.DrawLine(new Pen(Color.LightGray), 148, 20, 148, 280);
            e.Graphics.DrawLine(new Pen(Color.LightGray), 18, 150, 278, 150);

            // 轮廓大圆
            e.Graphics.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);

            // 画指北针
            var imageFileName = Path.Combine(Directory.GetCurrentDirectory(), "neel.png");
            Image newImage = Image.FromFile(imageFileName);
            e.Graphics.DrawImage(newImage, 244, 236, 36, 55);
        }

        /// <summary>
        /// 关闭窗体后所有的变量清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStereonet_FormClosed(object sender, FormClosedEventArgs e)
        {
            numOfA = 0;
            numOfB = 0;
            totalRecord = 0;

            typeOfArc = null;
            tempPlane = null;
            tempType = null;
            listOfCircle = new List<LongtitudeCircle>(); // 存放圆，对应结构面
            listOfPoint = new List<Point>(); //存放点，对应结构面交线

            for (int i = 0; i < attitudeInfo.RowCount; i++)
            {
                if (attitudeInfo.Rows[i].Cells[0].Value != null)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        attitudeInfo.Rows[i].Cells[j].Value = "";
                    }
                    attitudeInfo.Rows.Add(1);
                }
            }

        }
    }
}
