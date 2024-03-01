using UnityEngine;

internal class VideoAd : MonoBehaviour
{
    private float _money;
    private Wallet _wallet;

    public void Show(Wallet wallet, float money)
    {
        _wallet = wallet;
        _money = money;
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);        
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }

    private void OnRewardCallback() => _wallet.AddMoney(_money);

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = GameSaver.GetCurrentVolume();
        gameObject.SetActive(false);
    }   
}
