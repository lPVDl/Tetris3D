using Game.Core.Block;
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
        private readonly IBlockModelStorage _blockModelStorage;

        public BlockMovementHandler(IBlockMotionInputController inputController,
                                    IGameCameraView gameCamera,
                                    IBlockModelStorage blockModelStorage)
        {
            _inputController = inputController;
            _gameCamera = gameCamera;
            _blockModelStorage = blockModelStorage;

            _inputController.RegisterListener(EBlockMotionEvent.MoveForward, OnMoveForward);
            _inputController.RegisterListener(EBlockMotionEvent.MoveBackward, OnMoveBackward);
            _inputController.RegisterListener(EBlockMotionEvent.MoveLeft, OnMoveLeft);
            _inputController.RegisterListener(EBlockMotionEvent.MoveRight, OnMoveRight);
        }

        private void OnMoveForward()
        {
            _blockModelStorage.Blocks[0].Position += ComputeForwardDirection();
        }

        private void OnMoveBackward()
        {
            _blockModelStorage.Blocks[0].Position -= ComputeForwardDirection();
        }

        private void OnMoveRight()
        {
            _blockModelStorage.Blocks[0].Position += ComputeRightDirection();
        }

        private void OnMoveLeft()
        {
            _blockModelStorage.Blocks[0].Position -= ComputeRightDirection();
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
