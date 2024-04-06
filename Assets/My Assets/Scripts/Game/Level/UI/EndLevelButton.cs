using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SceneLoader))]
internal class EndLevelButton : MonoBehaviour
{
    private Button _button;
    private SceneLoader _sceneLoader;

    private bool _isTrained;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _sceneLoader = GetComponent<SceneLoader>();
        _isTrained = Convert.ToBoolean(PlayerPrefs.GetInt(GameSaver.Tutorial));
    }

    private void OnEnable() => _button.onClick.AddListener(FinishLevel);

    private void Start()
    {
        if (!_isTrained)
            FinishTutorial();
    }

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

    private void FinishTutorial()
    {
        PlayerPrefs.SetInt(GameSaver.Tutorial, Convert.ToInt16(true));
        PlayerPrefs.Save();
    }
}
