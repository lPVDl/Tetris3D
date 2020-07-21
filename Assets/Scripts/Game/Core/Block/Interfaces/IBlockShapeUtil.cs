using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockShapeUtil
    {
        IEnumerable<Vector3Int> IterateBlockSections(Vector3Int position, Quaternion rotation, BlockShapeData shapeData);
        IEnumerable<Vector3Int> IterateBlockSections(IBlockModel block);
    }
}
