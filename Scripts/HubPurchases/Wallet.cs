using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private float _money;

    public event UnityAction<float> MoneyChanged;

    public float Money => _money;

    private void Awake()
    {
        _money = PlayerPrefs.GetFloat(GameSaver.Money);
    }

    public bool TryBuy(float money)
    {
        bool canBuy = _money >= money;
        
        if (canBuy)        
            RemoveMoney(money);        

        return canBuy;
    }

    public void AddMoney(float money)
    {
        _money += money;
        PlayerPrefs.SetFloat(GameSaver.Money, _money);
        MoneyChanged?.Invoke(_money);
    }

    private void RemoveMoney(float money)
    {
        _money -= money;
        PlayerPrefs.SetFloat(GameSaver.Money, _money);
        MoneyChanged?.Invoke(_money);
    }

}
