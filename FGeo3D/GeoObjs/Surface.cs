using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    //地质曲面：仅用于拟合、延伸趋势面
    class Surface:GeoObject
    {
        //趋势面方程


        //TIN
        public TsData TinData { get; set; }

        public List<IGPoint> Points { get; set; } //几何参照点集

        public Surface(IGMarker marker)
        {
            for (var index = 0; index < marker.Points.Count; index++)
            {
                Points.Add(marker.Points.GetPoint(index));
            }
        }

        /// <summary>
        /// 绘制地质表面？？？？？
        /// </summary>
        /// <param name="sgworld"></param>
        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
        }


    }
}
