using Game.Common.UI;
using UnityEngine;

namespace Game.Menu.Background
{
    public class Background : IAttachableUIElement
    {
        private readonly BackgroundView _backgroundView;

        public Background(BackgroundView backgroundView)
        {
            _backgroundView = backgroundView;
        }

        public void SetParent(Transform parent)
        {
            _backgroundView.SetParent(parent);
        }
    }
}
