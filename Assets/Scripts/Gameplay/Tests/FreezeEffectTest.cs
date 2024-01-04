using Atomic.Behaviours;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sample
{
    public sealed class FreezeEffectTest : MonoBehaviour
    {
        [SerializeField]
        private AtomicBehaviour character; 
        
        [SerializeField]
        private FreezeEffect effectPref;

        [Button]
        public void AddEffect()
        {
            var effect = Instantiate(this.effectPref, this.character.transform);
            effect.Compose(this.character, () =>
            {
                this.character.RemoveLogic(effect);
                Destroy(effect.gameObject);
            });
            
            this.character.AddLogic(effect);
        }

        [Button]
        public void RemoveEffect()
        {
            if (this.character.FindLogic(out FreezeEffect effect))
            {
                this.character.RemoveLogic(effect);
                Destroy(effect.gameObject);
            }
        }
    }
}