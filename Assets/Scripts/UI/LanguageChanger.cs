using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class LanguageChanger : MonoBehaviour
{
    private readonly string[] _languages = new string[] { "Russian", "English", "Turkish" };

    [Tooltip("0 - Russian, 1 - English, 2 - Turkish")]
    [SerializeField, Range(0, 2)] private int _languageNumber;
    
    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(Translate);

    private void OnDisable() => _button.onClick.RemoveListener(Translate);

    private void Translate() => Lean.Localization.LeanLocalization.SetCurrentLanguageAll(_languages[_languageNumber]);
}
