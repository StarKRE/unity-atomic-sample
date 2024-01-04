using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    [Is(ObjectType.Damagable)]
    public sealed class HealthComponent : IDisposable
    {
        [Get(ObjectAPI.IsAlive)]
        public IAtomicValue<bool> IsAlive => this.isAlive;
        
        public AtomicEvent deathEvent;
        
        [Get(ObjectAPI.TakeDamageAction)]
        public AtomicEvent<int> takeDamageEvent;

        [Get(ObjectAPI.HitPoints)]
        public AtomicVariable<int> hitPoints = new(10);

        [SerializeField]
        private AtomicFunction<bool> isAlive;
        
        private TakeDamageMechanics takeDamageMechanics;
        private DeathMechanics deathMechanics;

        public void Compose()
        {
            this.isAlive.Compose(() => this.hitPoints.Value > 0);
            this.takeDamageMechanics = new TakeDamageMechanics(this.takeDamageEvent, this.hitPoints);
            this.deathMechanics = new DeathMechanics(this.hitPoints, this.deathEvent);
        }
        
        public void OnEnable()
        {
            this.takeDamageMechanics.OnEnable();
            this.deathMechanics.OnEnable();
        }

        public void OnDisable()
        {
            this.takeDamageMechanics.OnDisable();
            this.deathMechanics.OnDisable();
        }

        public void Dispose()
        {
            this.deathEvent?.Dispose();
            this.takeDamageEvent?.Dispose();
            this.hitPoints?.Dispose();
        }
    }
}