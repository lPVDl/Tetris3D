using UnityEngine;

namespace Game.Core.BlockMotion
{
    partial class BlockMotionInputController
    {
        private class KeyboardEvents
        {
            private readonly BlockMotionInputController _owner;

            public KeyboardEvents(BlockMotionInputController owner)
            {
                _owner = owner;
            }

            public void Update()
            {
                TryFireEvent(EBlockMotionEvent.MoveForward, KeyCode.W);
                TryFireEvent(EBlockMotionEvent.MoveRight, KeyCode.D);
                TryFireEvent(EBlockMotionEvent.MoveBackward, KeyCode.S);
                TryFireEvent(EBlockMotionEvent.MoveLeft, KeyCode.A);
            }

            private void TryFireEvent(EBlockMotionEvent eventType, KeyCode keyCode)
            {
                if (!Input.GetKeyDown(keyCode)) return;
                _owner._listeners.TryGetValue(eventType, out var action);
                action?.Invoke();
            }
        }
    }
}
