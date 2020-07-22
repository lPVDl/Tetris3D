using Game.Core.Block;
using System;

namespace Game.Core.BlockSpawn
{
    public interface IBlockSpawnController
    {
        event Action OnNextBlockChange;
        event Action OnBlockSpawned;

        IBlockModel NextBlock { get; }

        /// <summary>
        /// Will spawn new falling block at level top if space available.
        /// </summary>
        /// <returns></returns>
        bool TrySpawnBlock();
    }
}
