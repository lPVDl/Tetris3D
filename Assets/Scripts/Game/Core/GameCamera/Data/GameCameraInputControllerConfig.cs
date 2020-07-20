using System;
using UnityEngine;

namespace Game.Core.GameCamera
{
    [Serializable]
    public class GameCameraInputControllerConfig
    {
        /// <summary>
        /// Normalized value, which describes how much screen width required to complete one full horizontal turn.
        /// </summary>
        public float VerticalRotationPerScreenHeight => _verticalRotationPerScreenHeight;
        /// <summary>
        /// Normalized value, which describes how much screen height required to complete one full vertical turn.
        /// </summary>
        public float HorizontalRotationPerScreenWidth => _horizontalRotationPerScreenWidth;

        [SerializeField] private float _verticalRotationPerScreenHeight;
        [SerializeField] private float _horizontalRotationPerScreenWidth;
    }
}
