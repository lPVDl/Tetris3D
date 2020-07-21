using UnityEngine;

namespace Game.Core.GameCamera
{
    /// <summary>
    /// Describes a game object which is an game camera.
    /// </summary>
    public interface IGameCameraView
    {
        Vector3 Forward { get; }

        /// <summary>
        /// Sets a point around which camera is rotated.
        /// </summary>
        void SetPosition(Vector3 position);

        /// <summary>
        /// Sets camera rotation in degree around X and Y axis.
        /// </summary>
        void SetRotation(float xDegree, float yDegree);
    }
}
