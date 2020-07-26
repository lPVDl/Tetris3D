using Game.Common.Audio;
using Game.Core.GameCamera;
using System;
using UnityEngine;

using static UnityEngine.Mathf;

namespace Game.Core.BlockMotion
{
    public class BlockMovementHandler : IDisposable
    {
        private readonly IBlockMotionInputController _inputController;
        private readonly IGameCameraView _gameCamera;
        private readonly IBlockMotionController _motionController;
        private readonly IAudioController _audioController;

        public BlockMovementHandler(IBlockMotionInputController inputController,
                                    IGameCameraView gameCamera,
                                    IBlockMotionController motionController,
                                    IAudioController audioController)
        {
            _inputController = inputController;
            _gameCamera = gameCamera;
            _motionController = motionController;
            _audioController = audioController;
            _inputController.RegisterListener(EBlockMotionEvent.MoveForward, OnMoveForward);
            _inputController.RegisterListener(EBlockMotionEvent.MoveBackward, OnMoveBackward);
            _inputController.RegisterListener(EBlockMotionEvent.MoveLeft, OnMoveLeft);
            _inputController.RegisterListener(EBlockMotionEvent.MoveRight, OnMoveRight);
        }

        private void OnMoveForward() => TryMoveBlock(ComputeForwardDirection());

        private void OnMoveBackward() => TryMoveBlock(-ComputeForwardDirection());

        private void OnMoveRight() => TryMoveBlock(ComputeRightDirection());

        private void OnMoveLeft() => TryMoveBlock(-ComputeRightDirection());

        private void TryMoveBlock(Vector3Int direction)
        {
            if (_motionController.TryMoveBlock(direction))
                _audioController.ReportEvent(EAudioEventType.BlockMovedByPlayer);
        }

        private Vector3Int ComputeForwardDirection()
        {
            var direction = Vector3.ProjectOnPlane(_gameCamera.Forward, Vector3.up);
            return ConvertDirection(direction);
        }

        private Vector3Int ComputeRightDirection()
        {
            var direction = Vector3.ProjectOnPlane(_gameCamera.Forward, Vector3.up);
            direction = Vector3.Cross(Vector3.up, direction);
            return ConvertDirection(direction);
        }

        private Vector3Int ConvertDirection(Vector3 direction)
        {
            var zAxis = new Vector3Int(0, 0, (int)Sign(direction.z));
            var xAxis = new Vector3Int((int)Sign(direction.x), 0, 0);

            return Abs(direction.z) > Abs(direction.x) ? zAxis : xAxis;
        }

        public void Dispose()
        {
            _inputController.UnregisterListener(EBlockMotionEvent.MoveForward, OnMoveForward);
            _inputController.UnregisterListener(EBlockMotionEvent.MoveBackward, OnMoveBackward);
            _inputController.UnregisterListener(EBlockMotionEvent.MoveLeft, OnMoveLeft);
            _inputController.UnregisterListener(EBlockMotionEvent.MoveRight, OnMoveRight);
        }
    }
}
