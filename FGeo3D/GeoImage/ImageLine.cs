using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Spatial.Euclidean;

namespace FGeo3D_TE.GeoImage
{
    public enum GeoType
    {
        地形地貌, 地层岩性, 结构面, 构造分段, 褶皱, 风化, 卸荷, 泥石流, 滑坡, 崩塌, 蠕变, 潜在失稳块体, 岩溶, 地下水分段, 土体分层, 岩体分类
    }

    public enum StretchType
    {
        无, 三角形延伸, 半圆延伸, 半椭圆延伸
    }

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
        public GeoType GeoType { get; set; }

        //面内延伸方式
        public StretchType StretchType { get; set; }

        //延伸平面的点集
        public List<Point3D> StretchPoints = new List<Point3D>();

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
            InitWorldPoint();
        }

        public void InitWorldPoint()
        {
            foreach (var thisScreenPoint in ScreenPoints)
            {
                WorldPoints.Add(new Point3D(thisScreenPoint.X, thisScreenPoint.Y, 0));
            }
        }

        /// <summary>
        /// 校正坐标
        /// </summary>
        public void RectifyPoints()
        {
            
        }

        /// <summary>
        /// 构建延伸平面
        /// </summary>
        public void Stretch()
        {
            
        }

        /// <summary>
        /// 存入数据库
        /// </summary>
        public void Store()
        {
            //根据线点集和面点集构建ts文件

            //上传TS文件

            //根据地质对象类型，弹出数据库编录卡，保存信息（如何选定数据来源？），记录地质点guid

            //将ts文件与地质点关联




        }
    }
}
