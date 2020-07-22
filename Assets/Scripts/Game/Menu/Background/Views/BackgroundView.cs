using UnityEngine;

namespace Game.Menu.Background
{
    public class BackgroundView : MonoBehaviour
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }
    }
}
