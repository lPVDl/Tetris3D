using UnityEngine;
using Zenject;

namespace Game.Core.BlockGravity
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockGravity", fileName = "CoreBlockGravityInstaller")]
    public class CoreBlockGravityInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockGravityController>().AsSingle();
            Container.BindInterfacesTo<TestBlockGravityInvoker>().AsSingle();
        }
    }
}
