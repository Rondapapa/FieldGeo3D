using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stdole;
using TerraExplorerX;

namespace FGeo3D_TE
{
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

            //区域：PLine - 读取时注意！
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
                //标定区域：以Ts格式存储。
            }
            
        }

        //重构2：适用二维图像(线、半平面)
        public TsFile(List<Point> pointsList , string type)
        {
            TsData.VerticesList = pointsList;
        }

        //重构3：适用地质趋势面
        public TsFile(TsData inTsData)
        {
            TsData = inTsData;
        }

        //写TS文件，以FilePath路径保存。
        public void WriteTsFile()
        {
            
        }
    }
}
