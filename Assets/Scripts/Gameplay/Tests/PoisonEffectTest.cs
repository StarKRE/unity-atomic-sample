using Atomic.Behaviours;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sample
{
    public sealed class PoisonEffectTest : MonoBehaviour
    {
        [SerializeField]
        private AtomicBehaviour character; 
        
        [SerializeField]
        private PoisonEffect poisonEffectPref;

        [Button]
        public void AddEffect()
        {
            var effect = Instantiate(this.poisonEffectPref, this.character.transform);
            effect.Compose(this.character);
            this.character.AddLogic(effect);
        }

        [Button]
        public void RemoveEffect()
        {
            if (this.character.FindLogic(out PoisonEffect effect))
            {
                this.character.RemoveLogic(effect);
                Destroy(effect.gameObject);
            }
        }
    }
}