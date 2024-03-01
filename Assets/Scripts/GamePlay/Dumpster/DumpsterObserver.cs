using UnityEngine;

public abstract class DumpsterObserver : MonoBehaviour
{
    [SerializeField] private Dumpster _dumpster;

    private float _currentMoney = 0;
    private float _currentWeight = 0;

    protected float TargetWeight { get; private set; }
    protected float TargetMoney { get; private set; }

    private void OnEnable() => _dumpster.ScrapCollected += OnScrapCollected;

    private void OnDisable() => _dumpster.ScrapCollected -= OnScrapCollected;

    public void Initialize(LevelGoals levelGoals)
    {
        TargetWeight = levelGoals.TargetWeight;
        TargetMoney = levelGoals.TargetMoney;
        UpdateProgress(_currentWeight, _currentMoney);
    }

    protected abstract void UpdateProgress(float currentWeight, float currentMoney);

    private void OnScrapCollected(float weight, float money)
    {
        _currentWeight += weight;
        _currentMoney += money;
        UpdateProgress(_currentWeight, _currentMoney);
    }

}
