using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _money;

    public event Action<float> MoneyChanged;

    public float Money => _money;

    private void Awake()
    {
        _money = GameSaver.Money;
    }

    public bool CanBuy(float money)
    {
        return _money >= money;
    }

    public void AddMoney(float money)
    {
        if (money <= 0)
            return;

        _money += money;
        SaveMoney();
    }

    public void RemoveMoney(float money)
    {
        if (money <= 0)
            return;

        _money -= money;
        SaveMoney();
    }

    private void SaveMoney()
    {
        MoneyChanged?.Invoke(_money);
        GameSaver.SetMoney(_money);
    }
}