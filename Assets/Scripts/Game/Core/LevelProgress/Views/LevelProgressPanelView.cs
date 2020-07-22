using TMPro;
using UnityEngine;

namespace Game.Core.LevelProgress
{
    public class LevelProgressPanelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _levelText;

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

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
