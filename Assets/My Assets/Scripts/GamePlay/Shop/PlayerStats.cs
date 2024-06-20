using System;
using System.Collections.Generic;
using System.Linq;
using GMB.StatsConfig;
using UnityEngine;

internal class PlayerStats : MonoBehaviour
{
    private readonly int _firstElementIndex = 0;
    private readonly int _levelStep = 1;

    [SerializeField] private List<Stat> _stats;

    private string _statLevelName;
    private Stat _nextLevelStat;

    public event Action<float> PlayerUpgraded;

    public int MaxLevel => _stats.Count;
    public int CurrentLevel => GameSaver.GetStatLevelNumber(_statLevelName);

    private void Awake()
    {
        _statLevelName = _stats[_firstElementIndex].GetType().ToString();
    }

    public float GetPrice()
    {
        if (_nextLevelStat == null)
            SetNextStat();

        return _nextLevelStat.Price;
    }

    public void UpdateLevel()
    {
        PlayerUpgraded?.Invoke(_nextLevelStat.Value);
        GameSaver.SetNextStatLevel(_statLevelName, _nextLevelStat.Name, _nextLevelStat.Value);
        SetNextStat();
    }

    private void SetNextStat()
    {
        _nextLevelStat = _stats.FirstOrDefault(stat => stat.Level == CurrentLevel + _levelStep);
    }
}