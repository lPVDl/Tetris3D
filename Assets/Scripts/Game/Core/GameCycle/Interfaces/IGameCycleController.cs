namespace Game.Core.GameCycle
{
    /// <summary>
    /// Main core game controller, which determines how game behave.
    /// </summary>
    public interface IGameCycleController
    {
        /// <summary>
        /// Starts new game or stops current and restarts.
        /// </summary>
        void StartGame();
    }
}
