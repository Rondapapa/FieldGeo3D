using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FGeo3D.GeoObj;
using FGeo3D.GeoCurvedSurface;
using FGeo3D.LoggingObj;
using TerraExplorerX;

namespace FGeo3D.GeoCurvedSurface
{
    /// <summary>
    /// 根据选定的LoggingObject集合，分析其共有的marker，整理归类后输出。
    /// </summary>
    public static class Extractor
    {
        //选定的LoggingObject集合中，按照markerType、useFor、Marker列表，一一对应，输出
        public static List<Point> GetPointListOf(List<LoggingObject> listOfLoggingObjects, string markerType, string useFor)
        {
            var list = new List<Point>();
            foreach (var loggingObj in listOfLoggingObjects)
            {
                var markerList = loggingObj.Markers01;
                for (var index = 0; index < markerList.Count; ++index)
                {
                    var marker = markerList.GetMarker(index);
                    if (markerType == marker.Type && useFor == marker.UseFor)
                    {
                        list.Add(new Point(marker));
                    }

                }
            }
            return list;
        }
        
        
    }
}
