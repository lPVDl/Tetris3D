using UnityEngine;
using Zenject;

namespace Game.Core.LevelLight
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/LevelLight", fileName = "CoreLevelLightInstaller")]
    public class CoreLevelLightInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LevelLightView _levelLightView;

        public override void InstallBindings()
        {
            Container.Bind<LevelLightView>().FromComponentInNewPrefab(_levelLightView).AsSingle().NonLazy();            
        }
    }
}
