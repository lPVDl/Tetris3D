using UnityEngine;
using Zenject;

namespace Game.Common.Audio
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Common/Audio", fileName = "CommonAudioInstaller")]
    public class CommonAudioInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CommonAudioClipDatabase _audioClipDatabase;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AudioController>().AsSingle();
            Container.BindInterfacesTo<AudioClipProvider>().AsSingle().WithArguments(_audioClipDatabase);
        }
    }
}
