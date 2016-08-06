using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stdole;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
    //Ts部件，仅用于存储部件，不用于展示（除了三维TIN面）
    class TsFile
    {
        public string Guid { get; private set; }
        //几何类型：线PLine、面TSurf、区域PLine
        public string Type { get; private set; }

        public string FilePath { get; set; }

        public string Name { get; set; }

        public TsData TsData { get; } = new TsData();

        //构造函数：

        //重构1：适用三维场景(线、区域)
        public TsFile(ITerraExplorerObject66 inObj, string type)
        {
            Guid = System.Guid.NewGuid().ToString();
            Type = type;
            
            //线：PLine
            if (type == "Line")
            {
                
                var inLine = inObj as ITerrainPolyline66;
                var inPoints = inLine?.Geometry as ILineString;
                if (inPoints != null) 
                { 
                    foreach (var objPoint in inPoints.Points)
                    {
                        TsData.VerticesList.Add(new Point(objPoint as IPoint));
                    }
                }
            }

            //区域：边界PLine - 读取时注意！
            if (type == "Region")
            {
                var inRegion = inObj as ITerrainPolygon66;
                var inPoints = inRegion?.Geometry as ILinearRing;
                if (inPoints != null)
                {
                    foreach (var objPoint in inPoints.Points)
                    {
                        TsData.VerticesList.Add(new Point(objPoint as IPoint));
                    }
                }
                
            }
            
        }

        //重构2：适用二维图像(线、半平面)
        public TsFile(List<Point> pointsList)
        {
            Type = "Line";
            TsData.VerticesList = pointsList;
        }

        //重构3：适用任意情况（线、区域、面）
        public TsFile(TsData inTsData, string type)
        {
            Type = type;
            TsData = inTsData;
        }

        //重构4：读取Ts文件
        public TsFile(FileStream file)
        {
            
        }

        //写TS文件，以FilePath路径保存。
        public void WriteTsFile()
        {
            /*
            将TsData里记录的信息按照格式要求写进文件里，并把文件路径存入FilePath中。
            格式要求详见我给你发的“GoCad Data File Format”
            注意：
            1.需要先判断该对象的类型，再选择保存格式类型。
            （线“Line”,保存为PLine格式；
              区域“Region”,将多边形边界视为线环，保存PLine；
              面“Surface”,保存为TSurf格式。）
            2.文件Header的信息，参考示例文件。不明白什么意思的就问qq讨论组，可以根据需要给这个类添加属性。如果添加了属性，先不用管这个字段或属性的初始化和赋值，后续我来写。
            3.文件坐标信息，参考示例文件，可以照搬。
            4.思考如何进行测试。示例测试框架见主界面FrmMain的“临时测试”按钮代码，数据自己编。
            */
            switch (Type)
            {
                case "Region":
                case "Line":
                    {

                        var savets = new SaveFileDialog {Filter = @"part文件(*.part)|*.part|所有文件(*.*)|*.*"};
                        var result = savets.ShowDialog();
                        if (result != DialogResult.OK) return;
                        FilePath = savets.FileName;
                        var ts1 = new StreamWriter(FilePath, false, Encoding.Default);

                        ts1.WriteLine("GOCAD PLine 1");
                        ts1.WriteLine("HEADER {");
                        ts1.WriteLine("name:" + Name);
                        ts1.WriteLine("chidi_typeguid:");
                        ts1.WriteLine("chidi_typestr:" + Type);
                        ts1.WriteLine("chidi_objguid:");
                        ts1.WriteLine("chidi_cnname:");
                        ts1.WriteLine("bosl:");
                        ts1.WriteLine("chidi_cgObjType:");
                        ts1.WriteLine("*solid*color:");
                        ts1.WriteLine("ivolmap:false");
                        ts1.WriteLine("imap:false");
                        ts1.WriteLine("chi_conobj:");
                        ts1.WriteLine("mesh:on");//?
                        ts1.WriteLine("cn:on");
                        ts1.WriteLine("}");
                        ts1.WriteLine("GOCAD_ORIGINAL_COORDINATE_SYSTEM");
                        ts1.WriteLine("NAME Default");
                        ts1.WriteLine("AXIS_NAME \"X\" \"Y\" \"Z\"");
                        ts1.WriteLine("AXIS_UNIT \"m\" \"m\" \"m\"");
                        ts1.WriteLine("ZPOSITIVE Elevation");
                        ts1.WriteLine("END_ORIGINAL_COORDINATE_SYSTEM");
                        ts1.WriteLine("PLine");

                        for (int i = 0; i < TsData.VerticesList.Count; i++)
                        {
                            ts1.WriteLine("VART" + " " + (i + 1) + " " + TsData.VerticesList[i].X + " " + TsData.VerticesList[i].Y + " " + TsData.VerticesList[i].Z);
                        }

                        for (int i = 0; i < TsData.VerticesList.Count - 1; i++)
                        {
                            ts1.WriteLine("SEG" + " " + (i + 1) + (i + 2));
                        }
                        ts1.WriteLine("END");
                        ts1.Close();


                    }
                    break;


                case "Surface":
                    {

                        var savets = new SaveFileDialog {Filter = "part文件(*.part)|*.part|所有文件(*.*)|*.*"};
                        var result = savets.ShowDialog();
                        if (result != DialogResult.OK) return;
                        
                        FilePath = savets.FileName;
                        var ts1 = new StreamWriter(FilePath, false, Encoding.Default);
                        ts1.WriteLine("GOCAD TSurf 1");
                        ts1.WriteLine("HEADER {");
                        ts1.WriteLine("name:" + Name);
                        ts1.WriteLine("chidi_typeguid:");
                        ts1.WriteLine("chidi_typestr:" + Type);
                        ts1.WriteLine("chidi_objguid:");
                        ts1.WriteLine("chidi_cnname:");
                        ts1.WriteLine("bosl:");
                        ts1.WriteLine("chidi_cgObjType:");
                        ts1.WriteLine("*solid*color:");
                        ts1.WriteLine("ivolmap:false");
                        ts1.WriteLine("imap:false");
                        ts1.WriteLine("chi_conobj:");
                        ts1.WriteLine("mesh:on");
                        ts1.WriteLine("cn:on");
                        ts1.WriteLine("}");
                        ts1.WriteLine("GOCAD_ORIGINAL_COORDINATE_SYSTEM");
                        ts1.WriteLine("NAME Default");
                        ts1.WriteLine("AXIS_NAME \"X\" \"Y\" \"Z\"");
                        ts1.WriteLine("AXIS_UNIT \"m\" \"m\" \"m\"");
                        ts1.WriteLine("ZPOSITIVE Elevation");
                        ts1.WriteLine("END_ORIGINAL_COORDINATE_SYSTEM");
                        ts1.WriteLine("TFACE");
                        for (int i = 0; i < TsData.VerticesList.Count; i++)
                        {
                            ts1.WriteLine("VART" + " " + (i + 1) + " " + TsData.VerticesList[i].X + " " + TsData.VerticesList[i].Y + " " + TsData.VerticesList[i].Z);
                        }
                        for (int i = 0; i < TsData.TriLinksList.Count; i++)
                        {
                            ts1.WriteLine("TRGL" + " " + TsData.TriLinksList[i].VertexA + " " + TsData.TriLinksList[i].VertexB + " " + TsData.TriLinksList[i].VertexC);
                        }
                        double max_vert_z = 0, max2_vert_z = 0;
                        int num_max_vert_z = 0, num_max2_vert_z = 0;
                        for (int i = 0; i < TsData.VerticesList.Count; i++)
                        {
                            if (max_vert_z < TsData.VerticesList[i].Z)
                            {
                                max_vert_z = TsData.VerticesList[i].Z;
                                num_max_vert_z = i + 1;
                            }

                        }
                        for (int i = 0; i < TsData.VerticesList.Count; i++)
                        {
                            if (max2_vert_z < TsData.VerticesList[i].Z && i != num_max_vert_z - 1)
                            {
                                max2_vert_z = TsData.VerticesList[i].Z;
                                num_max2_vert_z = i + 1;
                            }

                        }

                        ts1.WriteLine("BSTONE " + num_max_vert_z);
                        ts1.WriteLine("BORDER " + (TsData.VerticesList.Count + 1) + " " + num_max_vert_z + " " + num_max2_vert_z);
                        ts1.WriteLine("END");
                        ts1.Close();

                        
                    }
                    break;
            }
        }

        public void UpdateTsFile(ref YWCHEntEx db)
        {
            FilePath = db.SkyGetPartNewContent(Guid);
        }
    }
}
