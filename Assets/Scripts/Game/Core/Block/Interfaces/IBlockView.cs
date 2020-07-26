using System;
using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockView : IDisposable
    {
        Quaternion Rotation { get; set; }

        void SetPosition(Vector3 position);

        void SetParent(Transform parent);

        void SetMaterial(Material material);
    }
}
