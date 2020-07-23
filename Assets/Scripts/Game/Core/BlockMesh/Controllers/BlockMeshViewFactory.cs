using UnityEngine;

namespace Game.Core.BlockMesh
{
    public class BlockMeshViewFactory : IBlockMeshViewFactory
    {
        private readonly BlockMeshView _prefab;

        public BlockMeshViewFactory(BlockMeshView prefab)
        {
            _prefab = prefab;
        }

        public IBlockMeshView CreateBlock()
        {
            return GameObject.Instantiate(_prefab);
        }
    }
}
