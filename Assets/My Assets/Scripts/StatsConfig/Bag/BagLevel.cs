using GMB.StaticData;
using UnityEngine;

namespace GMB.StatsConfig
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new BagLevel", order = 54)]
    public class BagLevel : Stat
    {
        private void Awake()
        {
            SetName(StaticGameData.Bag);
        }
    }
}