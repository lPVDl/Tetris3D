namespace Game.Core.BlockGravity
{
    public interface IBlockGravityController
    {
        bool TryApplyGravity(float deltaTime);
    }
}
