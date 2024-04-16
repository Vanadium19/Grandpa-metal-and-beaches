using System.Collections.Generic;
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

    private void TuneVolume() => AudioListener.volume = PlayerPrefs.GetFloat(GameSaverData.Audio, GameSaverData.DefaultVolume);

    private void TunePlayerStats()
    {
        foreach (var stat in _firstLevelStats)
        {
            string statLevelName = stat.GetType().ToString();

            if (!PlayerPrefs.HasKey(statLevelName))
                UpdateLevel(statLevelName, stat);
        }
    }

    private void UpdateLevel(string statLevelName, Stat stat)
    {
        PlayerPrefs.SetInt(statLevelName, GameSaverData.LevelStep);
        PlayerPrefs.SetFloat(stat.Name, stat.Value);
        PlayerPrefs.Save();
    }
}
