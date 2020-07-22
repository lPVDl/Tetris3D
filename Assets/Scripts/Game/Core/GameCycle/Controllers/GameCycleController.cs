using Game.Common.Coroutines;
using Game.Common.GameEvents;
using Game.Core.BlockGravity;
using Game.Core.BlockJoin;
using Game.Core.BlockMerge;
using Game.Core.BlockSpawn;
using Game.Core.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.GameCycle
{
    public class GameCycleController : IInitializable, IGameCycleController
    {
        private readonly ICoroutineManager _coroutineManager;
        private readonly IBlockSpawnController _spawnController;
        private readonly IBlockGravityController _gravityController;
        private readonly IBlockJoinController _joinController;
        private readonly IBlockMergeController _mergeController;
        private readonly List<IGameFinishListener> _gameFinishListeners;
        private readonly List<IGameStartListener> _gameStartListeners;
        private readonly ILevelModel _levelModel;

        private Coroutine _coroutine;

        public GameCycleController(ICoroutineManager coroutineManager,
                                   IBlockSpawnController spawnController,
                                   IBlockGravityController gravityController,
                                   IBlockJoinController joinController,
                                   IBlockMergeController mergeController,
                                   List<IGameFinishListener> gameFinishListeners,
                                   List<IGameStartListener> gameStartListeners,
                                   ILevelModel levelModel)
        {
            _coroutineManager = coroutineManager;
            _spawnController = spawnController;
            _gravityController = gravityController;
            _joinController = joinController;
            _mergeController = mergeController;
            _gameFinishListeners = gameFinishListeners;
            _gameStartListeners = gameStartListeners;
            _levelModel = levelModel;
        }

        public void Initialize()
        {
            StartGame();
        }

        public void StartGame()
        {
            if (_coroutine != null)
            {
                _coroutineManager.StopCoroutine(_coroutine);
            }

            _levelModel.Clear();
            _coroutine = _coroutineManager.StartCoroutine(GameRoutine());
        }

        private IEnumerator GameRoutine()
        {
            foreach (var listener in _gameStartListeners)
                listener.OnGameStart();

            yield return null;

            while (_spawnController.TrySpawnBlock())
            {
                while (_gravityController.TryApplyGravity(Time.deltaTime)) 
                    yield return null;

                _joinController.JoinBlock();

                _mergeController.TryMergeBlocks();
            }

            foreach (var listener in _gameFinishListeners)
                listener.OnGameFinish();
        }
    }
}
