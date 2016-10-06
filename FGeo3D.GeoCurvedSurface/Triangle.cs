using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIConvexHull;

namespace FGeo3D.GeoCurvedSurface
{
    using System.Windows.Forms;

    using FGeo3D.GeoObj;
    using FGeo3D.GoCAD;

    using MathNet.Spatial.Euclidean;

    public class Triangle
    {
        private List<Vertex> Vertices = new List<Vertex>();

        private List<Point> verticesList;

        private ITriangulation<Vertex, DefaultTriangulationCell<Vertex>> triangulations;

        public TsData TsData {get; } = new TsData();

        private readonly Dictionary<Vertex, int> vertexDictionary = new Dictionary<Vertex, int>();

        public Triangle(IList<Point> pointsList, IList<Point> verticesList)
        {
            this.verticesList = new List<Point>(verticesList);

            foreach (var p in pointsList)
            {
                this.Vertices.Add(new Vertex(p.X, p.Y));
            }
        }

        /// <summary>
        /// 划分Delaunay三角网，结果保存于tsData
        /// </summary>
        /// <param name="interpolateFunc">插值函数</param>
        public void Mesh(double depth, Func<IList<Point>, MathNet.Spatial.Euclidean.Plane, double, double, double, double> interpolateFunc)
        {
            try
            {
                triangulations = Triangulation.CreateDelaunay(this.Vertices);

                
                var verticesPlane = GeoHelper.GetPlaneViaPoints(verticesList);

                this.TsData.VerticesList = new List<Point3D>(this.Vertices.Count);
                this.TsData.TriLinksList = new List<TriLink>(this.triangulations.Cells.Count());

                // 以Dict记录三角形的编号
                int num = 1;
                foreach (var cell in this.triangulations.Cells)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        var v = cell.Vertices[i];
                        if (!this.vertexDictionary.ContainsKey(v))
                        {
                            this.vertexDictionary.Add(v, num++);
                        }
                    }

                    // 根据编号写ts的TriLinksList
                    this.TsData.TriLinksList.Add(new TriLink
                    {
                        VertexA = this.vertexDictionary[cell.Vertices[0]],
                        VertexB = this.vertexDictionary[cell.Vertices[1]],
                        VertexC = this.vertexDictionary[cell.Vertices[2]]
                    });
                }

                // 写ts的VerticesList, 并插值Z
                foreach (var kv in this.vertexDictionary.OrderBy(n => n.Value))
                {
                    var vPos = kv.Key.Position;
                    var x = vPos[0];
                    var y = vPos[1];
                    var z = interpolateFunc(verticesList, verticesPlane, depth, x, y);
                    // IList<Point> verticesList, MathNet.Spatial.Euclidean.Plane verticesPlane, double depth, double x, double y
                    this.TsData.VerticesList.Add(new Point3D(x, y, z));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
