using Game.Core.BlockMerge;
using Game.Core.BlockSpawn;
using System;

namespace Game.Core.LevelProgress
{
    public class LevelProgressController : IDisposable
    {
        private readonly ILevelProgressModel _progress;
        private readonly IBlockSpawnController _spawnController;
        private readonly IBlockMergeController _mergeController;

        private int _spawnedBlockCount;

        public LevelProgressController(ILevelProgressModel progress,
                                       IBlockSpawnController spawnController,
                                       IBlockMergeController mergeController)
        {
            _progress = progress;
            _spawnController = spawnController;
            _mergeController = mergeController;

            _spawnController.OnBlockSpawned += OnBlockSpawned;
            _mergeController.OnBlocksMerge += OnBlocksMerge;
        }

        private void OnBlocksMerge(int amount)
        {
            _progress.Score += amount;
        }

        private void OnBlockSpawned()
        {
            _spawnedBlockCount++;
            _progress.Level = _spawnedBlockCount / 10;
        }

        public void Dispose()
        {
            _spawnController.OnBlockSpawned -= OnBlockSpawned;
            _mergeController.OnBlocksMerge -= OnBlocksMerge;
        }
    }
}
