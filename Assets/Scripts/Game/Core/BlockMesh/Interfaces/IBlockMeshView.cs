using Game.Core.Block;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public interface IBlockMeshView : IBlockView
    {
        void SetMesh(Mesh mesh);
    }
}
