using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SceneLoader))]
internal class EndLevelButton : MonoBehaviour
{
    private Button _button;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _sceneLoader = GetComponent<SceneLoader>();
    }

    private void OnEnable() => _button.onClick.AddListener(FinishLevel);

    private void OnDisable() => _button.onClick.RemoveListener(FinishLevel);

    private void FinishLevel()
    {
        SaveProgress();
        _sceneLoader.Load();
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt(GameSaver.Level, PlayerPrefs.GetInt(GameSaver.Level, GameSaver.LevelStep) + GameSaver.LevelStep);
        PlayerPrefs.SetFloat(GameSaver.CurrentWeight, 0);
        PlayerPrefs.Save();
    }
}
