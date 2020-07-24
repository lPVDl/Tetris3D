namespace Game.Core.Block
{
    public interface IBlockShapeTextureProvider
    {
        EBlockTextureId GetTexture(BlockShapeData shapeData);
    }
}
