using Game.Core.Block;
using Game.Core.Level;
using UnityEngine;

namespace Game.Core.BlockMotion
{
    public class BlockMotionController : IBlockMotionController
    {
        private readonly IBlockModelStorage _blockStorage;
        private readonly ILevelPhysicsController _levelPhysics;

        public BlockMotionController(IBlockModelStorage blockStorage,
                                     ILevelPhysicsController levelPhysics)
        {
            _blockStorage = blockStorage;
            _levelPhysics = levelPhysics;
        }

        public bool TryMoveBlock(Vector3Int direction)
        {
            if (_blockStorage.Blocks.Count <= 0) return false;
            var block = _blockStorage.Blocks[0];

            var newPosition = block.Position + direction;
            if (!CheckAcceptableBlockState(newPosition, block.Rotation, block.Shape))
                return false;

            block.Position = newPosition;
            return true;
        }

        public bool TryRotateBlock(Quaternion rotation)
        {
            if (_blockStorage.Blocks.Count <= 0) return false;
            var block = _blockStorage.Blocks[0];

            var newRotation = rotation * block.Rotation;
            if (!CheckAcceptableBlockState(block.Position, newRotation, block.Shape))
                return false;

            block.Rotation = newRotation;
            return true;
        }

        private bool CheckAcceptableBlockState(Vector3Int position, Quaternion rotation, BlockShapeData shape)
        {
            if (!_levelPhysics.CheckShapeInsideLevelBounds(position, rotation, shape))
                return false;

            if (_levelPhysics.CheckOverlappingLevelBlocks(position, rotation, shape))
                return false;

            return true;
        }
    }
}
