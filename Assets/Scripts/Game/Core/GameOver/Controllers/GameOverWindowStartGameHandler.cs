using Game.Common.GameEvents;
using Game.Core.GameCycle;
using System;

namespace Game.Core.GameOver
{
    public class GameOverWindowStartGameHandler : IInitializable, IDisposable
    {
        private readonly IGameOverWindow _gameOverWindow;
        private readonly IGameCycleController _gameCycleController;

        public GameOverWindowStartGameHandler(IGameOverWindow gameOverWindow,
                                              IGameCycleController gameCycleController)
        {
            _gameOverWindow = gameOverWindow;
            _gameCycleController = gameCycleController;
        }

        public void Initialize()
        {
            _gameOverWindow.OnTryStartGame += _gameCycleController.StartGame;
        }

        public void Dispose()
        {
            _gameOverWindow.OnTryStartGame -= _gameCycleController.StartGame;
        }
    }
}
