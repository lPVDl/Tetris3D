using UnityEngine;

namespace Game.Common.UI
{
    public interface ICanvasView
    {
        Transform Transform { get; }

        void SetCamera(Camera camera);
    }
}
