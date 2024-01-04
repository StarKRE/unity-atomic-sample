using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class FireController
    {
        private readonly IAtomicAction fireAction;

        public FireController(IAtomicAction fireAction)
        {
            this.fireAction = fireAction;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.fireAction?.Invoke();
            }
        }
    }
}