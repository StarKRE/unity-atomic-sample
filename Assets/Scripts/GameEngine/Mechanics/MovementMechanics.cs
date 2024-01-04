using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class MovementMechanics
    {
        private readonly IAtomicValue<bool> moveEnabled;
        private readonly IAtomicValue<Vector3> moveDirection;
        private readonly IAtomicValue<float> moveSpeed;
        private readonly Transform transform;

        public MovementMechanics(
            IAtomicValue<bool> moveEnabled,
            IAtomicValue<Vector3> moveDirection,
            IAtomicValue<float> moveSpeed,
            Transform transform
        )
        {
            this.moveEnabled = moveEnabled;
            this.moveDirection = moveDirection;
            this.moveSpeed = moveSpeed;
            this.transform = transform;
        }

        public void Update()
        {
            if (this.moveEnabled.Value)
            {
                Vector3 moveOffset = this.moveDirection.Value * (this.moveSpeed.Value * Time.deltaTime);
                this.transform.position += moveOffset;
            }
        }
    }
}