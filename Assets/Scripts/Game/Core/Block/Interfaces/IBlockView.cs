using System;
using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockView : IDisposable
    {
        Quaternion Rotation { get; set; }

        Vector3 Position { get; set; }

        void SetParent(Transform parent);

        void SetMaterial(Material material);
    }
}
