using Game.Core.GameCycle;

namespace Game.Core.GameCamera
{
    public class GameCameraInputActivityRules : IGameStartListener, IGameFinishListener
    {
        private readonly IGameCameraInputController _inputController;

        public GameCameraInputActivityRules(IGameCameraInputController inputController)
        {
            _inputController = inputController;
        }

        public void OnGameStart()
        {
            _inputController.SetEnabled(true);
        }

        public void OnGameFinish()
        {
            _inputController.SetEnabled(false);
        }
    }
}
