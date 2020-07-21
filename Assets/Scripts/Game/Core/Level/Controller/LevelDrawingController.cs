using Game.Common.GameEvents;
using Game.Core.Block;
using System;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelDrawingController : IInitializable, IDisposable
    {
        private readonly ILevelModel _levelModel;
        private readonly IBlockViewFactory _blockViewFactory;
        private readonly ILevelViewTransform _viewTransform;

        private Transform _root;
        private IBlockSectionView[,,] _blocks;

        private IBlockSectionView this[Vector3Int index]
        {
            get => _blocks[index.x, index.y, index.z];
            set => _blocks[index.x, index.y, index.z] = value;
        }

        public LevelDrawingController(ILevelModel levelModel,
                                      IBlockViewFactory blockViewFactory,
                                      ILevelViewTransform viewTransform)
        {
            _levelModel = levelModel;
            _blockViewFactory = blockViewFactory;
            _viewTransform = viewTransform;

            _levelModel.OnBlockAdded += OnBlockAdded;
            _levelModel.OnBlockRemoved += OnBlockRemoved;
            _levelModel.OnBlockMoved += OnBlockMoved;
        }

        public void Initialize()
        {
            _root = new GameObject("_LevelDrawingController").transform;
            var size = _levelModel.Size;
            _blocks = new IBlockSectionView[size.x, size.y, size.z];
        }

        private void OnBlockAdded(Vector3Int pos)
        {
            var view = _blockViewFactory.CreateSection();
            view.SetParent(_root);
            var worldPos = _viewTransform.TransformPosition(pos);
            view.SetPosition(worldPos);
            this[pos] = view;
        }

        private void OnBlockRemoved(Vector3Int pos)
        {
            this[pos].Dispose();
            this[pos] = null;
        }

        private void OnBlockMoved(Vector3Int from, Vector3Int to)
        {
            this[to] = this[from];
            this[from] = null;
            this[to].SetPosition(_viewTransform.TransformPosition(to));
        }

        public void Dispose()
        {
            _levelModel.OnBlockAdded -= OnBlockAdded;
            _levelModel.OnBlockRemoved -= OnBlockRemoved;
            _levelModel.OnBlockMoved -= OnBlockMoved;
        }
    }
}
