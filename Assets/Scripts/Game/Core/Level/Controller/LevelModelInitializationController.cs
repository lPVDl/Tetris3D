using Game.Common.GameEvents;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelModelInitializationController : IInitializable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.LevelModelInitialization;

        private readonly ILevelModel _levelModel;

        public LevelModelInitializationController(ILevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        public void Initialize()
        {
            var xSize = Random.Range(8, 12);
            var zSize = Random.Range(8, 12);
            var ySize = Random.Range(15, 20);
            _levelModel.Initialize(new Vector3Int(xSize, ySize, zSize));
        }
    }
}
