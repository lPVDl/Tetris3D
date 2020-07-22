using System;
using Game.Common.GameEvents;
using UnityEngine;

namespace Game.Core.BlockGravity
{
    public class BlockGravitySpeedInputController : IBlockGravitySpeedInputController, IUpdatable
    {
        public event Action<bool> OnSpeedupToggle;

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnSpeedupToggle?.Invoke(true);
            if (Input.GetKeyUp(KeyCode.Space))
                OnSpeedupToggle?.Invoke(false);
        }
    }
}
