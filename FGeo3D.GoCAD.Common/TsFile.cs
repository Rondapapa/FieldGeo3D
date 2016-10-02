using System.Collections.Generic;
using System.IO;
using System.Text;
using MathNet.Spatial.Euclidean;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D.GoCAD
{
    using System.Linq;

    //Ts部件，仅用于存储部件，不用于展示（除了三维TIN面）
    public class TsFile
    {
        //保存：点线面地质对象类型的guid
        public static Dictionary<string, string> DictOfGeoMarkerTypeToGuid = new Dictionary<string, string>
        {
            {"D-DXDM", "3c896b17-51c4-410e-b0cf-d4e0b59fe417" },
            {"D-DCYX", "16a3cf62-5865-4dbf-9244-1921ea368884" },
            {"D-GZFD", "7dd45758-f6c8-49f0-9fff-1ce315ed4679" },
            {"D-ZZ", "7dd45758-f6c8-49f0-9fff-1ce315ed4679" },
            {"D-JGM", "7dd45758-f6c8-49f0-9fff-1ce315ed4679" },
            {"D-FH", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-XH", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-NSL", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-HP", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-BT", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-RB", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-YR", "c736cb26-80fb-4964-913f-6cc2ff20cec1" },
            {"D-DXSFD", "dff65fa7-a414-4432-9ac1-a347e5a6ed36" },
            {"D-TTFC", "e52f632a-0423-4f0a-b4db-6de2a66b2b77" },
            {"D-YTFL", "e52f632a-0423-4f0a-b4db-6de2a66b2b77" },

            {"X-DXDM", "642eac1f-33a3-46f7-851e-271c06871642" },
            {"X-DCYX", "7aeb6674-db4f-44fb-b750-7bba1d6ee1a1" },
            {"X-GZFD", "0ba11a41-ce84-44d0-aefd-ff0554c430c9" },
            {"X-ZZ", "0ba11a41-ce84-44d0-aefd-ff0554c430c9" },
            {"X-JGM", "0ba11a41-ce84-44d0-aefd-ff0554c430c9" },
            {"X-FH", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-XH", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-NSL", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-HP", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-BT", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-RB", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-YR", "a3124e0e-360d-4365-80a8-b603a9ec2807" },
            {"X-DXSFD", "71fb3a21-ab89-47e8-9ca5-10a781e1ec4c" },
            {"X-TTFC", "e67279f1-a418-4726-8223-e1e27b8cd516" },
            {"X-YTFL", "e67279f1-a418-4726-8223-e1e27b8cd516" },

            {"M-DXDM", "e589c110-91c4-4483-85e8-5340a1adc468" },
            {"M-DCYX", "9cae23ba-52b7-4df6-8ef3-0c7003f0595a" },
            {"M-GZFD", "ea627b90-8f16-4048-9d6d-5e056f32aab0" },
            {"M-ZZ", "ea627b90-8f16-4048-9d6d-5e056f32aab0" },
            {"M-JGM", "ea627b90-8f16-4048-9d6d-5e056f32aab0" },
            {"M-FH", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-XH", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-NSL", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-HP", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-BT", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-RB", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-YR", "4cf53bcd-f3bc-48a1-8787-d76f54d77d0a" },
            {"M-DXSFD", "22d488c0-3a82-4755-b3a8-57f1374cdf69" },
            {"M-TTFC", "b84f6f98-61b8-4907-943f-76ddf0343ab4" },
            {"M-YTFL", "b84f6f98-61b8-4907-943f-76ddf0343ab4" },
        };

        //保存路径
        public string FilePath { get; set; }

        //Guid
        public string Guid { get; } = System.Guid.NewGuid().ToString();

        //名称
        public string Name { get; set; }

        //Skyline模型类型：Line、Region等
        public string SkylineType { get; set; }

        //TS类型：线PLine、面TSurf、区域PLine
        public string TsType { get; }

        //几何类型：D（点）等
        public string GeoType { get; }

        //地质对象类型：DCYX（地层岩性）等
        public string MarkerType { get; }

        //关联地质对象Guid列表
        public List<string> ConnObjGuids { get; } = new List<string>();

        //Ts数据
        public TsData TsData { get; } = new TsData();




#region 构造函数        
        /// <summary>
        /// 构造函数1：适用于三维场景（画线、画区域）
        /// </summary>
        /// <param name="inObj">Skyline几何对象</param>
        /// <param name="skylineType">Skyline模型类型：Line、Region等</param>
        /// <param name="tsType">TS类型：线PLine、面TSurf、区域PLine</param>
        /// <param name="geoType">几何类型：D（点）等</param>
        /// <param name="markerType">地质对象类型：DCYX（地层岩性）等</param>
        /// <param name="name">名称</param>
        /// <param name="connGuids">关联地质对象Guid列表</param>
        public TsFile(ITerraExplorerObject66 inObj, string skylineType, string tsType, string geoType, string markerType, string name, List<string> connGuids)
        {
            TsType = tsType;
            GeoType = geoType;
            MarkerType = markerType;
            Name = name;
            ConnObjGuids = connGuids;

            //线：PLine
            if (skylineType == "Line")
            {
                TsType = "PLine";
                var inLine = inObj as ITerrainPolyline66;
                var inPoints = inLine?.Geometry as ILineString;
                if (inPoints == null) return; 
                foreach (var objPoint in inPoints.Points)
                {
                    var point = objPoint as IPoint;
                    if (point != null)
                        TsData.VerticesList.Add(new Point3D(point.X, point.Y, point.Z));
                }
            }

            //区域：边界PLine - 读取时注意！
            if (skylineType == "Region")
            {
                TsType = "PLine";
                var inRegion = inObj as ITerrainPolygon66;
                var inPoints = inRegion?.Geometry as ILinearRing;
                if (inPoints == null) return;
                foreach (var objPoint in inPoints.Points)
                {
                    var point = objPoint as IPoint;
                    if (point != null)
                        TsData.VerticesList.Add(new Point3D(point.X, point.Y, point.Z));
                }
            }
            
        }

        
        /// <summary>
        /// 构造函数2：适用于二维图像（延伸平面）
        /// </summary>
        /// <param name="inPointsList">点集列表</param>
        /// <param name="tsType">TS类型：线PLine、面TSurf、区域PLine</param>
        /// <param name="geoType">几何类型：D（点）等</param>
        /// <param name="markerType">地质对象类型：DCYX（地层岩性）等</param>
        /// <param name="name">名称</param>
        /// <param name="connGuids">关联地质对象Guid列表</param>
        public TsFile(IEnumerable<Point3D> inPointsList, string tsType, string geoType, string markerType, string name, List<string> connGuids )
        {
            TsType = tsType;
            GeoType = geoType;
            MarkerType = markerType;
            Name = name;
            ConnObjGuids = connGuids;

            foreach (var thisPoint in inPointsList)
            {
                TsData.VerticesList.Add(new Point3D(thisPoint.X, thisPoint.Y, thisPoint.Z));
            }
            if (TsData.VerticesList.Count == 0) return;
            if (TsType == "TSurf")
            {
                for (int index = 1; index < TsData.VerticesList.Count / 2; ++index)
                {
                    TsData.TriLinksList.Add(new TriLink
                    {
                        VertexA = index,
                        VertexB = index + 1,
                        VertexC = index + TsData.VerticesList.Count / 2
                    });
                    TsData.TriLinksList.Add(new TriLink
                    {
                        VertexA = index + 1,
                        VertexB = index + TsData.VerticesList.Count / 2,
                        VertexC = index + TsData.VerticesList.Count / 2 + 1
                    });
                }
            }
        }

        /// <summary>
        /// 构造函数3：适用于地质曲面
        /// </summary>
        /// <param name="inTsData">地质曲面TsData文件</param>
        /// <param name="tsType">TS类型：线PLine、面TSurf、区域PLine</param>
        public TsFile(TsData inTsData, string tsType)
        {
            TsType = tsType;
            TsData = inTsData;
        }

        /// <summary>
        /// 构造函数4：适用于地质曲面
        /// </summary>
        /// <param name="tsData"></param>
        /// <param name="tsType"></param>
        /// <param name="geoType"></param>
        /// <param name="markerType"></param>
        /// <param name="name"></param>
        /// <param name="connGuids"></param>
        public TsFile(TsData tsData, string tsType, string geoType, string markerType, string name, List<string> connGuids)
        {
            TsData = tsData;
            TsType = tsType;
            GeoType = geoType;
            MarkerType = markerType;
            Name = name;
            ConnObjGuids = connGuids;
        }


        /// <summary>
        /// 构造函数5：从文件中读取Ts信息
        /// </summary>
        /// <param name="file">Ts文件流</param>
        public TsFile(FileStream file)
        {
            
        }


        

#endregion

        /// <summary>
        /// 根据几何类型和地质对象类型，获取ts文件所需的TypeGuid
        /// </summary>
        /// <param name="connObjsName"></param>
        /// <returns></returns>
        public string GetConnObjGuidsString(string connObjsName = "")
        {
            StringBuilder result = new StringBuilder();
            result.Append(connObjsName);
            foreach (var guid in ConnObjGuids)
            {
                result.Append("#" + guid);
            }
            return result.ToString();
        }


        /// <summary>
        /// 写TS文件，以FilePath路径保存。
        /// </summary>
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

            //var savets = new SaveFileDialog { Filter = @"part文件(*.part)|*.part|所有文件(*.*)|*.*" };
            //var result = savets.ShowDialog();
            //if (result != DialogResult.OK) return;
            //FilePath = savets.FileName;

            var currentDirectory = Directory.GetCurrentDirectory();

            var pathString = Path.Combine(currentDirectory, "PartsToBeUpload");
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }
            var fileName = Guid + ".part";
            FilePath = Path.Combine(pathString, fileName);

            var ts = new StreamWriter(FilePath, false, Encoding.Default);

            //以下开始写Ts文件
            //头
            ts.WriteLine("GOCAD " + TsType + " 1");
            ts.WriteLine("HEADER {");
            ts.WriteLine("name:" + Name);
            ts.WriteLine("chidi_typeguid:" + DictOfGeoMarkerTypeToGuid[GeoType + "-" + MarkerType]);//地质对象类型Guid
            ts.WriteLine("chidi_typestr:" + MarkerType);//地质对象类型
            ts.WriteLine("chidi_objguid:" + Guid);//地质对象Guid
            ts.WriteLine("chidi_cnname:" + Name);//中文名
            ts.WriteLine("bosl:on");
            ts.WriteLine("chidi_cgObjType:238DED4F-7093-4b15-9DFC-F9D0C63CAFA6");//地质对象C++类:默认为部件最新可用版本
            ts.WriteLine("*solid*color:0.854902 0.666667 0 1");//颜色确定？
            ts.WriteLine("ivolmap:false");
            ts.WriteLine("imap:false");
            ts.WriteLine("chi_conobj:" + GetConnObjGuidsString("test_pts"));//关联地质对象的guid
            ts.WriteLine("mesh:on");
            ts.WriteLine("cn:on");
            ts.WriteLine("}");

            //参考系
            ts.WriteLine("GOCAD_ORIGINAL_COORDINATE_SYSTEM");
            ts.WriteLine("NAME Default");
            ts.WriteLine("AXIS_NAME \"X\" \"Y\" \"Z\"");
            ts.WriteLine("AXIS_UNIT \"m\" \"m\" \"m\"");
            ts.WriteLine("ZPOSITIVE Elevation");
            ts.WriteLine("END_ORIGINAL_COORDINATE_SYSTEM");
            switch (TsType)
            {
                case "PLine":
                    ts.WriteLine("ILINE");
                    break;
                case "TSurf":
                    ts.WriteLine("TFACE");
                    break;
            }
            
            //点
            for (var i = 0; i < TsData.VerticesList.Count; i++)
            {
                ts.WriteLine("VRTX" + " " + (i + 1) + " " + TsData.VerticesList[i].X + " " + TsData.VerticesList[i].Y + " " + TsData.VerticesList[i].Z);
            }

            //线
            if (TsType == "PLine")
            {
                for (var i = 0; i < TsData.VerticesList.Count - 1; i++)
                {
                    ts.WriteLine("SEG" + " " + (i + 1) + " " + (i + 2));
                }
                if (SkylineType == "Region")
                {
                    ts.WriteLine("SEG" + " " + (TsData.VerticesList.Count - 1) + " 1");
                }
            }

            //面
            else
            {
                for (var i = 0; i < TsData.TriLinksList.Count; i++)
                {
                    ts.WriteLine("TRGL" + " " + TsData.TriLinksList[i].VertexA + " " + TsData.TriLinksList[i].VertexB + " " + TsData.TriLinksList[i].VertexC);
                }

                //double maxVertZ = 0, max2VertZ = 0;
                //int numMaxVertZ = 0, numMax2VertZ = 0;
                //for (var i = 0; i < TsData.VerticesList.Count; i++)
                //{
                //    if (!(maxVertZ < TsData.VerticesList[i].Z)) continue;
                //    maxVertZ = TsData.VerticesList[i].Z;
                //    numMaxVertZ = i + 1;
                //}
                //for (var i = 0; i < TsData.VerticesList.Count; i++)
                //{
                //    if (!(max2VertZ < TsData.VerticesList[i].Z) || i == numMaxVertZ - 1) continue;
                //    max2VertZ = TsData.VerticesList[i].Z;
                //    numMax2VertZ = i + 1;
                //}
                //ts.WriteLine("BSTONE " + numMaxVertZ);
                //ts.WriteLine("BORDER " + (TsData.VerticesList.Count + 1) + " " + numMaxVertZ + " " + numMax2VertZ);


                List<Point3D> sortedListPoint3D = new List<Point3D>(this.TsData.VerticesList.OrderBy(p => p.Z));
                int numMaxVertZ = this.TsData.VerticesList.IndexOf(sortedListPoint3D[sortedListPoint3D.Count - 1]) + 1;
                int numMax2VertZ = this.TsData.VerticesList.IndexOf(sortedListPoint3D[sortedListPoint3D.Count - 2]) + 1;
                ts.WriteLine("BSTONE " + numMaxVertZ);
                ts.WriteLine("BORDER " + sortedListPoint3D.Count + " " + numMaxVertZ + " " + numMax2VertZ);
            }

            //尾
            ts.WriteLine("END");

            //关闭
            ts.Close();

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="db"></param>
        public void UpdateTsFile(ref YWCHEntEx db)
        {
            FilePath = db.SkyGetPartNewContent(Guid);
        }
    }
}
