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
    public static readonly IReadOnlyList<string> StatNames = new List<string>() { Bag, Speed, ScrapCollector };

    private static readonly int _levelStep = 1;
    private static readonly float _defaultVolume = 1f;

    public static void RestartProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public static float GetCurrentVolume() => PlayerPrefs.GetFloat(Audio, _defaultVolume);

    public static int GetCurrentStatLevel(string name) => PlayerPrefs.GetInt($"{name} {Level}", _levelStep);

    public static void SetNextStatLevel(string name, int level)
    {
        PlayerPrefs.SetInt($"{name} {Level}", level);
        PlayerPrefs.Save();
    }

    public static void FinishLevel(float weight, float money)
    {
        PlayerPrefs.SetFloat(Weight, PlayerPrefs.GetFloat(Weight) + weight);
        PlayerPrefs.SetFloat(Money, PlayerPrefs.GetFloat(Money) + money);
        PlayerPrefs.SetInt(Level, PlayerPrefs.GetInt(Level, _levelStep) + _levelStep);
        PlayerPrefs.Save();
    }
}