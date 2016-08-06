using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class DrawingRegion:DrawingObject
    {
        

        public DrawingRegion(ITerraExplorerObject66 inRegion, ITerrainLabel66 inLabel66, string useType)
        {
            Type = "Region";
            SkylineObj = inRegion;
            SkylineLabel = inLabel66;
            DbUseType = useType;
            Ts = new TsFile(inRegion, Type);
            Ts.WriteTsFile();
        }


    }
}
