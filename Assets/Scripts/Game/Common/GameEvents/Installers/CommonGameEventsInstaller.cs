using UnityEngine;
using Zenject;

namespace Game.Common.GameEvents
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Common/GameEvents", fileName = "CommonGameEventsInstaller")]
    public class CommonGameEventsInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InitializeMediator>().AsSingle();
            Container.BindInterfacesTo<UpdateMediator>().AsSingle();
        }
    }
}
