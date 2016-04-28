using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    class Object
    {
        public static Hashtable Labels = new Hashtable();

        public static Hashtable Points = new Hashtable();

        public static Hashtable Lines = new Hashtable();

        public static Hashtable Regions = new Hashtable();
        
        public string Type { get; set;}

        public Object()
        {
          	
        }

        public void AddObj(Object obj, string id)
        {
          	switch(obj.Type)
            {
              	case "Label":
                    Labels.Add(id, obj);
                    break;
                case "Point":
                    Points.Add(id, obj);
                    break;
                case "Line":
                    Lines.Add(id, obj);
                    break;
                case "Region":
                    Regions.Add(id, obj);
                    break;
                default:
                    break;
            }
        }

    }
}
