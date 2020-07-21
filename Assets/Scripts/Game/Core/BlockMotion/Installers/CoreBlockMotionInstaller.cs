using UnityEngine;
using Zenject;

namespace Game.Core.BlockMotion
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockMotion", fileName = "CoreBlockMotionInstaller")]
    public class CoreBlockMotionInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockMotionInputController>().AsSingle();
            Container.BindInterfacesTo<BlockMovementHandler>().AsSingle();
            Container.BindInterfacesTo<BlockRotationHandler>().AsSingle();
            Container.BindInterfacesTo<BlockMotionController>().AsSingle();
        }
    }
}
