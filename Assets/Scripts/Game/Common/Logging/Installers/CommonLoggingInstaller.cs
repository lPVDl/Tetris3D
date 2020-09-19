using UnityEngine;
using Zenject;

namespace Game.Common.Logging
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Common/Logging", fileName = "CommonLoggingInstaller")]
    public class CommonLoggingInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LogModuleFactory>().AsSingle();
        }
    }
}
