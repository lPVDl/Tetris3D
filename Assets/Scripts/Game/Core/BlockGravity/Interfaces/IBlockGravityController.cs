namespace Game.Core.BlockGravity
{
    public interface IBlockGravityController
    {
        void SetSpeed(float blocksPerSecond);

        bool TryApplyGravity(float deltaTime);
    }
}
