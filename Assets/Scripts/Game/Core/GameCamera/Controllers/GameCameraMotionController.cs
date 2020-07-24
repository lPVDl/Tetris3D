using Game.Common.GameEvents;
using Game.Core.Level;
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
        private readonly ILevelModel _levelModel;

        public GameCameraMotionController(IGameCameraView cameraView,
                                          IGameCameraInputController cameraInput,
                                          ILevelModel levelModel)
        {
            _cameraView = cameraView;
            _cameraInput = cameraInput;
            _levelModel = levelModel;
            _cameraInput.OnRotationChange += UpdateCameraRotation;
        }

        public void Initialize()
        {
            _cameraView.SetPosition(new Vector3(0, _levelModel.Size.y / 2, 0));
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
