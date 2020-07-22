using UnityEngine;

namespace Game.Common.UI
{
    public abstract class AbstractUIElementView : MonoBehaviour
    {
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
