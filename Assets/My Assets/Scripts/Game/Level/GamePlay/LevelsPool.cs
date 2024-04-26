using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class LevelsPool : MonoBehaviour
{
    [SerializeField] private List<LevelGoals> _levelGoals;

    public LevelGoals GetCurrentLevel()
    {
        var levelNumber = Mathf.Min(PlayerPrefs.GetInt(
            GameSaverData.Level, GameSaverData.LevelStep), _levelGoals.Count);

        return _levelGoals.FirstOrDefault(levelGoal => levelGoal.Number == levelNumber);
    }
}
