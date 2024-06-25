using GMB.GamePlay.PlayerEnvironment.Tools;
using TMPro;
using UnityEngine;

namespace GMB.GamePlay.PlayerEnvironment
{
    internal class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        [SerializeField] private Wallet _wallet;

        private void OnEnable()
        {
            _money.text = _wallet.Money.ToString();
            _wallet.MoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _wallet.MoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(float money)
        {
            _money.text = money.ToString();
        }
    }
}