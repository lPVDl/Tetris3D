using UnityEngine;

namespace Game.Common.Audio
{
    public interface IAudioClipProvider
    {
        AudioClip GetClip(EAudioEventType eventType);
    }
}
