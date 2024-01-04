using System;
using Atomic.Behaviours;
using Atomic.Extensions;
using Atomic.Objects;
using GameEngine;
using UnityEngine;

namespace Sample
{
    [Serializable]
    public sealed class PoisonEffect : MonoBehaviour, IEnable, IDisable, IUpdate
    {
        private IAtomicObject target;

        [SerializeField]
        private Countdown period = new(1);

        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private DealDamageAction damageAction = new();

        [SerializeField]
        private ParticleSystem vfx;

        public void Compose(IAtomicObject target)
        {
            this.target = target;
            this.damageAction.Compose(this.AsFunction(it => it.damage));
        }

        public void Enable()
        {
            this.vfx.Play();
        }

        public void Disable()
        {
            this.vfx.Stop();
        }

        public void OnUpdate()
        {
            var deltaTime = Time.deltaTime;
            this.UpdatePeriod(deltaTime);
        }

        private void UpdatePeriod(float deltaTime)
        {
            this.period.Tick(deltaTime);

            if (this.period.IsEnded())
            {
                this.damageAction.Invoke(this.target);
                this.period.Reset();
            }
        }
    }
}