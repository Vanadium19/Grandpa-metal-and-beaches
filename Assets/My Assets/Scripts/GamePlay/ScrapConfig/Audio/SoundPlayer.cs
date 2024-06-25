using UnityEngine;

namespace GMB.GamePlay.ScrapConfig.Audio
{
    [RequireComponent(typeof(AudioSource))]
    internal abstract class SoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        protected AudioSource Source => _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public abstract void Play();
    }
}