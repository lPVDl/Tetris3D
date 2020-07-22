using Game.Common.UI;
using Game.Core.GameCycle;
using UnityEngine;

namespace Game.Core.BlockPreview
{
    public class BlockPreviewPanel : AbstractUIElement, IGameStartListener, IGameFinishListener
    {
        private readonly BlockPreviewPanelView _panelView;

        public BlockPreviewPanel(BlockPreviewPanelView panelView) : base(panelView)
        {
            _panelView = panelView;
        }

        public void OnGameStart()
        {
            _panelView.SetVisible(true);
        }

        public void OnGameFinish()
        {
            _panelView.SetVisible(false);
        }
    }
}
