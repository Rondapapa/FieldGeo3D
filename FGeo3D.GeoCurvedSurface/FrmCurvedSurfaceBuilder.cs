using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGeo3D.GeoCurvedSurface
{
    using FGeo3D.GeoObj;
    using FGeo3D.LoggingObj;

    using GeoIM.CHIDI.DZ.COM;

    public partial class FrmCurvedSurfaceBuilder : Form
    {
        //地质对象信息字典
        private Dictionary<string, LoggingObject> loggingObjectsDict;

        //选定的地质对象信息列表
        private HashSet<LoggingObject> selectedObjsSet = new HashSet<LoggingObject>();
        
        //Marker列表
        private HashSet<string> markerSet = new HashSet<string>();

        //UseFor列表
        private HashSet<string> useforSet = new HashSet<string>();

        //目标marker点集！！！！！
        private List<Point> targetMarkersList;
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCurvedSurfaceBuilder"/> class.
        /// </summary>
        /// <param name="objsDict">
        /// The objs dict.
        /// </param>
        public FrmCurvedSurfaceBuilder(Dictionary<string, LoggingObject> objsDict)
        {
            this.InitializeComponent();
            this.loggingObjectsDict = objsDict;

            foreach (var kvLoggingObj in this.loggingObjectsDict)
            {
                this.listBoxAdvGeoObjs.Items.Add(kvLoggingObj.Value.Name);
            }
            
        }






        private void buttonXSave_Click(object sender, EventArgs e)
        {

        }

        private void listBoxAdvGeoObjs_ItemCheck(object sender, DevComponents.DotNetBar.ListBoxAdvItemCheckEventArgs e)
        {
            this.selectedObjsSet.Clear();
            foreach (var item in this.listBoxAdvGeoObjs.CheckedItems)
            {
                var loggingObj = this.GetLoggingObjectByName(item.Text);
                if (!this.selectedObjsSet.Contains(loggingObj) && loggingObj != null)
                {
                    this.selectedObjsSet.Add(loggingObj);
                }
            }

            //显示Marker类型的列表框
            this.markerSet.Clear();
            foreach (var item in this.selectedObjsSet)
            {
                var markerTypeList = item.GetMarkerTypeList();
                foreach (var markerType in markerTypeList)
                {
                    this.markerSet.Add(markerType);
                }
            }

            listBoxAdvMarkerType.Items.Clear();
            foreach (var markerType in this.markerSet)
            {
                this.listBoxAdvMarkerType.Items.Add(markerType);
            }

            if (this.useforSet.Count > 0)
            {
                this.useforSet.Clear();
                this.listBoxAdvUseFor.Items.Clear();
            }
            
            
        }


        private LoggingObject GetLoggingObjectByName(string name)
        {
            foreach (var kvLoggingObj in this.loggingObjectsDict)
            {
                if (name == kvLoggingObj.Value.Name)
                    return kvLoggingObj.Value;
            }
            return null;
        }

        private void buttonXGeoObjAllSel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBoxAdvGeoObjs.Items.Count; ++i)
            {
                this.listBoxAdvGeoObjs.SetItemCheckState(i, CheckState.Checked);
            }
            
        }

        private void buttonXGeoObjAllDesel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBoxAdvGeoObjs.Items.Count; ++i)
            {
                this.listBoxAdvGeoObjs.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAdvMarkerType_ItemClick(object sender, EventArgs e)
        {
            var selectedMarkerType = this.listBoxAdvMarkerType.SelectedItems[0].Text;

            this.useforSet.Clear();
            foreach (var selectedObj in this.selectedObjsSet)
            {
                var useForSet = selectedObj.GetUseForSetByMarkerType(selectedMarkerType);
                foreach (var usefor in useForSet)
                {
                    this.useforSet.Add(usefor);
                }
                
            }

            this.listBoxAdvUseFor.Items.Clear();
            foreach (var usefor in this.useforSet)
            {
                this.listBoxAdvUseFor.Items.Add(usefor);
            }
            

        }


        private void listBoxAdvMarkerType_ItemRemoved(object sender, DevComponents.DotNetBar.ItemRemovedEventArgs e)
        {
            if (listBoxAdvMarkerType.SelectedItems.Count > 0)
            {
                var selectedMarkerType = this.listBoxAdvMarkerType.SelectedItems[0].Text;

                this.useforSet.Clear();
                foreach (var selectedObj in this.selectedObjsSet)
                {
                    var useForSet = selectedObj.GetUseForSetByMarkerType(selectedMarkerType);
                    foreach (var usefor in useForSet)
                    {
                        this.useforSet.Add(usefor);
                    }

                }
            }

            this.listBoxAdvUseFor.Items.Clear();
            foreach (var usefor in this.useforSet)
            {
                this.listBoxAdvUseFor.Items.Add(usefor);
            }
        }


        private void listBoxAdvUseFor_ItemClick(object sender, EventArgs e)
        {
            var selectedMarkerType = this.listBoxAdvMarkerType.SelectedItems[0].Text;
            var selectedUseFor = this.listBoxAdvUseFor.SelectedItems[0].Text;
            this.targetMarkersList = Extractor.GetPointListOf(this.selectedObjsSet, selectedMarkerType, selectedUseFor);
            this.textBoxXCPCount.Text = this.targetMarkersList.Count.ToString();
        }

        
    }
}
