using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core.GameOver
{
    public class GameOverWindowView : MonoBehaviour
    {
        public event Action OnPlayClick;
        public event Action OnQuitClick;

        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonQuit;

        private void Awake()
        {
            _buttonPlay.onClick.AddListener(() => OnPlayClick?.Invoke());
            _buttonQuit.onClick.AddListener(() => OnQuitClick?.Invoke());
        }

        public void SetScore(string text)
        {
            _scoreText.text = text;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        public void SetVisible(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}
