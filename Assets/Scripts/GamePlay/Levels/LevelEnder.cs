using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
internal class LevelEnder : MonoBehaviour
{
    [SerializeField] private Dumpster _dumpster;

    //private readonly float _delay = 2f;

    //[SerializeField] private GameObject _congratulationsPanel;
    //[SerializeField] private CongratulationsView _weightView;
    //[SerializeField] private CongratulationsView _moneyView;
    
    private float _targetWeight;
    private float _currentWeight;
    private SceneLoader _sceneLoader;

    private void Awake() => _sceneLoader = GetComponent<SceneLoader>();

    private void OnEnable() => _dumpster.ScrapCollected += UpdateProgress;

    private void OnDisable() => _dumpster.ScrapCollected -= UpdateProgress;

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    private void UpdateProgress(Scrap scrap)
    {
        _currentWeight += scrap.Info.Weight;

        if (_currentWeight >= _targetWeight)
            FinishLevel();
    }

    private void FinishLevel()
    {
        GameSaver.FinishLevel(_currentWeight);
        _sceneLoader.Load();
    }   

    //private IEnumerator FinishLevel(float currentMoney, float currentWeight)
    //{
    //    _congratulationsPanel.SetActive(true);
    //    _weightView.StartCongratulate(currentWeight, TargetWeight);
    //    _moneyView.StartCongratulate(currentMoney, TargetMoney);
    //    GameSaver.FinishLevel(currentWeight, currentMoney);        
    //    yield return new WaitUntil(() => _weightView.IsFinished && _moneyView.IsFinished);
    //    yield return new WaitForSeconds(_delay);
    //    _sceneLoader.Load();
    //}
}
