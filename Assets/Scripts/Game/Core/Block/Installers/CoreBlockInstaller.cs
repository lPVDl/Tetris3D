using UnityEngine;
using Zenject;

namespace Game.Core.Block
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/Block", fileName = "CoreBlockInstaller")]
    public class CoreBlockInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BlockSectionView _blockSectionView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockViewFactory>().AsSingle().WithArguments(_blockSectionView);
            Container.BindInterfacesTo<TestBlockSpawner>().AsSingle();
        }
    }
}
