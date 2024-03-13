using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
internal class LevelEnder : MonoBehaviour
{
    [SerializeField] private GameObject _endLevelButton;
    [SerializeField] private Dumpster _dumpster;
    
    private float _targetWeight;
    private float _currentWeight;

    private void OnEnable() => _dumpster.ScrapCollected += UpdateProgress;

    private void OnDisable() => _dumpster.ScrapCollected -= UpdateProgress;

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    private void UpdateProgress(Scrap scrap)
    {
        AddWeight(scrap.Info.Weight);

        if (_endLevelButton.activeSelf == false && _currentWeight >= _targetWeight)
            _endLevelButton.SetActive(true);
    }

    private void AddWeight(float weight)
    {
        _currentWeight += weight;
        PlayerPrefs.SetFloat(GameSaver.Weight, PlayerPrefs.GetFloat(GameSaver.Weight) + weight);
        PlayerPrefs.Save();
    }
}
