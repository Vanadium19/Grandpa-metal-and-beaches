using UnityEngine;

public static class GameSaver
{
    private static readonly int _levelStep = 1;
    private static readonly float _defaultVolume = 1f;
    private static readonly float _defaultPlayerSpeed = 2f;
    private static readonly float _defaultCollectorLevel = 1f;
    private static readonly float _defaultBagCapacity = 25f;

    public static float Weight => PlayerPrefs.GetFloat(StaticGameData.Weight);
    public static float CurrentWeight => PlayerPrefs.GetFloat(StaticGameData.CurrentWeight);
    public static float CollectorLevel => PlayerPrefs.GetFloat(StaticGameData.ScrapCollector);
    public static float Speed => PlayerPrefs.GetFloat(StaticGameData.Speed);
    public static float BagCapacity => PlayerPrefs.GetFloat(StaticGameData.Bag);
    public static float Money => PlayerPrefs.GetFloat(StaticGameData.Money);
    public static float Volume => PlayerPrefs.GetFloat(StaticGameData.Volume, _defaultVolume);
    public static int LevelNumber => PlayerPrefs.GetInt(StaticGameData.Level, _levelStep);
    public static bool IsGameConfigured => PlayerPrefs.HasKey(StaticGameData.Settings);

    public static void SetWeight(float addedValue)
    {
        float weight = Weight + addedValue;

        PlayerPrefs.SetFloat(StaticGameData.Weight, weight);
        PlayerPrefs.Save();
    }

    public static void SetCurrentWeight(float value)
    {
        PlayerPrefs.SetFloat(StaticGameData.CurrentWeight, value);
        PlayerPrefs.Save();
    }

    public static void SetNextLevel()
    {
        int levelNumber = LevelNumber + _levelStep;

        PlayerPrefs.SetInt(StaticGameData.Level, levelNumber);
        PlayerPrefs.Save();
    }

    public static bool IsTutorialCompleted(string name)
    {
        return PlayerPrefs.HasKey(StaticGameData.Tutorial + name);
    }

    public static void SaveTutorial(string name)
    {
        PlayerPrefs.SetString(StaticGameData.Tutorial + name, true.ToString());
        PlayerPrefs.Save();
    }

    public static void SetMoney(float value)
    {
        PlayerPrefs.SetFloat(StaticGameData.Money, value);
        PlayerPrefs.Save();
    }

    public static void SetVolume(float value)
    {
        PlayerPrefs.SetFloat(StaticGameData.Volume, value);
        PlayerPrefs.Save();
    }

    public static int GetStatLevelNumber(string statLevelName)
    {
        return PlayerPrefs.GetInt(statLevelName, _levelStep);
    }

    public static void SetNextStatLevel(string statLevelName, string statName, float value)
    {
        int levelNumber = GetStatLevelNumber(statLevelName) + _levelStep;

        PlayerPrefs.SetInt(statLevelName, levelNumber);
        PlayerPrefs.SetFloat(statName, value);
        PlayerPrefs.Save();
    }

    public static void SetDefaultSettings()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt(nameof(ScrapCollectorLevel), _levelStep);
        PlayerPrefs.SetInt(nameof(SpeedLevel), _levelStep);
        PlayerPrefs.SetInt(nameof(BagLevel), _levelStep);

        PlayerPrefs.SetFloat(StaticGameData.ScrapCollector, _defaultCollectorLevel);
        PlayerPrefs.SetFloat(StaticGameData.Speed, _defaultPlayerSpeed);
        PlayerPrefs.SetFloat(StaticGameData.Bag, _defaultBagCapacity);

        PlayerPrefs.SetFloat(StaticGameData.Volume, _defaultVolume);

        PlayerPrefs.Save();
    }
}