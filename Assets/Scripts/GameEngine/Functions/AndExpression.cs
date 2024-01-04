using System;
using GameEngine;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AndExpression : AtomicExpression<bool>
    {
        public override bool Invoke()
        {
            for (int i = 0, count = this.members.Count; i < count; i++)
            {
                if (!this.members[i].Value)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}