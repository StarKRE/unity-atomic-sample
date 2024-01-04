using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sample
{
    public sealed class MoveComponentTest : MonoBehaviour
    {
        private const string MOVE_COMPONENT_CONTROLLER = "MoveComponentController";
        
        [SerializeField]
        private AtomicBehaviour character;

        [Button]
        public void AddMoveComponent()
        {
            var moveComponent = new MoveComponent(this.character.transform, 5);
            this.character.AddComponent(moveComponent);
            this.character.AddLogic(moveComponent);
            
            IAtomicValue<bool> isAlive = this.character.GetValue<bool>(ObjectAPI.IsAlive);
            IAtomicVariable<bool> moveEnabled = moveComponent.Enabled;
            var stateController = new UpdateMechanics(() => moveEnabled.Value = isAlive.Value);
            this.character.AddLogic(MOVE_COMPONENT_CONTROLLER, stateController);

            Animator animator = this.character.Get<Animator>(ObjectAPI.Animator);
            if (animator != null)
            {
                var movingAnimatorController = new MoveAnimatorController(animator, moveComponent.IsMoving);
                this.character.AddLogic(movingAnimatorController);   
            }
        }

        [Button]
        public void RemoveMoveComponent()
        {
            this.character.RemoveComponent<MoveComponent>();
            this.character.RemoveLogic<MoveComponent>();
            this.character.RemoveLogic(MOVE_COMPONENT_CONTROLLER);
            this.character.RemoveLogic<MoveAnimatorController>();
        }
    }
}