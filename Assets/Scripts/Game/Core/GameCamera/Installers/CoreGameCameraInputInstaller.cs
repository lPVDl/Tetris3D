using UnityEngine;
using Zenject;

namespace Game.Core.GameCamera
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/GameCamera", fileName = "CoreGameCameraInstaller")]
    public class CoreGameCameraInputInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameCameraInputControllerConfig _inputConfig;
        [SerializeField] private GameCameraView _cameraView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameCameraView>().FromComponentsInNewPrefab(_cameraView).AsSingle();

            Container.BindInterfacesTo<GameCameraInputController>().AsSingle().WithArguments(_inputConfig);
            Container.BindInterfacesTo<GameCameraMotionController>().AsSingle();
        }
    }
}
