using Game.Common.GameEvents;

namespace Game.Core.BlockGravity
{
    public class TestBlockGravityInvoker : IUpdatable
    {
        private readonly IBlockGravityController _blockGravityController;

        public TestBlockGravityInvoker(IBlockGravityController blockGravityController)
        {
            _blockGravityController = blockGravityController;
        }

        public void Update(float deltaTime)
        {
            _blockGravityController.TryApplyGravity(deltaTime);
        }
    }
}
