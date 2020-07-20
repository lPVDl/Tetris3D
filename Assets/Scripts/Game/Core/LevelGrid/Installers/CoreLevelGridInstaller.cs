using UnityEngine;
using Zenject;

namespace Game.Core.LevelGrid
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/LevelGrid", fileName = "CoreLevelGridInstaller")]
    public class CoreLevelGridInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LevelGridView _gridView;

        public override void InstallBindings()
        {
            Container.Bind<LevelGridView>().FromComponentInNewPrefab(_gridView).AsSingle().NonLazy();
        }
    }
}
