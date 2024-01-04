using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class MoveController
    {
        private readonly IAtomicVariable<Vector3> moveDirection;

        public MoveController(IAtomicVariable<Vector3> moveDirection)
        {
            this.moveDirection = moveDirection;
        }

        public void Update()
        {
            if (this.moveDirection == null)
            {
                return;
            }
            
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction.x = 1;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction.z = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                direction.z = -1;
            }
            
            this.moveDirection.Value = direction;
        }
    }
}