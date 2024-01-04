using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using GameEngine;
using UnityEngine;

namespace Sample
{
    public sealed class GameSystem : MonoBehaviour
    {
        [SerializeField]
        private AtomicObject character;
        
        private MoveController moveController;
        private FireController fireController;

        private void Start()
        {
            var moveDirection = new AtomicProperty<Vector3>(this.GetMoveDirection, this.SetMoveDirection);
            var fireAction = this.character.GetAction(ObjectAPI.FireAction);

            this.moveController = new MoveController(moveDirection);
            this.fireController = new FireController(fireAction);
        }

        private Vector3 GetMoveDirection()
        {
            var direction = this.character.GetVariable<Vector3>(ObjectAPI.MoveDirection);
            if (direction != null)
            {
                return direction.Value;
            }

            return default;
        }

        private void SetMoveDirection(Vector3 value)
        {
            var direction = this.character.GetVariable<Vector3>(ObjectAPI.MoveDirection);
            if (direction != null)
            {
                direction.Value = value;
            }
        }

        private void Update()
        {
            this.moveController.Update();
            this.fireController.Update();
        }
    }
}