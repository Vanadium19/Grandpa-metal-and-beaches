using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new ScrapCollectorLevel", order = 54)]
public class ScrapCollectorLevel : Stat
{
    public ScrapCollectorLevel() => Name = GameSaver.Names.ScrapCollector;
}
