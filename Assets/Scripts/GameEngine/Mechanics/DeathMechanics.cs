using Atomic.Elements;

namespace GameEngine
{
    public sealed class DeathMechanics
    {
        private readonly IAtomicObservable<int> hitPoints;
        private readonly IAtomicEvent deathEvent;

        public DeathMechanics(IAtomicObservable<int> hitPoints, IAtomicEvent deathEvent)
        {
            this.hitPoints = hitPoints;
            this.deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            this.hitPoints.Subscribe(this.OnHitPointsChanged);
        }

        public void OnDisable()
        {
            this.hitPoints.Unsubscribe(this.OnHitPointsChanged);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            if (hitPoints <= 0)
            {
                this.deathEvent.Invoke();
            }
        }
    }
}