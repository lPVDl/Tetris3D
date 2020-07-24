using Game.Core.Block;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public interface IBlockMeshBuilder
    {
        void BuildMesh(Mesh target, IEnumerable<BlockMeshData> blocks);

        Mesh BuildMesh(IEnumerable<Vector3Int> blocks, EBlockTextureId textureId);
    }
}
