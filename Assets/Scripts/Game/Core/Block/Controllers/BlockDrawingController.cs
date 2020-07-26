using Game.Core.Level;
using System;
using System.Collections.Generic;

namespace Game.Core.Block
{
    public class BlockDrawingController : IDisposable
    {
        private readonly IBlockModelStorage _blockModelStorage;
        private readonly IBlockViewBuilder _blockViewBuilder;
        private readonly ILevelViewTransform _viewTransform;
        private readonly IBlockViewRotationAnimator _rotationAnimator;
        private readonly Dictionary<IBlockModel, IBlockView> _blockToView;

        public BlockDrawingController(IBlockModelStorage blockModelStorage,
                                      IBlockViewBuilder blockViewBuilder,
                                      ILevelViewTransform viewTransform,
                                      IBlockViewRotationAnimator rotationAnimator)
        {
            _blockModelStorage = blockModelStorage;
            _blockViewBuilder = blockViewBuilder;
            _viewTransform = viewTransform;
            _rotationAnimator = rotationAnimator;
            _blockToView = new Dictionary<IBlockModel, IBlockView>();

            _blockModelStorage.OnBlockAdded += OnBlockAdded;
            _blockModelStorage.OnBlockRemoved += OnBlockRemoved;
        }

        private void OnBlockAdded(IBlockModel block)
        {
            var worldPos = _viewTransform.TransformPosition(block.Position);
            var view = _blockViewBuilder.BuildView(block);
            _blockToView[block] = view;
            view.SetPosition(worldPos);
            view.Rotation = block.Rotation;
            Subscribe(block);
        }

        private void OnBlockRemoved(IBlockModel block)
        {
            var view = _blockToView[block];
            _rotationAnimator.StopAnimation(view);
            view.Dispose();
            _blockToView.Remove(block);
            Unsubscribe(block);
        }

        private void Subscribe(IBlockModel block)
        {
            block.OnPositionChanged += UpdateBlockPosition;
            block.OnRotationChanged += UpdateBlockRotation;
        }

        private void Unsubscribe(IBlockModel block)
        {
            block.OnPositionChanged -= UpdateBlockPosition;
            block.OnRotationChanged -= UpdateBlockRotation;
        }

        private void UpdateBlockRotation(IBlockModel block)
        {
            _rotationAnimator.AnimateRotation(_blockToView[block], block.Rotation);
        }

        private void UpdateBlockPosition(IBlockModel block)
        {
            var worldPos = _viewTransform.TransformPosition(block.Position);
            _blockToView[block].SetPosition(worldPos);
        }

        public void Dispose()
        {
            _blockModelStorage.OnBlockAdded -= OnBlockAdded;
            _blockModelStorage.OnBlockRemoved -= OnBlockRemoved;
            foreach (var block in _blockToView.Keys)
                Unsubscribe(block);
        }
    }
}
