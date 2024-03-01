using UnityEngine;

internal class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel) => panel.SetActive(true);

    public void ClosePanel(GameObject panel) => panel.SetActive(false);

    public void ContinueTime() => Time.timeScale = 1;

    public void StopTime() => Time.timeScale = 0;

    public void ExitGame() => Application.Quit();
}
