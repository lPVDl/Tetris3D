using Game.Common.UI;
using UnityEngine;

namespace Game.Core.GameCamera
{
    public class GameCameraView : MonoBehaviour, IGameCameraView, ICanvasCamera
    {
        public Vector3 Forward => transform.forward;

        public Camera Camera => _camera;

        [SerializeField] private Camera _camera;

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(float xDegree, float yDegree)
        {
            transform.rotation = Quaternion.Euler(xDegree, yDegree, 0);
        }
    }
}
