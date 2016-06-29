using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoIM.CHIDI.DZ.COM;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class GeoObject
    {
        private IGPoint _pointObj;
        private IGMarker _markerObj;
        private ITerraExplorerObject66 _skylineObj;

        public string Guid => _markerObj.Guid;
        public string BH => _markerObj.BH;
        public string Name => _markerObj.Name;
        public string JHLX => _markerObj.JHLX;
        public string Layers => _markerObj.Layers;
        public string Type => _markerObj.Type;
        public string UseFor => _markerObj.UseFor;
        public double PathLength => _markerObj.PathLength;
        public int JMBJLX => _markerObj.JMBJLX;

        public double Dip => _markerObj.Dip;
        public double Angle => _markerObj.Angle;

        public string SkylineId => _skylineObj.ID;

        public GeoObject()
        {
        }

        public GeoObject(IGPoint gPoint)
        {
            _pointObj = gPoint;
        }

        public GeoObject(IGMarker marker)
        {
            _markerObj = marker;
        }



        public void SetSkylineObj(ITerraExplorerObject66 skylineObj)
        {
            _skylineObj = skylineObj;
        }


        /// <summary>
        /// 在三维场景中绘制该对象
        /// </summary>
        public virtual void Draw(ref SGWorld66 sgworld) { }


        /// <summary>
        /// 在三维场景中移除该对象
        /// </summary>
        public void Erase(ref SGWorld66 sgworld)
        {
            sgworld.Creator.DeleteObject(_skylineObj.ID);
            sgworld.ProjectTree.DeleteItem(_skylineObj.ID);
            _skylineObj = null;
        }


        /// <summary>
        /// 在数据库中查询该对象的详细地质信息
        /// </summary>
        public virtual void Detail() { }


        /// <summary>
        /// 将该对象存入数据库
        /// </summary>
        public virtual void Store() { }

        public int CompareTo(object obj)
        {

            throw new NotImplementedException();
        }

        public virtual void BuildTsFile() { }
    }
}
