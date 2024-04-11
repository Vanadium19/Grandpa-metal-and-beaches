using UnityEngine;

internal class Pointer : MonoBehaviour
{
    private readonly float _rightAngle = 90f;

    [SerializeField] private Transform _target;
    [SerializeField] private RectTransform _pointerTransform;
    [SerializeField] private Camera _mainCamera;    

    private float _staticPositionX => Screen.width / 2;
    private float _indent => 0.075f * Screen.height;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        Vector3 direction = _target.position - _mainCamera.transform.position;
        direction.Normalize();

        Vector3 localDirection = _mainCamera.transform.InverseTransformDirection(direction);
        float angle = Mathf.Atan2(localDirection.y, localDirection.x) * Mathf.Rad2Deg;

        _pointerTransform.rotation = Quaternion.Euler(0, 0, angle - _rightAngle);
    }

    private void Move()
    {
        Vector3 screenPosition = _mainCamera.WorldToScreenPoint(_target.position);

        float clampedX = Mathf.Clamp(screenPosition.x, _indent, Screen.width - _indent);
        float clampedY = Mathf.Clamp(screenPosition.y, _indent, Screen.height - _indent);
        screenPosition = Mathf.Approximately(clampedY, Screen.height - _indent) ? 
            new Vector3(_staticPositionX, _indent, 0) : new Vector3(clampedX, clampedY, screenPosition.z);      

        _pointerTransform.position = screenPosition;
    }
}

