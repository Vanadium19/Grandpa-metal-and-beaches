using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Dumpster : MonoBehaviour
{
    private readonly float _musicDelay = 3f;
    private readonly float _scrapMagnetDelay = 0.5f;

    [SerializeField] private Bag _bag;
    [SerializeField] private Transform _garbagePoint;

    private AudioSource _audioSource;
    private float _musicDelayCounter;

    public event UnityAction<Scrap> ScrapCollected;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

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

    private void PlaySound()
    {
        if (_musicDelayCounter <= 0)
        {
            _audioSource.Play();
            _musicDelayCounter = _musicDelay;
        }
    }

    private IEnumerator Collect(Transform scrap)
    {
        float elapsedTime = 0;
        Vector3 startPosition = scrap.position;
        Vector3 startScale = scrap.localScale;

        while (elapsedTime < _scrapMagnetDelay)
        {
            scrap.position = Vector3.Lerp(startPosition, _garbagePoint.position, elapsedTime / _scrapMagnetDelay);
            scrap.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsedTime / _scrapMagnetDelay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PlaySound();
        Destroy(scrap.gameObject);
    }
}
