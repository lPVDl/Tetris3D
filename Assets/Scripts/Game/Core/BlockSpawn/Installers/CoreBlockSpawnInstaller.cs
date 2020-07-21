using UnityEngine;
using Zenject;

namespace Game.Core.BlockSpawn
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockSpawn", fileName = "CoreBlockSpawnInstaller")]
    public class CoreBlockSpawnInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BlockSpawnControllerConfig _spawnControllerConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockSpawnController>().AsSingle().WithArguments(_spawnControllerConfig);
            Container.BindInterfacesTo<TestSpawnInvoker>().AsSingle();
        }
    }
}
