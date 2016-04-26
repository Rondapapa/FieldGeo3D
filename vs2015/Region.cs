using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Region:Object
    {
        private ITerrainPolygon66 _region;

        public string Id
        {
          	get { return _region.ID; }
        }

        public Region(ITerrainPolygon66 inRegion)
        {
            Type = "Region";
            _region = inRegion;
            AddObj(this, Id);
        }


    }
}
