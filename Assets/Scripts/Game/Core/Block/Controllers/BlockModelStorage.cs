using System;
using System.Collections.Generic;

namespace Game.Core.Block
{
    public class BlockModelStorage : IBlockModelStorage
    { 
        public event Action<IBlockModel> OnBlockAdded;
        public event Action<IBlockModel> OnBlockRemoved;

        public IReadOnlyList<IBlockModel> Blocks => _blocks;

        private List<IBlockModel> _blocks;

        public BlockModelStorage()
        {
            _blocks = new List<IBlockModel>();
        }

        public void AddBlock(IBlockModel block)
        {
            _blocks.Add(block);
            OnBlockAdded?.Invoke(block);
        }

        public void RemoveBlock(IBlockModel block)
        {
            _blocks.Remove(block);
            OnBlockRemoved?.Invoke(block);
        }
    }
}
