using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraExplorerX;

namespace FGeo3D_TE
{
    //地质面
    class GeoSurface:GeoObject
    {
        
        private List<string> _skylineId; //skyline id 集合

        public List<GeoPoint> References { get; set; } //几何参照点集

        public List<GeoPlane> Planes { get; set; }

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
