using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Spot:LoggingObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }

        public GeoMarkPoint Mark { get; set; }

        public Spot(double x, double y, double h, GeoMarkPoint mark)
        {
            X = x;
            Y = y;
            H = h;
            Mark = mark;
        }

        public void Draw(ref SGWorld66 sgworld) { }

        public override void QueryDetail()
        {
            base.QueryDetail();
        }

        public override void Store()
        {
            base.Store();
        }
    }
}
