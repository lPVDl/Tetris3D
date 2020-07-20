using UnityEngine;

namespace Game.Core.GameCamera
{
    public class GameCameraView : MonoBehaviour, IGameCameraView
    {
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
