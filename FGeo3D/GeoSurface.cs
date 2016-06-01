using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGeo3D_TE
{
    class GeoSurface:GeoObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }

        public List<GeoPoint> References { get; set; } //几何参照点集

        public List<GeoLine> Lines { get; set; } //地质构造点集


    }
}
