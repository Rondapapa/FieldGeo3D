using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
    class DrawingLine : DrawingObject
    {
        
        public DrawingLine(ITerraExplorerObject66 inLine, ITerrainLabel66 inLabel, string useType, List<string> conObjGuids )
        {
            Type = "Line";
            SkylineObj = inLine;
            SkylineLabel = inLabel;
            DbUseType = useType;
            Ts = new TsFile(inLine, Type);
            //Ts.WriteTsFile();
            ConnObjGuids = conObjGuids;
        }



        public override void Store(string dataSourceObjGuid, ref YWCHEntEx db)
        {
            base.Store(dataSourceObjGuid, ref db);
            
        }
    }
}
