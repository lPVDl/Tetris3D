namespace Game.Core.BlockGravity
{
    public interface IBlockGravityController
    {
        void SetSpeed(float blocksPerSecond);

        /// <summary>
        /// Will try to move current falling block down until bottom or other block reached. Returns true if block can be moved further.
        /// </summary>
        bool TryApplyGravity(float deltaTime);
    }
}
