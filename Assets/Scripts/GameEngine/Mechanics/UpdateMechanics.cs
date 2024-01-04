using System;
using Atomic.Behaviours;

namespace GameEngine
{
    public sealed class UpdateMechanics : IUpdate
    {
        private readonly Action action;

        public UpdateMechanics(Action action)
        {
            this.action = action;
        }

        public void OnUpdate()
        {
            this.action?.Invoke();
        }
    }
}