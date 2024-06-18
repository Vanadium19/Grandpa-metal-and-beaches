using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class Localizer : MonoBehaviour
{
    public const string RussianCode = "Russian";
    public const string EnglishCode = "English";
    public const string TurkishCode = "Turkish";
    public const string Russian = "ru";
    public const string English = "en";
    public const string Turkish = "tr";

    [SerializeField] private LeanLocalization _leanLocalization;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ChangeLanguage();
#endif
    }

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (languageCode)
        {
            case Russian:
                _leanLocalization.SetCurrentLanguage(RussianCode);
                break;

            case English:
                _leanLocalization.SetCurrentLanguage(EnglishCode);
                break;

            case Turkish:
                _leanLocalization.SetCurrentLanguage(TurkishCode);
                break;

            default:
                _leanLocalization.SetCurrentLanguage(EnglishCode);
                break;
        }
    }
}