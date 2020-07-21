using Game.Common.GameEvents;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.BlockMotion
{
    public class BlockMotionInputController : IBlockMotionInputController, IUpdatable
    {
        private Dictionary<EBlockMotionEvent, Action> _listeners;

        public BlockMotionInputController()
        {
            _listeners = new Dictionary<EBlockMotionEvent, Action>();
        }

        public void RegisterListener(EBlockMotionEvent motionEvent, Action onEvent)
        {
            if (_listeners.ContainsKey(motionEvent))
            {
                _listeners[motionEvent] += onEvent;
                return;
            }

            _listeners[motionEvent] = onEvent;
        }

        public void UnregisterListener(EBlockMotionEvent motionEvent, Action onEvent)
        {
            if (_listeners.ContainsKey(motionEvent))
            {
                _listeners[motionEvent] -= onEvent;
            }
        }

        public void Update(float deltaTime)
        {
            TryFireKeyEvent(EBlockMotionEvent.MoveForward, KeyCode.W);
            TryFireKeyEvent(EBlockMotionEvent.MoveRight, KeyCode.D);
            TryFireKeyEvent(EBlockMotionEvent.MoveBackward, KeyCode.S);
            TryFireKeyEvent(EBlockMotionEvent.MoveLeft, KeyCode.A);
        }

        private void TryFireKeyEvent(EBlockMotionEvent eventType, KeyCode keyCode)
        {
            if (!Input.GetKeyDown(keyCode)) return;
            _listeners.TryGetValue(eventType, out var action);
            action?.Invoke();
        }
    }
}
