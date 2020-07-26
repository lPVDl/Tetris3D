using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.Audio
{
    [CreateAssetMenu(menuName = "ScriptableObject/Database/Game/Common/AudioClip", fileName = "CommonAudioClipDatabase")]
    public class CommonAudioClipDatabase : ScriptableObject
    {
        public IReadOnlyList<AudioClipData> Clips => _clips;

        [SerializeField] List<AudioClipData> _clips;
    }
}
