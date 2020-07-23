using Game.Core.Block;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public interface IBlockShapeMeshProvider
    {
        Mesh GetShapeMesh(BlockShapeData shapeData);
    }
}
