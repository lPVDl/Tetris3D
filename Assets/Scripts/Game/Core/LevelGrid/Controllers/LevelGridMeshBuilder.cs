using Game.Common.MeshTools;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.LevelGrid
{
    public class LevelGridMeshBuilder : ILevelGridMeshBuilder
    {
        private static readonly Vector2 _uv0 = new Vector2(0, 0);
        private static readonly Vector2 _uv1 = new Vector2(0, 1);
        private static readonly Vector2 _uv2 = new Vector2(1, 1);
        private static readonly Vector2 _uv3 = new Vector2(1, 0);


        private readonly List<Vector3> _vertices;
        private readonly List<Vector2> _uvs;
        private readonly List<int> _triangles;

        public LevelGridMeshBuilder()
        {
            _vertices = new List<Vector3>();
            _uvs = new List<Vector2>();
            _triangles = new List<int>();
        }

        public Mesh Build(Vector3 size)
        {
            _vertices.Clear();
            _uvs.Clear();
            _triangles.Clear();

            var cube = new CubeMeshData(size);
            var zAxisUvScale = new Vector2(size.x, size.y);
            var xAxisUvScale = new Vector2(size.z, size.y);
            var yAxisUvScale = new Vector2(size.z, size.x);
            AddFace(cube.ReverseForward, zAxisUvScale);
            AddFace(cube.ReverseBackward, zAxisUvScale);
            AddFace(cube.ReverseRight, xAxisUvScale);
            AddFace(cube.ReverseLeft, xAxisUvScale);
            AddFace(cube.ReverseDown, yAxisUvScale);

            var mesh = new Mesh();
            mesh.SetVertices(_vertices);
            mesh.SetTriangles(_triangles, 0);
            mesh.SetUVs(0, _uvs);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.Optimize();

            return mesh;
        }

        private void AddFace(PlaneMeshData plane, Vector2 uvScale)
        {
            var vCount = _vertices.Count;
            _vertices.Add(plane.P0);
            _vertices.Add(plane.P1);
            _vertices.Add(plane.P2);
            _vertices.Add(plane.P3);

            _uvs.Add(_uv0 * uvScale);
            _uvs.Add(_uv1 * uvScale);
            _uvs.Add(_uv2 * uvScale);
            _uvs.Add(_uv3 * uvScale);

            _triangles.Add(vCount);
            _triangles.Add(vCount + 1);
            _triangles.Add(vCount + 2);

            _triangles.Add(vCount + 2);
            _triangles.Add(vCount + 3);
            _triangles.Add(vCount);
        }
    }
}