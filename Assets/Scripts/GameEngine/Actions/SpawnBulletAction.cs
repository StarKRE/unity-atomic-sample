using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class SpawnBulletAction : IAtomicAction
    {
        private Transform firePoint;
        private AtomicObject bulletPrefab;

        public SpawnBulletAction()
        {
        }

        public SpawnBulletAction(Transform firePoint, AtomicObject bulletPrefab)
        {
            this.firePoint = firePoint;
            this.bulletPrefab = bulletPrefab;
        }

        public void Compose(Transform firePoint, AtomicObject bulletPrefab)
        {
            this.firePoint = firePoint;
            this.bulletPrefab = bulletPrefab;
        }

        public void Invoke()
        {
            AtomicObject bullet = GameObject.Instantiate(
                this.bulletPrefab,
                this.firePoint.position,
                this.firePoint.rotation,
                null
            );
            
            IAtomicVariable<Vector3> bulletDirection = bullet.GetVariable<Vector3>(ObjectAPI.MoveDirection);
            if (bulletDirection != null)
            {
                bulletDirection.Value = this.firePoint.forward;
            }
        }
    }
}