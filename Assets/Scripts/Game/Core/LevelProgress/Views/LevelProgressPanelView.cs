using Game.Common.UI;
using TMPro;
using UnityEngine;

namespace Game.Core.LevelProgress
{
    public class LevelProgressPanelView : AbstractUIElementView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _levelText;

        public void SetScore(string text)
        {
            _scoreText.text = text;
        }

        public void SetLevel(string text)
        {
            _levelText.text = text;
        }
    }
}
