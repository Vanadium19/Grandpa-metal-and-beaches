using UnityEngine;

internal class Menu : MonoBehaviour
{
    private readonly float _pauseTimeScale = 0f;
    private readonly float _playTimeScale = 1f;

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

    public void ExitGame() => Application.Quit();
}
