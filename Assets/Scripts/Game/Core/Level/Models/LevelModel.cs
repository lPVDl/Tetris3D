using UnityEngine;

namespace Game.Core.Level
{
    public class LevelModel : ILevelModel
    {
        public Vector3 Size { get; private set; }

        public LevelModel()
        {
            Size = new Vector3(10, 20, 10);
        }
    }
}
