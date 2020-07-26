using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Common.Audio
{
    public class AudioClipProvider : IAudioClipProvider
    {
        private readonly Dictionary<EAudioEventType, AudioClip> _clips;

        public AudioClipProvider(CommonAudioClipDatabase database)
        {
            _clips = database.Clips.ToDictionary(c => c.EventType, c => c.Clip);
        }

        public AudioClip GetClip(EAudioEventType eventType)
        {
            if (!_clips.TryGetValue(eventType, out var clip))
                UnityEngine.Debug.LogError($"{this}: event '{eventType}' clip was not found");

            return clip;
        }
    }
}
