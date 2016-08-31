using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Spatial.Euclidean;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE.GeoImage
{

    class ImageLine
    {
        //平面线点集
        public List<System.Drawing.Point> ScreenPoints = new List<System.Drawing.Point>();

        //真实三维线点集
        public List<Point3D> WorldPoints = new List<Point3D>();

        //颜色(默认黑色)
        public Color Color = Color.Black;

        //名称
        public string Name { get; set; }

        //地质对象类型
        public string MarkerType { get; set; }

        //面内延伸方式
        public double StretchDepth { get; set; }

        //延伸平面的点集
        public List<Point3D> StretchPoints = new List<Point3D>();

        //
        public Dictionary<System.Drawing.Point, Point3D> ScreenToWorld = new Dictionary<System.Drawing.Point, Point3D>();

        //关联的地质点guid
        private string GeoSpotGuid { get; }

        //关联的TS部件--线
        public TsFile TsLine { get; set; }  

        //关联的TS部件--面
        public TsFile TsSurface { get; set; }

        public ImageLine(IEnumerable<System.Drawing.Point> inPoints)
        {
            foreach (var thisPoint in inPoints)
            {
                ScreenPoints.Add(thisPoint);
            }
            Stretch();
            
            
        }


        /// <summary>
        /// 构建延伸平面， 写入StretchPoints,未校正
        /// </summary>
        public void Stretch()
        {
            foreach (var thisScreenPoint in ScreenPoints)
            {
                StretchPoints.Add(new Point3D(thisScreenPoint.X, thisScreenPoint.Y, -StretchDepth));
            }
        }

        /// <summary>
        /// 校正坐标，根据StretchPoints更新WorldPoints
        /// </summary>
        public void Rectify()
        {
            //校正坐标
            foreach (var thisStretchPoint in StretchPoints)
            {
                WorldPoints.Add(new Point3D(thisStretchPoint.X, thisStretchPoint.Y, -StretchDepth));
            }
            Vector3D v = new Vector3D();
            Plane p = new Plane();
        }



        /// <summary>
        /// 保存，StretchPoints以Ts部件存入数据库，ScreenPoints自己保存。
        /// </summary>
        public bool Store(ref YWCHEntEx db)
        {
            //面
            //根据地质对象类型，弹出数据库编录卡，保存信息（数据来源:私有模型），记录地质点guid
            var partSurfaceGuid = db.SkyFrmSymxDzdx(MarkerType);
            if (string.IsNullOrEmpty(partSurfaceGuid))
                return false;
            var sourceSurfaceGuid = db.PublishPartVer(partSurfaceGuid);

            //根据线点集构建ts文件
            TsSurface = new TsFile(WorldPoints, "TSurf", "M", MarkerType, Name, new List<string>
            {
                sourceSurfaceGuid //?
            });
            TsSurface.WriteTsFile();
            
            //上传面TS文件
            var isSurfacePartUploaded = db.SkyUploadPartVer(partSurfaceGuid, TsSurface.FilePath);

            ////线
            ////创建
            //var newLineGuid = Guid.NewGuid().ToString();
            //var partLineGuid = db.SkyNewObject(MarkerType, newLineGuid, "X", Name, GetColorRGB());
            //if (string.IsNullOrEmpty(partLineGuid))
            //    return false;
            //var sourceLineGuid = db.PublishPartVer(partLineGuid);

            ////根据面点集构建ts文件
            //TsLine = new TsFile(WorldPoints, "PLine", "X", MarkerType, Name, new List<string>
            //{
            //    sourceLineGuid //??
            //});
            //TsLine.WriteTsFile();

            ////上传面TS文件
            //var isLinePartUploaded = db.SkyUploadPartVer(partLineGuid, TsLine.FilePath);

            
            return isSurfacePartUploaded;
            
            

            //将ts文件与地质点关联
            //db.SkyAddConnect(1, TsLine.Guid, markerGuid);
        }


        private string GetColorRGB()
        {
            return $"{Color.R},{Color.G},{Color.B}";
        }
    }
}
