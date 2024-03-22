using System.Collections.Generic;
using UnityEngine;

public class MoneyPool : MonoBehaviour
{
    [SerializeField] private Money _moneyPrefab;

    private Queue<Money> _spawnQueue = new Queue<Money>();

    public void Push(Money money)
    {
        money.gameObject.SetActive(false);
        _spawnQueue.Enqueue(money);
    }

    public Money Pull()
    {
        if (_spawnQueue.Count == 0)
            Instantiate(_moneyPrefab, Vector3.zero, Quaternion.Euler(-90f, Random.Range(0f, 360f), 0)).Initialize(this);

        return _spawnQueue.Dequeue();        
    }
}
