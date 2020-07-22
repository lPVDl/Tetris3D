using UnityEngine;

namespace Game.Core.BlockMotion
{
    public interface IBlockMotionController
    {
        /// <summary>
        /// Moves falling block if after movement it still will inside level bounds and does not intersect level blocks.
        /// </summary>
        bool TryMoveBlock(Vector3Int direction);

        /// <summary>
        /// Rotates falling block if after rotation it still will inside level bounds and does not intersect level blocks.
        /// </summary>
        bool TryRotateBlock(Quaternion rotation);
    }
}
