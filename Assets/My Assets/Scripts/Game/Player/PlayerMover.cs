using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
internal class PlayerMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UpgradePanel _upgradePanel;

    private float _speed;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        SetSpeed();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }
    private void OnEnable() => _upgradePanel.PlayerUpgraded += SetSpeed;
    
    private void Update()
    {
        Move();
        Rotate();
    }

    private void OnDisable() => _upgradePanel.PlayerUpgraded -= SetSpeed;

    public void Stop() => _speed = 0;

    public void SetSpeed() => _speed = PlayerPrefs.GetFloat(GameSaver.Speed);

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
