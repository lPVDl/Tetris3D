using UnityEngine;
using Zenject;

namespace Game.Core.BlockJoin
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockJoin", fileName = "CoreBlockJoinInstaller")]
    public class CoreBlockJoinInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockJoinController>().AsSingle();
        }
    }
}
