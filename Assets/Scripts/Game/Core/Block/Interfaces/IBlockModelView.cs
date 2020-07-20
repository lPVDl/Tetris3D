using System;
using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockView : IDisposable
    {
        void SetPosition(Vector3 position);

        void SetRotation(Quaternion rotation);

        void AttachSection(IBlockSectionView section);
    }
}
