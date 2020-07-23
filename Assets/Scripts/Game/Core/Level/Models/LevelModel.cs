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

        private bool this[Vector3Int index]
        {
            get => _blocks[index.x, index.y, index.z];
            set => _blocks[index.x, index.y, index.z] = value;
        }

        private bool[,,] _blocks;

        public LevelModel()
        {
            Size = new Vector3Int(10, 20, 10);
            _blocks = new bool[Size.x, Size.y, Size.z];
        }

        public void AddBlock(Vector3Int position)
        {
            if (!CheckInsideBounds(position)) return;
            if (this[position]) return;
            
            this[position] = true;
            OnBlockAdded?.Invoke(position);
        }

        public void RemoveBlock(Vector3Int position)
        {
            if (!CheckInsideBounds(position)) return;
            if (!this[position]) return;

            this[position] = false;
            OnBlockRemoved?.Invoke(position);
        }

        public bool CheckHasBlock(Vector3Int index)
        {
            return CheckInsideBounds(index) && this[index];
        }

        public bool CheckInsideBounds(Vector3Int index)
        {
            if (index.x < 0 || index.x >= Size.x) return false;
            if (index.y < 0 || index.y >= Size.y) return false;
            if (index.z < 0 || index.z >= Size.z) return false;

            return true;
        }

        public IEnumerable<Vector3Int> IterateBlocks()
        {
            for (var x = 0; x < Size.x; x++)
                for (var y = 0; y < Size.y; y++)
                    for (var z = 0; z < Size.z; z++)
                        if (_blocks[x, y, z])
                            yield return new Vector3Int(x, y, z);
        }

        public void MoveBlock(Vector3Int from, Vector3Int to)
        {
            if (!CheckInsideBounds(from)) return;
            if (!CheckInsideBounds(to)) return;
            if (!this[from]) return;
            if (this[to]) RemoveBlock(to);

            this[from] = false;
            this[to] = true;
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
