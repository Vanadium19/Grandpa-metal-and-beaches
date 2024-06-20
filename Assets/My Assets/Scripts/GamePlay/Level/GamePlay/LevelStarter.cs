using System;
using System.Collections.Generic;
using GMB.Settings;
using UnityEngine;

namespace GMB.GamePlay.Level
{
    internal class LevelStarter : MonoBehaviour
    {
        [SerializeField] private List<LevelSpawner> _levelSpawners;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private LevelsPool _levelsPool;
        [SerializeField] private ProgressBar _progressBar;

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
            float targetWeight = _levelGoals.TargetWeight;
            float currentWeight = GameSaver.CurrentWeight;

            foreach (var levelSpawner in _levelSpawners)
                levelSpawner.Initialize(Mathf.Max(0, targetWeight - currentWeight));

            _levelEnder.Initialize(targetWeight, currentWeight);
            _progressBar.Initialize(targetWeight, currentWeight);
        }

        private void FindLevelGoals()
        {
            _levelGoals = _levelsPool.GetCurrentLevel();

            if (_levelGoals == null)
                throw new ArgumentOutOfRangeException(nameof(LevelGoals));
        }
    }
}