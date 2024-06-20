using UnityEngine;

namespace GMB.StatsConfig
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new ScrapCollectorLevel", order = 54)]
    public class ScrapCollectorLevel : Stat
    {
        public ScrapCollectorLevel()
        {
            SetName(StaticGameData.ScrapCollector);
        }
    }
}