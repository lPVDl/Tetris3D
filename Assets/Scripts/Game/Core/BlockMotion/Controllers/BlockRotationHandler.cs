using Game.Core.Block;
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
        private readonly IBlockModelStorage _blockModelStorage;

        public BlockRotationHandler(IBlockMotionInputController inputController,
                                    IGameCameraView gameCamera,
                                    IBlockModelStorage blockModelStorage)
        {
            _inputController = inputController;
            _gameCamera = gameCamera;
            _blockModelStorage = blockModelStorage;

            _inputController.RegisterListener(EBlockMotionEvent.RotateRight, OnRotateRight);
            _inputController.RegisterListener(EBlockMotionEvent.RotateLeft, OnRotateLeft);
            _inputController.RegisterListener(EBlockMotionEvent.RotateDown, OnRotateDown);
            _inputController.RegisterListener(EBlockMotionEvent.RotateUp, OnRotateUp);
        }

        private void OnRotateRight()
        {
            ApplyRotation(90, Vector3.up);
        }

        private void OnRotateLeft()
        {
            ApplyRotation(-90, Vector3.up);
        }

        private void OnRotateUp()
        {
            ApplyRotation(90, ComputeSideDirection());
        }

        private void OnRotateDown()
        {
            ApplyRotation(-90, ComputeSideDirection());
        }

        private Vector3 ComputeSideDirection()
        {
            var dir = Vector3.ProjectOnPlane(_gameCamera.Forward, Vector3.up);
            dir = Vector3.Cross(Vector3.up, dir);
            
            var zAxis = new Vector3(0, 0, Sign(dir.z));
            var xAxis = new Vector3(Sign(dir.x), 0, 0);
            
            return Abs(dir.z) > Abs(dir.x) ? zAxis : xAxis;
        }

        private void ApplyRotation(float angle, Vector3 axis)
        {
            var model = _blockModelStorage.Blocks[0];
            var rotation =  Quaternion.AngleAxis(angle, axis) * model.Rotation;
            model.Rotation = rotation;

            // TODO: Find proper way to clamp rotation.
            // model.Rotation = ClampRotation90(rotation);
        }

        private Quaternion ClampRotation90(Quaternion rotation)
        {
            var euler = rotation.eulerAngles;
            euler = new Vector3()
            {
                x = (int)(euler.x / 90) * 90,
                y = (int)(euler.y / 90) * 90,
                z = (int)(euler.z / 90) * 90
            };
            return Quaternion.Euler(euler);
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
