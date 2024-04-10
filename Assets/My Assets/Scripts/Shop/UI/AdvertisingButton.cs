using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class AdvertisingButton : MonoBehaviour
{
    private readonly float _rewardMoneyCount = 25f;

    [SerializeField] private Menu _menu;
    [SerializeField] private Wallet _wallet;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(ShowAdvertisement);

    private void OnDisable() => _button.onClick.RemoveListener(ShowAdvertisement);

    private void ShowAdvertisement() => Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);

    private void OnOpenCallback()
    {
        _menu.StopTime();
        _menu.StopMusic();
    }

    private void OnRewardCallback() => _wallet.AddMoney(_rewardMoneyCount);

    private void OnCloseCallback()
    {
        _menu.ContinueTime();
        _menu.ContinueMusic();
    }
}
