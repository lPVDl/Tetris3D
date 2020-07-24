using System.Collections.Generic;
using Game.Core.Block;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public class BlockMeshBuilder : IBlockMeshBuilder
    {
        //   3---------0
        //  /|        /|
        // 2---------1 |
        // | |       | |   Y
        // | 7-------|-4   | Z
        // |/        |/    |/
        // 6---------5     0---X
        private static readonly Vector3 P0 = new Vector3(0.5f, 0.5f, 0.5f);
        private static readonly Vector3 P1 = new Vector3(0.5f, 0.5f, -0.5f);
        private static readonly Vector3 P2 = new Vector3(-0.5f, 0.5f, -0.5f);
        private static readonly Vector3 P3 = new Vector3(-0.5f, 0.5f, 0.5f);
        private static readonly Vector3 P4 = new Vector3(0.5f, -0.5f, 0.5f);
        private static readonly Vector3 P5 = new Vector3(0.5f, -0.5f, -0.5f);
        private static readonly Vector3 P6 = new Vector3(-0.5f, -0.5f, -0.5f);
        private static readonly Vector3 P7 = new Vector3(-0.5f, -0.5f, 0.5f);

        private static readonly Vector3Int Forward = new Vector3Int(0, 0, 1);
        private static readonly Vector3Int Backward = new Vector3Int(0, 0, -1);
        private static readonly Vector3Int Right = new Vector3Int(1, 0, 0);
        private static readonly Vector3Int Left = new Vector3Int(-1, 0, 0);
        private static readonly Vector3Int Top = new Vector3Int(0, 1, 0);
        private static readonly Vector3Int Down = new Vector3Int(0, -1, 0);

        private readonly List<Vector3> _vertex;
        private readonly List<Vector2> _uvs;
        private readonly Vector2 _uvShift0;
        private readonly Vector2 _uvShift1;
        private readonly Vector2 _upShift2;
        private readonly Vector2 _uvShift3;
        private readonly List<int> _triangles;
        private readonly HashSet<Vector3Int> _blockHashset;
        private readonly Vector2Int _textureCount;
        private readonly Vector2 _uvSize;
        
        private Vector3 _vertexShift;
        private Vector2 _uvShiftBase;

        public BlockMeshBuilder(Vector2Int textureCount)
        {
            _textureCount = textureCount;
            _uvSize = new Vector2(1f / _textureCount.x, 1f / _textureCount.y);
            _uvShift0 = new Vector2(0, 0);
            _uvShift1 = new Vector2(0, _uvSize.y);
            _upShift2 = new Vector2(_uvSize.x, _uvSize.y);
            _uvShift3 = new Vector2(_uvSize.x, 0);

            _vertex = new List<Vector3>();
            _uvs = new List<Vector2>();
            _triangles = new List<int>();
            _blockHashset = new HashSet<Vector3Int>();
        }

        public void BuildMesh(Mesh target, IEnumerable<BlockMeshData> blocks)
        {
            ClearData(target);

            foreach (var b in blocks)
                _blockHashset.Add(b.Position);

            foreach (var b in blocks)
                AddBlock(b.Position, (int)b.TextureId);

            FinishBuilding(target);
        }

        public Mesh BuildMesh(IEnumerable<Vector3Int> blocks, EBlockTextureId textureId)
        {
            var target = new Mesh();
            ClearData(target);

            foreach (var p in blocks)
                _blockHashset.Add(p);

            var texId = (int)textureId;
            foreach (var p in blocks)
                AddBlock(p, texId);

            FinishBuilding(target);

            return target;
        }

        private void ClearData(Mesh target)
        {
            _blockHashset.Clear();
            _vertex.Clear();
            _triangles.Clear();
            _uvs.Clear();
            target.Clear();
        }

        private void FinishBuilding(Mesh target)
        {
            target.SetVertices(_vertex);
            target.SetTriangles(_triangles, 0);
            target.SetUVs(0, _uvs);
            target.RecalculateBounds();
            target.RecalculateNormals();
            target.Optimize();
        }

        private void AddBlock(Vector3Int pos, int textureId)
        {
            _vertexShift = pos;
            _uvShiftBase = new Vector2(textureId % _textureCount.y, textureId / _textureCount.y) * _uvSize;

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

            _uvs.Add(_uvShiftBase + _uvShift0);
            _uvs.Add(_uvShiftBase + _uvShift1);
            _uvs.Add(_uvShiftBase + _upShift2);
            _uvs.Add(_uvShiftBase + _uvShift3);

            _triangles.Add(vCount);
            _triangles.Add(vCount + 1);
            _triangles.Add(vCount + 2);
            
            _triangles.Add(vCount + 2);
            _triangles.Add(vCount + 3);
            _triangles.Add(vCount);
        }
    }
}
