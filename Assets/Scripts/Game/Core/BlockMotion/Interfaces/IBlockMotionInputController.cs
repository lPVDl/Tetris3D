using System;

namespace Game.Core.BlockMotion
{
    public interface IBlockMotionInputController
    {
        void RegisterListener(EBlockMotionEvent motionEvent, Action onEvent);

        void UnregisterListener(EBlockMotionEvent motionEvent, Action onEvent);
    }
}
