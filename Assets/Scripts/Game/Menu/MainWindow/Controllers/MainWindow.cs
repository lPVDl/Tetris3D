using Game.Common.UI;
using System;
using UnityEngine;

namespace Game.Menu.MainWindow
{
    public class MainWindow : IAttachableUIElement, IDisposable
    {
        private readonly MainWindowView _windowView;

        public MainWindow(MainWindowView windowView)
        {
            _windowView = windowView;

            _windowView.OnQuitClick += OnQuitClick;
        }

        public void SetParent(Transform parent)
        {
            _windowView.SetParent(parent);
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
