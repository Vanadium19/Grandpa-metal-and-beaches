using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class LevelsPool : MonoBehaviour
{
    private readonly int _firstLevel = 1;

    [SerializeField] private List<LevelGoals> _levelGoals;

    public LevelGoals GetCurrentLevel()
    {
        var levelNumber = Mathf.Clamp(PlayerPrefs.GetInt(GameSaver.Level, _firstLevel), _firstLevel, _levelGoals.Count);
        
        return _levelGoals.FirstOrDefault(levelGoal => levelGoal.Number == levelNumber);
    }
}
