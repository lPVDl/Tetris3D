using System;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public interface IBlockMeshView : IDisposable
    {
        void SetPosition(Vector3 position);

        void SetRotation(Quaternion rotation);

        void SetParent(Transform parent);

        void SetMesh(Mesh mesh);
    }
}
