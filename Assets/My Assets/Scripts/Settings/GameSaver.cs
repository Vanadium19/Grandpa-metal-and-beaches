using UnityEngine;

public static class GameSaver
{
    private static readonly int _levelStep = 1;
    private static readonly float _defaultVolume = 1f;
    private static readonly float _defaultPlayerSpeed = 2f;
    private static readonly float _defaultCollectorLevel = 1f;
    private static readonly float _defaultBagCapacity = 25f;

    public static float Weight => PlayerPrefs.GetFloat(Names.Weight);
    public static float CurrentWeight => PlayerPrefs.GetFloat(Names.CurrentWeight);
    public static float CollectorLevel => PlayerPrefs.GetFloat(Names.ScrapCollector);
    public static float Speed => PlayerPrefs.GetFloat(Names.Speed);
    public static float BagCapacity => PlayerPrefs.GetFloat(Names.Bag);
    public static float Money => PlayerPrefs.GetFloat(Names.Money);
    public static float Volume => PlayerPrefs.GetFloat(Names.Volume, _defaultVolume);
    public static int LevelNumber => PlayerPrefs.GetInt(Names.Level, _levelStep);
    public static bool IsGameConfigured => PlayerPrefs.HasKey(Names.Settings);

    public static void SetWeight(float addedValue)
    {
        float weight = Weight + addedValue;

        PlayerPrefs.SetFloat(Names.Weight, weight);
        PlayerPrefs.Save();
    }

    public static void SetCurrentWeight(float value)
    {
        PlayerPrefs.SetFloat(Names.CurrentWeight, value);
        PlayerPrefs.Save();
    }

    public static void SetNextLevel()
    {
        int levelNumber = LevelNumber + _levelStep;

        PlayerPrefs.SetInt(Names.Level, levelNumber);
        PlayerPrefs.Save();
    }

    public static bool IsTutorialCompleted(string name)
    {
        return PlayerPrefs.HasKey(Names.Tutorial + name);
    }

    public static void SaveTutorial(string name)
    {
        PlayerPrefs.SetString(Names.Tutorial + name, true.ToString());
        PlayerPrefs.Save();
    }

    public static void SetMoney(float value)
    {
        PlayerPrefs.SetFloat(Names.Money, value);
        PlayerPrefs.Save();
    }

    public static void SetVolume(float value)
    {
        PlayerPrefs.SetFloat(Names.Volume, value);
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

        PlayerPrefs.SetFloat(Names.ScrapCollector, _defaultCollectorLevel);
        PlayerPrefs.SetFloat(Names.Speed, _defaultPlayerSpeed);
        PlayerPrefs.SetFloat(Names.Bag, _defaultBagCapacity);

        PlayerPrefs.SetFloat(Names.Volume, _defaultVolume);

        PlayerPrefs.Save();
    }

    public static class Names
    {
        public static readonly string Money = "Money";
        public static readonly string Weight = "Weight";
        public static readonly string CurrentWeight = "CurrentWeight";

        public static readonly string Level = "Level";
        public static readonly string Tutorial = "Tutorial";
        public static readonly string Volume = "Volume";
        public static readonly string Settings = "Settings";

        public static readonly string Bag = "Bag";
        public static readonly string Speed = "Speed";
        public static readonly string ScrapCollector = "ScrapCollector";
    }
}