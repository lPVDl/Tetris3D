using System;

namespace Game.Core.Block
{
    public interface IBlockModelStorage
    {
        event Action<IBlockModel> OnBlockAdded;
        event Action<IBlockModel> OnBlockRemoved;

        void AddBlock(IBlockModel block);

        void RemoveBlock(IBlockModel block);
    }
}
