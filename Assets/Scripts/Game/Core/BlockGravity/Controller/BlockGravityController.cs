using Game.Core.BlockMotion;
using UnityEngine;

namespace Game.Core.BlockGravity
{
    public class BlockGravityController : IBlockGravityController
    {
        private readonly IBlockMotionController _blockMotion;
        
        private float _movementDelay;
        private float _delay;

        public BlockGravityController(IBlockMotionController blockMotion)
        {
            _blockMotion = blockMotion;
            _movementDelay = 1;
        }

        public void SetSpeed(float blocksPerSecond)
        {
            _movementDelay = 1 / blocksPerSecond;
            _delay = 0;
        }

        public bool TryApplyGravity(float deltaTime)
        {
            _delay += deltaTime;

            if (_delay < _movementDelay) return true;

            _delay -= _movementDelay;

            return _blockMotion.TryMoveBlock(Vector3Int.down);
        }
    }
}
