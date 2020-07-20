using UnityEngine;

namespace Game.Core.Block
{
    public class BlockModelFactory : IBlockModelFactory
    {
        private readonly IBlockShapeDataProvider _blockShapeProvider;

        public BlockModelFactory(IBlockShapeDataProvider blockShapeProvider)
        {
            _blockShapeProvider = blockShapeProvider;
        }

        public IBlockModel CreateBlock(EBlockShapeType shapeType, Vector3 position, Quaternion rotation)
        {
            var shape = _blockShapeProvider.GetShape(shapeType);
            return new BlockModel(shape, position, rotation);
        }
    }
}
