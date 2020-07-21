using Game.Core.Block;
using System.Linq;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelPhysicsController : ILevelPhysicsController
    {
        private readonly ILevelModel _levelModel;
        private readonly IBlockShapeUtil _shapeUtil;

        public LevelPhysicsController(ILevelModel levelModel,
                                      IBlockShapeUtil shapeUtil)
        {
            _levelModel = levelModel;
            _shapeUtil = shapeUtil;
        }

        public bool CheckOverlappingLevelBlocks(Vector3Int position, Quaternion rotation, BlockShapeData shape)
        {
            return _shapeUtil.IterateBlockSections(position, rotation, shape)
                .Any(p => _levelModel.CheckHasBlock(p));
        }

        public bool CheckShapeInsideLevelBounds(Vector3Int position, Quaternion rotation, BlockShapeData shape)
        {
            return _shapeUtil.IterateBlockSections(position, rotation, shape)
                .All(p => _levelModel.CheckInsideBounds(p));
        }
    }
}
