using Game.Common.GameEvents;
using System;
using System.Collections.Generic;

namespace Game.Core.BlockMotion
{
    public partial class BlockMotionInputController : IBlockMotionInputController, IUpdatable
    {
        private Dictionary<EBlockMotionEvent, Action> _listeners;
        private KeyboardEvents _keyboardEvents;
        private MouseEvents _mouseEvents;

        public BlockMotionInputController()
        {
            _listeners = new Dictionary<EBlockMotionEvent, Action>();
            _keyboardEvents = new KeyboardEvents(this);
            _mouseEvents = new MouseEvents(this);
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
            _keyboardEvents.Update();
            _mouseEvents.Update();
        }
    }
}
