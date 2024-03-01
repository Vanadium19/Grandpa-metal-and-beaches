using System;
using System.Collections.Generic;
using System.Linq;
using Agava.YandexGames;
using UnityEngine;

internal class GameTuner : MonoBehaviour
{    
    [SerializeField] private List<Stat> _firstLevelStats;

    private void Awake()
    {
        foreach (var stat in _firstLevelStats)
            if (GameSaver.StatNames.Contains(stat.Name) == false)
                throw new ArgumentOutOfRangeException(nameof(stat.Name));
    }

    private void Start()
    {
        TuneVolume();
        TunePlayerStats();
        YandexGamesSdk.GameReady();
    }

    private void TuneVolume() => AudioListener.volume = GameSaver.GetCurrentVolume();

    private void TunePlayerStats()
    {
        foreach (var stat in _firstLevelStats)
            if (GameSaver.GetCurrentStatLevel(stat.Name) == stat.Level)            
                UpdateLevel(stat);        
    }

    private void UpdateLevel(Stat stat)
    {
        PlayerPrefs.SetFloat(stat.Name, stat.Value);
        PlayerPrefs.Save();
    }
}
