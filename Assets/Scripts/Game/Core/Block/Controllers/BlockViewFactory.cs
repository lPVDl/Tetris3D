using UnityEngine;

namespace Game.Core.Block
{
    public class BlockViewFactory : IBlockViewFactory
    {
        private readonly BlockSectionView _sectionView;

        public BlockViewFactory(BlockSectionView sectionView)
        {
            _sectionView = sectionView;
        }

        public IBlockSectionView CreateSection()
        {
            return GameObject.Instantiate(_sectionView);
        }
    }
}
