using System;
using System.Collections.Generic;
using UnityEngine;

internal class LevelStarter : MonoBehaviour
{
    [SerializeField] private List<LevelSpawner> _levelSpawners;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private WeightView _weightView;

    private LevelGoals _levelGoals;

    private void Awake()
    {
        FindLevelGoals();
        Initialize();
    }

    private void Start()
    {
        foreach (var levelSpawner in _levelSpawners)
            levelSpawner.StartSpawn();
    }

    private void Initialize()
    {
        foreach (var levelSpawner in _levelSpawners)
            levelSpawner.Initialize(_levelGoals.TargetWeight);

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
