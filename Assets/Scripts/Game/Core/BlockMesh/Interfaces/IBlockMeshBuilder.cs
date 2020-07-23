using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public interface IBlockMeshBuilder
    {
        void BuildMesh(Mesh target, IEnumerable<Vector3Int> blocks);
    }
}
