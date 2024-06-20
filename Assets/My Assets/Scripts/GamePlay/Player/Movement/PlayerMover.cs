using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
internal class PlayerMover : MonoBehaviour
{
    private readonly float _zeroSpeed = 0;

    [SerializeField] private Animator _animator;

    private float _speed;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _speed = GameSaver.Speed;
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void StopPlayer()
    {
        _speed = _zeroSpeed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Rotate()
    {
        if (_playerInput.MoveInput * _speed != Vector3.zero)
            _transform.rotation = Quaternion.LookRotation(_playerInput.MoveInput, Vector3.up);
    }

    private void Move()
    {
        var horizontalVelocity = _rigidbody.velocity.y * Vector3.up;
        _rigidbody.velocity = horizontalVelocity + _playerInput.MoveInput * _speed;
        _animator.SetBool(StaticAnimatorData.Walking, _playerInput.MoveInput != Vector3.zero);
    }
}