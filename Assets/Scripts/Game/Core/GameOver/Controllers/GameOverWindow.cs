using Game.Common.SceneManagement;
using Game.Common.UI;
using Game.Core.GameCycle;
using Game.Core.LevelProgress;
using System;
using UnityEngine;

namespace Game.Core.GameOver
{
    public class GameOverWindow : AbstractUIElement, IGameOverWindow, IGameStartListener, IGameFinishListener, IDisposable
    {
        public event Action OnTryStartGame;

        private readonly GameOverWindowView _windowView;
        private readonly ILevelProgressModel _levelProgress;
        private readonly ISceneSwitcher _sceneSwitcher;

        public GameOverWindow(GameOverWindowView windowView,
                              ILevelProgressModel levelProgress,
                              ISceneSwitcher sceneSwitcher) : base(windowView)
        {
            _windowView = windowView;
            _levelProgress = levelProgress;
            _sceneSwitcher = sceneSwitcher;

            _windowView.OnPlayClick += OnPlayClick;
            _windowView.OnQuitClick += OnQuitClick;
        }

        private void OnPlayClick()
        {
            OnTryStartGame?.Invoke();
        }

        private void OnQuitClick()
        {
            _sceneSwitcher.Switch(ESceneType.Menu);
        }

        public void OnGameStart()
        {
            _windowView.SetVisible(false);
        }

        public void OnGameFinish()
        {
            _windowView.SetScore(_levelProgress.Score.ToString());
            _windowView.SetVisible(true);
        }

        public void Dispose()
        {
            _windowView.OnPlayClick -= OnPlayClick;
            _windowView.OnQuitClick -= OnQuitClick;
        }
    }
}
