using UnityEngine;

namespace Game.Core.Level
{
    public class LevelViewTransform : ILevelViewTransform
    {
        private readonly ILevelModel _level;

        public LevelViewTransform(ILevelModel levelModel)
        {
            _level = levelModel;
        }

        public Vector3 TransformPosition(Vector3Int index)
        {
            return new Vector3()
            {
                x = index.x + (1 - _level.Size.x) * 0.5f,
                z = index.z + (1 - _level.Size.z) * 0.5f,
                y = index.y + 0.5f,
            };
        }

        public Vector3Int InverseTransformPosition(Vector3 position)
        {
            return new Vector3Int()
            {
                x = Mathf.RoundToInt(position.x - (1 - _level.Size.x) * 0.5f),
                z = Mathf.RoundToInt(position.z - (1 - _level.Size.z) * 0.5f),
                y = Mathf.RoundToInt(position.y - 0.5f)
            };
        }
    }
}
