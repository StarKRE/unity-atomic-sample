using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace GameEngine
{
    [Serializable]
    public sealed class FireAction : IAtomicAction
    {
        private IAtomicVariable<int> charges;
        private IAtomicValue<bool> shootCondition;
        private IAtomicAction shootAction;
        private IAtomicEvent shootEvent;

        public void Compose(
            IAtomicAction shootAction,
            IAtomicVariable<int> charges,
            IAtomicValue<bool> shootCondition,
            IAtomicEvent shootEvent
        )
        {
            this.shootAction = shootAction;
            this.charges = charges;
            this.shootCondition = shootCondition;
            this.shootEvent = shootEvent;
        }

        [Button]
        public void Invoke()
        {
            if (!this.shootCondition.Value)
            {
                return;
            }

            this.shootAction.Invoke();
            this.charges.Value--;
            this.shootEvent.Invoke();
        }
    }
}