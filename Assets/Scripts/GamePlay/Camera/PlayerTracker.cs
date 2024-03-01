using UnityEngine;

internal class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Transform _transform;
    private float _lagX;
    private float _lagZ;

    private void Awake()
    {
        _transform = transform;
        _lagX = _target.position.x - _transform.position.x;
        _lagZ = _target.position.z - _transform.position.z;
    }

    private void LateUpdate() => _transform.position = new Vector3(_target.position.x - _lagX, _transform.position.y, _target.position.z - _lagZ);
}
