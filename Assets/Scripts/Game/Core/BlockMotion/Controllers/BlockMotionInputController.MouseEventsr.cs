using UnityEngine;

using static UnityEngine.Mathf;

namespace Game.Core.BlockMotion
{
    partial class BlockMotionInputController
    {
        private class MouseEvents
        {
            private readonly BlockMotionInputController _owner;

            private Vector3 _mousePosition;

            public MouseEvents(BlockMotionInputController owner)
            {
                _owner = owner;
            }

            public void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _mousePosition = Input.mousePosition;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    var direction = Input.mousePosition - _mousePosition;
                    var motionEvent = ConvertDirectionToEvent(direction);
                    _owner._listeners.TryGetValue(motionEvent, out var action);
                    action?.Invoke();
                }
            }

            private EBlockMotionEvent ConvertDirectionToEvent(Vector3 mouseDirection)
            {
                var dir = mouseDirection;

                if (Abs(dir.x) > Abs(dir.y))
                {
                    return Sign(dir.x) > 0 ? EBlockMotionEvent.RotateRight : EBlockMotionEvent.RotateLeft;
                }

                return Sign(dir.y) > 0 ? EBlockMotionEvent.RotateUp : EBlockMotionEvent.RotateDown;
            }
        }
    }
}
