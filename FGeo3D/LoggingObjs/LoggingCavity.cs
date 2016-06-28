using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingCavity:LoggingObject
    {
        public LoggingCavity(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
        }
    }
}
