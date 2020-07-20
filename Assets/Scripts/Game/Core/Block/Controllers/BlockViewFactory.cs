using UnityEngine;

namespace Game.Core.Block
{
    public class BlockViewFactory : IBlockViewFactory
    {
        private readonly BlockViewFactoryConfig _config;

        public BlockViewFactory(BlockViewFactoryConfig config)
        {
            _config = config;
        }

        public IBlockSectionView CreateSection()
        {
            return GameObject.Instantiate(_config.BlockSectionView);
        }

        public IBlockView CreateBlock()
        {
            return GameObject.Instantiate(_config.BlockView);
        }
    }
}
