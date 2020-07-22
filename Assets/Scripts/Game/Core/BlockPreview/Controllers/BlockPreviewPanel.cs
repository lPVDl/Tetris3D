using Game.Common.UI;
using UnityEngine;

namespace Game.Core.BlockPreview
{
    public class BlockPreviewPanel : IAttachableUIElement
    {
        private readonly BlockPreviewPanelView _panelView;

        public BlockPreviewPanel(BlockPreviewPanelView panelView)
        {
            _panelView = panelView;
        }

        public void SetParent(Transform parent)
        {
            _panelView.SetParent(parent);
        }
    }
}
