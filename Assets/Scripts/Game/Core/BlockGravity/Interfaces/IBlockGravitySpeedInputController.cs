using System;

namespace Game.Core.BlockGravity
{
    public interface IBlockGravitySpeedInputController
    {
        event Action<bool> OnSpeedupToggle;
    }
}
