using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Pit
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Depth { get; set; }

        public List<GeoMarkPoint> Marks { get; set; }

        public Pit(string id, string name, double x, double y, double h, double depth, List<GeoMarkPoint> marks)
        {
            ID = id;
            Name = name;
            X = x;
            Y = y;
            H = h;
            Depth = depth;
            Marks = marks;
        }

        public void QueryDetail() { }

        public void Draw(ref SGWorld66 sgworld) { }
    }
}
