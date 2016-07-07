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

        public string Id => _line.ID;

        public DrawingLine(ITerrainPolyline66 inLine):base(inLine as ITerrainObject66)
        {
            Type = "Line";
            _line = inLine;
            AddObj(this, Id);
        }



    }
}
