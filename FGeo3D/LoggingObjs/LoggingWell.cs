using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class LoggingWell:LoggingObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Depth { get; set; }

        public List<GeoMarkPoint> Marks { get; set; }

        public LoggingWell(string id, string name, double x, double y, double h, double depth, List<GeoMarkPoint> marks)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
            H = h;
            Depth = depth;
            Marks = marks;
            Type = LoggingType.Well;
        }

        public override void QueryDetail() { }

        public void Draw(ref SGWorld66 sgworld) { }
    }
}
