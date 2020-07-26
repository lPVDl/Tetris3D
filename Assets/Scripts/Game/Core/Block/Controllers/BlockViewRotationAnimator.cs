using Game.Common.GameEvents;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Block
{
    public class BlockViewRotationAnimator : IBlockViewRotationAnimator, IUpdatable
    {
        private const float AnimationTime = 0.1f;

        public struct AnimationData
        {
            public IBlockView View { get; set; }
            public Quaternion StartRotation { get; set; }
            public Quaternion EndRotation { get; set; }
            public float Time { get; set; }
        }

        private readonly List<AnimationData> _animations;

        public BlockViewRotationAnimator()
        {
            _animations = new List<AnimationData>();
        }

        public void AnimateRotation(IBlockView view, Quaternion targetRotation)
        {
            StopAnimation(view);

            var data = new AnimationData()
            {
                View = view,
                StartRotation = view.Rotation,
                EndRotation = targetRotation,
                Time = 0
            };
            _animations.Add(data);
        }

        public void Update(float deltaTime)
        {
            for (var i = _animations.Count - 1; i >= 0; i--)
            {
                var anim = _animations[i];
                anim.Time += deltaTime;
                var progress = anim.Time / AnimationTime;
                _animations[i] = anim;
                anim.View.Rotation = Quaternion.Lerp(anim.StartRotation, anim.EndRotation, progress);
                if (progress >= 1)
                    _animations.RemoveAt(i);
            }
        }

        public void StopAnimation(IBlockView view)
        {
            for (var i = _animations.Count - 1; i >= 0; i--)
                if (view == _animations[i].View)
                    _animations.RemoveAt(i);
        }
    }
}
