using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class DeathAnimatorTrigger
    {
        private static readonly int Death = Animator.StringToHash("Death");

        private readonly Animator animator;
        private readonly IAtomicObservable deathEvent;

        public DeathAnimatorTrigger(Animator animator, IAtomicObservable deathEvent)
        {
            this.animator = animator;
            this.deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            this.deathEvent.Subscribe(this.OnDeath);
        }

        public void OnDisable()
        {
            this.deathEvent.Unsubscribe(this.OnDeath);
        }
        
        private void OnDeath()
        {
            this.animator.SetTrigger(Death);
        }
    }
}