using Atomic.Behaviours;
using Atomic.Objects;
using UnityEngine;

namespace Sample
{
    public sealed class Character : AtomicBehaviour
    {
        [Section]
        [SerializeField]
        private Character_Core core;

        [Section]
        [SerializeField]
        private Character_View view;
        
        public override void Compose()
        {
            base.Compose();
            
            this.core.Compose();
            this.view.Compose(this.core);
        }

        private void Awake()
        {
            this.Compose();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            this.core.OnEnable();
            this.view.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            this.core.OnDisable();
            this.view.OnDisable();
        }

        protected override void Update()
        {
            base.Update();
            
            this.core.Update();
            this.view.Update();
        }

        private void OnDestroy()
        {
            this.core.Dispose();
        }
    }
}