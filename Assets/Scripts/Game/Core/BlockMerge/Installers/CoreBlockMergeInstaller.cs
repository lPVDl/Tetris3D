using UnityEngine;
using Zenject;

namespace Game.Core.BlockMerge
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockMerge", fileName = "CoreBlockMergeInstaller")]
    public class CoreBlockMergeInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockMergeController>().AsSingle();
        }
    }
}
