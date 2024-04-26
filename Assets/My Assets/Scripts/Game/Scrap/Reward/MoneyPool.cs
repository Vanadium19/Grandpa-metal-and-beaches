using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoneyZone))]
public class MoneyPool : MonoBehaviour
{
    private readonly float _moneyAngleX = -90f;

    [SerializeField] private Money _moneyPrefab;

    private MoneyZone _moneyZone;
    private Queue<Money> _spawnQueue = new Queue<Money>();

    private void Awake() => _moneyZone = GetComponent<MoneyZone>();

    public void Push(Money money)
    {
        money.gameObject.SetActive(false);
        _spawnQueue.Enqueue(money);
    }

    public Money Pull()
    {
        if (_spawnQueue.Count == 0)
            Instantiate(_moneyPrefab, _moneyZone.GetPosition(), Quaternion.Euler(_moneyAngleX, 0, 0)).Initialize(this);

        return _spawnQueue.Dequeue();
    }
}
