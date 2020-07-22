using Game.Common.GameEvents;
using Game.Common.UI;
using System;
using UnityEngine;

namespace Game.Core.LevelProgress
{
    public class LevelProgressPanel : AbstractUIElement, IInitializable, IDisposable
    {
        private readonly LevelProgressPanelView _panelView;
        private readonly ILevelProgressModel _progress;

        public LevelProgressPanel(LevelProgressPanelView panelView,
                                  ILevelProgressModel progress) : base (panelView)
        {
            _panelView = panelView;
            _progress = progress;

            _progress.OnLevelChange += RedrawLevel;
            _progress.OnScoreChange += RedrawScore;
        }

        public void Initialize()
        {
            RedrawScore();
            RedrawLevel();
        }

        private void RedrawScore()
        {
            _panelView.SetScore(_progress.Score.ToString());
        }

        private void RedrawLevel()
        {
            _panelView.SetLevel(_progress.Level.ToString());
        }

        public void Dispose()
        {
            _progress.OnLevelChange -= RedrawLevel;
            _progress.OnScoreChange -= RedrawScore;
        }
    }
}
