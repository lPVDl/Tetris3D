using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.GameEvents
{
    public partial class UpdateMediator : IInitializable
    {
        private readonly List<IUpdatable> _updatables;

        public UpdateMediator(List<IUpdatable> updatables)
        {
            _updatables = updatables;
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
    }
}
