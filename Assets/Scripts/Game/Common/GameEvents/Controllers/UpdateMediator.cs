using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.GameEvents
{
    public partial class UpdateMediator : IInitializable
    {
        private readonly List<IUpdatable> _updatables;
        private readonly List<ILateUpdatable> _lateUpdatables;

        public UpdateMediator(List<IUpdatable> updatables, List<ILateUpdatable> lateUpdatables)
        {
            _updatables = updatables;
            _lateUpdatables = lateUpdatables;
        }

        public void Initialize()
        {
            var gameObject = new GameObject("_UpdateMediator", typeof(UpdateListener));
            gameObject.GetComponent<UpdateListener>().SetMediator(this);
        }

        private void OnUpdate(float deltaTime)
        {
            foreach (var entity in _updatables)
                entity.Update(deltaTime);
        }

        private void OnLateUpdate(float deltaTime)
        {
            foreach (var entity in _lateUpdatables)
                entity.LateUpdate(deltaTime);
        }
    }
}
