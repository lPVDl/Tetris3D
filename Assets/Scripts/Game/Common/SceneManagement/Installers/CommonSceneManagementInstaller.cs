using UnityEngine;
using Zenject;

namespace Game.Common.SceneManagement
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Common/SceneManagement", fileName = "CommonSceneManagemenInstaller")]
    public class CommonSceneManagementInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneSwitcher>().AsSingle();
        }
    }
}
