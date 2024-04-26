using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

internal class Localizer : MonoBehaviour
{
    public const string RussianCode = "Russian";
    public const string EnglishCode = "English";
    public const string TurkishCode = "Turkish";
    public const string Russian = "ru";
    public const string English = "en";
    public const string Turkish = "tr";

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
                LeanLocalization.SetCurrentLanguageAll(RussianCode);
                break;

            case English:
                LeanLocalization.SetCurrentLanguageAll(EnglishCode);
                break;

            case Turkish:
                LeanLocalization.SetCurrentLanguageAll(TurkishCode);
                break;

            default:
                LeanLocalization.SetCurrentLanguageAll(EnglishCode);
                break;
        }
    }
}
