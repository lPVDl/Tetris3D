using Game.Common.UI;
using UnityEngine;

namespace Game.Menu.GameCamera
{
    public class GameCameraView : MonoBehaviour, ICanvasCamera
    {
        public Camera Camera => _camera;

        [SerializeField] private Camera _camera;
    }
}
