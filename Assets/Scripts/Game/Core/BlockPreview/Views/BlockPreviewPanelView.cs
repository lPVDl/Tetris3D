using UnityEngine;

namespace Game.Core.BlockPreview
{
    public class BlockPreviewPanelView : MonoBehaviour
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }
    }
}
