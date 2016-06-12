using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGeo3D_TE
{
    public enum LoggingType
    {
        Bore, Footrill, Pit, Well, Trench, Spot
    }

    class LoggingObject
    {
        public string Id { get; set; }
        public LoggingType Type { get; set; }
        public string Name { get; set; }

        public static Hashtable LoggingObjects = new Hashtable();

        public static Hashtable Bores = new Hashtable();
        public static Hashtable Footrills = new Hashtable();
        public static Hashtable Pits = new Hashtable();
        public static Hashtable Wells = new Hashtable();
        public static Hashtable Trenches = new Hashtable();
        public static Hashtable Spots = new Hashtable();

        public void AddObj(string skylineId, LoggingObject obj)
        {
            LoggingObjects.Add(skylineId, obj);

            switch (obj.Type)
            {
                case LoggingType.Bore:
                    Bores.Add(skylineId, obj);
                    break;
                case LoggingType.Footrill:
                    Footrills.Add(skylineId, obj);
                    break;
                case LoggingType.Pit:
                    Pits.Add(skylineId, obj);
                    break;
                case LoggingType.Well:
                    Wells.Add(skylineId, obj);
                    break;
                case LoggingType.Trench:
                    Trenches.Add(skylineId, obj);
                    break;
                case LoggingType.Spot:
                    Spots.Add(skylineId, obj);
                    break;
                default:
                    break;
            }
        }

        public string SkylineIdToGuId(string skylineId)
        {
            var obj = LoggingObjects[skylineId] as LoggingObject;
            return obj != null ? obj.Id : string.Empty;
        }

        

        public virtual void QueryDetail() { }

        public virtual void Store() { }

    }
}
