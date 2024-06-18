using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new SpeedLevel", order = 54)]
public class SpeedLevel : Stat
{
    public SpeedLevel()
    {
        SetName(StaticParams.GameNames.Speed);
    }
}