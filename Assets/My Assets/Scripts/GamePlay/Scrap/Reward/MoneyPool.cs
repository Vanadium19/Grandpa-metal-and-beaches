using System.Collections.Generic;
using UnityEngine;

namespace GMB.GamePlay.ScrapConfig
{
    [RequireComponent(typeof(MoneyZone))]
    internal class MoneyPool : MonoBehaviour
    {
        private readonly Quaternion _moneyAngle = Quaternion.Euler(-90f, 0, 0);

        [SerializeField] private Money _moneyPrefab;

        private MoneyZone _moneyZone;
        private Queue<Money> _spawnQueue = new Queue<Money>();

        private void Awake()
        {
            _moneyZone = GetComponent<MoneyZone>();
        }

        public void Push(Money money)
        {
            money.gameObject.SetActive(false);
            _spawnQueue.Enqueue(money);
        }

        public Money Pull()
        {
            if (_spawnQueue.Count == 0)
                Instantiate(_moneyPrefab, _moneyZone.GetPosition(), _moneyAngle).Initialize(this);

            return _spawnQueue.Dequeue();
        }
    }
}