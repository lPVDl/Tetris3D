using System;

namespace Game.Core.BlockMerge
{
    public interface IBlockMergeController
    {
        event Action<int> OnBlocksMerge;

        /// <summary>
        /// Will try to find full lines in level blocks and remove them.
        /// </summary>
        bool TryMergeBlocks();
    }
}
