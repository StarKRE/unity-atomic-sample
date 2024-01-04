using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class FireComponent : IDisposable
    {
        public AtomicVariable<bool> enabled = new(true);
        public AtomicEvent fireEvent;

        public Transform firePoint;
        public AtomicObject bulletPrefab;
        public AtomicVariable<int> charges = new(10);
        
        [Get(ObjectAPI.FireAction)]
        public FireAction fireAction;

        [Get("FireCondition")]
        public AndExpression fireCondition;
        
        public SpawnBulletAction bulletAction;
        
        public void Compose()
        {
            this.fireCondition
                .AddMember(this.enabled)
                .AddMember(this.charges.AsFunction(it => it.Value > 0));
            
            this.fireAction.Compose(this.bulletAction, this.charges, this.fireCondition, this.fireEvent);
            this.bulletAction.Compose(this.firePoint, this.bulletPrefab);
        }

        public void Dispose()
        {
            this.fireEvent?.Dispose();
            this.charges?.Dispose();
        }
    }
}