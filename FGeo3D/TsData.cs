using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGeo3D_TE
{
    internal struct TriLink
    {
        int VertexA;
        int VertexB;
        int VertexC;
    }

    internal struct SegLink
    {
        int SegA;
        int SegB;
    }

    class TsData
    {
        public List<Point> VerticesList = new List<Point>();

        public List<SegLink> SegLinksList = new List<SegLink>();

        public List<TriLink> TriLinksList = new List<TriLink>();

    }
}
