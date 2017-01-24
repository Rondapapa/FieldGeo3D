using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Layout;
using DevComponents.DotNetBar.Rendering;
using DevComponents.DotNetBar.Keyboard;
using System.IO;
using System.Collections;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;
using System.Diagnostics;


namespace WindowsFormsApplication12
{

    public partial class Form1 : Form

    {
        int numOfA = 0;
        int numOfB = 0;
        int totalRecord = 0;
        const float R = 130;
        string typeOfArc = null;
        DataGridViewRow tempPlane = null;
        string tempType = null;
        List<LongtitudeCircle> listOfCircle = new List<LongtitudeCircle>();// 存放圆，对应结构面
        List<Point> listOfPoint = new List<Point>(); //存放点，对应结构面交线


        public Form1()
        {
            InitializeComponent();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX4_CursorChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX5_CursorChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void Form1_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxX5_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxX5_TabIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBoxX5_CommandKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBoxX5_AcceptsTabChanged(object sender, EventArgs e)
        {

        }
        private void ButtonX2_BackColorChanged(object sender, EventArgs e)
        {
        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 倾向 文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX5_MouseClick(object sender, MouseEventArgs e)
        {
            keyboardControl1.Visible = true;

        }

        /// <summary>
        /// 倾角 文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX4_Click(object sender, EventArgs e)
        {

            keyboardControl1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Text = "";
            keyboardControl1.Invalidate();

            dataGridViewX1.Rows.Add(9);
            dataGridViewX1.ClearSelection();


        }
        /// <summary>
        /// 临空面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            highlighter1.SetHighlightColor(buttonX2, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            highlighter1.SetHighlightColor(buttonX3, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            typeOfArc = buttonX2.Name;
        }


        /// <summary>
        /// 刷新键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX8_Click(object sender, EventArgs e)
        {
            FreshMethod();
        }

        /// <summary>
        /// 开始分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            // 分析前清理 临时列表

            for (int k = totalRecord; k < totalRecord + listOfPoint.Count; k++)
            {
                dataGridViewX1.Rows[k].Cells[0].Value = null;
                dataGridViewX1.Rows[k].Cells[1].Value = null;
                dataGridViewX1.Rows[k].Cells[2].Value = null;
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
                        if (intersection != null)
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
                    dataGridViewX1.Rows[tot].Cells[0].Value = String.Format("L_" + (k + 1).ToString());
                    dataGridViewX1.Rows[tot].Cells[1].Value = float.Parse(listOfPoint[k].alpha.ToString("#0.0"));
                    dataGridViewX1.Rows[tot].Cells[2].Value = float.Parse(listOfPoint[k].beta.ToString("#0.0"));
                    dataGridViewX1.Rows.Add(1);
                    // 在列表中给点加名字
                    listOfPoint[k].Name = String.Format("L_" + (k + 1).ToString());
                    tot++;
                }
            }

            if (totalRecord > 0)
            {
                // 生成分析报告
                textBoxX1.Text = "";
                textBoxX1.Text += "分析报告：\r\n";
                textBoxX1.Text += "（一）交线情况：\r\n";
                foreach (Point p in listOfPoint)
                    textBoxX1.Text += "  " + p.Name.ToString() + ":(" + p.C1.Name + "," + p.C2.Name + ")(NE " + p.alpha.ToString("#0.0") + ", " + p.beta.ToString("#0.0") + ")\r\n";
            }
            else
                textBoxX1.Text = "";
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            highlighter1.SetHighlightColor(buttonX3, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            highlighter1.SetHighlightColor(buttonX2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            typeOfArc = buttonX3.Name;
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            highlighter1.SetHighlightColor(buttonX2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            highlighter1.SetHighlightColor(buttonX3, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            textBoxX4.Text = "";
            textBoxX5.Text = "";

        }

        /// <summary>
        /// 确定键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX5_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (textBoxX5.Text != "" && (double.Parse(textBoxX5.Text) > 360 || double.Parse(textBoxX5.Text) < -360))
            { FreshMethod(); return; }
            if (textBoxX4.Text != "" && (double.Parse(textBoxX4.Text) >= 90 || double.Parse(textBoxX4.Text) < 0))
            { FreshMethod(); return; }

            // 某一个类型面的数目
            int planeNum = 0;

            // 有没有选中某一行
            if (tempPlane != null && textBoxX4.Text != "" && textBoxX5.Text != "")
            {
                // 在list中找到这一行
                for (int i = 0; i < listOfCircle.Count; i++)
                {
                    if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString() == listOfCircle[i].Name)
                        listOfCircle.RemoveAt(i);
                }
                int p = dataGridViewX1.SelectedRows[0].Index;
                //选中的行有没有改结构面类型
                if (tempType == typeOfArc)
                {

                    dataGridViewX1.Rows[p].Cells[1].Value = double.Parse(double.Parse(textBoxX5.Text).ToString("#0.0"));
                    dataGridViewX1.Rows[p].Cells[2].Value = double.Parse(double.Parse(textBoxX4.Text).ToString("#0.0"));
                }
                else if (tempType != typeOfArc)
                {
                    planeNum = (tempType == buttonX2.Name) ? ++numOfB : ++numOfA;
                    string aOrB = (tempType == buttonX2.Name) ? "B_" : "A_";

                    dataGridViewX1.Rows[p].Cells[0].Value = String.Format(aOrB + planeNum.ToString());
                    dataGridViewX1.Rows[p].Cells[1].Value = double.Parse(double.Parse(textBoxX5.Text).ToString("#0.0"));
                    dataGridViewX1.Rows[p].Cells[2].Value = double.Parse(double.Parse(textBoxX4.Text).ToString("#0.0"));
                }
                LongtitudeCircle newCircle;
                DrawPlanes(out newCircle, g, dataGridViewX1.Rows[p], new Pen(Color.Red, 1));
                listOfCircle.Add(newCircle);

            }
            // 没有选中的行，就加新行
            else if (typeOfArc != null && textBoxX4.Text != "" && textBoxX5.Text != "")
            {
                totalRecord++;
                planeNum = (typeOfArc == buttonX2.Name) ? ++numOfA : ++numOfB;
                string aOrB = (typeOfArc == buttonX2.Name) ? "A_" : "B_";
                dataGridViewX1.Rows[totalRecord - 1].Cells[0].Value = String.Format(aOrB + planeNum.ToString());
                dataGridViewX1.Rows[totalRecord - 1].Cells[1].Value = double.Parse(double.Parse(textBoxX5.Text).ToString("#0.0"));
                dataGridViewX1.Rows[totalRecord - 1].Cells[2].Value = double.Parse(double.Parse(textBoxX4.Text).ToString("#0.0"));

                // 有新面，立即画出来
                LongtitudeCircle newCircle;
                DrawPlanes(out newCircle, g, dataGridViewX1.Rows[totalRecord - 1], new Pen(Color.Red));
                listOfCircle.Add(newCircle);
            }

            // 每次添加完就排序
            if (totalRecord > 1)
                SortMethod();
            if (dataGridViewX1.Rows.Count - totalRecord == 1)
                dataGridViewX1.Rows.Add(1);
            ReDraw();
            FreshMethod();
            
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
            dataGridViewX1.ClearSelection();
            typeOfArc = null;
            highlighter1.SetHighlightColor(buttonX2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            highlighter1.SetHighlightColor(buttonX3, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            textBoxX4.Text = "";
            textBoxX5.Text = "";
            tempPlane = null; tempType = null;
        }

        /// <summary>
        /// 排序，每次添加新产状后用到
        /// </summary>
        public void SortMethod()
        {
            int numOfEmpty = 0;
            for (int p = dataGridViewX1.Rows.Count - 2; p >= totalRecord; p--)
            {
                dataGridViewX1.Rows.RemoveAt(p);
                numOfEmpty++;
            }
            dataGridViewX1.Sort(dataGridViewX1.Columns[0], ListSortDirection.Ascending);
            dataGridViewX1.Rows.Add(numOfEmpty);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (totalRecord > 0)
            {
                if (dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "A")
                    {
                        totalRecord--;
                        try
                        {
                            int a = dataGridViewX1.SelectedRows[0].Index;
                            if (dataGridViewX1.Rows[a + 1].IsNewRow)
                                numOfA--;
                            else if (dataGridViewX1.Rows[a].Cells[0].Value.ToString().Substring(0, 1) != "A")
                                numOfA--;
                        }
                        finally { }

                    }
                    else if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "B")
                    {
                        totalRecord--;
                        try
                        {
                            int a = dataGridViewX1.SelectedRows[0].Index;
                            if (dataGridViewX1.Rows[a + 1].IsNewRow)
                                numOfB--;
                            else if (dataGridViewX1.Rows[a].Cells[0].Value.ToString().Substring(0, 1) != "A")
                                numOfB--;
                        }
                        finally { }
                    }

                    // 在list 中删除
                    for (int i = 0; i < listOfCircle.Count; i++)
                    {
                        if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString() == listOfCircle[i].Name)
                            listOfCircle.RemoveAt(i);
                    }
                }
                if (dataGridViewX1.SelectedRows.Count > 0)
                    dataGridViewX1.Rows.Remove(dataGridViewX1.SelectedRows[0]);
                if (dataGridViewX1.Rows.Count < 11)
                    dataGridViewX1.Rows.Add(11 - dataGridViewX1.Rows.Count);

                FreshMethod();
            }
        }

        /// <summary>
        /// 选择产状信息，用于编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {

            ReDraw();
            if (dataGridViewX1.SelectedRows.Count > 0)
                if (dataGridViewX1.SelectedRows[0].Cells[0].Value != null)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    LongtitudeCircle tempCircle = new LongtitudeCircle();

                    if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "A")
                    {
                        typeOfArc = buttonX2.Name;
                        highlighter1.SetHighlightColor(buttonX2, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
                        highlighter1.SetHighlightColor(buttonX3, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                        textBoxX5.Text = dataGridViewX1.SelectedRows[0].Cells[1].Value.ToString();
                        textBoxX4.Text = dataGridViewX1.SelectedRows[0].Cells[2].Value.ToString();

                        DrawPlanes(out tempCircle, g, dataGridViewX1.SelectedRows[0], new Pen(Color.Gold, 2));
                        g.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);
                    }
                    else if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "B")
                    {
                        typeOfArc = buttonX3.Name;
                        highlighter1.SetHighlightColor(buttonX3, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
                        highlighter1.SetHighlightColor(buttonX2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                        textBoxX5.Text = dataGridViewX1.SelectedRows[0].Cells[1].Value.ToString();
                        textBoxX4.Text = dataGridViewX1.SelectedRows[0].Cells[2].Value.ToString();

                        DrawPlanes(out tempCircle, g, dataGridViewX1.SelectedRows[0], new Pen(Color.Gold, 2));
                        g.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);
                    }
                    else if (dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 1) == "L")
                    {
                        int pointR = 4;
                        for (int i = 0; i < listOfPoint.Count; i++)
                        {
                            if (listOfPoint[i].Name == dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString())
                                g.FillEllipse(Brushes.OliveDrab, (float)(listOfPoint[i].X + 148 - pointR), (float)(listOfPoint[i].Y + 150 - pointR), (float)(pointR * 2), (float)(pointR * 2));
                        }
                    }
                    tempPlane = dataGridViewX1.SelectedRows[0];
                    tempType = typeOfArc;
                }
                else
                    dataGridViewX1.ClearSelection();
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

        }

        /// <summary>
        /// 大圆
        /// </summary>
        public class LongtitudeCircle
        {
            public double X0 { get; set; }
            public double Y0 { get; set; }
            public double R { get; set; }
            public string Name { get; set; }
            public LongtitudeCircle(string name, double x, double y, double r)
            {
                Name = name;
                X0 = x;
                Y0 = y;
                R = r;
            }
            public LongtitudeCircle() { }
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
            if (b * b - 4 * a * c <= 0)
                return false;
            else
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
            if (IsInCircle(p1))
                return p1;
            else if (IsInCircle(p2))
                return p2;
            else
                return null;
            
        }


        /// <summary>
        /// 判断 点是否在圆内
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool IsInCircle(Point p)
        {
            if (p.X * p.X + p.Y * p.Y < R * R)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 初始化图板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DebuggerStepThrough]
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Point p1 = new Point(0, -R);
            Point p2 = new Point(0, R);
            for (int theta = 10; theta < 90; theta += 10)
            {

                double a, b, r, ra;

                // 绘制左半部分
                Point p3  = new Point(-R * Math.Tan((90 - theta)* Math.PI / 2 / 180 ), 0);
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
            var imageFileName = Path.Combine(Directory.GetCurrentDirectory(),"neel.png");
            Image newImage = Image.FromFile(imageFileName);
            e.Graphics.DrawImage(newImage, 244, 236,36,55);


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
              double d = R * Math.Tan(Math.PI/4-dip/2);
            // Point newp3 = new Point(R * Math.Sin(trend) / (Math.Tan(dip) + 1), -R * Math.Cos(trend) / (Math.Tan(dip) + 1));
            Point newp3 = new Point(d * Math.Sin(trend), -d * Math.Cos(trend));
           
            double x0, y0, r;

            // 三点定圆
            CenterAndR(out x0, out y0, out r, newp1, newp2, newp3);

            // 存入经向大圆临时列表
            newCircle = new LongtitudeCircle(name, x0, y0, r);
            //  listOfCircle.Add(new LongtitudeCircle(name, x0, y0, r));

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
                if (dataGridViewX1.Rows[i].Cells[0].Value.ToString().Substring(0, 1) == "A")
                    DrawPlanes(out tempCirle, g, dataGridViewX1.Rows[i], new Pen(Color.MidnightBlue, 1));
                else
                    DrawPlanes(out tempCirle, g, dataGridViewX1.Rows[i], new Pen(Color.HotPink, 1));
            }
            if (listOfPoint.Count > 0)
            {
                int pointR = 3;
                for (int j = 0; j < listOfPoint.Count; j++)
                {
                    g.FillEllipse(Brushes.Black, (float)(listOfPoint[j].X + 148 - pointR), (float)(listOfPoint[j].Y + 150 - pointR), (float)(pointR * 2), (float)(pointR * 2));
                    // g.DrawLine
                }


            }
            g.DrawArc(new Pen(Color.MidnightBlue, 3), 18, 20, 260, 260, 0, 360);
        }
        
        /// <summary>
        /// 倾向
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBoxX4.Focus();
        }
        /// <summary>
        /// 倾角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBoxX5.Focus();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "文本文件(*.txt)|*.txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.AppendText(file.FileName);
                sw.Write(textBoxX1.Text);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
