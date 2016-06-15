using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class DrawingLine : DrawingObject
    {
        private ITerrainPolyline66 _line;

        public string Id
        {
            get { return _line.ID; }
        }

        public DrawingLine(ITerrainPolyline66 inLine)
        {
            Type = "Line";
            _line = inLine;
            AddObj(this, Id);
        }



    }
}
