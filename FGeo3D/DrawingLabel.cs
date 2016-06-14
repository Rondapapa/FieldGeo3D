using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class DrawingLabel:DrawingObject
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

        public DrawingLabel(ITerrainLabel66 inLabel66)
        {
            Type = "Label";
            _label = inLabel66;

        }

        public DrawingLabel(DrawingObjectInfo objInfo, ref SGWorld66 sgworld)
        {
            Type = "Label";
            _label = sgworld.Creator.CreateTextLabel(objInfo.LabelPosition, objInfo.LabelText, objInfo.LabelStyle, objInfo.GroupId, "Label:" + objInfo.LabelText);
            AddObj(this, Id);
        }

    }
}
