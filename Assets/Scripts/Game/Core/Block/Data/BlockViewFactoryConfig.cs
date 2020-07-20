using UnityEngine;

namespace Game.Core.Block
{
    [System.Serializable]
    public class BlockViewFactoryConfig
    {
        public BlockSectionView BlockSectionView => _blockSectionView;
        public BlockView BlockView => _blockView;

        [SerializeField] private BlockSectionView _blockSectionView;
        [SerializeField] private BlockView _blockView;
    }
}
