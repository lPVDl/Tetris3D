using System;

namespace Game.Core.GameCamera
{
    public interface IGameCameraInputController
    {
        /// <summary>
        /// Event fired when user touched screen and moving pointer.
        /// </summary>
        event Action OnRotationChange;

        /// <summary>
        /// Normalized value, which describes camera horizontal rotation.
        /// </summary>
        float HorizontalRotation { get; }

        /// <summary>
        /// Normalized value, which describes camera vertical rotation.
        /// </summary>
        float VerticalRotation { get; }
    }
}
