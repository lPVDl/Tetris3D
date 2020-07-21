using System;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelModel : ILevelModel
    {
        public event Action<Vector3Int> OnBlockAdded;
        public event Action<Vector3Int> OnBlockRemoved;

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

        public bool CheckInsideBounds(Vector3Int index)
        {
            if (index.x < 0 || index.x >= Size.x) return false;
            if (index.y < 0 || index.y >= Size.y) return false;
            if (index.z < 0 || index.z >= Size.z) return false;

            return true;
        }
    }
}
