using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    //地质面
    class GeoSurface:GeoObject
    {
        public List<IGPoint> Points { get; set; } //几何参照点集

        public GeoSurface(IGMarker marker)
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
