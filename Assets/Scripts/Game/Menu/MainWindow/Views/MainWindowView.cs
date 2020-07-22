using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.MainWindow
{
    public class MainWindowView : MonoBehaviour
    {
        public event Action OnPlayClick;
        public event Action OnQuitClick;

        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonQuit;

        private void Awake()
        {
            _buttonPlay.onClick.AddListener(() => OnPlayClick?.Invoke());
            _buttonQuit.onClick.AddListener(() => OnQuitClick?.Invoke());
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }
    }
}
