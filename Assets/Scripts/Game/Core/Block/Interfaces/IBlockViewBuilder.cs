namespace Game.Core.Block
{
    public interface IBlockViewBuilder
    {
        IBlockView BuildView(IBlockModel block);
    }
}
