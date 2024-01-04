using Atomic.Behaviours;
using Atomic.Objects;
using GameEngine;
using UnityEngine;

namespace Sample
{
    public sealed class Bullet : AtomicBehaviour
    {
        [SerializeField]
        private bool composeOnAwake = true;
        
        [Section]
        public MoveComponent moveComponent;

        public override void Compose()
        {
            base.Compose();
            this.moveComponent.Compose(this.transform);
        }

        private void Awake()
        {
            if (this.composeOnAwake)
            {
                this.Compose();
            }
        }

        protected override void Update()
        {
            base.Update();
            this.moveComponent.OnUpdate();
        }

        private void OnDestroy()
        {
            this.moveComponent.Dispose();
        }
    }
}