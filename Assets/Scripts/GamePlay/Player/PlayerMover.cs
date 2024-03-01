using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
internal class PlayerMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _speed;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _speed = PlayerPrefs.GetFloat(GameSaver.Speed);
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        if (_playerInput.MoveInput != Vector3.zero)
            _transform.rotation = Quaternion.LookRotation(_playerInput.MoveInput, Vector3.up);
    }

    private void Move()
    {
        var horizontalVelocity = _rigidbody.velocity.y * Vector3.up;
        _rigidbody.velocity = horizontalVelocity + _playerInput.MoveInput * _speed;
        _animator.SetBool(AnimatorNames.Walking, _playerInput.MoveInput != Vector3.zero);
    }
}
