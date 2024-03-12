using System;
using UnityEngine;

internal class MetalDetector : MonoBehaviour
{
    [SerializeField] private ScrapCollector _scrapCollector;
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Scrap scrap) && scrap.IsCollected == false)
            _scrapCollector.Collect(scrap);
        else if (collider.TryGetComponent(out Money money))
            CollectMoney(money);
    }

    private void CollectMoney(Money money)
    {
        _wallet.AddMoney(money.Value);
        money.Collect();
    }
}
