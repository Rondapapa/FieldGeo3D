using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoIM.CHIDI.DZ.COM;
using GeoIM.CHIDI.DZ.COM.Common;
using GeoIM.CHIDI.DZ.Util.Common;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
    public enum LoggingType
    {
        Bore, Footrill, Pit, Well, Trench, Spot, Slope, Cavity, Foundation
    }

    class LoggingObject
    {
        private readonly IObjData _dataObj; //GeoSmart对象
        protected ITerraExplorerObject66 SkylineMouthObj;
        protected ITerraExplorerObject66 SkylineBodyObj;
        protected ITerraExplorerObject66 SkylineLabelObj;

        public string Guid => _dataObj.Guid;

        public string BH => _dataObj.BH;
        public string Name => _dataObj.Name;
        public string sType => _dataObj.Type;

        public IGPoint Top { get; set; }
        public IGPoint Bottom { get; set; }
        public double Depth => Top.Z - Bottom.Z; //?

        public IGMarkerList Markers01 { get; set; }
        public IGMarkerList Markers02 { get; set; }
        public IGMarkerList Markers03 { get; set; }

        public List<IGMarker> DC_Markers { get; set; } = new List<IGMarker>(); //地层岩性
        public List<IGMarker> GZ_Markers { get; set; } = new List<IGMarker>(); //构造分段
        public List<IGMarker> DXS_Markers { get; set; } = new List<IGMarker>(); //地下水分段
        public List<IGMarker> FH_Markers { get; set; } = new List<IGMarker>(); //风化        
        public List<IGMarker> XH_Markers { get; set; } = new List<IGMarker>(); //卸荷
        public List<IGMarker> SYD_Markers { get; set; } = new List<IGMarker>(); //试验点
        public List<IGMarker> JGM_Markers { get; set; } = new List<IGMarker>(); //结构面
        public List<IGMarker> GZD_Markers { get; set; } = new List<IGMarker>(); //构造带


        public string SkylineId => SkylineMouthObj.ID;
        public ObjectTypeCode SkylineType => SkylineMouthObj.ObjectType;

        public LoggingType Type { get; set; }


        public static Dictionary<string, LoggingObject> DictOfLoggingObjects = new Dictionary<string, LoggingObject>();

        

        public static Dictionary<string, string> DictOfSkyId_Guid = new Dictionary<string, string>();

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
            if (dataObj.Points.Count > 0)
            {
                Top = dataObj.Points.GetPoint(0);
                var last = dataObj.Points.Count - 1;
                Bottom = dataObj.Points.GetPoint(last);
            }
            else
            {
                MessageBox.Show($"类型：{dataObj.Type} 编号：{dataObj.BH} 数据无效或格式错误，请到数据库后台校验",@"数据导入错误");
                return;
            }
            
            Markers01 = dataObj.MarkersNO1;
            Markers02 = dataObj.MarkersNO2;
            Markers03 = dataObj.MarkersNO3;

            for (var index = 0; index < dataObj.MarkersNO1.Count; index++)
            {
                var thisMarker = dataObj.MarkersNO1.GetMarker(index);
                switch (thisMarker.Type)
                {
                    case "地层岩性":
                        DC_Markers.Add(thisMarker);
                        break;
                    case "构造分段":
                        GZ_Markers.Add(thisMarker);
                        break;
                    case "地下水分段":
                        DXS_Markers.Add(thisMarker);
                        break;
                    case "风化":
                        FH_Markers.Add(thisMarker);
                        break;
                    case "卸荷":
                        XH_Markers.Add(thisMarker);
                        break;
                    case "试验点":
                        SYD_Markers.Add(thisMarker);
                        break;
                    case "结构面":
                        JGM_Markers.Add(thisMarker);
                        break;
                    case "构造带":
                        GZD_Markers.Add(thisMarker);
                        break;
                }
            }

            DictOfLoggingObjects.Add(Guid, this);
        }

        public LoggingObject()
        {
        }

        public void RecordLabelSkyId()
        {
            if (!DictOfSkyId_Guid.ContainsKey(SkylineLabelObj.ID))
                DictOfSkyId_Guid.Add(SkylineLabelObj.ID, Guid);
            
        }

        /// <summary>
        /// 查询该数据来源的详细信息，调用GeoSmart面板。
        /// </summary>
        public void QueryDetail(ref YWCHEntEx db)
        {
            db.SkyFrmSJLYEdit(db.SkyGetSJLYMDL(Guid).SJSJLYID, new List<DMarker>(), Guid);
        }


        public void Erase(ref SGWorld66 sgworld)
        {
            if (SkylineMouthObj != null)
            {
                sgworld.Creator.DeleteObject(SkylineMouthObj.ID);
                
                SkylineMouthObj = null;
            }
            if (SkylineBodyObj != null)
            {
                sgworld.Creator.DeleteObject(SkylineBodyObj.ID);
                
                SkylineBodyObj = null;
            }
            if (SkylineLabelObj != null)
            {
                sgworld.Creator.DeleteObject(SkylineLabelObj.ID);
                
                SkylineLabelObj = null;
            }
        }

        public void HighlightLabel(ref SGWorld66 sgworld)
        {
            var textLabel = SkylineLabelObj as ITerrainLabel66;
            if (textLabel == null) return;
            var textLabelStyle = textLabel.Style;
            textLabelStyle.TextColor = sgworld.Creator.CreateColor(255, 0, 0, 255);
            textLabelStyle.Underline = true;
        }

        public void ResetLabel(ref SGWorld66 sgworld)
        {
            var textLabel = SkylineLabelObj as ITerrainLabel66;
            if (textLabel == null) return;
            var textLabelStyle = textLabel.Style;
            textLabelStyle.TextColor = sgworld.Creator.CreateColor(0, 0, 0, 0);
            textLabelStyle.Underline = false;
        }

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
