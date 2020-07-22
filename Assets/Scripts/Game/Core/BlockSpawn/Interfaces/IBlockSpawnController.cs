using Game.Core.Block;
using System;

namespace Game.Core.BlockSpawn
{
    public interface IBlockSpawnController
    {
        event Action OnNextBlockChange;
        event Action OnBlockSpawned;

        IBlockModel NextBlock { get; }

        bool TrySpawnBlock();
    }
}
