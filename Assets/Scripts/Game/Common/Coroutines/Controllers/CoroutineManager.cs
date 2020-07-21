using System.Collections;
using UnityEngine;

namespace Game.Common.Coroutines
{
    public partial class CoroutineManager : ICoroutineManager
    {
        private readonly Behaviour _behaviour;

        public CoroutineManager()
        {
            _behaviour = new GameObject("_CoroutineManager").AddComponent<Behaviour>();
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _behaviour.StartCoroutine(routine);
        }

        public void StopCoroutine(Coroutine routine)
        {
            _behaviour.StopCoroutine(routine);
        }
    }
}
