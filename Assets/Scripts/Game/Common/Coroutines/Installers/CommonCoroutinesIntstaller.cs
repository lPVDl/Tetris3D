using UnityEngine;
using Zenject;

namespace Game.Common.Coroutines
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Common/Coroutines", fileName = "CommonCoroutinesIntstaller")]
    public class CommonCoroutinesIntstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
        }
    }
}
