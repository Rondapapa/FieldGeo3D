using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoSurface:GeoObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        private List<string> _skylineId; //skyline id 集合

        public List<GeoPoint> References { get; set; } //几何参照点集

        public List<GeoLine> Lines { get; set; } //地质构造点集

        /// <summary>
        /// 绘制地质表面
        /// </summary>
        /// <param name="sgworld"></param>
        public override void Draw(ref SGWorld66 sgworld)
        {
            base.Draw(ref sgworld);
        }


    }
}
