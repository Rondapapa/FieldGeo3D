using System.Collections.Generic;
using MathNet.Spatial.Euclidean;

namespace FGeo3D.GoCAD
{
    public struct TriLink
    {
        public int VertexA;
        public int VertexB;
        public int VertexC;
    }


    public class TsData
    {
        //点
        public List<Point3D> VerticesList = new List<Point3D>();

        //三角形
        public List<TriLink> TriLinksList = new List<TriLink>();

    }
}
