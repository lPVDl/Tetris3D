using UnityEngine;
using Zenject;

namespace Game.Core.Level
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/Level", fileName = "CoreLevelInstaller")]
    public class CoreLevelInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelModel>().AsSingle();
            Container.BindInterfacesTo<LevelViewTransform>().AsSingle();
            Container.BindInterfacesTo<LevelPhysicsController>().AsSingle();
            Container.BindInterfacesTo<LevelDrawingController>().AsSingle();
        }
    }
}
