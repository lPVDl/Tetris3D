using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockViewRotationAnimator
    {
        void AnimateRotation(IBlockView view, Quaternion targetRotation);

        void StopAnimation(IBlockView view);
    }
}
