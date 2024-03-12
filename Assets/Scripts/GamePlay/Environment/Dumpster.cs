using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Dumpster : MonoBehaviour
{
    private readonly float _delay = 1f;

    [SerializeField] private Bag _bag;
    [SerializeField] private Transform _garbagePoint;

    private AudioSource _audioSource;       

    public event UnityAction<float, float> ScrapCollectedOld;
    public event UnityAction<Scrap> ScrapCollected;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.TryGetComponent(out Bag bag))
        //    CollectScrap(bag);
        if (collider.TryGetComponent(out Scrap scrap))
            StartCollect(scrap);
    }

    //private void CollectScrap(Bag bag)
    //{
    //    if (bag.TryGet(out float weight, out float money))
    //    {
    //        _audioSource.Play();
    //        ScrapCollected?.Invoke(weight, money);
    //    }       
    //}

    private void StartCollect(Scrap scrap)
    {
        //_audioSource.Play();
        _bag.Remove(scrap);
        StartCoroutine(Collect(scrap.transform));
        ScrapCollected?.Invoke(scrap);

        ScrapCollectedOld?.Invoke(scrap.Info.Weight, scrap.Info.Price);
    }

    private IEnumerator Collect(Transform scrap)
    {
        scrap.SetParent(transform);
        float elapsedTime = 0;
        Vector3 startPosition = scrap.position;
        Vector3 startScale = scrap.localScale;

        while (elapsedTime < _delay)
        {
            scrap.position = Vector3.Lerp(startPosition, _garbagePoint.position, elapsedTime / _delay);
            scrap.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsedTime / _delay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(scrap.gameObject);
    }
}
