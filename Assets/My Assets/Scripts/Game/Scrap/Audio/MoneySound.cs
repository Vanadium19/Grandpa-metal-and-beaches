using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MoneySound : MonoBehaviour
{
    private readonly float _delay = 0.3f;

    private AudioSource _audioSource;
    private float _delayCounter;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void Update()
    {
        if (_delayCounter > 0)
            _delayCounter -= Time.deltaTime;
    }

    public void Play()
    {
        if (_delayCounter > 0)
            return;

        _audioSource.Play();
        _delayCounter = _delay;
    }
}
