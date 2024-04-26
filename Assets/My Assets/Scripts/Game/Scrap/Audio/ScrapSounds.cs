using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScrapSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;

    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    public void Play()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Count)]);
    }
}
