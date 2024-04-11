using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _startPoint;
    private PlayerMover _playerMover;
    private Coroutine _heightTracking;

    private void Awake()
    {
        _transform = transform;
        _startPoint = _transform.position;
        _playerMover = GetComponent<PlayerMover>();
    }

    public void StopMove(bool value)
    {
        if (value)
            _playerMover.Stop();        
        else        
            _playerMover.SetSpeed(PlayerPrefs.GetFloat(GameSaver.Speed));        
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
