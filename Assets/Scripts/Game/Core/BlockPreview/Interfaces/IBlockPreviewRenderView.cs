using UnityEngine;

namespace Game.Core.BlockPreview
{
    public interface IBlockPreviewRenderView
    {
        Transform BlockRoot { get; }

        void SetCameraScale(float scale);
    }
}
