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

        private List<Point> verticesList;

        private ITriangulation<Vertex, DefaultTriangulationCell<Vertex>> triangulations;

        public TsData TsData {get; } = new TsData();


        private readonly Dictionary<Vertex, int> vertexnumDictionary = new Dictionary<Vertex, int>();

        private readonly Dictionary<int, Vertex> numVertexDictionary = new Dictionary<int, Vertex>();

        public Triangulations(IList<Point> pointsList, IList<Point> verticesList)
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

        /// <summary>
        /// Skyline中绘制该三角网面片
        /// </summary>
        /// <param name="sgworld"></param>
        public void Draw(ref SGWorld66 sgworld)
        {


            List<ILinearRing> ringsList = new List<ILinearRing>(this.triangulations.Cells.Count());
            foreach (var facet in this.TsData.TriLinksList)
            {
                int intA = facet.VertexA - 1;
                int intB = facet.VertexB - 1;
                int intC = facet.VertexC - 1;

                List<double> vList = new List<double>();

                // 三角面片的三个顶点坐标列表
                vList.Add(TsData.VerticesList[intA].X);
                vList.Add(TsData.VerticesList[intA].Y);
                vList.Add(TsData.VerticesList[intA].Z);
                vList.Add(TsData.VerticesList[intB].X);
                vList.Add(TsData.VerticesList[intB].Y);
                vList.Add(TsData.VerticesList[intB].Z);
                vList.Add(TsData.VerticesList[intC].X);
                vList.Add(TsData.VerticesList[intC].Y);
                vList.Add(TsData.VerticesList[intC].Z);
                vList.Add(TsData.VerticesList[intA].X);
                vList.Add(TsData.VerticesList[intA].Y);
                vList.Add(TsData.VerticesList[intA].Z);
                var ring = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(vList.ToArray());
                ringsList.Add(ring);
            }



            IMultiPolygon multiPolygonGeo = sgworld.Creator.GeometryCreator.CreateMultiPolygonGeometry(ringsList.ToArray());
            IColor66 lineColor = sgworld.Creator.CreateColor(128, 0, 0, 128);
            IColor66 fillColor = sgworld.Creator.CreateColor(128, 128, 128, 128);

            // throw new Exception(multiPolygonGeo.GeometryTypeStr);

            for (int i = 0; i < multiPolygonGeo.NumGeometries; ++i)
            {
                IPolygon iP = multiPolygonGeo[i] as IPolygon;

                sgworld.Creator.CreatePolygon(
                    iP,
                    lineColor,
                    fillColor,
                    AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
                    GeoHelper.CreateGroup("TestMultiPolygon", ref sgworld));
            }
            
            
            
        }
    }
}
