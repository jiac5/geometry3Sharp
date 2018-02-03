#define USE_VTK

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;

namespace GeometryProcessing {
    public partial class FormGeometryProcessing : Form {
        public FormGeometryProcessing() {
            InitializeComponent();
        }

        g3.DMesh3 _mesh = null;

        vtkActor actor = null;
                

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK) {
                var path = dialog.FileName;

                var builder = new g3.DMesh3Builder();
                var reader = new g3.StandardMeshReader() { MeshBuilder = builder };
                g3.IOReadResult result = reader.Read(path, g3.ReadOptions.Defaults);
                if (result.code == g3.IOCode.Ok) {
                    var meshes = builder.Meshes;

                    _mesh = meshes[0];

                    DrawMesh();
                }
            }
        }

        private void qualityStatisticsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (_mesh == null) {
                
            } else { 
                var genus = g3.MeshMeasurements.Genus(_mesh).Genus;
                MessageBox.Show("Genus:"+genus+"\n");
            }
        }

        private void DrawMesh() {
#if USE_VTK
            var renderer = this.renderWindowControl.RenderWindow.GetRenderers().GetFirstRenderer();

            if (this.actor != null) {
                renderer.RemoveActor(this.actor);
                this.actor.Dispose();
                this.actor = null;
            }

            var points = vtkPoints.New();
            points.SetNumberOfPoints(_mesh.VertexCount);
            int index = 0;
            foreach (var vertex in _mesh.Vertices()) {
                points.SetPoint(index++, vertex.x, vertex.y, vertex.z);
            }

            var triangles = vtkCellArray.New();
            triangles.Allocate(triangles.EstimateSize(_mesh.TriangleCount, 3), _mesh.TriangleCount / 2);

            
            foreach (var triangle in _mesh.Triangles()) {
                vtkIdList verts = vtkIdList.New();
                verts.InsertNextId(triangle.a);
                verts.InsertNextId(triangle.b);
                verts.InsertNextId(triangle.c);
                triangles.InsertNextCell(verts);
            }

            var polyData = vtkPolyData.New();
            polyData.SetPoints(points);
            polyData.SetPolys(triangles);

            points.Dispose();
            triangles.Dispose();

            var mapper = vtkPolyDataMapper.New();
            mapper.SetInput(polyData);

            actor = vtkActor.New();
            actor.SetMapper(mapper);

            renderer.AddActor(actor);

            this.renderWindowControl.RenderWindow.Render();
#endif
        }
        
        private bool CheckAndWarnMeshExist() {
            if (_mesh == null) {
                MessageBox.Show("No mesh loaded yet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void laplacianSmoothToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!CheckAndWarnMeshExist()) {
                return;
            }

            // JC: Note that this is not the g3.LaplacianMeshSmoother. I am not sure what that function does.
            // According to MeshLab, Laplacian smoothing means: for each vertex, calculate the average position with nearest vertex.


            // TODO(jiac5): a lot of optimization is needed here.
            List<g3.Vector3d> temp = new List<g3.Vector3d>(_mesh.VertexCount);
            for (int i = 0; i < _mesh.VertexCount; ++i) {
                temp.Add(new g3.Vector3d());
            }
            foreach (var v in _mesh.VertexIndices()) {
                var avg = new g3.Vector3d();
                int count = 0;
                foreach (var neighbor_v in _mesh.VtxVerticesItr(v)) {
                    avg = avg + _mesh.GetVertex(neighbor_v);
                    count++;
                }
                avg = avg / count;
                temp[v] = avg;
            }

            foreach (var v in _mesh.VertexIndices()) {
                _mesh.SetVertex(v, temp[v]);
            }

            DrawMesh();
        }
    }
}
