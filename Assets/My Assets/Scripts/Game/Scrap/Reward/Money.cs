using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
public class Money : MonoBehaviour
{
    private readonly float _delay = 1f;

    private Animator _animator;
    private BoxCollider _collider;
    private MoneyPool _moneyPool;

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

    public void Collect()
    {
        _animator.SetTrigger(AnimatorStaticData.Names.CollectMoney);
        _collider.enabled = false;
        Invoke(nameof(Push), _delay);
    }

    public void SetValue(float value) => Value = value;

    private void Push()
    {
        _collider.enabled = true;
        _moneyPool.Push(this);
    }
}
