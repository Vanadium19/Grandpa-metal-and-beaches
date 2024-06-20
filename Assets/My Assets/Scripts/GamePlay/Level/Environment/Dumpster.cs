using System;
using System.Collections;
using UnityEngine;

namespace GMB.GamePlay.Level
{
    [RequireComponent(typeof(AudioSource))]
    internal class Dumpster : MonoBehaviour
    {
        private readonly float _musicDelay = 3f;
        private readonly float _scrapMagnetDelay = 0.5f;

        [SerializeField] private Bag _bag;
        [SerializeField] private Transform _garbagePoint;

        private AudioSource _audioSource;
        private float _musicDelayCounter;

        public event Action<Scrap> ScrapCollected;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (_musicDelayCounter > 0)
                _musicDelayCounter -= Time.deltaTime;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Scrap scrap))
                StartCollect(scrap);
        }

        private void StartCollect(Scrap scrap)
        {
            _bag.Remove(scrap);
            scrap.transform.SetParent(transform);
            StartCoroutine(Collect(scrap.transform));
            ScrapCollected?.Invoke(scrap);
        }

        private IEnumerator Collect(Transform scrap)
        {
            float elapsedTime = 0;
            Vector3 startPosition = scrap.position;
            Vector3 startScale = scrap.localScale;

            while (elapsedTime < _scrapMagnetDelay)
            {
                float lerpValue = elapsedTime / _scrapMagnetDelay;
                scrap.position = Vector3.Lerp(startPosition, _garbagePoint.position, lerpValue);
                scrap.localScale = Vector3.Lerp(startScale, Vector3.zero, lerpValue);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            PlaySound();
            Destroy(scrap.gameObject);
        }

        private void PlaySound()
        {
            if (_musicDelayCounter > 0)
                return;

            _audioSource.Play();
            _musicDelayCounter = _musicDelay;
        }
    }
}