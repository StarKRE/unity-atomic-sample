using Atomic.Behaviours;
using Atomic.Objects;
using GameEngine;
using UnityEngine;

namespace Sample
{
    public sealed class Tower : AtomicBehaviour
    {
        [Get(ObjectAPI.Transform)]
        public Transform mainTransform;
        
        [Section]
        public HealthComponent healthComponent;

        [Section]
        public FireComponent fireComponent;

        public override void Compose()
        {
            base.Compose();
            this.healthComponent.Compose();
            this.fireComponent.Compose();
        }

        private void Awake()
        {
            this.Compose();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.healthComponent.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.healthComponent.OnDisable();
        }

        private void OnDestroy()
        {
            this.healthComponent.Dispose();
            this.fireComponent.Dispose();
        }
    }
}