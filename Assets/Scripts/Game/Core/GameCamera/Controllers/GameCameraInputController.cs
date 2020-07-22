using Game.Common.GameEvents;
using System;
using UnityEngine;

using static UnityEngine.Input;
using static UnityEngine.Mathf;

namespace Game.Core.GameCamera
{
    public class GameCameraInputController : IGameCameraInputController, IUpdatable
    {
        public event Action OnRotationChange;

        public float HorizontalRotation { get; private set; }
        public float VerticalRotation { get; private set; }

        private readonly GameCameraInputControllerConfig _config;

        private float _cashedHorizontal;
        private float _cashedVertical;
        private Vector3 _cashedMousePosition;
        private bool _isEnabled;

        public GameCameraInputController(GameCameraInputControllerConfig config)
        {
            HorizontalRotation = 0f;
            VerticalRotation = 0.5f;
            _config = config;
        }

        public void Update(float deltaTime)
        {
            if (!_isEnabled)
                return;

            if (GetMouseButtonDown(1))
            {
                _cashedHorizontal = HorizontalRotation;
                _cashedVertical = VerticalRotation;
                _cashedMousePosition = mousePosition;
            }

            if (GetMouseButton(1))
            {
                var mouseDelta = mousePosition - _cashedMousePosition;
                HorizontalRotation = Repeat(_cashedHorizontal + (mouseDelta.x / Screen.width) * _config.HorizontalRotationPerScreenWidth, 1);
                VerticalRotation = Clamp01(_cashedVertical - (mouseDelta.y / Screen.height) * _config.VerticalRotationPerScreenHeight);
                OnRotationChange?.Invoke();
            }
        }

        public void SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
        }
    }
}
