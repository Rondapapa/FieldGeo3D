using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIConvexHull;

namespace FGeo3D.GeoCurvedSurface
{
    using System.Windows.Forms;

    using DevComponents.DotNetBar;

    using FGeo3D.GeoObj;
    using FGeo3D.GoCAD;

    using MathNet.Spatial.Euclidean;

    using TerraExplorerX;

    public class Triangulations
    {
        private List<Vertex> Vertices = new List<Vertex>();

        private readonly List<Point> verticesList;

        private ITriangulation<Vertex, DefaultTriangulationCell<Vertex>> triangulations;

        public TsData TsData {get; } = new TsData();


        private readonly Dictionary<Vertex, int> vertexnumDictionary = new Dictionary<Vertex, int>();

        private readonly Dictionary<int, Vertex> numVertexDictionary = new Dictionary<int, Vertex>();


        /// <summary>
        /// 构造Delaunay三角网
        /// </summary>
        /// <param name="pointsList">数据点集</param>
        /// <param name="verticesList">边界点（Surface无需此项，可给空）</param>
        public Triangulations(IList<Point> pointsList, IList<Point> verticesList)
        {
            this.verticesList = new List<Point>(verticesList);

            foreach (var p in pointsList)
            {
                this.Vertices.Add(new Vertex(p.X, p.Y));
            }
        }

        /// <summary>
        /// Ring：划分Delaunay三角网，结果保存于tsData
        /// </summary>
        /// <param name="depth">深度</param>
        /// <param name="interpolateFunc">插值函数</param>
        public void MeshRing(
            double depth, 
            Func<IList<Point>, double, double, double, double> interpolateFunc)
        {
            try
            {
                triangulations = Triangulation.CreateDelaunay(this.Vertices);


                this.TsData.VerticesList = new List<Point3D>(this.Vertices.Count);
                this.TsData.TriLinksList = new List<TriLink>(this.triangulations.Cells.Count());

                // 以Dict记录三角形的编号
                int num = 1;
                foreach (var cell in this.triangulations.Cells)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        var v = cell.Vertices[i];
                        if (!this.vertexnumDictionary.ContainsKey(v))
                        {
                            this.vertexnumDictionary.Add(v, num++);
                        }
                    }

                    // 根据编号写ts的TriLinksList
                    this.TsData.TriLinksList.Add(new TriLink
                    {
                        VertexA = this.vertexnumDictionary[cell.Vertices[0]],
                        VertexB = this.vertexnumDictionary[cell.Vertices[1]],
                        VertexC = this.vertexnumDictionary[cell.Vertices[2]]
                    });
                }

                // 写ts的VerticesList, 并插值Z
                foreach (var kv in this.vertexnumDictionary.OrderBy(n => n.Value))
                {
                    var vPos = kv.Key.Position;
                    var x = vPos[0];
                    var y = vPos[1];
                    var z = interpolateFunc(this.verticesList, depth, x, y);
                    
                    this.TsData.VerticesList.Add(new Point3D(x, y, z));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Surface： 划分Delaunay三角网，结果保存于tsData
        /// </summary>
        /// <param name="se">曲面插值函数</param>
        public void MeshSurface(SurfaceEquation se)
        {
            try
            {
                triangulations = Triangulation.CreateDelaunay(this.Vertices);


                this.TsData.VerticesList = new List<Point3D>(this.Vertices.Count);
                this.TsData.TriLinksList = new List<TriLink>(this.triangulations.Cells.Count());

                // 以Dict记录三角形的编号
                int num = 1;
                foreach (var cell in this.triangulations.Cells)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        var v = cell.Vertices[i];
                        if (!this.vertexnumDictionary.ContainsKey(v))
                        {
                            this.vertexnumDictionary.Add(v, num++);
                        }
                    }

                    // 根据编号写ts的TriLinksList
                    this.TsData.TriLinksList.Add(new TriLink
                    {
                        VertexA = this.vertexnumDictionary[cell.Vertices[0]],
                        VertexB = this.vertexnumDictionary[cell.Vertices[1]],
                        VertexC = this.vertexnumDictionary[cell.Vertices[2]]
                    });
                }

                // 写ts的VerticesList, 并插值Z
                foreach (var kv in this.vertexnumDictionary.OrderBy(n => n.Value))
                {
                    double[] vPos = kv.Key.Position;
                    var x = vPos[0];
                    var y = vPos[1];
                    var z = se.GetInterpolateValue(x, y);

                    this.TsData.VerticesList.Add(new Point3D(x, y, z));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        /// <summary>
        /// 倒置字典
        /// </summary>
        private void WriteNumVertexDict()
        {
            foreach (var kv_vertexnum in this.vertexnumDictionary)
            {
                this.numVertexDictionary.Add(kv_vertexnum.Value, kv_vertexnum.Key);
            }
        }


    }
}
