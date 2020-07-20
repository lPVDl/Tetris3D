using System;
using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockModel : IDisposable
    {
        event Action<IBlockModel> OnPositionChanged;
        event Action<IBlockModel> OnRotationChanged;
        event Action<IBlockModel> OnDestroyed;

        BlockShapeData Shape { get; }
        Quaternion Rotation { get; set; }
        Vector3 Position { get; set; }
    }
}
