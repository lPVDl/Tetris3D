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
        private readonly IBlockMeshBuilder _blockMeshBuilder;

        private IBlockMeshView _meshView;
        private Mesh _mesh;
        private bool _isDirty;

        public LevelDrawingController(ILevelModel levelModel,
                                      IBlockMeshViewFactory blockMeshFactory,
                                      IBlockMeshBuilder blockMeshBuilder)
        {
            _levelModel = levelModel;
            _blockMeshFactory = blockMeshFactory;
            _blockMeshBuilder = blockMeshBuilder;

            _levelModel.OnBlockAdded += OnBlockAdded;
            _levelModel.OnBlockRemoved += OnBlockRemoved;
            _levelModel.OnBlockMoved += OnBlockMoved;
        }

        public void Initialize()
        {
            var size = _levelModel.Size;
            _mesh = new Mesh();
            _meshView = _blockMeshFactory.CreateBlock();
            _meshView.Position = new Vector3(-size.x / 2f + 0.5f, 0.5f, -size.z / 2f + 0.5f);
            _meshView.Rotation = Quaternion.identity;
            _meshView.SetMesh(_mesh);
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
