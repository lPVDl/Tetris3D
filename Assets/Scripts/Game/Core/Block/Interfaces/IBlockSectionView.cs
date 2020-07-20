using System;
using UnityEngine;

namespace Game.Core.Block
{
    /// <summary>
    /// Repesents an object used to display block sections.
    /// </summary>
    public interface IBlockSectionView : IDisposable
    {
        void SetPosition(Vector3 position);

        void SetParent(Transform parent);

        void SetColor(Color color);
    }
}
