using UnityEngine;

namespace Game.Common.UI
{
    public class AbstractUIElement : IAttachableUIElement
    {
        private readonly AbstractUIElementView _elementView;

        public AbstractUIElement(AbstractUIElementView elementView)
        {
            _elementView = elementView;
        }

        public void SetParent(Transform parent)
        {
            _elementView.SetParent(parent);
        }
    }
}
