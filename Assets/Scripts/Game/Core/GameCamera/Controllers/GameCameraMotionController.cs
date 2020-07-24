using Game.Common.GameEvents;
using System;
using UnityEngine;

namespace Game.Core.GameCamera
{
    /// <summary>
    /// Controller which updates camera position and rotation according to game context.
    /// </summary>
    public class GameCameraMotionController : IDisposable, IInitializable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.Common;

        private readonly IGameCameraView _cameraView;
        private readonly IGameCameraInputController _cameraInput;

        public GameCameraMotionController(IGameCameraView cameraView,
                                          IGameCameraInputController cameraInput)
        {
            _cameraView = cameraView;
            _cameraInput = cameraInput;

            _cameraInput.OnRotationChange += UpdateCameraRotation;
        }

        public void Initialize()
        {
            _cameraView.SetPosition(Vector3.up * 10);
            UpdateCameraRotation();
        }

        private void UpdateCameraRotation()
        {
            var xAxis = _cameraInput.VerticalRotation * 80;
            var yAxis = _cameraInput.HorizontalRotation * 360;
            _cameraView.SetRotation(xAxis, yAxis);
        }

        public void Dispose()
        {
            _cameraInput.OnRotationChange -= UpdateCameraRotation;
        }
    }
}
