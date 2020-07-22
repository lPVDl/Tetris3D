using UnityEngine;

namespace Game.Common.UI
{
    public interface IAttachableUIElement
    {
        void SetParent(Transform parent);
    }
}
