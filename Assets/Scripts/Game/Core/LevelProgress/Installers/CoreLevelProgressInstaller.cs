using UnityEngine;
using Zenject;

namespace Game.Core.LevelProgress
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/LevelProgress", fileName = "CoreLevelProgressInstaller")]
    public class CoreLevelProgressInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LevelProgressPanelView _panelView;

        public override void InstallBindings()
        {
            Container.Bind<LevelProgressPanelView>().FromComponentsInNewPrefab(_panelView).AsSingle();
            Container.BindInterfacesTo<LevelProgressModel>().AsSingle();
            Container.BindInterfacesTo<LevelProgressController>().AsSingle();
            Container.BindInterfacesTo<LevelProgressPanel>().AsSingle();
        }
    }
}
