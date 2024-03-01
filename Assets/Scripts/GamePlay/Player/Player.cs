using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _startPoint;
    private Coroutine _heightTracking;

    private void Awake()
    {
        _transform = transform;
        _startPoint = _transform.position;
    }

    public void StartHeightTracking()
    {
        StopHeightTracking();
        _heightTracking = StartCoroutine(TrackHeight());
    }

    public void StopHeightTracking()
    {
        if (_heightTracking != null)
            StopCoroutine(_heightTracking);
    }

    private IEnumerator TrackHeight()
    {
        while (true)
        {
            if (_transform.position.y < -7)
            {
                _transform.position = _startPoint;
                break;
            }

            yield return null;
        }
    }
}
