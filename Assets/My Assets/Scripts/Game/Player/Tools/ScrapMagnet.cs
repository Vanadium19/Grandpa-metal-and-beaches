using System.Collections;
using UnityEngine;

internal class ScrapMagnet : MonoBehaviour
{
    private readonly float _delay = 2f;

    private readonly float _minDistance = 0f;
    private readonly float _maxDistance = 0.5f;

    [SerializeField] private float _speed;

    public void StartAttract(Transform scrap) => StartCoroutine(Attract(scrap));

    private IEnumerator Attract(Transform scrap)
    {
        float elapsedTime = 0;
        float range = Random.Range(_minDistance, _maxDistance);

        while (Vector3.Distance(transform.position, scrap.position) >= range)
        {
            scrap.position = Vector3.MoveTowards(scrap.position, transform.position, _speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _delay)
                break;

            yield return null;
        }

        scrap.SetParent(transform);
    }
}
