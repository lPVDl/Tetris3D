namespace Game.Core.Block
{
    public interface IBlockShapeDataProvider
    {
        BlockShapeData GetShape(EBlockShapeType shapeType);
    }
}
