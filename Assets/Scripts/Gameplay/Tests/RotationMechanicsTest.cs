using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Extensions;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sample
{
    public sealed class RotationMechanicsTest : MonoBehaviour
    {
        [SerializeField]
        private AtomicBehaviour character;

        [Button]
        private void AddRotationMechanics()
        {
            if (this.character.Is(ObjectType.Moveable))
            {
                IAtomicValue<Vector3> moveDirection = this.character.GetValue<Vector3>(ObjectAPI.MoveDirection);
                IAtomicValue<bool> isAlive = this.character.GetValue<bool>(ObjectAPI.IsAlive);
                var rotationMechanics = new RotationMechanics(isAlive, moveDirection, this.character.transform);
                this.character.AddLogic(rotationMechanics);
            }
        }

        [Button]
        private void RemoveRotationMechanics()
        {
            this.character.RemoveLogic<RotationMechanics>();
        }
    }
}