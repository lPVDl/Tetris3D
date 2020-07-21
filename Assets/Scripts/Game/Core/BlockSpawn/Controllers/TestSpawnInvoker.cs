using Game.Common.GameEvents;

namespace Game.Core.BlockSpawn
{
    public class TestSpawnInvoker : IInitializable
    {
        private readonly IBlockSpawnController _blockSpawnController;

        public TestSpawnInvoker(IBlockSpawnController blockSpawnController)
        {
            _blockSpawnController = blockSpawnController;
        }

        public void Initialize()
        {
            _blockSpawnController.TrySpawnBlock();
        }
    }
}
