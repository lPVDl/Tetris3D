using Game.Common.GameEvents;
using Game.Core.LevelProgress;
using System;
using UnityEngine;

namespace Game.Core.BlockGravity
{
    public class BlockGravitySpeedController : IInitializable, IDisposable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.Common;

        private readonly IBlockGravityController _gravityController;
        private readonly IBlockGravitySpeedInputController _inputController;
        private readonly ILevelProgressModel _levelProgress;

        private bool _isSpeedup;

        public BlockGravitySpeedController(IBlockGravityController gravityController,
                                           IBlockGravitySpeedInputController inputController,
                                           ILevelProgressModel levelProgress)
        {
            _gravityController = gravityController;
            _inputController = inputController;
            _levelProgress = levelProgress;

            _inputController.OnSpeedupToggle += OnSpeedupToggle;
        }

        private void OnSpeedupToggle(bool isSpeedup)
        {
            _isSpeedup = isSpeedup;
            UpdateSpeed();
        }

        public void Initialize()
        {
            UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            var speedup = _isSpeedup ? 20 : 1;
            var levelSpeed = 1 + _levelProgress.Level / 10f;
            _gravityController.SetSpeed(Mathf.Max(levelSpeed, speedup));
        }

        public void Dispose()
        {
            _inputController.OnSpeedupToggle -= OnSpeedupToggle;
        }
    }
}
