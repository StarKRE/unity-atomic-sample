using System;
using Atomic.Elements;

namespace GameEngine
{
    [Serializable]
    public sealed class FireCondition : IAtomicFunction<bool>
    {
        private IAtomicValue<bool> enabled;
        private IAtomicValue<int> charges;

        public void Compose(IAtomicValue<bool> enabled, IAtomicValue<int> charges)
        {
            this.enabled = enabled;
            this.charges = charges;
        }

        public bool Invoke()
        {
            return this.enabled.Value && this.charges.Value > 0;
        }
    }
}