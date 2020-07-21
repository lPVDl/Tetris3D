using UnityEngine;

namespace Game.Core.BlockMotion
{
    public interface IBlockMotionController
    {
        bool TryMoveBlock(Vector3Int direction);

        bool TryRotateBlock(Quaternion rotation);
    }
}
