using Game.Common.GameEvents;
using Game.Core.BlockMesh;
using Game.Core.Level;
using UnityEngine;

namespace Game.Core.LevelGrid
{
    public class LevelGridMeshController : IInitializable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.Common;

        private readonly IBlockMeshViewFactory _blockMeshViewFactory;
        private readonly ILevelGridMeshBuilder _gridMeshBuilder;
        private readonly Material _gridMaterial;
        private readonly ILevelModel _levelModel;

        public LevelGridMeshController(IBlockMeshViewFactory blockMeshViewFactory,
                                       ILevelGridMeshBuilder gridMeshBuilder,
                                       Material gridMaterial,
                                       ILevelModel levelModel)
        {
            _blockMeshViewFactory = blockMeshViewFactory;
            _gridMeshBuilder = gridMeshBuilder;
            _gridMaterial = gridMaterial;
            _levelModel = levelModel;
        }

        public void Initialize()
        {
            var gridMesh = _gridMeshBuilder.Build(_levelModel.Size);
            var gridView = _blockMeshViewFactory.CreateBlock();
            gridView.Position = new Vector3(0, _levelModel.Size.y / 2f, 0);
            gridView.Rotation = Quaternion.identity;
            gridView.SetMaterial(_gridMaterial);
            gridView.SetMesh(gridMesh);
        }
    }
}
