using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
internal class ScrapSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;
    [SerializeField] private ScrapCollector _scrapCollector;
    
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable() => _scrapCollector.ScrapCollected += OnScrapCollected;

    private void OnDisable() => _scrapCollector.ScrapCollected -= OnScrapCollected;

    private void OnScrapCollected()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Count)]);
    }
}
