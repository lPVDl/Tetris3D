using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public class BlockMeshBuilder : IBlockMeshBuilder
    {
        private static readonly Vector3 P0 = new Vector3(0.5f, 0.5f, 0.5f);
        private static readonly Vector3 P1 = new Vector3(0.5f, 0.5f, -0.5f);
        private static readonly Vector3 P2 = new Vector3(-0.5f, 0.5f, -0.5f);
        private static readonly Vector3 P3 = new Vector3(-0.5f, 0.5f, 0.5f);
        private static readonly Vector3 P4 = new Vector3(0.5f, -0.5f, 0.5f);
        private static readonly Vector3 P5 = new Vector3(0.5f, -0.5f, -0.5f);
        private static readonly Vector3 P6 = new Vector3(-0.5f, -0.5f, -0.5f);
        private static readonly Vector3 P7 = new Vector3(-0.5f, -0.5f, 0.5f);

        private static readonly Vector2 U0 = Vector2.zero;
        private static readonly Vector2 U1 = Vector2.up;
        private static readonly Vector2 U2 = Vector2.one;
        private static readonly Vector2 U3 = Vector2.right;

        private static readonly Vector3Int Forward = new Vector3Int(0, 0, 1);
        private static readonly Vector3Int Backward = new Vector3Int(0, 0, -1);
        private static readonly Vector3Int Right = new Vector3Int(1, 0, 0);
        private static readonly Vector3Int Left = new Vector3Int(-1, 0, 0);
        private static readonly Vector3Int Top = new Vector3Int(0, 1, 0);
        private static readonly Vector3Int Down = new Vector3Int(0, -1, 0);

        private readonly List<Vector3> _vertex;
        private readonly List<Vector2> _uv;
        private readonly List<int> _triangle;
        private readonly HashSet<Vector3Int> _blockHashset;
        
        private Vector3 _vertexShift;

        public BlockMeshBuilder()
        {
            _vertex = new List<Vector3>();
            _uv = new List<Vector2>();
            _triangle = new List<int>();
            _blockHashset = new HashSet<Vector3Int>();
        }

        public void BuildMesh(Mesh target, IEnumerable<Vector3Int> blocks)
        {
            _blockHashset.Clear();
            _vertex.Clear();
            _triangle.Clear();
            _uv.Clear();
            target.Clear();

            foreach (var pos in blocks)
                _blockHashset.Add(pos);

            foreach (var pos in blocks)
                AddBlock(pos);

            target.SetVertices(_vertex);
            target.SetTriangles(_triangle, 0);
            target.SetUVs(0, _uv);

            target.RecalculateBounds();
            target.RecalculateNormals();
            target.Optimize();
        }

        private void AddBlock(Vector3Int pos)
        {
            _vertexShift = pos;

            if (!_blockHashset.Contains(pos + Forward))
                AddFace(P4, P0, P3, P7);

            if (!_blockHashset.Contains(pos + Backward))
                AddFace(P6, P2, P1, P5);

            if (!_blockHashset.Contains(pos + Right))
                AddFace(P5, P1, P0, P4);

            if (!_blockHashset.Contains(pos + Left))
                AddFace(P7, P3, P2, P6);

            if (!_blockHashset.Contains(pos + Top))
                AddFace(P2, P3, P0, P1);

            if (!_blockHashset.Contains(pos + Down))
                AddFace(P7, P6, P5, P4);
        }

        // 1---2
        // |   |
        // 0---3
        private void AddFace(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            var vCount = _vertex.Count;
            _vertex.Add(p0 + _vertexShift);
            _vertex.Add(p1 + _vertexShift);
            _vertex.Add(p2 + _vertexShift);
            _vertex.Add(p3 + _vertexShift);

            _uv.Add(U0);
            _uv.Add(U1);
            _uv.Add(U2);
            _uv.Add(U3);

            _triangle.Add(vCount);
            _triangle.Add(vCount + 1);
            _triangle.Add(vCount + 2);
            
            _triangle.Add(vCount + 2);
            _triangle.Add(vCount + 3);
            _triangle.Add(vCount);
        }
    }
}
