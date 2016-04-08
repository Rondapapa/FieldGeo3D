using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoLabel:GeoObj
    {

        private ITerrainLabel66 _label;

        public string Id
        {
            get
            {
                return _label.ID;
            }
        }

        public IPosition66 Position
        {
          	get { return _label.Position; }
        }

        public string Text
        {
          	get { return _label.Text; }
        }

        public ILabelStyle66 Style
        {
          	get { return _label.Style; }
        }

        public GeoLabel(ITerrainLabel66 inLabel66)
        {
            GeoType = "Label";
            _label = inLabel66;

        }

        public GeoLabel(GeoObjInfo geoObjInfo, ref SGWorld66 sgworld)
        {
            GeoType = "Label";
            _label = sgworld.Creator.CreateTextLabel(geoObjInfo.LabelPosition, geoObjInfo.LabelText, geoObjInfo.LabelStyle, geoObjInfo.GroupId, "Label:" + geoObjInfo.LabelText);
            AddObj(this, Id);
        }

    }
}
