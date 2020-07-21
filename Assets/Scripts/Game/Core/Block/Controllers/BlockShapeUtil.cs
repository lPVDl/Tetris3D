using Game.Core.Level;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Block
{
    public class BlockShapeUtil : IBlockShapeUtil
    {
        private readonly ILevelViewTransform _levelTransform;

        public BlockShapeUtil(ILevelViewTransform levelTransform)
        {
            _levelTransform = levelTransform;
        }

        public IEnumerable<Vector3Int> IterateBlockSections(IBlockModel block) => IterateBlockSections(block.Position, block.Rotation, block.Shape);

        public IEnumerable<Vector3Int> IterateBlockSections(Vector3Int position, Quaternion rotation, BlockShapeData shapeData)
        {
            var center = _levelTransform.TransformPosition(position);
            foreach (var seg in shapeData.Sections)
            {
                var pos = center + rotation * seg;
                yield return _levelTransform.InverseTransformPosition(pos);
            }
        }
    }
}
