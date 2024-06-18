using UnityEngine;

public static class GameSaver
{
    private static readonly int _levelStep = 1;
    private static readonly float _defaultVolume = 1f;
    private static readonly float _defaultPlayerSpeed = 2f;
    private static readonly float _defaultCollectorLevel = 1f;
    private static readonly float _defaultBagCapacity = 25f;

    public static float Weight => PlayerPrefs.GetFloat(StaticParams.GameNames.Weight);
    public static float CurrentWeight => PlayerPrefs.GetFloat(StaticParams.GameNames.CurrentWeight);
    public static float CollectorLevel => PlayerPrefs.GetFloat(StaticParams.GameNames.ScrapCollector);
    public static float Speed => PlayerPrefs.GetFloat(StaticParams.GameNames.Speed);
    public static float BagCapacity => PlayerPrefs.GetFloat(StaticParams.GameNames.Bag);
    public static float Money => PlayerPrefs.GetFloat(StaticParams.GameNames.Money);
    public static float Volume => PlayerPrefs.GetFloat(StaticParams.GameNames.Volume, _defaultVolume);
    public static int LevelNumber => PlayerPrefs.GetInt(StaticParams.GameNames.Level, _levelStep);
    public static bool IsGameConfigured => PlayerPrefs.HasKey(StaticParams.GameNames.Settings);

    public static void SetWeight(float addedValue)
    {
        float weight = Weight + addedValue;

        PlayerPrefs.SetFloat(StaticParams.GameNames.Weight, weight);
        PlayerPrefs.Save();
    }

    public static void SetCurrentWeight(float value)
    {
        PlayerPrefs.SetFloat(StaticParams.GameNames.CurrentWeight, value);
        PlayerPrefs.Save();
    }

    public static void SetNextLevel()
    {
        int levelNumber = LevelNumber + _levelStep;

        PlayerPrefs.SetInt(StaticParams.GameNames.Level, levelNumber);
        PlayerPrefs.Save();
    }

    public static bool IsTutorialCompleted(string name)
    {
        return PlayerPrefs.HasKey(StaticParams.GameNames.Tutorial + name);
    }

    public static void SaveTutorial(string name)
    {
        PlayerPrefs.SetString(StaticParams.GameNames.Tutorial + name, true.ToString());
        PlayerPrefs.Save();
    }

    public static void SetMoney(float value)
    {
        PlayerPrefs.SetFloat(StaticParams.GameNames.Money, value);
        PlayerPrefs.Save();
    }

    public static void SetVolume(float value)
    {
        PlayerPrefs.SetFloat(StaticParams.GameNames.Volume, value);
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

        PlayerPrefs.SetFloat(StaticParams.GameNames.ScrapCollector, _defaultCollectorLevel);
        PlayerPrefs.SetFloat(StaticParams.GameNames.Speed, _defaultPlayerSpeed);
        PlayerPrefs.SetFloat(StaticParams.GameNames.Bag, _defaultBagCapacity);

        PlayerPrefs.SetFloat(StaticParams.GameNames.Volume, _defaultVolume);

        PlayerPrefs.Save();
    }
}