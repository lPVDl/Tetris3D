using UnityEngine;
using Zenject;

namespace Game.Core.GameCycle
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/GameCycle", fileName = "CoreGameCycleInstaller")]
    public class CoreGameCycleInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameCycleController>().AsSingle();
        }
    }
}
