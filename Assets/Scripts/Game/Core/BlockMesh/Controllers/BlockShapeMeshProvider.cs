using Game.Core.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public class BlockShapeMeshProvider : IBlockShapeMeshProvider
    {
        private readonly IBlockMeshBuilder _meshBuilder;
        private readonly Dictionary<EBlockShapeType, Mesh> _shapes;

        public BlockShapeMeshProvider(IBlockMeshBuilder meshBuilder)
        {
            _meshBuilder = meshBuilder;
            _shapes = new Dictionary<EBlockShapeType, Mesh>();
        }

        public Mesh GetShapeMesh(BlockShapeData shapeData)
        {
            if (!_shapes.TryGetValue(shapeData.ShapeType, out var mesh))
            {
                mesh = new Mesh();
                _meshBuilder.BuildMesh(mesh, shapeData.Sections.Select(p => (Vector3)p));
                _shapes[shapeData.ShapeType] = mesh;
            }

            return mesh;
        }
    }
}
