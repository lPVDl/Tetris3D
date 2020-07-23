using UnityEngine;

namespace Game.Common.GameEvents
{
    partial class UpdateMediator
    {
        private class UpdateListener : MonoBehaviour
        {
            private UpdateMediator _mediator;

            public void SetMediator(UpdateMediator mediator)
            {
                _mediator = mediator;
            }

            private void Update()
            {
                _mediator.OnUpdate(Time.deltaTime);
            }

            private void LateUpdate()
            {
                _mediator.OnLateUpdate(Time.deltaTime);
            }
        }
    }
}
