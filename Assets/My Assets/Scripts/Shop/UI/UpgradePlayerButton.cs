using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
internal class UpgradePlayerButton : MonoBehaviour
{
    private readonly string _max = "max";

    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerStats _playerStats;

    private Animator _animator;
    private Button _upgradeButton;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _upgradeButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _playerStats.LevelUpgraded += UpdateDisplay;
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
    }

    private void Start() => UpdateDisplay();

    private void OnDisable()
    {
        _playerStats.LevelUpgraded -= UpdateDisplay;
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);
    }

    protected virtual void Buy(float price)
    {
        _wallet.RemoveMoney(price);
        _playerStats.UpdateLevel();
        _animator.SetTrigger(AnimatorNames.Buy);        
    }

    protected virtual float GetPrice() => _playerStats.GetPrice();

    protected virtual void OffButton()
    {
        _price.text = _max;
        _upgradeButton.interactable = false;
    }

    private void UpdateDisplay()
    {
        if (_playerStats.CurrentLevel == _playerStats.MaxLevel)
            OffButton();
        else
            _price.text = GetPrice().ToString();

        _slider.value = Convert.ToSingle(_playerStats.CurrentLevel) / _playerStats.MaxLevel;
    }

    private void OnUpgradeButtonClicked()
    {
        var price = GetPrice();

        if (_wallet.CanBuy(price))
            Buy(price);
        else
            _animator.SetTrigger(AnimatorNames.NoMoney);
    }
}
