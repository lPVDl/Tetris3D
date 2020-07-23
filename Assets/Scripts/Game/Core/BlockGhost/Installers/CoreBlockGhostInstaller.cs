using UnityEngine;
using Zenject;

namespace Game.Core.BlockGhost
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockGhost", fileName = "CoreBlockGhostInstaller")]
    public class CoreBlockGhostInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Material _ghostBlockMaterial;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockGhostController>().AsSingle().WithArguments(_ghostBlockMaterial);
        }
    }
}
