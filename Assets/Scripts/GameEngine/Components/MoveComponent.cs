using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    [Is(ObjectType.Moveable)]
    public sealed class MoveComponent : IDisposable, IUpdate
    {
        public IAtomicValue<bool> IsMoving => this.isMoving;

        public IAtomicVariable<bool> Enabled => this.enabled;

        public IAtomicVariable<float> Speed => this.speed;

        [Get("MoveCondition")]
        public IAtomicExpression<bool> Condition => this.moveCondition;

        [Get(ObjectAPI.MoveDirection)]
        public IAtomicVariable<Vector3> Direction => this.direction;

        [SerializeField]
        private AtomicVariable<float> speed = new();

        [SerializeField]
        private AtomicVariable<bool> enabled = new(true);

        [SerializeField]
        private AtomicVariable<Vector3> direction = new();

        [SerializeField]
        private AtomicFunction<bool> isMoving = new();

        [SerializeField]
        private AndExpression moveCondition = new();

        private MovementMechanics movementMechanics;

        public MoveComponent(Transform transform, float speed = default)
        {
            this.Compose(transform);
            this.speed.Value = speed;
        }

        public MoveComponent()
        {
        }

        public void Compose(Transform transform)
        {
            this.isMoving.Compose(
                () => this.enabled.Value && this.direction.Value.magnitude > 0 && this.moveCondition.Invoke()
            );

            this.movementMechanics = new MovementMechanics(
                this.moveCondition, this.direction, this.speed, transform
            );
        }

        public void OnUpdate()
        {
            if (this.enabled.Value)
            {
                this.movementMechanics.Update();
            }
        }

        public void Dispose()
        {
            this.enabled?.Dispose();
            this.speed?.Dispose();
            this.direction?.Dispose();
        }
    }
}