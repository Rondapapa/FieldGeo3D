using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoIM.CHIDI.DZ.Util.Common;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
    class DrawingObject
    {

        protected ITerraExplorerObject66 SkylineObj;

        protected ITerrainLabel66 SkylineLabel;

        protected TsFile Ts;

        //关联关系对应列表
        public List<string> ConnObjGuids { get; set; } = new List<string>();

        public string ID => SkylineObj.ID;

        public string Guid { get; private set; }
        
        public string Type { get; set;}
        //几何类型（点、线、面）
        public string DbGeoType
        {
            get
            {
                switch (Type)
                {
                    case "Line":
                        return "X";
                    case "Region":
                        return "M";
                    case "Point":
                        return "D";
                    default:
                        return null;
                }
            }
        }
        //地质对象类型（）
        public string MarkerType { get; set; }

        //public string SourceGuid { get; set; }

        public string Name => SkylineLabel.Text;

        public string Color
        {
            get
            {
                switch (Type)
                {
                    case "Line":
                    {
                        var skyItem = SkylineObj as ITerrainPolyline66;
                        if (skyItem == null) return "255,255,255";
                        var colorInt = skyItem.LineStyle.Color.ToARGBColor();
                        var argb = System.Drawing.Color.FromArgb((int)colorInt);
                        return $"{argb.R},{argb.G},{argb.B}";
                    }
                    case "Region":
                    {
                        var skyItem = SkylineObj as ITerrainPolygon66;
                        if (skyItem == null) return "255,255,255";
                        var colorInt = skyItem.LineStyle.Color.ToARGBColor();
                        var argb = System.Drawing.Color.FromArgb((int)colorInt);
                        return $"{argb.R},{argb.G},{argb.B}";
                    }
                    default:
                        return "255,255,255";
                }
            }
        }

        public DrawingObject()
        {
            Guid = System.Guid.NewGuid().ToString();
            
            
        }

        public DrawingObject(string useType)
        {
            Guid = System.Guid.NewGuid().ToString();
            
            MarkerType = useType;
        }

        public virtual void Store(string dataSourceObjGuid, ref YWCHEntEx db)
        {
            //上传TS部件文件
            db.SkyUploadPartVer(Ts.Guid, Ts.FilePath);
            //创建地质对象（几何部件、界线、结构面等）,并关联ts
            switch (MarkerType)
            {
                case "几何部件":
                    //以标识点（BSD）形式创建几何部件地质对象（数据来源级别?）
                    var sourceGuid = db.SkyNewObject("BSD", Guid, DbGeoType, Name, Color);
                    db.SkyAddConnect(1, Ts.Guid, sourceGuid);//?
                    break;
                case "界线":
                    StoreMarkerProcess(dataSourceObjGuid, "DXM", ref db);
                    break;
                case "结构面":
                    StoreMarkerProcess(dataSourceObjGuid, "JGM", ref db);
                    break;
                case "崩塌":
                    StoreMarkerProcess(dataSourceObjGuid, "BT", ref db);
                    break;
                case "滑坡":
                    StoreMarkerProcess(dataSourceObjGuid, "HP", ref db);
                    break;
                case "泥石流":
                    StoreMarkerProcess(dataSourceObjGuid, "NSL", ref db);
                    break;
                case "构造带":
                    StoreMarkerProcess(dataSourceObjGuid, "GZD", ref db);
                    break;
                default:
                    MessageBox.Show(@"Marker类型无效。", @"保存失败");
                    return;
            }
        }


        private void StoreMarkerProcess(string dataSourceObjGuid, string markerType, ref YWCHEntEx db)
        {
            var dataSourceType = db.SkyGetSJLYMDL(dataSourceObjGuid).SJLYLXID;
            
            var markerGuid = db.SkyFrmDzdx(dataSourceType, dataSourceObjGuid, markerType);

            //var pointList = new List<DMarker>();
            //var sourcePoints = db.SkyGetGeoDataList(dataSourceObjGuid).GetObjData(0).Points;
            //for (var index = 0; index < sourcePoints.Count; index++)
            //{
            //    var thisPoint = sourcePoints.GetPoint(index);
            //    pointList.Add(new DMarker
            //    {
            //        X = thisPoint.X,
            //        Y = thisPoint.Y,
            //        Z = thisPoint.Z,
            //        DZDXLX = "KZD",
            //        SD = 0  //SD? 深度桩号需要写嘛？
            //    });
            //}

            //db.SkyAddDzdxMXZB(SourceGuid, markerGuid, pointList);

            db.SkyAddConnect(1, Ts.Guid, markerGuid);
        }

        //从数据库中获取模型部件TS的新版本。
        public void GetTsFileFromDb(ref YWCHEntEx db)
        {
            Ts.UpdateTsFile(ref db);
        }
    }
}
