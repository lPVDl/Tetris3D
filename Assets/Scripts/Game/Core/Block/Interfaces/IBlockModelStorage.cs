using System;
using System.Collections.Generic;

namespace Game.Core.Block
{
    public interface IBlockModelStorage
    {
        IReadOnlyList<IBlockModel> Blocks { get; }

        event Action<IBlockModel> OnBlockAdded;
        event Action<IBlockModel> OnBlockRemoved;

        void AddBlock(IBlockModel block);

        void RemoveBlock(IBlockModel block);
    }
}
