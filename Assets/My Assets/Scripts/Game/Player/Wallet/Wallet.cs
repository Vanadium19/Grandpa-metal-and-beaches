using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private float _money;

    public event UnityAction<float> MoneyChanged;

    public float Money => _money;

    private void Awake() => _money = PlayerPrefs.GetFloat(GameSaver.Money);

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
        PlayerPrefs.SetFloat(GameSaver.Money, _money);
        PlayerPrefs.Save();
    }
}
