using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIConvexHull;


namespace FGeo3D.GeoCurvedSurface
{
    using FGeo3D.GoCAD;

    using TerraExplorerX;

    public class Facet
    {
        private SGWorld66 sgworld;

        public string GroupID { get; private set; }

        public string FacetName { get; private set; }

        public IPosition66 GroupPositon { get; private set; }

        public IColor66 FillColor { get; private set; }

        public IColor66 LineColor { get; private set; }


        private List<ILinearRing> ringsList = new List<ILinearRing>();
        private List<ITerrainPolygon66> polygonList = new List<ITerrainPolygon66>();


        public Facet(ref SGWorld66 inSgworld, TsData tsData, string facetName, string parentGroupID, IColor66 lineColor, IColor66 fillColor)
        {
            this.sgworld = inSgworld;
            this.FacetName = facetName;
            this.FillColor = fillColor;
            this.LineColor = lineColor;

            
            foreach (var triLink in tsData.TriLinksList)
            {
                int intA = triLink.VertexA - 1;
                int intB = triLink.VertexB - 1;
                int intC = triLink.VertexC - 1;

                var vList = new List<double>
                                {
                                    tsData.VerticesList[intA].X,
                                    tsData.VerticesList[intA].Y,
                                    tsData.VerticesList[intA].Z,
                                    tsData.VerticesList[intB].X,
                                    tsData.VerticesList[intB].Y,
                                    tsData.VerticesList[intB].Z,
                                    tsData.VerticesList[intC].X,
                                    tsData.VerticesList[intC].Y,
                                    tsData.VerticesList[intC].Z,
                                    tsData.VerticesList[intA].X,
                                    tsData.VerticesList[intA].Y,
                                    tsData.VerticesList[intA].Z
                                };

                // 三角面片的三个顶点坐标列表
                var ring = this.sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(vList.ToArray());
                this.ringsList.Add(ring);
            }


            this.GroupID = this.sgworld.ProjectTree.CreateLockedGroup(facetName, parentGroupID);
        }



        public void DrawFacet()
        {
            foreach (var ring in this.ringsList)
            {
                var polygonGeo = this.sgworld.Creator.GeometryCreator.CreatePolygonGeometry(ring);
                var face = this.sgworld.Creator.CreatePolygon(
                    polygonGeo,
                    LineColor,
                    FillColor,
                    AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE,
                    GroupID);
                this.polygonList.Add(face);
            }
        }

    }
}
