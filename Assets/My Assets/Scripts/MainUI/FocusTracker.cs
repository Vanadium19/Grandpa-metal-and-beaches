using Agava.WebUtility;
using UnityEngine;

public class FocusTracker : MonoBehaviour
{
    private float _currentTimeScale = 1f;
    private float _currentVolume;

    private void Awake()
    {
        _currentVolume = GameSaver.Volume;
    }

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    public void SetCurrentTimeScale(float value)
    {
        _currentTimeScale = value;
    }

    public void SetCurrentVolume(float value)
    {
        _currentVolume = value;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.volume = value ? 0 : _currentVolume;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : _currentTimeScale;
    }
}