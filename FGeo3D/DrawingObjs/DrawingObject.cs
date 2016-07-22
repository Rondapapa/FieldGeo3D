using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
    class DrawingObject
    {

        protected ITerraExplorerObject66 SkylineObj;

        protected ITerrainLabel66 SkylineLabel;

        protected TsFile Ts;



        public string ID => SkylineObj.ID;

        public string Guid { get; private set; }
        
        public string Type { get; set;}

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

        public string DbUseType { get; set; }

        public string connectGuid { get; set; }

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
            
            DbUseType = useType;
        }

        public virtual void Store(string dataSourceObjGuid, ref YWCHEntEx db)
        {
            //上传TS部件文件
            db.SkyUploadPartVer(Ts.Guid, Ts.FilePath);
            //创建地质对象（几何部件、界线、结构面）,并关联ts
            switch (DbUseType)
            {
                case "几何部件":
                    //以标识点（BSD）形式创建几何部件地质对象
                    connectGuid = db.SkyNewObject("BSD", Guid, DbGeoType, Name, Color);
                    db.SkyAddConnect(1, Ts.Guid, connectGuid);
                    break;
                case "界线":
                {
                    connectGuid = dataSourceObjGuid;
                    var dataSourceType = db.SkyGetSJLYMDL(dataSourceObjGuid).SJLYLXID;
                    db.SkyFrmDzdx(dataSourceType, dataSourceObjGuid, "DXM");
                    
                    db.SkyAddConnect(0, Ts.Guid, connectGuid);
                }
                    break;
                case "结构面":
                {
                    connectGuid = dataSourceObjGuid;
                    var dataSourceType = db.SkyGetSJLYMDL(dataSourceObjGuid).SJLYLXID;
                    db.SkyFrmDzdx(dataSourceType, dataSourceObjGuid, "JGM");
                    db.SkyAddConnect(0, Ts.Guid, connectGuid);
                }
                    break;
                default:
                    break;
            }
            

        }

        //从数据库中获取模型部件TS的新版本。
        public void GetTsFileFromDb()
        {
            
        }
    }
}
