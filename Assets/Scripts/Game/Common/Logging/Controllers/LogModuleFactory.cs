namespace Game.Common.Logging
{
    public class LogModuleFactory : ILogModuleFactory
    {
        public LogModule Create(object owner)
        {
            return new LogModule(owner.GetType().Name + ": ");
        }
    }
}
