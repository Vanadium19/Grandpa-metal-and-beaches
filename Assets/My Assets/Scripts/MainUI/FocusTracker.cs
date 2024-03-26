using Agava.WebUtility;
using UnityEngine;

internal class FocusTracker : MonoBehaviour
{
    private float _actualTimeScale;

    private void Awake() => _actualTimeScale = 1f;

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

    private void MuteAudio(bool value) => AudioListener.volume = value ? 0 : GameSaver.GetCurrentVolume();

    private void PauseGame(bool value)
    {
        if (value)        
            _actualTimeScale = Time.timeScale;

        Time.timeScale = value ? 0 : _actualTimeScale;
    }
}
