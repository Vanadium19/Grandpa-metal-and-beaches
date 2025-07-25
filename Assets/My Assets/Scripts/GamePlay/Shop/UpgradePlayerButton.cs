using System;
using GMB.Advertising;
using GMB.GamePlay.PlayerEnvironment.Tools;
using GMB.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace GMB.GamePlay.Shop
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ButtonDisplay))]
    internal class UpgradePlayerButton : MonoBehaviour
    {
        private readonly float _saleFactor = 0.75f;

        [SerializeField] private Wallet _wallet;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private VideoAd _videoAd;

        private float _currentPrice;
        private Button _upgradeButton;
        private ButtonDisplay _buttonDisplay;

        private bool IsSaleButton => _wallet.Money >= _saleFactor * _currentPrice && _wallet.Money < _currentPrice;

        private void Awake()
        {
            _upgradeButton = GetComponent<Button>();
            _buttonDisplay = GetComponent<ButtonDisplay>();
        }

        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
            _wallet.MoneyChanged += UpdateButton;

            InitializeButton();
        }

        private void Start()
        {
            InitializeButton();
        }

        private void OnDisable()
        {
            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);
            _wallet.MoneyChanged -= UpdateButton;
        }

        private void InitializeButton()
        {
            if (_upgradeButton.interactable)
                UpdateButton(_wallet.Money);
        }

        private void Buy(float price)
        {
            _playerStats.UpdateLevel();
            _wallet.RemoveMoney(price);
            _buttonDisplay.SetAnimationTrigger(StaticAnimatorData.Buy);
        }

        private void OffButton()
        {
            _buttonDisplay.Off();
            _upgradeButton.interactable = false;
        }

        private void UpdateDisplay(float money)
        {
            _currentPrice = _playerStats.GetPrice();
            _buttonDisplay.UpdatePrice(IsSaleButton, IsSaleButton ? money : _currentPrice);
        }

        private void OnUpgradeButtonClicked()
        {
            if (IsSaleButton)
                _videoAd.Show(_upgradeButton, Buy, _wallet.Money);
            else if (_wallet.CanBuy(_currentPrice))
                Buy(_currentPrice);
            else
                _buttonDisplay.SetAnimationTrigger(StaticAnimatorData.NoMoney);
        }

        private void UpdateButton(float money)
        {
            if (_playerStats.CurrentLevel == _playerStats.MaxLevel)
                OffButton();
            else
                UpdateDisplay(money);

            _buttonDisplay.SetSlider(Convert.ToSingle(_playerStats.CurrentLevel) / _playerStats.MaxLevel);
        }
    }
}