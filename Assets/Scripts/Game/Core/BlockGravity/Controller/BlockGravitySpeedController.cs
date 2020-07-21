using Game.Common.GameEvents;
using UnityEngine;

namespace Game.Core.BlockGravity
{
    public class BlockGravitySpeedController : IInitializable, IUpdatable
    {
        private readonly IBlockGravityController _gravityController;

        public BlockGravitySpeedController(IBlockGravityController gravityController)
        {
            _gravityController = gravityController;
        }

        public void Initialize()
        {
            _gravityController.SetSpeed(1);
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _gravityController.SetSpeed(10);

            if (Input.GetKeyUp(KeyCode.Space))
                _gravityController.SetSpeed(1);
        }
    }
}
