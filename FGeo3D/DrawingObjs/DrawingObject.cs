using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
    class DrawingObject
    {

        protected ITerraExplorerObject66 SkylineObj;

        protected ITerrainLabel66 SkylineLabel;

        protected TsFile Ts;

        public string ID => SkylineObj.ID;
        
        public string Type { get; set;}



        public DrawingObject()
        {
            
        }



        public virtual void Store(ref YWCHEntEx db) { }

    }
}
