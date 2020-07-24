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
        private readonly IBlockShapeTextureProvider _shapeTextureProvider;
        private readonly Dictionary<EBlockShapeType, Mesh> _shapes;

        public BlockShapeMeshProvider(IBlockMeshBuilder meshBuilder,
                                      IBlockShapeTextureProvider shapeTextureProvider)
        {
            _meshBuilder = meshBuilder;
            _shapeTextureProvider = shapeTextureProvider;
            _shapes = new Dictionary<EBlockShapeType, Mesh>();
        }

        public Mesh GetShapeMesh(BlockShapeData shapeData)
        {
            if (!_shapes.TryGetValue(shapeData.ShapeType, out var mesh))
            {
                var textureId = _shapeTextureProvider.GetTexture(shapeData);
                mesh = _meshBuilder.BuildMesh(shapeData.Sections, textureId);
                _shapes[shapeData.ShapeType] = mesh;
            }

            return mesh;
        }
    }
}
