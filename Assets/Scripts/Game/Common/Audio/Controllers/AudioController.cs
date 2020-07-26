using UnityEngine;

namespace Game.Common.Audio
{
    public class AudioController : IAudioController
    {
        private readonly AudioSource _audioSource;
        private readonly IAudioClipProvider _clipProvider;

        public AudioController(IAudioClipProvider clipProvider)
        {
            var gameObject = new GameObject("_AudioController");
            _audioSource = gameObject.AddComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(gameObject);
            _clipProvider = clipProvider;
        }

        public void ReportEvent(EAudioEventType eventType)
        {
            _audioSource.PlayOneShot(_clipProvider.GetClip(eventType));
        }
    }
}
