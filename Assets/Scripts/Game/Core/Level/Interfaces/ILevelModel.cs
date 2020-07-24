using Game.Core.Block;
using Game.Core.BlockMesh;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Level
{
    public interface ILevelModel
    {
        event Action<Vector3Int> OnBlockAdded;
        event Action<Vector3Int> OnBlockRemoved;
        event Action<Vector3Int, Vector3Int> OnBlockMoved;

        Vector3Int Size { get; }

        void Initialize(Vector3Int size);

        void AddBlock(Vector3Int position, EBlockTextureId textureId);

        void RemoveBlock(Vector3Int position);

        void MoveBlock(Vector3Int from, Vector3Int to);

        bool CheckInsideBounds(Vector3Int position);

        bool CheckHasBlock(Vector3Int position);

        IEnumerable<BlockMeshData> IterateBlocks();

        void Clear();
    }
}
