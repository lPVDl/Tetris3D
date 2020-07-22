using System;

namespace Game.Core.LevelProgress
{
    public interface ILevelProgressModel
    {
        event Action OnLevelChange;
        event Action OnScoreChange;

        int Level { get; set; }
        int Score { get; set; }
    }
}
