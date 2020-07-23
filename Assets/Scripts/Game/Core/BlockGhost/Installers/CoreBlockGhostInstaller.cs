using UnityEngine;
using Zenject;

namespace Game.Core.BlockGhost
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockGhost", fileName = "CoreBlockGhostInstaller")]
    public class CoreBlockGhostInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockGhostController>().AsSingle();
        }
    }
}
