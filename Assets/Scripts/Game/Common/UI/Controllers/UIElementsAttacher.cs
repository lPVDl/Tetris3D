using Game.Common.GameEvents;
using System.Collections.Generic;

namespace Game.Common.UI
{
    public class UIElementsAttacher : IInitializable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.Common;

        private readonly List<IAttachableUIElement> _uiElements;
        private readonly ICanvasView _canvas;

        public UIElementsAttacher(List<IAttachableUIElement> uiElements,
                                  ICanvasView canvas)
        {
            _uiElements = uiElements;
            _canvas = canvas;
        }

        public void Initialize()
        {
            foreach (var entity in _uiElements)
                entity.SetParent(_canvas.Transform);
        }
    }
}
