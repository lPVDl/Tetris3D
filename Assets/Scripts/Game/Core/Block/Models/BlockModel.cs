using System;
using UnityEngine;

namespace Game.Core.Block
{
    public class BlockModel : IBlockModel
    {
        public event Action<IBlockModel> OnPositionChanged;
        public event Action<IBlockModel> OnRotationChanged;
        public event Action<IBlockModel> OnDestroyed;

        public BlockShapeData Shape { get; }

        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                OnRotationChanged?.Invoke(this);
            }
        }
        
        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPositionChanged?.Invoke(this);
            }
        }

        private Vector3 _position;
        private Quaternion _rotation;

        public BlockModel(BlockShapeData shape,
                          Vector3 position,
                          Quaternion rotation)
        {
            Shape = shape;
            Position = position;
            Rotation = rotation;
        }

        public void Dispose()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}
