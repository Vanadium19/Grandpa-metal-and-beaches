using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
public class Money : MonoBehaviour
{    
    private Animator _animator;
    private BoxCollider _collider;
    private MoneyPool _moneyPool;
    private float _delay = 1f;

    public float Value { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
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
        _animator.SetTrigger("CollectMoney");
        _collider.enabled = false;
        Invoke(nameof(Push), _delay);
    }

    public void SetValue(float value) => Value = value;
}
