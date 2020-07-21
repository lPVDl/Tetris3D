using Game.Core.Block;
using UnityEngine;

namespace Game.Core.Level
{
    public interface ILevelPhysicsController
    {
        bool CheckShapeInsideLevelBounds(Vector3Int position, Quaternion rotation, BlockShapeData shape);
    }
}
