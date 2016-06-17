using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingPit:LoggingObject
    {



        public List<GeoMarkPoint> Marks { get; set; }

        public LoggingPit(IObjData dataObj) : base(dataObj)
        {
        }

        public void Draw(ref SGWorld66 sgworld) { }


    }
}
