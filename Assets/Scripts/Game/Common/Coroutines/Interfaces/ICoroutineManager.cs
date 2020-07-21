using System.Collections;
using UnityEngine;

namespace Game.Common.Coroutines
{
    public interface ICoroutineManager
    {
        Coroutine StartCoroutine(IEnumerator routine);

        void StopCoroutine(Coroutine routine);
    }
}
