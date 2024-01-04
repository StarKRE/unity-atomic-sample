using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;

namespace GameEngine
{
    [Serializable]
    public sealed class DealDamageAction : IAtomicAction<IAtomicObject>
    {
        private IAtomicValue<int> damage;

        public void Compose(IAtomicValue<int> damage)
        {
            this.damage = damage;
        }

        public void Invoke(IAtomicObject target)
        {
            if (!target.Is(ObjectType.Damagable))
            {
               return; 
            }
            
            IAtomicAction<int> damageAction = target.GetAction<int>(ObjectAPI.TakeDamageAction);
            damageAction?.Invoke(this.damage.Value);
        }
    }
}