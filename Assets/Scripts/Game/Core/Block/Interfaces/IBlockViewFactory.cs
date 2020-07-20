namespace Game.Core.Block
{
    public interface IBlockViewFactory
    {
        IBlockView CreateBlock();
        IBlockSectionView CreateSection();
    }
}
