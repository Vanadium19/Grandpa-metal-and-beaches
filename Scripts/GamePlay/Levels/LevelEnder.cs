using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
internal class LevelEnder : DumpsterObserver
{
    private readonly float _delay = 2f;

    [SerializeField] private GameObject _congratulationsPanel;
    [SerializeField] private CongratulationsView _weightView;
    [SerializeField] private CongratulationsView _moneyView;
    
    private SceneLoader _sceneLoader;

    private void Awake() => _sceneLoader = GetComponent<SceneLoader>();

    protected override void UpdateProgress(float currentWeight, float currentMoney)
    {
        if (currentWeight >= TargetWeight && currentMoney >= TargetMoney)
            StartCoroutine(FinishLevel(currentMoney, currentWeight));
    }

    private IEnumerator FinishLevel(float currentMoney, float currentWeight)
    {
        _congratulationsPanel.SetActive(true);
        _weightView.StartCongratulate(currentWeight, TargetWeight);
        _moneyView.StartCongratulate(currentMoney, TargetMoney);
        GameSaver.FinishLevel(currentWeight, currentMoney);        
        yield return new WaitUntil(() => _weightView.IsFinished && _moneyView.IsFinished);
        yield return new WaitForSeconds(_delay);
        _sceneLoader.Load();
    }
}
