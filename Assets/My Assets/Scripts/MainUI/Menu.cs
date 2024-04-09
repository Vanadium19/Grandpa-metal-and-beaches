using UnityEngine;

public class Menu : MonoBehaviour
{
    private readonly float _pauseTimeScale = 0f;
    private readonly float _playTimeScale = 1f;
    private readonly float _minVolume = 0;

    [SerializeField] private FocusTracker _focusTracker;

    public void OpenPanel(GameObject panel) => panel.SetActive(true);

    public void ClosePanel(GameObject panel) => panel.SetActive(false);

    public void ContinueTime()
    {
        Time.timeScale = _playTimeScale;
        _focusTracker.SetCurrentTimeScale(_playTimeScale);
    }

    public void StopTime()
    {
        Time.timeScale = _pauseTimeScale;
        _focusTracker.SetCurrentTimeScale(_pauseTimeScale);
    }

    public void ContinueMusic()
    {
        var volume = PlayerPrefs.GetFloat(GameSaver.Audio, GameSaver.DefaultVolume);

        AudioListener.volume = volume;
        _focusTracker.SetCurrentVolume(volume);
    }

    public void StopMusic()
    {
        AudioListener.volume = _minVolume;
        _focusTracker.SetCurrentVolume(_minVolume);
    }
}
