using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private readonly int _levelStep = 1;

    [SerializeField] private List<Stat> _stats;

    private string _name;

    public int MaxLevel => _stats.Count;
    public int CurrentLevel => GameSaver.GetCurrentStatLevel(_name);
    public Stat NextLevelStat => _stats.FirstOrDefault(stat => stat.Level == CurrentLevel + _levelStep);

    private void Awake() => CheckValues();

    public void UpdateLevel()
    {
        PlayerPrefs.SetFloat(_name, NextLevelStat.Value);
        GameSaver.SetNextStatLevel(_name, NextLevelStat.Level);
        PlayerPrefs.Save();
    }

    private void CheckValues()
    {
        _name = _stats[0].Name;

        if (GameSaver.StatNames.Contains(_name) == false)
            throw new ArgumentOutOfRangeException(nameof(_name));

        foreach (var stat in _stats)
            if (stat.Name != _name)
                throw new ArgumentOutOfRangeException(nameof(_name));
    }
}
