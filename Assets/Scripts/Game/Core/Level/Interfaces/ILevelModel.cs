using System;
using UnityEngine;

namespace Game.Core.Level
{
    public interface ILevelModel
    {
        event Action<Vector3Int> OnBlockAdded;
        event Action<Vector3Int> OnBlockRemoved;
        event Action<Vector3Int, Vector3Int> OnBlockMoved;

        Vector3Int Size { get; }

        void AddBlock(Vector3Int position);

        void RemoveBlock(Vector3Int position);

        void MoveBlock(Vector3Int from, Vector3Int to);

        bool CheckInsideBounds(Vector3Int index);

        bool CheckHasBlock(Vector3Int index);

        void Clear();
    }
}
