using GMB.StaticData;
using UnityEngine;

namespace GMB.StatsConfig
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new ScrapCollectorLevel", order = 54)]
    public class ScrapCollectorLevel : Stat
    {
        private void Awake()
        {
            SetName(StaticGameData.ScrapCollector);
        }
    }
}