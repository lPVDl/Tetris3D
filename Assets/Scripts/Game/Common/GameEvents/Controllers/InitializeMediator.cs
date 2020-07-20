using System.Collections.Generic;

namespace Game.Common.GameEvents
{
    public class InitializeMediator : Zenject.IInitializable
    {
        private readonly List<IInitializable> _initializables;

        public InitializeMediator(List<IInitializable> initializables)
        {
            _initializables = initializables;
        }

        public void Initialize()
        {
            foreach (var entity in _initializables)
                entity.Initialize();
        }
    }
}
