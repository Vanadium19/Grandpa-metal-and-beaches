using UnityEngine;

internal class VideoAd : MonoBehaviour
{
    private readonly float _pauseTimeScale = 0f;
    private readonly float _playTimeScale = 1f;
    private readonly float _minVolume = 0;

    [SerializeField] private FocusTracker _focusTracker;

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
        AudioListener.volume = _minVolume;
        _focusTracker.SetCurrentVolume(_minVolume);

        Time.timeScale = _pauseTimeScale;
        _focusTracker.SetCurrentTimeScale(_pauseTimeScale);
    }

    private void OnRewardCallback() => _wallet.AddMoney(_money);

    private void OnCloseCallback()
    {
        var volume = PlayerPrefs.GetFloat(GameSaver.Audio, GameSaver.DefaultVolume);

        AudioListener.volume = volume;
        _focusTracker.SetCurrentVolume(volume);

        Time.timeScale = _playTimeScale;
        _focusTracker.SetCurrentTimeScale(_playTimeScale);
        gameObject.SetActive(false);
    }   
}
