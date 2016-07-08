using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class DrawingLine : DrawingObject
    {
        
        public DrawingLine(ITerraExplorerObject66 inLine, ITerrainLabel66 inLabel)
        {
            Type = "Line";
            SkylineObj = inLine;
            SkylineLabel = inLabel;

        }



    }
}
