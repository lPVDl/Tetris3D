namespace Game.Common.Logging
{
    public interface ILogModuleFactory
    {
        LogModule Create(object owner);
    }
}
