using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingFoundation:LoggingObject
    {
        public LoggingFoundation(IObjData dataObj, ref SGWorld66 sgworld) : base(dataObj, ref sgworld)
        {
        }
    }
}
