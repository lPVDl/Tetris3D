using Game.Common.SceneManagement;
using Game.Common.UI;
using System;
using UnityEngine;

namespace Game.Menu.MainWindow
{
    public class MainWindow : IAttachableUIElement, IDisposable
    {
        private readonly MainWindowView _windowView;
        private readonly ISceneSwitcher _sceneSwitcher;

        public MainWindow(MainWindowView windowView,
                          ISceneSwitcher sceneSwitcher)
        {
            _windowView = windowView;
            _sceneSwitcher = sceneSwitcher;

            _windowView.OnQuitClick += OnQuitClick;
            _windowView.OnPlayClick += OnPlayClick;
        }

        public void SetParent(Transform parent)
        {
            _windowView.SetParent(parent);
        }

        private void OnPlayClick()
        {
            _sceneSwitcher.Switch(ESceneType.Core);
        }

        private void OnQuitClick()
        {
            Application.Quit();

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        public void Dispose()
        {
            _windowView.OnQuitClick -= OnQuitClick;
        }
    }
}
