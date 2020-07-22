using System;

namespace Game.Core.BlockMerge
{
    public interface IBlockMergeController
    {
        event Action<int> OnBlocksMerge;

        bool TryMergeBlocks();
    }
}
