using UnityEngine;

internal class MoneyZone : MonoBehaviour
{
    [SerializeField] private Transform _minPoint;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _stepX = 0.4f;
    [SerializeField] private float _stepZ = 0.75f;

    private float _positionY;
    private Vector3 _currentPosition;

    private void Awake()
    {
        _positionY = _minPoint.position.y;
        _currentPosition = new Vector3(_minPoint.position.x - _stepX, _positionY, _minPoint.position.z);
    }

    public Vector3 GetPosition()
    {
        float positionX = _currentPosition.x >= _maxPositionX ? _minPoint.position.x : _currentPosition.x + _stepX;
        float positionZ = _currentPosition.x >= _maxPositionX ? _currentPosition.z + _stepZ : _currentPosition.z;

        _currentPosition = new Vector3(positionX, _positionY, positionZ);
        return _currentPosition;
    }
}
