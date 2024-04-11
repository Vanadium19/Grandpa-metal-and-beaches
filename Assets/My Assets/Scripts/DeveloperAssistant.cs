using Lean.Localization;
using UnityEngine;

public class DeveloperAssistant : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    [ContextMenu("AddLittleMoney")]
    public void AddLittleMoney()
    {
        _wallet.AddMoney(10f);
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat(GameSaverData.Bag, 25f);
        PlayerPrefs.SetFloat(GameSaverData.Speed, 2f);
        PlayerPrefs.SetFloat(GameSaverData.ScrapCollector, 1f);
        PlayerPrefs.Save();
    }

    [ContextMenu("AddMoney")]
    public void AddMoney()
    {
        PlayerPrefs.SetFloat(GameSaverData.Money, 5000f);
        PlayerPrefs.Save();
    }

    [ContextMenu("SetSpeed")]
    public void SetSpeed()
    {
        PlayerPrefs.SetFloat(GameSaverData.Speed, 15);
        PlayerPrefs.Save();
    }

    [ContextMenu("SetEnglish")]
    public void SetEnglish() => LeanLocalization.SetCurrentLanguageAll("English");

    [ContextMenu("SetTurkish")]
    public void SetTurkish() => LeanLocalization.SetCurrentLanguageAll("Turkish");

    [ContextMenu("SetRussian")]
    public void SetRussian() => LeanLocalization.SetCurrentLanguageAll("Russian");
}
