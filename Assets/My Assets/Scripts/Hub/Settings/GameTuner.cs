using System;
using System.Collections.Generic;
using System.Linq;
using Agava.YandexGames;
using UnityEngine;

internal class GameTuner : MonoBehaviour
{
    [SerializeField] private List<Stat> _firstLevelStats;

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
            if (Convert.ToBoolean(PlayerPrefs.GetInt(stat.GetType().ToString())) == false)
                UpdateLevel(stat);      
    }

    private void UpdateLevel(Stat stat)
    {
        PlayerPrefs.SetFloat(stat.Name, stat.Value);
        PlayerPrefs.Save();
    }
}
