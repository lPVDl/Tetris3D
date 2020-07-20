using System;
using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockModel
    {
        event Action<IBlockModel> OnPositionChanged;
        event Action<IBlockModel> OnRotationChanged;

        BlockShapeData Shape { get; }
        Quaternion Rotation { get; set; }
        Vector3 Position { get; set; }
    }
}
