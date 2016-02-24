using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoRegion:GeoObj
    {
        private ITerrainPolygon65 _region;

        public string Id
        {
          	get { return _region.ID; }
        }

        public GeoRegion(ITerrainPolygon65 inRegion)
        {
            GeoType = "Region";
            _region = inRegion;
            AddObj(this, Id);
        }


    }
}
