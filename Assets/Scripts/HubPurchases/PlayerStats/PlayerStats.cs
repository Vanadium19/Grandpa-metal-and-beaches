using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private readonly int _levelStep = 1;

    [SerializeField] private List<Stat> _stats;

    private string _levelName;
    private Stat _nextLevelStat;

    public int MaxLevel => _stats.Count;
    public int CurrentLevel => PlayerPrefs.GetInt(_levelName, _levelStep);
    public float NextStatPrice => _nextLevelStat.Price;

    private void Awake()
    {
        _levelName = _stats[0].GetType().ToString();
        SetNextLevelStat();
    }

    public void UpdateLevel()
    {
        PlayerPrefs.SetFloat(_nextLevelStat.Name, _nextLevelStat.Value);
        PlayerPrefs.SetInt(_levelName, _nextLevelStat.Level);
        PlayerPrefs.Save();
        SetNextLevelStat();
    }

    private void SetNextLevelStat() => _nextLevelStat = _stats.FirstOrDefault(stat => stat.Level == CurrentLevel + _levelStep);
}
