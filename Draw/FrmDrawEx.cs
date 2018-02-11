using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using DevComponents.DotNetBar.Keyboard;
using DevExpress.XtraEditors;
using Draw.Drawing;
using GeoIM.CHIDI.DZ.BLL.Geometry;
using GeoIM.CHIDI.DZ.COM;

using MathNet.Numerics.LinearAlgebra;

using MathNet.Spatial.Euclidean;
using MathNet.Spatial;


namespace Draw
{
    public partial class FrmBLHT : XtraForm
    {

        // 绘图方式：在图片上绘图、空白绘图
        private enum DrawMethod
        {
            OnPicture,
            OnBoard
        }

        /// <summary>
        /// 记录正在进行的操作：无操作、校正、缩放、添加线
        /// </summary>
        private enum Doing
        {
            None,
            Rectify,
            Zoom,
            DrawLine
        }
        // 像素坐标对应的 线
        public class ScreenLine
        {
            public List<PointF> linePointFs = new List<PointF>();
            public Color Color = Color.CornflowerBlue; //不同类型的线用不同颜色
        }

        // 实际的线
        public class RealLine
        {
            public List<Point3D> linePoints = new List<Point3D>();
            public string GUID;
            public string Name;
            public string Type;
        }

        private List<ScreenLine> screenLines = new List<ScreenLine>(); // 存放画板上的线
        private List<RealLine> RealLines = new List<RealLine>();         //存放 转化成的开挖坐标对应的线
        public string allLines;



        public string MarkerType { get; set; } = "JGM";   //  添加线的类型


        Document doc = null;


        BufferedGraphics bfg = null;   // 双缓冲绘图
        public Color DrawBackColor = Color.Wheat;
        DrawMethod drawMethod = DrawMethod.OnBoard;
        Doing doing = Doing.None;
        private bool dragPictrue = false;         // 判断是否在拖拽
        private PointF startMove;                  // 记录拖拽起始时鼠标的位置
        private double widthHeightRatio = 2;     //  宽高比，就从控制点推出的包络矩形中求出，在 document 中，测试暂设 4

        /// <summary>
        /// 专用于洞室编录的参数
        /// </summary>
        public double caveWidth;// 实际洞室的宽
        public double caveHeight; //实际洞室的高
        public double caveLength;//实际洞室的长
        public double caveWidthScreen;//画板上洞室的宽
        public double caveHeightScreen;//画板上洞室的高
        public double caveLengthScreen;//画板上洞室的长

        private RectangleF drawZone;    // 绘图的区域


        Bitmap backPicture = null;               // 背景照片

        private bool isEditing = false;          //是否在编辑坐标点


        private List<Point3D> controlPtsKW = new List<Point3D>(); // 校正点开挖坐标
        private List<PointF> controlPtsScreen = new List<PointF>();// 校正点屏幕坐标

        private Matrix<double> MatrixScreenToKW;     // 建立两个3x3的转换矩阵
        private Matrix<double> MatrixKWToScreen;
        private double[] JBplane = new double[] { };                   // 局部平面，即边坡对应的平面


        public FrmBLHT()
        {
            InitializeComponent();
            ShowIcon = true;
            numericKeyboard.Keyboard = CreateNumericKeyboard();
            pictureBox.BackColor = DrawBackColor;
            pictureBox.Refresh();
        }

        public FrmBLHT(drawParameter para)
        {
            InitializeComponent();
            doc = new Document(para);
            widthHeightRatio = doc.widthHeightRito;
            numericKeyboard.Keyboard = CreateNumericKeyboard();



        }


        #region 工具栏  按键等

        /// <summary>
        /// 关闭键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rst = MessageBox.Show("是否保存测绘?", "提示", MessageBoxButtons.YesNoCancel);
            // 选择是，则保存
            if (rst == DialogResult.Yes)
            {

                // 每条线的记录格式 为： # GUID，Name，Type，x1，y1，z1，x2，y2，z2，...，xn，yn，zn #
                string upLoadInfo;
                StringBuilder upLoadInfoTmp1 = new StringBuilder("#");
                // 存洞室的  宽、高、长
                if (doc.TypeOfBLHT == "DS")
                {
                    upLoadInfoTmp1.Append(caveWidth.ToString() + ",");
                    upLoadInfoTmp1.Append(caveHeight.ToString() + ",");
                    upLoadInfoTmp1.Append(caveLength.ToString());
                }
                else
                {
                    // 存三个屏幕控制点
                    for (int i = 0; i < 3; i++)
                    {
                        upLoadInfoTmp1.Append(controlPtsScreen[i].X.ToString() + ",");
                        upLoadInfoTmp1.Append(controlPtsScreen[i].Y.ToString() + ",");
                    }
                    upLoadInfoTmp1.Remove(upLoadInfoTmp1.Length - 1, 1);

                    // 存所有的实际控制点
                    upLoadInfoTmp1.Append("#");
                    for (int i = 0; i < 3; i++)
                    {
                        upLoadInfoTmp1.Append(controlPtsKW[i].X.ToString() + ",");
                        upLoadInfoTmp1.Append(controlPtsKW[i].Y.ToString() + ",");
                        upLoadInfoTmp1.Append(controlPtsKW[i].Z.ToString() + ",");

                    }
                    upLoadInfoTmp1.Remove(upLoadInfoTmp1.Length - 1, 1);
                }



                //存所有的线
                StringBuilder upLoadInfoTmp2 = new StringBuilder();
                for (int i = 0; i < screenLines.Count; i++)
                {
                    upLoadInfoTmp2.Append("#");
                    upLoadInfoTmp2.Append(RealLines[i].GUID + "," + RealLines[i].Name + "," + RealLines[i].Type + ",");

                    for (int j = 0; j < RealLines[i].linePoints.Count; j++)
                    {
                        upLoadInfoTmp2.Append(RealLines[i].linePoints[j].X.ToString() + ",");
                        upLoadInfoTmp2.Append(RealLines[i].linePoints[j].Y.ToString() + ",");
                        upLoadInfoTmp2.Append(RealLines[i].linePoints[j].Z.ToString() + ",");
                    }
                    upLoadInfoTmp2.Remove(upLoadInfoTmp2.Length - 1, 1);


                }
                upLoadInfo = upLoadInfoTmp1.ToString() + upLoadInfoTmp2.ToString();
                allLines = upLoadInfoTmp2.ToString();  // 用于上传

                // 创建文件
                string fileName = doc.SJLYID.ToString();
                string filePath = @"C:\test\" + fileName + ".txt";
                string filePath2 = @"C:\test\" + "Line_" + fileName + ".txt";

                FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(upLoadInfoTmp1.ToString());//开始写入值
                sw.Close();
                fs1.Close();

                FileStream fs2 = new FileStream(filePath2, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw2 = new StreamWriter(fs2);
                sw2.WriteLine(upLoadInfoTmp2.ToString());//开始写入值
                sw2.Close();
                fs2.Close();




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
        /// <summary>
        /// 添加线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (controlPtsScreen.Count < 3)
            {
                if (drawMethod == DrawMethod.OnPicture && doc.TypeOfBLHT != "DS")
                {
                    ReDraw();
                    MessageBox.Show("请先完成校正");
                    return;
                }
                // 如果没有校正直接添加线，则计算绘图区域和控制点
                else if (drawMethod == DrawMethod.OnBoard)
                {
                    // 计算绘图区域
                    CalculateDrawZone();

                    // 如果不是洞室，则用三控制点校正
                    if (doc.TypeOfBLHT != "DS")
                    {
                        PointF ctrlOriginSC = new PointF(drawZone.X, drawZone.Y + drawZone.Height);
                        //存左下方的点
                        controlPtsKW.Add(doc.ptsTriangleSC[1]);
                        controlPtsScreen.Add(new PointF(drawZone.X, drawZone.Y + drawZone.Height));
                        //存右下方的点
                        controlPtsKW.Add(doc.ptsTriangleSC[2]);
                        controlPtsScreen.Add(new PointF(drawZone.X + drawZone.Width, drawZone.Y + drawZone.Height));
                        //存顶点
                        controlPtsKW.Add(doc.ptsTriangleSC[0]);
                        double distAC = doc.ptsTriangleSC[0].DistanceTo(doc.ptsTriangleSC[1]);
                        double distAB = doc.ptsTriangleSC[1].DistanceTo(doc.ptsTriangleSC[2]);
                        double screenAC = distAC * drawZone.Width / distAB;
                        double pUpX = Math.Sqrt(screenAC * screenAC - drawZone.Height * drawZone.Height);
                        controlPtsScreen.Add(new PointF(drawZone.X + (float)pUpX, drawZone.Y));

                        CalculateMatrixScreenToKW(controlPtsScreen, controlPtsKW);
                        CalculateMatrixKWToScreen(controlPtsScreen, controlPtsKW);
                        JBplane = CalculatePlane(controlPtsKW[0], controlPtsKW[1], controlPtsKW[2]);

                    }
                }

            }


            ReDraw();
            btnPanorama_ItemClick(sender, e);

            lableLineName.Caption = "名称:";

            ShowBtnAndItem(new string[] { "btnOK", "btnCancel", "btnRecall", "inputName", "inputType", "inputXYZ" });

            doing = Doing.DrawLine;
            screenLines.Add(new ScreenLine());
            RealLines.Add(new RealLine());




        }



        /// <summary>
        /// 取消键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (doing == Doing.DrawLine)
            {
                if (screenLines.Count > 0)
                {
                    screenLines.RemoveAt(screenLines.Count - 1);
                    RealLines.RemoveAt(RealLines.Count - 1);
                }

                ReDraw();
                ShowBtnAndItem(new string[] { "btnAddLine", "btnClose", "zoom" });
                doing = Doing.None;
                return;
            }
            if (doing == Doing.Rectify || screenLines.Count == 0)
            {
                controlPtsKW.Clear();
                controlPtsScreen.Clear();

                drawZone = new RectangleF();
                ShowBtnAndItem(new string[] { "btnClose", "btnLoadPictures", "btnDrawOnBoard" });
                bfg.Graphics.Clear(DrawBackColor);
                bfg.Render();
                doing = Doing.None;
                return;
            }

        }

        /// <summary>
        /// 完成画线、完成校正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (doing == Doing.DrawLine)
            {
                if (listLinetypes.Caption == "请选择")
                {
                    MessageBox.Show("请先择类型");
                    return;
                }
                if (lineName.Text == "")
                {
                    MessageBox.Show("请输入名称");
                    return;
                }
                if (screenLines.Count > 0 && screenLines.Last().linePointFs.Count < 2)
                {
                    MessageBox.Show("只有一个点，无法记录");
                    screenLines.RemoveAt(screenLines.Count - 1);
                    RealLines.RemoveAt(RealLines.Count - 1);
                    return;

                }
                if (lineName.Text.Contains("#") || lineName.Text.Contains(","))
                {
                    MessageBox.Show("名称中不可出现“#”或“，”");

                    return;
                }
                RealLines[RealLines.Count - 1].GUID = Guid.NewGuid().ToString();
                RealLines[RealLines.Count - 1].Name = lineName.Text;
                RealLines[RealLines.Count - 1].Type = MarkerType;
                screenLines[screenLines.Count - 1].Color = Color.Red;

                ShowBtnAndItem(new string[] { "btnAddLine", "btnClose", "zoom" });
                doing = Doing.None;
            }
            if (doing == Doing.Rectify)
            {
                if (controlPtsScreen.Count < 3)
                {
                    MessageBox.Show("校正点不足3个，不能完成校正");
                    return;
                }

                // 如果三个控制点共线，则报错
                if (IsCollineation(controlPtsKW[0], controlPtsKW[1], controlPtsKW[2]))
                {
                    MessageBox.Show("三个控制点共线，无法建立平面");

                    controlPtsKW.RemoveAt(controlPtsKW.Count - 1);
                    controlPtsScreen.RemoveAt(controlPtsScreen.Count - 1);
                    ReDraw();
                    return;

                }
                //建立两个转换矩阵  和  边坡平面方程
                CalculateMatrixScreenToKW(controlPtsScreen, controlPtsKW);
                CalculateMatrixKWToScreen(controlPtsScreen, controlPtsKW);


                JBplane = CalculatePlane(controlPtsKW[0], controlPtsKW[1], controlPtsKW[2]);

                ShowBtnAndItem(new string[] { "btnAddLine", "btnClose", "zoom" });

                // 判断是否有 x为定值、y为定值、z为定值的情况，如果有，则把x或y或z设置为只读，不允许用户修改
                var differenceOfX = Math.Max(Math.Max(controlPtsKW[0].X, controlPtsKW[1].X), controlPtsKW[2].X)
                    - Math.Min(Math.Min(controlPtsKW[0].X, controlPtsKW[1].X), controlPtsKW[2].X);
                var differenceOfY = Math.Max(Math.Max(controlPtsKW[0].Y, controlPtsKW[1].Y), controlPtsKW[2].Y)
                    - Math.Min(Math.Min(controlPtsKW[0].Y, controlPtsKW[1].Y), controlPtsKW[2].Y);
                var differenceOfZ = Math.Max(Math.Max(controlPtsKW[0].Z, controlPtsKW[1].Z), controlPtsKW[2].Z)
                    - Math.Min(Math.Min(controlPtsKW[0].Z, controlPtsKW[1].Z), controlPtsKW[2].Z);
                if (differenceOfX < 0.005)
                {
                    xValue.BackColor = Color.Gainsboro;
                    xValue.Text = controlPtsKW[0].X.ToString("#0.00");
                    xValue.ReadOnly = true;
                }
                if (differenceOfY < 0.005)
                {
                    yValue.BackColor = Color.Gainsboro;
                    yValue.Text = controlPtsKW[0].Y.ToString("#0.00");
                    yValue.ReadOnly = true;
                }
                if (differenceOfZ < 0.005)
                {
                    zValue.BackColor = Color.Gainsboro;
                    zValue.Text = controlPtsKW[0].Z.ToString("#0.00");
                    zValue.ReadOnly = true;
                }
                doing = Doing.None;
            }

        }

        /// <summary>
        /// 撤消键，用于在画图过程中对线修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (doing == Doing.DrawLine && screenLines.Count > 0 && screenLines.Last().linePointFs.Count > 0)
            {
                screenLines.Last().linePointFs.RemoveAt(screenLines.Last().linePointFs.Count - 1);     // 每次撤消该拆线的最后一个点
                if (doc.TypeOfBLHT == "BP" || doc.TypeOfBLHT == "JC")
                {
                    RealLines.Last().linePoints.RemoveAt(RealLines.Last().linePoints.Count - 1);
                }
                else if (doc.TypeOfBLHT == "DS")
                {

                }

                if (screenLines.Last().linePointFs.Count == 0)
                {
                    btnCancel_ItemClick(sender, e);
                }
                ReDraw();

            }
            if (doing == Doing.Rectify && controlPtsKW.Count > 0)
            {
                controlPtsKW.RemoveAt(controlPtsKW.Count - 1);
                controlPtsScreen.RemoveAt(controlPtsScreen.Count - 1);

                ReDraw();
            }
        }

        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            doing = Doing.Zoom;
            bfg.Graphics.ScaleTransform((float)1.25, (float)1.25); // 放大 1.25 倍
            bfg.Graphics.Clear(DrawBackColor);
            ReDraw();

        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            doing = Doing.Zoom;
            bfg.Graphics.ScaleTransform((float)0.8, (float)0.8); // 缩小为原来的 1/1.25=0.8
            ReDraw();
        }


        /// <summary>
        /// 用于放大缩小操作后，恢复图形原貌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanorama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (doing == Doing.Zoom)
            {
                bfg.Graphics.ResetTransform();
                doing = Doing.None;
                ReDraw();
            }
        }


        /// <summary>
        /// 空白绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawOnBoard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            drawMethod = DrawMethod.OnBoard;
            ShowBtnAndItem(new string[] { "btnAddLine", "zoom", "btnCancel", "btnRectify" });

        }

        /// <summary>
        /// 请选择   （类型）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listLinetypes_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

            listLinetypes.Caption = listLinetypes.Strings[listLinetypes.DataIndex];
            switch (listLinetypes.Caption.ToString())
            {
                case "地形地貌":
                    MarkerType = "DXDM";
                    break;
                case "地层岩性":
                    MarkerType = "DCYX";
                    break;
                case "结构面":
                    MarkerType = "JGM";
                    break;
                case "构造分段":
                    MarkerType = "GZFD";
                    break;
                case "褶皱":
                    MarkerType = "ZZ";
                    break;
                case "风化":
                    MarkerType = "FH";
                    break;
                case "卸荷":
                    MarkerType = "XH";
                    break;
                case "泥石流":
                    MarkerType = "NSL";
                    break;
                case "滑坡":
                    MarkerType = "HP";
                    break;
                case "崩塌":
                    MarkerType = "BT";
                    break;
                case "蠕变":
                    MarkerType = "RB";
                    break;
                case "潜在失稳块体":
                    MarkerType = "QZSWKT";
                    break;
                case "岩溶":
                    MarkerType = "YR";
                    break;
                case "地下水分段":
                    MarkerType = "DXSFD";
                    break;
                case "土体分层":
                    MarkerType = "TTFC";
                    break;
                case "岩体分类":
                    MarkerType = "YTFL";
                    break;
                default:
                    MarkerType = "";
                    break;
            }

        }


        /// <summary>
        /// 输入名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineName_MouseClick(object sender, MouseEventArgs e)
        {
            keyboardControl1.Visible = true;
        }

        /// <summary>
        /// 键盘关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyboardControl1_KeyboardClosed(object sender, EventArgs e)
        {

            pictureBox.Refresh();
            ReDraw();
        }
        private void keyboardControl1_VisibleChanged(object sender, EventArgs e)
        {
            pictureBox.Refresh();
            ReDraw();
        }

        /// <summary>
        /// 数字键盘关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericKeyboard_KeyboardClosed(object sender, EventArgs e)
        {
            pictureBox.Refresh();
            ReDraw();
        }

        private void numericKeyboard_VisibleChanged(object sender, EventArgs e)
        {
            pictureBox.Refresh();
            ReDraw();
        }
        /// <summary>
        /// 坐标输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xValue_MouseClick(object sender, MouseEventArgs e)
        {

            isEditing = true;
            numericKeyboard.Visible = true;

        }

        private void yValue_MouseClick(object sender, MouseEventArgs e)
        {
            isEditing = true;
            numericKeyboard.Visible = true;
        }

        private void zValue_MouseClick(object sender, MouseEventArgs e)
        {
            isEditing = true;
            numericKeyboard.Visible = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (doing == Doing.DrawLine)
            {
                int x = e.X;
                int y = e.Y;
            }
            if (doing == Doing.Rectify)
            {

            }
        }
        #endregion

        #region 窗体事件

        private void FrmDrawEx_Resize(object sender, EventArgs e)
        {
            //g_bmp = null;
            //  Invalidate();
        }

        private void FrmDrawEx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.doing != Doing.None && this.doc != null)
            {
                if (doing == Doing.DrawLine)
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


        /// <summary>
        /// 用于  画点  移动画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            // 在画线
            if (doing == Doing.DrawLine)
            {
                if (controlPtsKW.Count > 0)
                {
                    screenLines[screenLines.Count - 1].linePointFs.Add(new PointF(e.X, e.Y));

                    ReDraw();

                    Cursor = Cursors.Cross;

                    var scXYZ = CreateVector.DenseOfArray<double>(new double[] { e.X, e.Y, 1 });

                    var kwXYZ = scXYZ * MatrixScreenToKW;

                    xValue.Text = kwXYZ[0].ToString("#0.00");
                    yValue.Text = kwXYZ[1].ToString("#0.00");
                    zValue.Text = kwXYZ[2].ToString("#0.00");

                    RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(double.Parse(xValue.Text), double.Parse(yValue.Text), double.Parse(zValue.Text)));
                    return;
                }
                else
                {

                }


            }

            // 在放大
            if (doing == Doing.Zoom)
            {
                startMove = Cursor.Position;
                dragPictrue = true;

            }

            // 在校正
            if (doing == Doing.Rectify)
            {

                controlPtsScreen.Add(new PointF(e.X, e.Y));
                // 如果画板中三个点共线，报错
                if (controlPtsScreen.Count == 3 && IsCollineation(controlPtsScreen[0], controlPtsScreen[1], controlPtsScreen[2]))
                {
                    MessageBox.Show("画板中三点共线，无法建立转换关系");
                    controlPtsScreen.RemoveAt(controlPtsScreen.Count - 1);
                    return;
                }
                if (controlPtsScreen.Count > 3)
                {
                    MessageBox.Show("控制点个数已达到3个，请点击完成校正");
                    return;
                }

                //if (drawMethod == DrawMethod.OnBoard)
                //{

                FrmInputCtrl2 frmInputCtrls = new FrmInputCtrl2(controlPtsKW, controlPtsScreen[controlPtsScreen.Count - 1], doc.ptsForM3);
                frmInputCtrls.ShowDialog();
                if (frmInputCtrls.DialogResult == DialogResult.OK)
                {
                    controlPtsKW.Add(new Point3D(frmInputCtrls.ctrlPtsKW.x, frmInputCtrls.ctrlPtsKW.y, frmInputCtrls.ctrlPtsKW.z));
                    ReDraw();
                }
                // 如果没有保存校正点，则移除刚刚存入的点
                else
                {
                    controlPtsScreen.RemoveAt(controlPtsScreen.Count - 1);
                    return;
                }

            }

        }

        /// <summary>
        /// 用于洞室编录 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown_2(object sender, MouseEventArgs e)
        {
            // 在画线
            if (doing == Doing.DrawLine)
            {
                if (!drawZone.Contains(new PointF(e.X, e.Y)))
                {
                    MessageBox.Show("该点不在洞壁上，请重新绘制");

                    return;
                }

                if (screenLines[screenLines.Count - 1].linePointFs.Count != 0)
                {
                    int tmp = screenLines[screenLines.Count - 1].linePointFs.Count - 1;
                    PointF tmpP = screenLines[screenLines.Count - 1].linePointFs[tmp];
                    if (e.Y > drawZone.Y + caveHeightScreen + 0.001 && tmpP.Y < drawZone.Y + caveHeightScreen - 0.001)
                    {
                        MessageBox.Show("只能在一面墙壁上绘制");
                        return;
                    }
                    if (tmpP.Y > drawZone.Y + caveHeightScreen + caveWidthScreen + 0.001 && e.Y < drawZone.Y + caveHeightScreen + caveWidthScreen - 0.001)
                    {
                        MessageBox.Show("只能在一面墙壁上绘制");
                        return;
                    }
                    if (tmpP.Y < drawZone.Y + caveHeightScreen + caveWidthScreen - 0.001 && tmpP.Y > drawZone.Y + caveHeightScreen + 0.001 &&
                        (e.Y > drawZone.Y + caveHeightScreen + caveWidthScreen + 0.001 || e.Y < drawZone.Y + caveHeightScreen - 0.001))
                    {
                        MessageBox.Show("只能在一面墙壁上绘制");
                        return;
                    }
                }

                var scXYZ = CreateVector.DenseOfArray<double>(new double[] { e.X, e.Y, 1 });
                screenLines[screenLines.Count - 1].linePointFs.Add(new PointF(e.X, e.Y));
                ReDraw();

                double zhuangHao;// 桩号 
                double offsetWidth;// 横向偏移
                double offsetHeight;// 纵向偏移
                zhuangHao = caveLength * (e.X - drawZone.X) / caveLengthScreen;

                if (e.Y >= drawZone.Y + caveHeightScreen && e.Y <= drawZone.Y + caveHeightScreen + caveWidthScreen)
                {
                    offsetHeight = caveHeight;
                    offsetWidth = -caveWidth / 2 * (e.Y - (drawZone.Y + drawZone.Height / 2)) / (caveWidthScreen / 2);
                }
                else if (e.Y >= drawZone.Y && e.Y < drawZone.Y + caveHeightScreen)
                {
                    offsetHeight = caveHeight * (e.Y - drawZone.Y) / caveHeightScreen;
                    offsetWidth = caveWidth / 2;
                }
                else
                {
                    offsetHeight = caveHeight * (drawZone.Y + drawZone.Height - e.Y) / caveHeightScreen;
                    offsetWidth = -caveWidth / 2;
                }
                RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(offsetWidth, offsetHeight, zhuangHao));
                xValue.Text = offsetWidth.ToString("#0.00");
                yValue.Text = offsetHeight.ToString("#0.00");
                zValue.Text = zhuangHao.ToString("#0.00");

                return;


            }

            // 在放大
            if (doing == Doing.Zoom)
            {
                startMove = Cursor.Position;
                dragPictrue = true;

            }


        }




        #endregion


        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (doing == Doing.Zoom)
            {

                startMove = new PointF();
                pictureBox.Refresh();
                ReDraw();
                dragPictrue = false;
            }

        }


        /// <summary>
        /// 放大或缩小过程中，用鼠标拖动图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (dragPictrue)
            {
                float px = Cursor.Position.X - startMove.X;
                float py = Cursor.Position.Y - startMove.Y;

                // DeleteAll();
                bfg.Graphics.TranslateTransform(px, py);
                startMove = Cursor.Position;
                bfg.Graphics.Clear(DrawBackColor);

                ReDraw();
                return;
            }

        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
            return;
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (doing == Doing.DrawLine || doing == Doing.Rectify) Cursor = Cursors.Cross;

        }



        #region 方法



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
            kl.AddKey("-", "{Subtract}", height: 32);
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
        /// 计算出 转换矩阵，用于屏幕坐标转开挖坐标
        /// </summary>
        /// <param name="lp">画板上的坐标</param>
        /// <param name="ls">实际坐标</param>
        private void CalculateMatrixScreenToKW(List<PointF> lp, List<Point3D> ls)
        {
            var mOfScreen = CreateMatrix.DenseOfArray<double>(new double[,] { {lp[0].X,lp[0].Y,1 },
                    { lp[1].X, lp[1].Y, 1 },
                    { lp[2].X, lp[2].Y, 1 } });

            var mOfKW = CreateMatrix.DenseOfArray(new double[,] { { ls[0].X,ls[0].Y,ls[0].Z},
                    { ls[1].X, ls[1].Y, ls[1].Z },
                    { ls[2].X, ls[2].Y, ls[2].Z } });

            MatrixScreenToKW = mOfScreen.Inverse() * mOfKW;

        }

        /// <summary>
        /// 计算转换矩阵， 用于开挖坐标转屏幕坐标
        /// </summary>
        /// <param name="lp">画板上的坐标</param>
        /// <param name="ls">实际坐标</param>
        private void CalculateMatrixKWToScreen(List<PointF> lp, List<Point3D> ls)
        {
            var mOfScreen = CreateMatrix.DenseOfArray<double>(new double[,] { {lp[0].X,lp[0].Y,1 },
                    { lp[1].X, lp[1].Y, 1 },
                    { lp[2].X, lp[2].Y, 1 } });

            var mOfKW = CreateMatrix.DenseOfArray(new double[,] { { ls[0].X,ls[0].Y,ls[0].Z},
                    { ls[1].X, ls[1].Y, ls[1].Z },
                    { ls[2].X, ls[2].Y, ls[2].Z } });

            MatrixKWToScreen = mOfKW.Inverse() * mOfScreen;

        }


        /// <summary>
        /// 判断空间三点是否共线
        /// </summary>
        /// <returns></returns>
        private static bool IsCollineation(Point3D dm1, Point3D dm2, Point3D dm3)
        {
            double e1 = (dm1.X - dm2.X) * (dm3.Y - dm2.Y) - (dm2.X - dm3.X) * (dm2.Y - dm1.Y);
            double e2 = (dm1.X - dm2.X) * (dm3.Z - dm2.Z) - (dm2.X - dm3.X) * (dm2.Z - dm1.Z);
            if (Math.Abs(e1) < 0.005 && Math.Abs(e2) < 0.005) return true;
            return false;
        }
        /// <summary>
        /// 判断平面三点是否共线
        /// </summary>
        /// <param name="dm1"></param>
        /// <param name="dm2"></param>
        /// <param name="dm3"></param>
        /// <returns></returns>
        private static bool IsCollineation(PointF dm1, PointF dm2, PointF dm3)
        {
            double e = (dm1.X - dm2.X) * (dm3.Y - dm2.Y) - (dm2.X - dm3.X) * (dm2.Y - dm1.Y);
            if (Math.Abs(e) < 1e-6) return true;
            return false;
        }



        /// <summary>
        /// 重绘画板上的线
        /// </summary>
        private void ReDraw()
        {
            if (drawMethod == DrawMethod.OnBoard)
            {
                bfg.Graphics.Clear(DrawBackColor);
                if (drawZone != null)
                {
                    // 如果有包络矩形，绘制
                    bfg.Graphics.DrawRectangle(new Pen(Color.Black, 3), drawZone.X, drawZone.Y, drawZone.Width, drawZone.Height);
                }
                if (doc.TypeOfBLHT == "DS")
                {

                    //洞室中的多画两个线
                    bfg.Graphics.DrawLine(new Pen(Color.Black, (float)1.5), drawZone.X, drawZone.Y + (float)caveHeightScreen,
                        drawZone.X + drawZone.Width, drawZone.Y + (float)caveHeightScreen);
                    bfg.Graphics.DrawLine(new Pen(Color.Black, (float)1.5), drawZone.X, drawZone.Y + (float)(caveHeightScreen + caveWidthScreen),
                        drawZone.X + drawZone.Width, drawZone.Y + (float)(caveHeightScreen + caveWidthScreen));
                    // bfg.Graphics.DrawLine(new Pen(Color.Red, (float)1.5), drawZone.X, drawZone.Y + (float)drawZone.Height / 2, drawZone.X + drawZone.Width, drawZone.Y + (float)drawZone.Height / 2);

                    bfg.Graphics.DrawString("右", new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.Black), drawZone.X + 3, drawZone.Y + (float)caveHeightScreen / 2);
                    bfg.Graphics.DrawString("顶", new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.Black), drawZone.X + 3, drawZone.Y + drawZone.Height / 2);
                    bfg.Graphics.DrawString("左", new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.Black), drawZone.X + 3, (float)(drawZone.Y + drawZone.Height - caveHeightScreen / 2));


                }

            }
            if (drawMethod == DrawMethod.OnPicture)
            {
                bfg.Graphics.Clear(DrawBackColor);
                bfg.Graphics.DrawImage(backPicture, drawZone.X, drawZone.Y);

            }
            // 画线
            if (screenLines.Count > 0)
            {
                foreach (var item in screenLines)
                {
                    if (item.linePointFs.Count <= 0) continue;

                    bfg.Graphics.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)item.linePointFs[0].X - 5, (float)item.linePointFs[0].Y - 5, 10, 10);
                    for (int i = 1; i < item.linePointFs.Count; i++)
                    {
                        bfg.Graphics.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)item.linePointFs[i].X - 5, (float)item.linePointFs[i].Y - 5, 10, 10);
                        bfg.Graphics.DrawLine(new Pen(item.Color, (float)2.5),
                            item.linePointFs[i - 1].X, item.linePointFs[i - 1].Y,
                            item.linePointFs[i].X, item.linePointFs[i].Y);
                    }


                }
            }
            RedrawRectifyPointF(bfg.Graphics);
            bfg.Render();

        }
        /// <summary>
        /// 按需求显示按键
        /// </summary>
        /// <param name="strs">btnLoadPictures：加入图片；btnDrawOnBoard：空白绘制；
        /// btnAddLine：添加线；btnCancel：取消；btnRecall：撤消；btnOK：确定；btnRectify：校正；
        /// btnClose：关闭；inputName：名称；inputType：类型；zoom：缩放功能组；inputXYZ：坐标输入功能组</param>
        private void ShowBtnAndItem(string[] strs)
        {
            keyboardControl1.Visible = false;
            numericKeyboard.Visible = false;
            btnLoadPictures.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnLoadPictures")) btnLoadPictures.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnDrawOnBoard.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnDrawOnBoard")) btnDrawOnBoard.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnAddLine")) btnAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnCancel")) btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnRecall")) btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnOK")) btnOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnRectify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnRectify")) btnRectify.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("btnClose")) btnClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            //输入 名字组
            textLineName.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lableLineName.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lineName.Visible = false;
            if (strs.Contains("inputName"))
            {
                lableLineName.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                textLineName.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                lineName.Visible = true;
            }

            //输入类型组
            lbLineType.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            listLinetypes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("inputType"))
            {
                lbLineType.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                listLinetypes.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            // 缩放组
            btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPanorama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (strs.Contains("zoom"))
            {
                btnZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnPanorama.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            //坐标录入组
            lbX.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lbY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lbZ.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ValueX.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ValueY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ValueZ.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCertainForPts.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            xValue.Visible = false;
            yValue.Visible = false;
            zValue.Visible = false;
            if (strs.Contains("inputXYZ"))
            {
                lbX.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                lbY.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                lbZ.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                ValueX.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                ValueY.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                ValueZ.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnCertainForPts.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                xValue.Visible = true;
                yValue.Visible = true;
                zValue.Visible = true;
                listLinetypes.Caption = "请选择";
                lineName.Text = "";
                if (xValue.ReadOnly == false) xValue.Text = "";
                if (yValue.ReadOnly == false) yValue.Text = "";
                if (zValue.ReadOnly == false) zValue.Text = "";
            }

        }

        /// <summary>
        /// 重绘校正点
        /// </summary>
        /// <param name="inG"></param>
        private void RedrawRectifyPointF(Graphics inG)
        {
            //画图
            Pen pen = new Pen(Color.Red);
            Brush brush = new SolidBrush(Color.Red);
            Font font = new Font(FontFamily.GenericMonospace, 15);
            int count = 1;
            foreach (var rectScPointF in this.controlPtsScreen)
            {

                inG.DrawEllipse(pen, rectScPointF.X - 9, rectScPointF.Y - 9, 18, 18);
                inG.FillEllipse(brush, rectScPointF.X - 4, rectScPointF.Y - 4, 8, 8);
                inG.DrawString((count++).ToString(), font, brush, rectScPointF.X, rectScPointF.Y);
            }
        }

        /// <summary>
        /// 计算绘图区域
        /// </summary>
        private void CalculateDrawZone()
        {
            // 如果是洞室，要先确定宽高比
            if (doc.TypeOfBLHT == "DS")
            {
                widthHeightRatio = caveLength / (caveHeight * 2 + caveWidth);
            }


            // 计算绘图区域
            if (widthHeightRatio >= (float)pictureBox.Width / (float)pictureBox.Height)
            {
                drawZone = new RectangleF(0, pictureBox.Height / 2 - (float)(pictureBox.Width / widthHeightRatio) / 2,
                    pictureBox.Width, (float)(pictureBox.Width / widthHeightRatio));

            }
            else
            {
                drawZone = new RectangleF(pictureBox.Width / 2 - (float)(pictureBox.Height * widthHeightRatio) / 2, 0,
                    (float)(pictureBox.Height * widthHeightRatio), pictureBox.Height);

            }
            // 如果是洞室，计算画板上洞室的宽、高、长
            if (doc.TypeOfBLHT == "DS")
            {
                caveWidthScreen = drawZone.Height * caveWidth / (caveHeight * 2 + caveWidth);
                caveHeightScreen = drawZone.Height * caveHeight / (caveHeight * 2 + caveWidth);
                caveLengthScreen = drawZone.Width;
            }
        }




        /// <summary>
        /// 计算平面的四个参数
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        private double[] CalculatePlane(Point3D p1, Point3D p2, Point3D p3)
        {

            //a=0,则平行于x轴；b=0,则平行于y轴；c=0,则平行于z轴；
            double a, b, c, d;
            a = ((p2.Y - p1.Y) * (p3.Z - p1.Z) - (p2.Z - p1.Z) * (p3.Y - p1.Y));
            b = ((p2.Z - p1.Z) * (p3.X - p1.X) - (p2.X - p1.X) * (p3.Z - p1.Z));
            c = ((p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X));
            d = (0 - (a * p1.X + b * p1.Y + c * p1.Z));

            return new double[] { a, b, c, d };
        }



        #endregion



        /// <summary>
        /// 载入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadPictures_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            drawMethod = DrawMethod.OnPicture;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = @"所有图像文件|*.jpg;*.jpeg;*.bmp;*.png|Jpg|*.jpg;*.jpeg|Bmp|*.bmp|Png|*.png|所有文件|*.*",
                Title = @"载入地质图像"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            backPicture = new Bitmap(ofd.FileName);

            //根据图片的尺寸，计算绘图区域
            if (backPicture.Width / backPicture.Height > pictureBox.Width / pictureBox.Height)
            {
                backPicture = new Bitmap(backPicture, pictureBox.Width, backPicture.Height * pictureBox.Width / backPicture.Width);
                drawZone = new RectangleF(0, pictureBox.Height / 2 - backPicture.Height / 2, backPicture.Width, backPicture.Height);

            }
            else
            {
                backPicture = new Bitmap(backPicture, backPicture.Width * pictureBox.Height / backPicture.Height, pictureBox.Height);
                drawZone = new RectangleF(pictureBox.Width / 2 - backPicture.Width / 2, 0, backPicture.Width, backPicture.Height);
            }
            ReDraw();

            ShowBtnAndItem(new string[] { "btnRectify", "btnAddLine", "zoom", "btnRecall", "btnCancel", "btnClose" });

        }
        /// <summary>
        /// 校正控制点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRectify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            doing = Doing.Rectify;

            lableLineName.Caption = "校正点:";

            ShowBtnAndItem(new string[] { "btnRecall", "btnOK", "btnCancel" });

        }


        /// <summary>
        /// 确定画一个点，专用于边坡和基础编录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCertainForPts_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 关闭键盘
            keyboardControl1.Visible = false;
            numericKeyboard.Visible = false;

            //判断 输入的是否为数字
            if (xValue.Text != "")
            {
                try
                {
                    double.Parse(xValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入数值格式错误");
                    xValue.Text = "";
                    return;
                }

            }
            if (yValue.Text != "")
            {
                try
                {
                    double.Parse(yValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入数值格式错误");
                    yValue.Text = "";
                    return;
                }

            }
            if (zValue.Text != "")
            {
                try
                {
                    double.Parse(zValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入数值格式错误");
                    zValue.Text = "";
                    return;
                }

            }


            // 有两个及以上为空，提示
            if ((xValue.Text == "" && yValue.Text == "") || (xValue.Text == "" && zValue.Text == "") || (zValue.Text == "" && yValue.Text == ""))
            {
                MessageBox.Show("请输入完整坐标");
                return;
            }


            if (isEditing)
            {
                // 全有值不可，除非平面和某一轴平行
                if (xValue.Text != "" && yValue.Text != "" && zValue.Text != "" &&
                   (Math.Abs(JBplane[0]) > 1e-6 && Math.Abs(JBplane[1]) > 1e-6 && Math.Abs(JBplane[2]) > 1e-6))
                {
                    // 询问舍弃 X、Y、Z中的哪一个
                    FrmChooseXYZ frmChooseXYZ = new FrmChooseXYZ();
                    frmChooseXYZ.StartPosition = FormStartPosition.CenterParent;
                    frmChooseXYZ.ShowDialog();

                    if (frmChooseXYZ.DialogResult == DialogResult.Yes)
                    {
                        if (xValue.ReadOnly == false)
                        {
                            xValue.Text = "";
                            btnCertainForPts_ItemClick_1(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("该值为只读，不可舍弃");
                        }

                    }
                    else if (frmChooseXYZ.DialogResult == DialogResult.No)
                    {
                        if (yValue.ReadOnly == false)
                        {
                            yValue.Text = "";
                            btnCertainForPts_ItemClick_1(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("该值为只读，不可舍弃");
                        }
                    }
                    else if (frmChooseXYZ.DialogResult == DialogResult.Cancel)
                    {
                        if (zValue.ReadOnly == false)
                        {
                            zValue.Text = "";
                            btnCertainForPts_ItemClick_1(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("该值为只读，不可舍弃");
                        }
                    }
                    return;
                }
                else if (xValue.Text != "" && yValue.Text != "" && zValue.Text != "")
                {
                    // 计算输入 的坐标 是否在边坡平面上
                    double x = double.Parse(xValue.Text);
                    double y = double.Parse(yValue.Text);
                    double z = double.Parse(zValue.Text);
                    double Tmp = -1 * (JBplane[0] * x + JBplane[1] * y + JBplane[2] * z + JBplane[3]);
                    if (Math.Abs(Tmp) > 1)
                    {
                        MessageBox.Show("输入的坐标误差过大，请重新输入");
                    }
                    else
                    {
                        // 将输入的坐标存起
                        var tmpKWVector = CreateVector.DenseOfArray(new double[] { x, y, z });
                        var tmpScreenVector = tmpKWVector * MatrixKWToScreen;
                        PointF tmpScreenP = new PointF((int)(tmpScreenVector[0]), (int)(tmpScreenVector[1]));
                        if (tmpScreenP.X <= 0 || tmpScreenP.X >= pictureBox.Width || tmpScreenP.Y <= 0 || tmpScreenP.Y >= pictureBox.Height)
                        {
                            MessageBox.Show("超出绘制范围，请重新输入并计算");
                        }
                        else
                        {
                            screenLines[screenLines.Count - 1].linePointFs.Add(tmpScreenP);
                            RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(Math.Round(x, 2), Math.Round(y, 2), Math.Round(z, 2)));
                            ReDraw();
                        }

                    }
                    return;

                }


                if (xValue.Text == "")
                {
                    double x;
                    double y = double.Parse(yValue.Text);
                    double z = double.Parse(zValue.Text);

                    //计算边坡平面是否平行于x轴
                    if (Math.Abs(JBplane[0]) > 1e-6)
                    {
                        x = -(JBplane[1] * y + JBplane[2] * z + JBplane[3]) / JBplane[0];
                        xValue.Text = x.ToString("#0.00");

                        var tmpKWVector = CreateVector.DenseOfArray(new double[] { x, y, z });
                        var tmpScreenVector = tmpKWVector * MatrixKWToScreen;
                        PointF tmpScreenP = new PointF((int)(tmpScreenVector[0]), (int)(tmpScreenVector[1]));
                        if (tmpScreenP.X <= 0 || tmpScreenP.X >= pictureBox.Width || tmpScreenP.Y <= 0 || tmpScreenP.Y >= pictureBox.Height)
                        {
                            MessageBox.Show("超出绘制范围，请重新输入并计算");
                            return;
                        }

                        screenLines[screenLines.Count - 1].linePointFs.Add(tmpScreenP);
                        RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(Math.Round(x, 2), Math.Round(y, 2), Math.Round(z, 2)));
                        ReDraw();

                    }
                    else
                    {
                        MessageBox.Show("边坡面平行于x轴，无法计算x坐标值");
                    }
                }
                if (yValue.Text == "")
                {
                    double x = double.Parse(xValue.Text);
                    double y;
                    double z = double.Parse(zValue.Text);
                    //计算边坡平面是否平行于y轴
                    if (Math.Abs(JBplane[1]) > 1e-6)
                    {
                        y = -(JBplane[0] * x + JBplane[2] * z + JBplane[3]) / JBplane[1];
                        yValue.Text = y.ToString("#0.0");
                        var tmpKWVector = CreateVector.DenseOfArray(new double[] { x, y, z });
                        var tmpScreenVector = tmpKWVector * MatrixKWToScreen;
                        PointF tmpScreenP = new PointF((int)(tmpScreenVector[0]), (int)(tmpScreenVector[1]));
                        if (tmpScreenP.X <= 0 || tmpScreenP.X >= pictureBox.Width || tmpScreenP.Y <= 0 || tmpScreenP.Y >= pictureBox.Height)
                        {
                            MessageBox.Show("超出绘制范围，请重新输入并计算");
                            return;
                        }

                        screenLines[screenLines.Count - 1].linePointFs.Add(tmpScreenP);
                        RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(Math.Round(x, 2), Math.Round(y, 2), Math.Round(z, 2)));
                        ReDraw();
                    }
                    else
                    {
                        MessageBox.Show("边坡面平行于y轴，无法计算y坐标值");
                    }
                }
                if (zValue.Text == "")
                {
                    double x = double.Parse(xValue.Text);
                    double y = double.Parse(yValue.Text);
                    double z;
                    //计算边坡平面是否平行于z轴
                    if (Math.Abs(JBplane[2]) > 1e-6)
                    {
                        z = -(JBplane[1] * y + JBplane[0] * x + JBplane[3]) / JBplane[2];
                        zValue.Text = z.ToString("#0.00");

                        var tmpKWVector = CreateVector.DenseOfArray(new double[] { x, y, z });
                        var tmpScreenVector = tmpKWVector * MatrixKWToScreen;
                        PointF tmpScreenP = new PointF((int)(tmpScreenVector[0]), (int)(tmpScreenVector[1]));
                        if (tmpScreenP.X <= 0 || tmpScreenP.X >= pictureBox.Width || tmpScreenP.Y <= 0 || tmpScreenP.Y >= pictureBox.Height)
                        {
                            MessageBox.Show("超出绘制范围，请重新输入并计算");
                            return;
                        }

                        screenLines[screenLines.Count - 1].linePointFs.Add(tmpScreenP);
                        RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(Math.Round(x, 2), Math.Round(y, 2), Math.Round(z, 2)));
                        ReDraw();
                    }
                    else
                    {
                        MessageBox.Show("边坡面平行于z轴，无法计算z坐标值");
                    }
                }
            }
            if (!isEditing && xValue.Text != "" && yValue.Text != "" && zValue.Text != "")
            {

            }

            isEditing = false;
        }

        /// <summary>
        /// 确定画一个点，专用于洞室编录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCertainForPts_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            keyboardControl1.Visible = false;
            numericKeyboard.Visible = false;

            //判断 输入的是否为数字
            if (xValue.Text != "")
            {
                try
                {
                    double.Parse(xValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入数值格式错误");
                    xValue.Text = "";
                    return;
                }

            }
            if (yValue.Text != "")
            {
                try
                {
                    double.Parse(yValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入数值格式错误");
                    yValue.Text = "";
                    return;
                }

            }
            if (zValue.Text != "")
            {
                try
                {
                    double.Parse(zValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入数值格式错误");
                    zValue.Text = "";
                    return;
                }

            }


            // 有两个及以上为空，提示
            if ((xValue.Text == "" && yValue.Text == "") || (xValue.Text == "" && zValue.Text == "") || (zValue.Text == "" && yValue.Text == ""))
            {
                MessageBox.Show("请输入完整坐标");
                return;
            }


            if (isEditing)
            {
                double x = double.Parse(xValue.Text);
                double y = double.Parse(yValue.Text);
                double z = double.Parse(zValue.Text);
                if (x > caveWidth / 2 || x < -caveWidth / 2)
                {
                    MessageBox.Show("该点不在洞壁上，请重新绘制");
                    xValue.Text = "";
                    return;
                }
                if (y < 0 || y > caveHeight)
                {
                    MessageBox.Show("该点不在洞壁上，请重新绘制");
                    yValue.Text = "";
                    return;
                }
                if (z < 0 || z > caveLength)
                {
                    MessageBox.Show("该点不在洞壁上，请重新绘制");
                    zValue.Text = "";
                    return;
                }

                //如果值符合要求，画点
                double pointX;
                double pointY;
                pointX = drawZone.Width * z / caveLength;
                if (x == caveWidth / 2)
                {
                    pointY = drawZone.Y + caveHeightScreen * y / caveHeight;
                }
                else if (x > -caveWidth / 2 && x < caveWidth / 2)
                {
                    if (y < caveHeight)
                    {
                        MessageBox.Show("该点不在洞壁上，请重新绘制");
                        yValue.Text = "";
                        return;
                    }
                    pointY = drawZone.Y + caveHeightScreen + (caveWidthScreen / 2) * (caveWidth / 2 - x) / (caveWidth / 2);
                }
                else
                {
                    pointY = drawZone.Y + drawZone.Height - caveHeightScreen * y / caveHeight;
                }

                screenLines[screenLines.Count - 1].linePointFs.Add(new PointF((float)pointX, (float)pointY));
                RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(x, y, z));
                ReDraw();
            }

            isEditing = false;
        }

        private void xValue_TextChanged(object sender, EventArgs e)
        {
            if (!isEditing) return;
            isEditing = true;

        }

        private void yValue_TextChanged(object sender, EventArgs e)
        {
            if (!isEditing) return;
            isEditing = true;
        }

        private void zValue_TextChanged(object sender, EventArgs e)
        {
            if (!isEditing) return;
            isEditing = true;
        }



        /// <summary>
        /// 窗体加载的同时，加入背景颜色，计算是否有已添加过的线，如果有则导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBLHT_Load(object sender, EventArgs e)
        {

            pictureBox.BackColor = DrawBackColor;

            // 创建双缓冲，防止绘图闪烁
            BufferedGraphicsContext currentBf = BufferedGraphicsManager.Current;
            currentBf.MaximumBuffer = new Size(pictureBox.Width, pictureBox.Height);
            bfg = currentBf.Allocate(pictureBox.CreateGraphics(), pictureBox.DisplayRectangle);

            //读取文件夹中的文件，
            string testPath = @"C:\test\";
            string[] filePaths = Directory.GetFiles(testPath, "*.*", SearchOption.AllDirectories);
            List<string> files = new List<string>();
            // 搜索文件夹中的文件，如果有，则将线画进初始画板
            foreach (var item in filePaths)
            {
                files.Add(Path.GetFileName(item));
            }

            if (files.Contains(doc.SJLYID.ToString() + ".txt"))
            {
                string headFile = File.ReadAllText(testPath + doc.SJLYID.ToString() + ".txt");
                string lineFile = File.ReadAllText(testPath + "Line_" + doc.SJLYID.ToString() + ".txt");
                doc.AllLines = headFile + lineFile;
            }

            // 已存在线，则画出
            if (doc.AllLines != "")
            {
                string[] str = doc.AllLines.Remove(0, 1).Split('#');

                if (doc.TypeOfBLHT == "DS")
                {
                    // 洞室，提取长宽高
                    string[] sizeData = str[0].Split(',');
                    caveWidth = double.Parse(sizeData[0]);
                    caveHeight = double.Parse(sizeData[1]);
                    caveLength = double.Parse(sizeData[2]);


                    CalculateDrawZone();

                    for (int i = 1; i < str.Count(); i++)
                    {

                        string[] theLine = str[i].Split(',');
                        // 画所有线
                        screenLines.Add(new ScreenLine());
                        screenLines[screenLines.Count - 1].Color = Color.CornflowerBlue;
                        RealLines.Add(new RealLine());
                        RealLines[RealLines.Count - 1].GUID = theLine[0];
                        RealLines[RealLines.Count - 1].Name = theLine[1];
                        RealLines[RealLines.Count - 1].Type = theLine[2];

                        for (int j = 3; j < theLine.Count(); j += 3)
                        {
                            double tmpx = double.Parse(theLine[j]);
                            double tmpy = double.Parse(theLine[j + 1]);
                            double tmpz = double.Parse(theLine[j + 2]);


                            double pointX;
                            double pointY;
                            pointX = drawZone.Width * tmpz / caveLength;
                            if (tmpx == caveWidth / 2)
                            {
                                pointY = drawZone.Y + caveHeightScreen * tmpy / caveHeight;
                            }
                            else if (tmpx > -caveWidth / 2 && tmpx < caveWidth / 2)
                            {
                                pointY = drawZone.Y + caveHeightScreen + (caveWidthScreen / 2) * (caveWidth / 2 - tmpx) / (caveWidth / 2);
                            }
                            else
                            {
                                pointY = drawZone.Y + drawZone.Height - caveHeightScreen * tmpy / caveHeight;
                            }

                            screenLines[screenLines.Count - 1].linePointFs.Add(new PointF((float)pointX, (float)pointY));
                            RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(tmpx, tmpy, tmpz));
                        }
                    }

                }
                else
                {

                    // 边坡或基础，先导入屏幕控制点和实际控制点
                    string[] downLoadCtrlPtsScreen = str[0].Split(',');
                    for (int i = 0; i < downLoadCtrlPtsScreen.Count(); i += 2)
                    {
                        float tmpx = float.Parse(downLoadCtrlPtsScreen[i]);
                        float tmpy = float.Parse(downLoadCtrlPtsScreen[i + 1]);
                        controlPtsScreen.Add(new PointF(tmpx, tmpy));
                    }
                    string[] downLoadCtrlPtsReal = str[0 + 1].Split(',');
                    for (int i = 0; i < downLoadCtrlPtsReal.Count(); i += 3)
                    {
                        double tmpx = double.Parse(downLoadCtrlPtsReal[i]);
                        double tmpy = double.Parse(downLoadCtrlPtsReal[i + 1]);
                        double tmpz = double.Parse(downLoadCtrlPtsReal[i + 2]);
                        controlPtsKW.Add(new Point3D(tmpx, tmpy, tmpz));
                    }
                    CalculateMatrixScreenToKW(controlPtsScreen, controlPtsKW);
                    CalculateMatrixKWToScreen(controlPtsScreen, controlPtsKW);
                    JBplane = CalculatePlane(controlPtsKW[0], controlPtsKW[1], controlPtsKW[2]);
                    ShowBtnAndItem(new string[] { "btnAddLine", "btnClose", "zoom" });


                    CalculateDrawZone();
                    if (Math.Abs(drawZone.X - controlPtsScreen[0].X) + Math.Abs(drawZone.Y + drawZone.Height - controlPtsScreen[0].Y) +
                        Math.Abs(drawZone.X + drawZone.Width - controlPtsScreen[1].X) + Math.Abs(drawZone.Y + drawZone.Height - controlPtsScreen[1].Y) > 1e-3)
                    {
                        drawZone = new RectangleF();
                    }
                    for (int i = 0 + 2; i < str.Count(); i++)
                    {

                        string[] theLine = str[i].Split(',');
                        // 画所有线
                        screenLines.Add(new ScreenLine());
                        RealLines.Add(new RealLine());
                        RealLines[RealLines.Count - 1].GUID = theLine[0];
                        RealLines[RealLines.Count - 1].Name = theLine[1];
                        RealLines[RealLines.Count - 1].Type = theLine[2];


                        for (int j = 3; j < theLine.Count(); j += 3)
                        {
                            double tmpx = double.Parse(theLine[j]);
                            double tmpy = double.Parse(theLine[j + 1]);
                            double tmpz = double.Parse(theLine[j + 2]);

                            RealLines[RealLines.Count - 1].linePoints.Add(new Point3D(tmpx, tmpy, tmpz));

                            var tmpKWVector = CreateVector.DenseOfArray(new double[] { tmpx, tmpy, tmpz });
                            var tmpScreenVector = tmpKWVector * MatrixKWToScreen;
                            PointF tmpScreenP = new PointF((int)(tmpScreenVector[0]), (int)(tmpScreenVector[1]));
                            screenLines[screenLines.Count - 1].linePointFs.Add(tmpScreenP);
                        }
                    }
                }


            }
            ReDraw();

            if (doc.TypeOfBLHT == "BP" || doc.TypeOfBLHT == "JC")
            {
                pictureBox.MouseDown += pictureBox_MouseDown_1;
                btnCertainForPts.ItemClick += btnCertainForPts_ItemClick_1;
            }
            else if (doc.TypeOfBLHT == "DS")
            {
                pictureBox.MouseDown += pictureBox_MouseDown_2;
                btnCertainForPts.ItemClick += btnCertainForPts_ItemClick_2;
                lbX.Caption = "横向偏移:";

                lbY.Caption = "纵向偏移:";
                lbZ.Caption = "桩号:";
                xValue.Location = new Point(xValue.Location.X + 41, xValue.Location.Y);
                yValue.Location = new Point(yValue.Location.X + 82, yValue.Location.Y);
                zValue.Location = new Point(zValue.Location.X + 100, zValue.Location.Y);

                ShowBtnAndItem(new string[] { "btnAddLine", "zoom", "btnClose" });
                if (doc.AllLines == "")
                {
                    caveLength = Math.Abs((doc.CtrlPts[0].X - doc.CtrlPts[1].X) * (doc.CtrlPts[0].X - doc.CtrlPts[1].X) +
                                        (doc.CtrlPts[0].Y - doc.CtrlPts[1].Y) * (doc.CtrlPts[0].Y - doc.CtrlPts[1].Y) +
                                        (doc.CtrlPts[0].Z - doc.CtrlPts[1].Z) * (doc.CtrlPts[0].Z - doc.CtrlPts[1].Z));

                    caveWidth = doc.CaveWidth;
                    caveHeight = doc.CaveHeight;
                }

            }

        }

        /// <summary>
        /// 如果初始有线，则初始化画板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (drawMethod == DrawMethod.OnBoard && doc.AllLines != "")
            {
                e.Graphics.Clear(DrawBackColor);
                if (drawZone != null)
                {
                    // 如果有包络矩形，绘制
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 3), drawZone.X, drawZone.Y, drawZone.Width, drawZone.Height);
                }
                if (doc.TypeOfBLHT == "DS")
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, (float)1.5), drawZone.X, drawZone.Y + (float)caveHeightScreen,
                        drawZone.X + drawZone.Width, drawZone.Y + (float)caveHeightScreen);
                    e.Graphics.DrawLine(new Pen(Color.Black, (float)1.5), drawZone.X, drawZone.Y + (float)(caveHeightScreen + caveWidthScreen),
                        drawZone.X + drawZone.Width, drawZone.Y + (float)(caveHeightScreen + caveWidthScreen));
                    e.Graphics.DrawString("右", new Font(FontFamily.GenericMonospace, 12),
                        new SolidBrush(Color.Black), drawZone.X + 3, drawZone.Y + (float)caveHeightScreen / 2);
                    e.Graphics.DrawString("顶", new Font(FontFamily.GenericMonospace, 12),
                        new SolidBrush(Color.Black), drawZone.X + 3, drawZone.Y + drawZone.Height / 2);
                    e.Graphics.DrawString("左", new Font(FontFamily.GenericMonospace, 12),
                        new SolidBrush(Color.Black), drawZone.X + 3, (float)(drawZone.Y + drawZone.Height - caveHeightScreen / 2));

                }

            }
            if (drawMethod == DrawMethod.OnPicture)
            {
                e.Graphics.Clear(DrawBackColor);
                e.Graphics.DrawImage(backPicture, drawZone.X, drawZone.Y);

            }
            // 画线
            if (screenLines.Count > 0)
            {
                foreach (var item in screenLines)
                {
                    if (item.linePointFs.Count <= 0) continue;

                    e.Graphics.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)item.linePointFs[0].X - 5, (float)item.linePointFs[0].Y - 5, 10, 10);
                    for (int i = 1; i < item.linePointFs.Count; i++)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(Color.CornflowerBlue), (float)item.linePointFs[i].X - 5, (float)item.linePointFs[i].Y - 5, 10, 10);
                        e.Graphics.DrawLine(new Pen(Color.MediumSlateBlue, (float)2.5),
                            item.linePointFs[i - 1].X, item.linePointFs[i - 1].Y,
                            item.linePointFs[i].X, item.linePointFs[i].Y);
                    }
                }
            }
            RedrawRectifyPointF(e.Graphics);

        }
    }
}
