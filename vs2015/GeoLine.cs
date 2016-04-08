using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoLine : GeoObj
    {
        private ITerrainPolyline66 _line;

        public string Id
        {
            get { return _line.ID; }
        }

        public GeoLine(ITerrainPolyline66 inLine)
        {
            GeoType = "Line";
            _line = inLine;
            AddObj(this, Id);
        }

    }
}
