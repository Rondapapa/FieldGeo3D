using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using GeoIM.CHIDI.DZ.COM.Common;
using TerraExplorerX;

namespace FGeo3D_TE
{
    public enum LoggingType
    {
        Bore, Footrill, Pit, Well, Trench, Spot, Slope, Cavity, Foundation
    }

    class LoggingObject
    {
        private readonly IObjData _dataObj; //GeoSmart对象
        protected ITerraExplorerObject66 _skylineMouthObj;
        protected ITerraExplorerObject66 _skylineBodyObj;
        protected ITerraExplorerObject66 _skylineLabelObj;

        public string Guid => _dataObj.Guid;
        public string BH => _dataObj.BH;
        public string Name => _dataObj.Name;
        public string sType => _dataObj.Type;

        public GeoPoint Top { get; set; }
        public GeoPoint Bottom { get; set; }
        public double Depth => Top.Z - Bottom.Z;

        public IGMarkerList Markers01 { get; set; }
        public IGMarkerList Markers02 { get; set; }
        public IGMarkerList Markers03 { get; set; }

        


        public string SkylineId => _skylineMouthObj.ID;
        public ObjectTypeCode SkylineType => _skylineMouthObj.ObjectType;

        public LoggingType Type { get; set; }


        public static Dictionary<string, LoggingObject> DictOfLoggingObjects = new Dictionary<string, LoggingObject>();

        /*
        public static Hashtable Bores = new Hashtable();
        public static Hashtable Footrills = new Hashtable();
        public static Hashtable Pits = new Hashtable();
        public static Hashtable Wells = new Hashtable();
        public static Hashtable Trenches = new Hashtable();
        public static Hashtable Spots = new Hashtable();
        */

        public LoggingObject(IObjData dataObj, ref SGWorld66 sgworld)
        {
            _dataObj = dataObj;
            Top = new GeoPoint
            {
                X = dataObj.Points.GetPoint(0).X,
                Y = dataObj.Points.GetPoint(0).Y,
                Z = dataObj.Points.GetPoint(0).Z
                
            };
            Bottom = new GeoPoint
            {
                X = dataObj.Points.GetPoint(1).X,
                Y = dataObj.Points.GetPoint(1).Y,
                Z = dataObj.Points.GetPoint(1).Z
                
            };
            Markers01 = dataObj.MarkersNO1;
            Markers02 = dataObj.MarkersNO2;
            Markers03 = dataObj.MarkersNO3;
        }

        public LoggingObject()
        {
        }

        public void SetSkylineObj(ITerraExplorerObject66 skylineObj)
        {
            _skylineMouthObj = skylineObj;
        }

        /// <summary>
        /// 查询该数据来源的详细信息，调用GeoSmart面板。
        /// </summary>
        public void QueryDetail() { }

        public virtual void DrawTop() { }

        public virtual void DrawBottom() { }

        public virtual void DrawPath() { }

        public virtual void EraseAll()
        {
            
        }

        public virtual void Store() { }

        /*
        public void AddObj(string skylineId, LoggingObject obj)
        {
            LoggingObjects.Add(skylineId, obj);
            
            switch (obj.Type)
            {
                case LoggingType.Bore:
                    Bores.Add(skylineId, obj);
                    break;
                case LoggingType.Footrill:
                    Footrills.Add(skylineId, obj);
                    break;
                case LoggingType.Pit:
                    Pits.Add(skylineId, obj);
                    break;
                case LoggingType.Well:
                    Wells.Add(skylineId, obj);
                    break;
                case LoggingType.Trench:
                    Trenches.Add(skylineId, obj);
                    break;
                case LoggingType.Spot:
                    Spots.Add(skylineId, obj);
                    break;
                default:
                    break;
            }
        }
        */

        /*
        public string SkylineIdToGuId(string skylineId)
        {
            var obj = LoggingObjects[skylineId] as LoggingObject;
            return obj != null ? obj.Guid : string.Empty;
        }
        */







    }
}
