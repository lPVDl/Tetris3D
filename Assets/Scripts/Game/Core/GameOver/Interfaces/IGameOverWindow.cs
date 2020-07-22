using System;

namespace Game.Core.GameOver
{
    public interface IGameOverWindow
    {
        event Action OnTryStartGame;
    }
}
