using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Money : MonoBehaviour
{    
    private Animator _animator;
    private readonly float _delay = 1f;

    private BoxCollider _collider;
    private AudioSource _audioSource;
    private MoneyPool _moneyPool;

    public float Value { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Initialize(MoneyPool moneyPool)
    {
        _moneyPool = moneyPool;
        Push();
    }

    public void Push()
    {
        _collider.enabled = true;
        _moneyPool.Push(this);
    }

    public void Collect()
    {
        _animator.SetTrigger(AnimatorNames.CollectMoney);
        _audioSource.Play();
        _collider.enabled = false;
        Invoke(nameof(Push), _delay);
    }

    public void SetValue(float value) => Value = value;
}
