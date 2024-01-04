using Atomic.Behaviours;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class MoveAnimatorController : IUpdate
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private readonly Animator animator;
        private readonly IAtomicValue<bool> isMoving;

        public MoveAnimatorController(Animator animator, IAtomicValue<bool> isMoving)
        {
            this.animator = animator;
            this.isMoving = isMoving;
        }

        public void OnUpdate()
        {
            this.animator.SetBool(IsMoving, this.isMoving.Value);
        }
    }
}