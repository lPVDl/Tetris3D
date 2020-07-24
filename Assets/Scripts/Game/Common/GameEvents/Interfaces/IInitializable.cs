namespace Game.Common.GameEvents
{
    public interface IInitializable
    {
        EInitializationOrder InitializationOrder { get; }

        void Initialize();
    }
}
