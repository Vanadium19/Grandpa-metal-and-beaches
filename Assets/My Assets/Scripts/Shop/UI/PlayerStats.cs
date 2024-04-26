using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private List<Stat> _stats;

    private string _levelName;
    private Stat _nextLevelStat;

    public event Action<float> PlayerUpgraded;

    public int MaxLevel => _stats.Count;
    public int CurrentLevel => PlayerPrefs.GetInt(_levelName, GameSaverData.LevelStep);

    private void Awake()
    {
        _levelName = _stats[0].GetType().ToString();
        SetNextStat();
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
        SaveNewStat();
        SetNextStat();
    }

    private void SaveNewStat()
    {
        PlayerPrefs.SetFloat(_nextLevelStat.Name, _nextLevelStat.Value);
        PlayerPrefs.SetInt(_levelName, _nextLevelStat.Level);
        PlayerPrefs.Save();
    }

    private void SetNextStat() => _nextLevelStat = _stats.FirstOrDefault(stat => stat.Level == CurrentLevel + GameSaverData.LevelStep);
}
