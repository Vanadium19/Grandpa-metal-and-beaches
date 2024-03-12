using System;
using UnityEngine;

internal class LevelStarter : MonoBehaviour
{
    [SerializeField] private LevelSpawner _levelSpawner;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private WeightView _weightView;

    private LevelGoals _levelGoals;

    private void Awake()
    {
        FindLevelGoals();
        Initialize();
    }

    private void Start() => _levelSpawner.StartSpawn();

    private void Initialize()
    {
        _levelSpawner.Initialize(_levelGoals.TargetWeight);
        _levelEnder.Initialize(_levelGoals.TargetWeight);
        _weightView.Initialize(_levelGoals.TargetWeight);
    }

    private void FindLevelGoals()
    {
        _levelGoals = _levelsPool.GetCurrentLevel();

        if (_levelGoals == null)
            throw new ArgumentOutOfRangeException(nameof(LevelGoals));
    }
}
