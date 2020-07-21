using Game.Core.Block;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelPhysicsController : ILevelPhysicsController
    {
        private readonly ILevelModel _levelModel;
        private readonly ILevelViewTransform _levelTransform;

        public LevelPhysicsController(ILevelModel levelModel,
                                      ILevelViewTransform levelTransform)
        {
            _levelModel = levelModel;
            _levelTransform = levelTransform;
        }

        public bool CheckShapeInsideLevelBounds(Vector3Int position, Quaternion rotation, BlockShapeData shape)
        {
            var center = _levelTransform.TransformPosition(position);
            foreach (var seg in shape.Sections)
            {
                var pos = center + rotation * seg;
                var index = _levelTransform.InverseTransformPosition(pos);
                if (!CheckPointInsideLevelBounds(index))
                    return false;
            }

            return true;
        }

        private bool CheckPointInsideLevelBounds(Vector3Int index)
        {
            if (index.x < 0 || index.x >= _levelModel.Size.x) return false;
            if (index.y < 0 || index.y >= _levelModel.Size.y) return false;
            if (index.z < 0 || index.z >= _levelModel.Size.z) return false;

            return true;
        }
    }
}
