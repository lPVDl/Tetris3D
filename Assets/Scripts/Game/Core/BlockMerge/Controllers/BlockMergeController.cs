using System;
using Game.Core.Level;
using UnityEngine;

namespace Game.Core.BlockMerge
{
    public class BlockMergeController : IBlockMergeController
    {
        public event Action<int> OnBlocksMerge;

        private readonly ILevelModel _level;

        public BlockMergeController(ILevelModel level)
        {
            _level = level;
        }

        public bool TryMergeBlocks()
        {
            var startIndex = _level.Size.y - 1;
            for (; startIndex >= 0 && !CheckLineFull(startIndex); startIndex--) ;
            if (startIndex < 0) return false;

            var endIndex = startIndex - 1;
            for (; endIndex >= 0 && CheckLineFull(endIndex); endIndex--) ;

            for (var i = startIndex; i > endIndex; i--)
                ClearLine(i);

            var delta = startIndex - endIndex;
            for (var i = startIndex + 1; i < _level.Size.y; i++)
                MoveRow(i, i - delta);

             OnBlocksMerge?.Invoke(delta * _level.Size.x * _level.Size.z);

            return true;
        }

        private bool CheckLineFull(int height)
        {
            for (var x = 0; x < _level.Size.x; x++)
                for (var z = 0; z < _level.Size.z; z++)
                    if (!_level.CheckHasBlock(new Vector3Int(x, height, z)))
                        return false;

            return true;
        }

        private void ClearLine(int height)
        {
            for (var x = 0; x < _level.Size.x; x++)
                for (var z = 0; z < _level.Size.z; z++)
                    _level.RemoveBlock(new Vector3Int(x, height, z));
        }

        private void MoveRow(int height, int newHeight)
        {
            for (var x = 0; x < _level.Size.x; x++)
                for (var z = 0; z < _level.Size.z; z++)
                {
                    var from = new Vector3Int(x, height, z);
                    var to = new Vector3Int(x, newHeight, z);
                    _level.MoveBlock(from, to);
                }
        }
    }
}
