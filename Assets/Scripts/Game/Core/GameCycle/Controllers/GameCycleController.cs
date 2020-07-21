using Game.Common.Coroutines;
using Game.Common.GameEvents;
using Game.Core.Block;
using Game.Core.BlockGravity;
using Game.Core.BlockSpawn;
using System.Collections;
using UnityEngine;

namespace Game.Core.GameCycle
{
    public class GameCycleController : IInitializable
    {
        private readonly ICoroutineManager _coroutineManager;
        private readonly IBlockSpawnController _spawnController;
        private readonly IBlockGravityController _gravityController;
        private readonly IBlockModelStorage _modelStorage;

        public GameCycleController(ICoroutineManager coroutineManager,
                                   IBlockSpawnController spawnController,
                                   IBlockGravityController gravityController,
                                   IBlockModelStorage modelStorage)
        {
            _coroutineManager = coroutineManager;
            _spawnController = spawnController;
            _gravityController = gravityController;
            _modelStorage = modelStorage;
        }

        public void Initialize()
        {
            _coroutineManager.StartCoroutine(GameRoutine());
        }

        private IEnumerator GameRoutine()
        {
            yield return null;

            while (_spawnController.TrySpawnBlock())
            {
                while (_gravityController.TryApplyGravity(Time.deltaTime)) 
                    yield return null;

                _modelStorage.RemoveBlock(_modelStorage.Blocks[0]);
            }
        }
    }
}
