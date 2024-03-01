using TMPro;
using UnityEngine;

internal class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Wallet _wallet;

    private void Awake() => _money.text = _wallet.Money.ToString();

    private void OnEnable() => _wallet.MoneyChanged += OnMoneyChanged;

    private void OnDisable() => _wallet.MoneyChanged -= OnMoneyChanged;

    private void OnMoneyChanged(float money) => _money.text = money.ToString();
}
