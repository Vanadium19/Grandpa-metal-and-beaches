using UnityEngine;

namespace GMB.GamePlay.ScrapConfig
{
    internal class DelayedSoundPlayer : SoundPlayer
    {
        private readonly float _delay = 0.3f;

        private float _delayCounter;

        private void Update()
        {
            if (_delayCounter > 0)
                _delayCounter -= Time.deltaTime;
        }

        public override void Play()
        {
            if (_delayCounter > 0)
                return;

            Source.Play();
            _delayCounter = _delay;
        }
    }
}