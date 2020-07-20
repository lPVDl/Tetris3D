using System;
using System.Collections.Generic;

namespace Game.Core.Block
{
    public class BlockDrawingController : IDisposable
    {
        private readonly IBlockModelStorage _blockModelStorage;
        private readonly IBlockViewBuilder _blockViewBuilder;
        private readonly Dictionary<IBlockModel, IBlockView> _blockToView;

        public BlockDrawingController(IBlockModelStorage blockModelStorage,
                                      IBlockViewBuilder blockViewBuilder)
        {
            _blockModelStorage = blockModelStorage;
            _blockViewBuilder = blockViewBuilder;
            _blockToView = new Dictionary<IBlockModel, IBlockView>();

            _blockModelStorage.OnBlockAdded += OnBlockAdded;
            _blockModelStorage.OnBlockRemoved += OnBlockRemoved;
        }

        private void OnBlockAdded(IBlockModel block)
        {
            _blockToView[block] = _blockViewBuilder.BuildView(block);
            Subscribe(block);
        }

        private void OnBlockRemoved(IBlockModel block)
        {
            var view = _blockToView[block];
            view.Dispose();
            _blockToView.Remove(block);
            Unsubscribe(block);
        }

        private void Subscribe(IBlockModel block)
        {
            block.OnPositionChanged += OnBlockPositionChanged;
            block.OnRotationChanged += OnBlockRotationChanged;
        }

        private void Unsubscribe(IBlockModel block)
        {
            block.OnPositionChanged -= OnBlockPositionChanged;
            block.OnRotationChanged -= OnBlockRotationChanged;
        }

        private void OnBlockRotationChanged(IBlockModel block)
        {
            _blockToView[block].SetPosition(block.Position);
        }

        private void OnBlockPositionChanged(IBlockModel block)
        {
            _blockToView[block].SetRotation(block.Rotation);
        }

        public void Dispose()
        {
            _blockModelStorage.OnBlockAdded -= OnBlockAdded;
            _blockModelStorage.OnBlockRemoved -= OnBlockRemoved;
        }
    }
}
