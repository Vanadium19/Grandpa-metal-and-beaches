using GMB.StaticData;
using UnityEngine;

namespace GMB.GamePlay.ScrapConfig
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider))]
    internal class Money : MonoBehaviour
    {
        private readonly float _delay = 1f;

        private Animator _animator;
        private BoxCollider _collider;
        private MoneyPool _moneyPool;
        private float _value;

        public float Value => _value;

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
            _animator.SetTrigger(StaticAnimatorData.CollectMoney);
            _collider.enabled = false;
            Invoke(nameof(Push), _delay);
        }

        public void SetValue(float value)
        {
            _value = value;
        }

        private void Push()
        {
            _collider.enabled = true;
            _moneyPool.Push(this);
        }
    }
}