using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Line : Object
    {
        private ITerrainPolyline66 _line;

        public string Id
        {
            get { return _line.ID; }
        }

        public Line(ITerrainPolyline66 inLine)
        {
            Type = "Line";
            _line = inLine;
            AddObj(this, Id);
        }



    }
}
