using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class GeoObj
    {
        public static Hashtable Labels = new Hashtable();

        public static Hashtable Points = new Hashtable();

        public static Hashtable Lines = new Hashtable();

        public static Hashtable Regions = new Hashtable();
        
        public string GeoType { get; set;}

        public GeoObj()
        {
          	
        }

        public void AddObj(GeoObj geoObj, string geoId)
        {
          	switch(geoObj.GeoType)
            {
              	case "Label":
                    Labels.Add(geoId, geoObj);
                    break;
                case "Point":
                    Points.Add(geoId, geoObj);
                    break;
                case "Line":
                    Lines.Add(geoId, geoObj);
                    break;
                case "Region":
                    Regions.Add(geoId, geoObj);
                    break;
                default:
                    break;
            }
        }

    }
}
