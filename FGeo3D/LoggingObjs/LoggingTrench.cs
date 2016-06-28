using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingTrench:LoggingObject
    {

        public GeoLine BaseLine { get; set; } //探槽基线（包括位置，方位角）
        public List<GeoSurface> Surfaces { get; set; } //探槽壁

        public LoggingTrench(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
        }

        public void Draw(ref SGWorld66 sgworld) { }


    }
}
