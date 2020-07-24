using Game.Common.GameEvents;
using Game.Core.BlockMesh;
using System;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelDrawingController : IInitializable, ILateUpdatable, IDisposable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.Common;

        private readonly ILevelModel _levelModel;
        private readonly IBlockMeshViewFactory _blockMeshFactory;
        private readonly ILevelViewTransform _levelViewTransform;
        private readonly IBlockMeshBuilder _blockMeshBuilder;

        private IBlockMeshView _meshView;
        private Mesh _mesh;
        private bool _isDirty;

        public LevelDrawingController(ILevelModel levelModel,
                                                  IBlockMeshViewFactory blockMeshFactory,
                                                  ILevelViewTransform levelViewTransform,
                                                  IBlockMeshBuilder blockMeshBuilder)
        {
            _levelModel = levelModel;
            _blockMeshFactory = blockMeshFactory;
            _levelViewTransform = levelViewTransform;
            _blockMeshBuilder = blockMeshBuilder;

            _levelModel.OnBlockAdded += OnBlockAdded;
            _levelModel.OnBlockRemoved += OnBlockRemoved;
            _levelModel.OnBlockMoved += OnBlockMoved;
        }

        public void Initialize()
        {
            _mesh = new Mesh();
            _meshView = _blockMeshFactory.CreateBlock();
            _meshView.SetPosition(Vector3.zero);
            _meshView.SetRotation(Quaternion.identity);
            _meshView.SetMesh(_mesh);
            var size = _levelModel.Size;
            _meshView.SetPosition(new Vector3(-size.x / 2 + 0.5f, 0.5f, -size.z / 2 + 0.5f));
        }

        public void LateUpdate(float deltaTime)
        {
            if (!_isDirty)
                return;

            _isDirty = false;
            _blockMeshBuilder.BuildMesh(_mesh, _levelModel.IterateBlocks());
        }

        private void OnBlockAdded(Vector3Int position)
        {
            _isDirty = true;
        }

        private void OnBlockRemoved(Vector3Int position)
        {
            _isDirty = true;
        }

        private void OnBlockMoved(Vector3Int from, Vector3Int to)
        {
            _isDirty = true;
        }

        public void Dispose()
        {
            _levelModel.OnBlockAdded -= OnBlockAdded;
            _levelModel.OnBlockRemoved -= OnBlockRemoved;
            _levelModel.OnBlockMoved -= OnBlockMoved;
        }
    }
}
