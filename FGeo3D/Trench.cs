using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraExplorerX;

namespace FGeo3D_TE
{
    class Trench
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Depth { get; set; }
        public GeoLine BaseLine { get; set; } //探槽基线（包括位置，方位角）
        public List<GeoSurface> Surfaces { get; set; } //探槽壁

        public Trench(string id, string name, double x, double y, double h, double depth, GeoLine baseLine, List<GeoSurface> surfaces)
        {
            ID = id;
            Name = name;
            X = x;
            Y = y;
            H = h;
            Depth = depth;
            BaseLine = baseLine;
            Surfaces = surfaces;
        }

        public void QueryDetail() { }

        public void Draw(ref SGWorld66 sgworld) { }
    }
}
