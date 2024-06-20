using System.Collections.Generic;
using System.Linq;
using GMB.Settings;
using UnityEngine;

internal class LevelsPool : MonoBehaviour
{
    [SerializeField] private List<LevelGoals> _levelGoals;

    public LevelGoals GetCurrentLevel()
    {
        var levelNumber = Mathf.Min(GameSaver.LevelNumber, _levelGoals.Count);

        return _levelGoals.FirstOrDefault(levelGoal => levelGoal.Number == levelNumber);
    }
}