using UnityEngine;

namespace Game.Core.BlockPreview
{
    public class BlockPreviewRenderView : MonoBehaviour, IBlockPreviewRenderView
    {
        public Transform BlockRoot => _blockRoot;

        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _blockRoot;

        public void SetCameraScale(float scale)
        {
            _camera.orthographicSize = scale;
        }
    }
}
