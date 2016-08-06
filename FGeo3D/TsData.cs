using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGeo3D_TE
{
    internal struct TriLink
    {
        public int VertexA;
        public int VertexB;
        public int VertexC;
    }



    class TsData
    {
        //点
        public List<Point> VerticesList = new List<Point>();

        //三角形
        public List<TriLink> TriLinksList = new List<TriLink>();

    }
}
