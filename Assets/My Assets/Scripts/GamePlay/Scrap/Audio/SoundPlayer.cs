using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    protected AudioSource Source => _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public abstract void Play();
}