using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private List<Stat> _stats;

    private string _levelName;
    private Stat _nextLevelStat;

    public int MaxLevel => _stats.Count;
    public int CurrentLevel => PlayerPrefs.GetInt(_levelName, GameSaver.LevelStep);

    private void Awake()
    {
        _levelName = _stats[0].GetType().ToString();
        SetNextLevelStat();
    }

    public float GetPrice()
    {
        return _nextLevelStat != null ? _nextLevelStat.Price : _stats.FirstOrDefault(stat => stat.Level == CurrentLevel + GameSaver.LevelStep).Price;
    }

    public void UpdateLevel()
    {
        PlayerPrefs.SetFloat(_nextLevelStat.Name, _nextLevelStat.Value);
        PlayerPrefs.SetInt(_levelName, _nextLevelStat.Level);
        PlayerPrefs.Save();
        SetNextLevelStat();
    }

    private void SetNextLevelStat() => _nextLevelStat = _stats.FirstOrDefault(stat => stat.Level == CurrentLevel + GameSaver.LevelStep);
}
