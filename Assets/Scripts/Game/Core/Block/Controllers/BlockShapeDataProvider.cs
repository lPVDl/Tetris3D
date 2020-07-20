using System.Collections.Generic;
using System.Linq;

namespace Game.Core.Block
{
    public class BlockShapeDataProvider : IBlockShapeDataProvider
    {
        private Dictionary<EBlockShapeType, BlockShapeData> _shapes;

        public BlockShapeDataProvider(List<BlockShapeData> shapes)
        {
            _shapes = shapes.ToDictionary(s => s.ShapeType);
        }

        public BlockShapeData GetShape(EBlockShapeType shapeType)
        {
            if (!_shapes.TryGetValue(shapeType, out var shape))
                UnityEngine.Debug.LogError($"{this}: shape '{shapeType}' was not found");

            return shape;
        }
    }
}
