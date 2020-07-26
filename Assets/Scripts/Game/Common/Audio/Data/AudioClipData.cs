using UnityEngine;

namespace Game.Common.Audio
{
    [System.Serializable]
    public class AudioClipData
    {
        public AudioClip Clip => _clip;
        public EAudioEventType EventType => _eventType;

        [SerializeField] private AudioClip _clip;
        [SerializeField] private EAudioEventType _eventType;
    }
}
