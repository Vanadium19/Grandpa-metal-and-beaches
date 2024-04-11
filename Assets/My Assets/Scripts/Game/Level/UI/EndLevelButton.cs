using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SceneLoader))]
[RequireComponent(typeof(InterstitialAd))]
internal class EndLevelButton : MonoBehaviour
{
    private Button _button;
    private SceneLoader _sceneLoader;
    private InterstitialAd _interstitialAd;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _sceneLoader = GetComponent<SceneLoader>();
        _interstitialAd = GetComponent<InterstitialAd>();
    }

    private void OnEnable() => _button.onClick.AddListener(FinishLevel);

    private void Start() => _interstitialAd.Initialize(_button);

    private void OnDisable() => _button.onClick.RemoveListener(FinishLevel);

    private void FinishLevel()
    {
        SaveProgress();
        _interstitialAd.Show();
        _sceneLoader.Load();
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt(GameSaverData.Level, PlayerPrefs.GetInt(GameSaverData.Level, GameSaverData.LevelStep) + GameSaverData.LevelStep);
        PlayerPrefs.SetFloat(GameSaverData.CurrentWeight, 0);
        PlayerPrefs.Save();
    }
}
