using Lean.Localization;
using UnityEngine;

public class DeveloperAssistant : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("BagLevel"));
    }

    [ContextMenu("AddLittleMoney")]
    public void AddLittleMoney()
    {
        PlayerPrefs.SetFloat(GameSaver.Money, PlayerPrefs.GetFloat(GameSaver.Money) + 55f);
        PlayerPrefs.Save();
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        GameSaver.RestartProgress();
    }

    [ContextMenu("AddMoney")]
    public void AddMoney()
    {
        PlayerPrefs.SetFloat(GameSaver.Money, 5000f);
        PlayerPrefs.Save();
    }

    [ContextMenu("SetSpeed")]
    public void SetSpeed()
    {
        PlayerPrefs.SetFloat(GameSaver.Speed, 15);
        PlayerPrefs.Save();
    }
}
