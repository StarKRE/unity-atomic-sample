using System;
using Atomic.Elements;

namespace GameEngine
{
    [Serializable]
    public sealed class TakeDamageMechanics
    {
        private readonly IAtomicObservable<int> takeDamageEvent;
        private readonly IAtomicVariable<int> hitPoints;

        public TakeDamageMechanics(IAtomicObservable<int> takeDamageEvent, IAtomicVariable<int> hitPoints)
        {
            this.takeDamageEvent = takeDamageEvent;
            this.hitPoints = hitPoints;
        }

        public void OnEnable()
        {
            this.takeDamageEvent.Subscribe(this.OnTakeDamage);
        }

        public void OnDisable()
        {
            this.takeDamageEvent.Unsubscribe(this.OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            if (this.hitPoints.Value > 0)
            {
                this.hitPoints.Value = Math.Max(0, this.hitPoints.Value - damage);
            }
        }
    }
}