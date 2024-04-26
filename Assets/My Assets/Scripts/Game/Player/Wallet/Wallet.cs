using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _money;

    public event Action<float> MoneyChanged;

    public float Money => _money;

    private void Awake() => _money = PlayerPrefs.GetFloat(GameSaverData.Money);

    public bool CanBuy(float money) => _money >= money;

    public void AddMoney(float money)
    {
        if (money <= 0)
            return;

        _money += money;
        MoneyChanged?.Invoke(_money);
        SaveMoney();
    }

    public void RemoveMoney(float money)
    {
        if (money <= 0)
            return;

        _money -= money;
        MoneyChanged?.Invoke(_money);
        SaveMoney();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetFloat(GameSaverData.Money, _money);
        PlayerPrefs.Save();
    }
}
