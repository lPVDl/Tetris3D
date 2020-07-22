using UnityEngine;

namespace Game.Common.UI
{
    public class CanvasView : MonoBehaviour, ICanvasView
    {
        public Transform Transform => transform;

        [SerializeField] private Canvas _canvas;

        public void SetCamera(Camera camera)
        {
            _canvas.worldCamera = camera;
        }
    }
}
