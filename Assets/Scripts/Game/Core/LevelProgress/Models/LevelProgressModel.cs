using System;

namespace Game.Core.LevelProgress
{
    public class LevelProgressModel : ILevelProgressModel
    {
        public event Action OnLevelChange;
        public event Action OnScoreChange;

        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    OnLevelChange?.Invoke();
                }
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                if (value != _score)
                {
                    _score = value;
                    OnScoreChange?.Invoke();
                }
            }
        }

        private int _level;
        private int _score;
    }
}
