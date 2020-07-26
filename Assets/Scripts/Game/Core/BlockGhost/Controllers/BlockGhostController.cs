using Game.Core.Block;
using Game.Core.Level;
using System;
using UnityEngine;

namespace Game.Core.BlockGhost
{
    public class BlockGhostController : IDisposable
    {
        private readonly IBlockViewBuilder _blockViewBuilder;
        private readonly ILevelViewTransform _levelViewTransform;
        private readonly ILevelPhysicsController _levelPhysics;
        private readonly IBlockModelStorage _blockModelStorage;
        private readonly Material _ghostMaterial;
        private readonly IBlockViewRotationAnimator _rotationAnimator;

        private IBlockView _ghostBlockView;

        public BlockGhostController(IBlockViewBuilder blockViewBuilder,
                                    ILevelViewTransform levelViewTransform,
                                    ILevelPhysicsController levelPhysics,
                                    IBlockModelStorage blockModelStorage,
                                    Material ghostMaterial,
                                    IBlockViewRotationAnimator rotationAnimator)
        {
            _blockViewBuilder = blockViewBuilder;
            _levelViewTransform = levelViewTransform;
            _levelPhysics = levelPhysics;
            _blockModelStorage = blockModelStorage;
            _ghostMaterial = ghostMaterial;
            _rotationAnimator = rotationAnimator;

            _blockModelStorage.OnBlockAdded += OnBlockAdded;
            _blockModelStorage.OnBlockRemoved += OnBlockRemoved;
        }

        private void OnBlockAdded(IBlockModel block)
        {
            var levelPos = ComputeGhostPosition(block);
            var worldPos = _levelViewTransform.TransformPosition(levelPos);

            _rotationAnimator.StopAnimation(_ghostBlockView);
            _ghostBlockView?.Dispose();
            _ghostBlockView = _blockViewBuilder.BuildView(block);
            _ghostBlockView.SetMaterial(_ghostMaterial);
            _ghostBlockView.SetPosition(worldPos);
            _ghostBlockView.Rotation = block.Rotation;

            block.OnPositionChanged += UpdateGhostPositionRotation;
            block.OnRotationChanged += UpdateGhostPositionRotation;
        }

        private void OnBlockRemoved(IBlockModel block)
        {
            _rotationAnimator.StopAnimation(_ghostBlockView);
            _ghostBlockView?.Dispose();
            _ghostBlockView = null;
            block.OnPositionChanged -= UpdateGhostPositionRotation;
            block.OnRotationChanged -= UpdateGhostPositionRotation;
        }

        private void UpdateGhostPositionRotation(IBlockModel block)
        {
            var levelPos = ComputeGhostPosition(block);
            var worldPos = _levelViewTransform.TransformPosition(levelPos);
            _ghostBlockView.SetPosition(worldPos);
            _rotationAnimator.AnimateRotation(_ghostBlockView, block.Rotation);
        }

        private Vector3Int ComputeGhostPosition(IBlockModel block)
        {
            var pos = block.Position;
            var offset = ShiftUntilBorderOrBlockCollision(block, Vector3Int.down);
            if (offset == 0)
                return new Vector3Int(pos.x, 1000, pos.y);
            return pos + Vector3Int.down * offset;
        }

        private int ShiftUntilBorderOrBlockCollision(IBlockModel block, Vector3Int direction)
        {
            var pos = block.Position;
            var offset = 1;
            for (; ; offset++)
            {
                var shift = direction * offset;
                if (_levelPhysics.CheckOverlappingLevelBlocks(pos + shift, block.Rotation, block.Shape))
                    break;
                if (!_levelPhysics.CheckShapeInsideLevelBounds(pos + shift, block.Rotation, block.Shape))
                    break;
            }
            return offset - 1;
        }

        public void Dispose()
        {
            _blockModelStorage.OnBlockAdded -= OnBlockAdded;
            _blockModelStorage.OnBlockRemoved -= OnBlockRemoved;
        }
    }
}
