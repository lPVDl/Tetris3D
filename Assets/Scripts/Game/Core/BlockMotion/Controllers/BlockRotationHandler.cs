using Game.Core.GameCamera;
using System;
using UnityEngine;

using static UnityEngine.Mathf;

namespace Game.Core.BlockMotion
{
    public class BlockRotationHandler : IDisposable
    {
        private readonly IBlockMotionInputController _inputController;
        private readonly IGameCameraView _gameCamera;
        private readonly IBlockMotionController _motionController;

        public BlockRotationHandler(IBlockMotionInputController inputController,
                                    IGameCameraView gameCamera,
                                    IBlockMotionController motionController)
        {
            _inputController = inputController;
            _gameCamera = gameCamera;
            _motionController = motionController;

            _inputController.RegisterListener(EBlockMotionEvent.RotateRight, OnRotateRight);
            _inputController.RegisterListener(EBlockMotionEvent.RotateLeft, OnRotateLeft);
            _inputController.RegisterListener(EBlockMotionEvent.RotateDown, OnRotateDown);
            _inputController.RegisterListener(EBlockMotionEvent.RotateUp, OnRotateUp);
        }

        private void OnRotateRight() => TryApplyRotation(90, Vector3.up);

        private void OnRotateLeft() => TryApplyRotation(-90, Vector3.up);

        private void OnRotateUp() => TryApplyRotation(90, ComputeSideDirection());

        private void OnRotateDown() => TryApplyRotation(-90, ComputeSideDirection());

        private Vector3 ComputeSideDirection()
        {
            var dir = Vector3.ProjectOnPlane(_gameCamera.Forward, Vector3.up);
            dir = Vector3.Cross(Vector3.up, dir);
            
            var zAxis = new Vector3(0, 0, Sign(dir.z));
            var xAxis = new Vector3(Sign(dir.x), 0, 0);
            
            return Abs(dir.z) > Abs(dir.x) ? zAxis : xAxis;
        }

        private void TryApplyRotation(float angle, Vector3 axis)
        {
            _motionController.TryRotateBlock(Quaternion.AngleAxis(angle, axis));
        }

        public void Dispose()
        {
            _inputController.UnregisterListener(EBlockMotionEvent.RotateRight, OnRotateRight);
            _inputController.UnregisterListener(EBlockMotionEvent.RotateLeft, OnRotateLeft);
            _inputController.UnregisterListener(EBlockMotionEvent.RotateDown, OnRotateDown);
            _inputController.UnregisterListener(EBlockMotionEvent.RotateUp, OnRotateUp);
        }
    }
}
