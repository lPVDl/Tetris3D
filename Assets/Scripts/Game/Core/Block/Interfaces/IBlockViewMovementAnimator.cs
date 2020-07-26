using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockViewMovementAnimator
    {
        void AnimateMovement(IBlockView view, Vector3 targetPosition);

        void StopAnimation(IBlockView view);
    }
}
