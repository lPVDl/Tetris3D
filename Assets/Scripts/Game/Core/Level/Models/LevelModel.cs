using Game.Core.Block;
using Game.Core.BlockMesh;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelModel : ILevelModel
    {
        public event Action<Vector3Int> OnBlockAdded;
        public event Action<Vector3Int> OnBlockRemoved;
        public event Action<Vector3Int, Vector3Int> OnBlockMoved;

        public Vector3Int Size { get; private set; }

        private EBlockTextureId this[Vector3Int index]
        {
            get => _blocks[index.x, index.y, index.z];
            set => _blocks[index.x, index.y, index.z] = value;
        }

        private EBlockTextureId[,,] _blocks;

        public void Initialize(Vector3Int size)
        {
            Size = size;
            _blocks = new EBlockTextureId[Size.x, Size.y, Size.z];
        }

        public void AddBlock(Vector3Int position, EBlockTextureId textureId)
        {
            if (textureId == EBlockTextureId.None) throw new ArgumentException(nameof(textureId));
            if (!CheckInsideBounds(position)) return;
            if (this[position] != EBlockTextureId.None) return;
            
            this[position] = textureId;
            OnBlockAdded?.Invoke(position);
        }

        public void RemoveBlock(Vector3Int position)
        {
            if (!CheckInsideBounds(position)) return;
            if (this[position] == EBlockTextureId.None) return;

            this[position] = EBlockTextureId.None;
            OnBlockRemoved?.Invoke(position);
        }

        public bool CheckHasBlock(Vector3Int index)
        {
            return CheckInsideBounds(index) && this[index] != EBlockTextureId.None;
        }

        public bool CheckInsideBounds(Vector3Int index)
        {
            if (index.x < 0 || index.x >= Size.x) return false;
            if (index.y < 0 || index.y >= Size.y) return false;
            if (index.z < 0 || index.z >= Size.z) return false;

            return true;
        }

        public IEnumerable<BlockMeshData> IterateBlocks()
        {
            for (var x = 0; x < Size.x; x++)
            {
                for (var y = 0; y < Size.y; y++)
                {
                    for (var z = 0; z < Size.z; z++)
                    {
                        var textureId = _blocks[x, y, z];
                        if (textureId != EBlockTextureId.None)
                            yield return new BlockMeshData()
                            {
                                Position = new Vector3Int(x, y, z),
                                TextureId = textureId
                            };
                    }
                }
            } 
        }

        public void MoveBlock(Vector3Int from, Vector3Int to)
        {
            if (!CheckInsideBounds(from)) return;
            if (!CheckInsideBounds(to)) return;
            if (this[from] == EBlockTextureId.None) return;
            if (this[to] != EBlockTextureId.None) RemoveBlock(to);

            this[to] = this[from];
            this[from] = EBlockTextureId.None;

            OnBlockMoved?.Invoke(from, to);
        }

        public void Clear()
        {
            for (var x = 0; x < Size.x; x++)
                for (var y = 0; y < Size.y; y++)
                    for (var z = 0; z < Size.z; z++)
                        RemoveBlock(new Vector3Int(x, y, z));
        }
    }
}
