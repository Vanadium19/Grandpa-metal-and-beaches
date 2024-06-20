using GMB.Advertising;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SceneLoader))]
[RequireComponent(typeof(InterstitialAd))]
internal class EndLevelButton : MonoBehaviour
{
    private readonly float _defaultWeight = 0;

    private Button _button;
    private SceneLoader _sceneLoader;
    private InterstitialAd _interstitialAd;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _sceneLoader = GetComponent<SceneLoader>();
        _interstitialAd = GetComponent<InterstitialAd>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(FinishLevel);
        _interstitialAd.AdvertisingClosed += OnAdvertisingClosed;
    }

    private void Start()
    {
        _interstitialAd.Initialize(_button);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(FinishLevel);
        _interstitialAd.AdvertisingClosed -= OnAdvertisingClosed;
    }

    private void SaveProgress()
    {
        GameSaver.SetNextLevel();
        GameSaver.SetCurrentWeight(_defaultWeight);
    }

    private void FinishLevel()
    {
        SaveProgress();
        _interstitialAd.Show();
    }

    private void OnAdvertisingClosed()
    {
        _sceneLoader.Load();
    }
}