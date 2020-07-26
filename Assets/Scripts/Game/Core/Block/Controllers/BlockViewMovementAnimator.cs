using Game.Common.GameEvents;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Block
{
    public class BlockViewMovementAnimator : IBlockViewMovementAnimator, IUpdatable
    {
        private struct AnimationData
        {
            public IBlockView View { get; set; }
            public Vector3 StartPosition { get; set; }
            public Vector3 EndPosition { get; set; }
            public float Time { get; set; }
        }

        private const float AnimationTime = 0.1f;

        private readonly List<AnimationData> _animations;
        
        public BlockViewMovementAnimator()
        {
            _animations = new List<AnimationData>();
        }

        public void AnimateMovement(IBlockView view, Vector3 targetPosition)
        {
            StopAnimation(view);

            var data = new AnimationData()
            {
                View = view,
                StartPosition = view.Position,
                EndPosition = targetPosition,
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
                anim.View.Position = Vector3.Lerp(anim.StartPosition, anim.EndPosition, progress);
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
