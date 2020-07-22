using Game.Common.GameEvents;
using Game.Common.UI;
using Game.Core.GameCycle;
using System;

namespace Game.Core.LevelProgress
{
    public class LevelProgressPanel : AbstractUIElement, IInitializable, IDisposable, IGameStartListener, IGameFinishListener
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

        public void OnGameStart()
        {
            _panelView.SetVisible(true);
        }

        public void OnGameFinish()
        {
            _panelView.SetVisible(false);
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
