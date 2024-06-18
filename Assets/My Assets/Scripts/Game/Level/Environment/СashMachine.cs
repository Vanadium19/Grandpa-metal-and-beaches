using UnityEngine;

internal class ÑashMachine : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;
    [SerializeField] private Dumpster _dumpster;
    [SerializeField] private MoneyPool _moneyPool;

    private void OnEnable()
    {
        _dumpster.ScrapCollected += GiveMoney;
    }

    private void OnDisable()
    {
        _dumpster.ScrapCollected -= GiveMoney;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
            _pointer.SetActive(false);
    }

    private void GiveMoney(Scrap scrap)
    {
        var money = _moneyPool.Pull();

        money.gameObject.SetActive(true);
        money.SetValue(scrap.Info.Price);

        _pointer.SetActive(true);
    }
}