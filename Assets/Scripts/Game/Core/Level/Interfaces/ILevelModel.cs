using System;
using UnityEngine;

namespace Game.Core.Level
{
    public interface ILevelModel
    {
        event Action<Vector3Int> OnBlockAdded;
        event Action<Vector3Int> OnBlockRemoved;

        Vector3Int Size { get; }

        void AddBlock(Vector3Int position);

        void RemoveBlock(Vector3Int position);
        bool CheckInsideBounds(Vector3Int index);
    }
}
