using UnityEngine;

namespace Game.Core.Level
{
    public class LevelModel : ILevelModel
    {
        public Vector3Int Size { get; private set; }

        public LevelModel()
        {
            Size = new Vector3Int(10, 20, 10);
        }
    }
}
