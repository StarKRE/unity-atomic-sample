using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class Countdown
    {
        public float duration;
        public float currentTime;

        public Countdown()
        {
        }

        public Countdown(float duration)
        {
            this.duration = duration;
        }

        public bool IsPlaying()
        {
            return this.currentTime > 0;
        }

        public bool IsEnded()
        {
            return this.currentTime <= 0;
        }

        public void Tick(float deltaTime)
        {
            this.currentTime = Mathf.Max(this.currentTime - deltaTime, 0);
        }

        public void Reset()
        {
            this.currentTime = this.duration;
        }
    }
}