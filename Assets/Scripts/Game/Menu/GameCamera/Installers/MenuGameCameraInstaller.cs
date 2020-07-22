using UnityEngine;
using Zenject;

namespace Game.Menu.GameCamera
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Menu/GameCamera", fileName = "MenuGameCameraInstaller")]
    public class MenuGameCameraInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameCameraView _gameCameraView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameCameraView>().FromComponentsInNewPrefab(_gameCameraView).AsSingle();
        }
    }
}
