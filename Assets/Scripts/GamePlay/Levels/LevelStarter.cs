using System;
using UnityEngine;

internal class LevelStarter : MonoBehaviour
{
    [SerializeField] private LevelSpawner _levelSpawner;
    [SerializeField] private LevelGoalsView _levelGoalsView;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private LevelsPool _levelsPool;

    private LevelGoals _levelGoals;

    private void Awake()
    {
        FindLevelGoals();
        Initialize();
    }

    private void Start() => _levelSpawner.StartSpawn();

    private void Initialize()
    {
        _levelSpawner.Initialize(_levelGoals);
        _levelEnder.Initialize(_levelGoals);
        _levelGoalsView.Initialize(_levelGoals);
    }

    private void FindLevelGoals()
    {
        _levelGoals = _levelsPool.GetCurrentLevel();

        if (_levelGoals == null)
            throw new ArgumentOutOfRangeException(nameof(LevelGoals));
    }
}
