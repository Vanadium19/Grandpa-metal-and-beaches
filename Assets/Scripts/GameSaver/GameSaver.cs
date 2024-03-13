using System.Collections.Generic;
using UnityEngine;

public static class GameSaver
{
    public static readonly string Money = "Money";    
    public static readonly string Weight = "Weight";

    public static readonly string Level = "Level";
    public static readonly string Tutorial = "Tutorial";
    public static readonly string Audio = "AudioListener";

    public static readonly string Bag = "Bag";
    public static readonly string Speed = "Speed";
    public static readonly string ScrapCollector = "ScrapCollector";
    public static readonly int LevelStep = 1;

    private static readonly float _defaultVolume = 1f;

    public static void RestartProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat(Bag, 25f);
        PlayerPrefs.SetFloat(Speed, 3f);
        PlayerPrefs.SetFloat(ScrapCollector, 1f);
        PlayerPrefs.Save();
    }

    public static void SaveVolume()
    {
        PlayerPrefs.SetFloat(GameSaver.Audio, AudioListener.volume);
        PlayerPrefs.Save();
    }

    public static float GetCurrentVolume() => PlayerPrefs.GetFloat(Audio, _defaultVolume);
}
