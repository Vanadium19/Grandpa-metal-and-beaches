using UnityEngine;

namespace GMB.GamePlay.ScrapConfig
{
    [CreateAssetMenu(fileName = "New Scrap", menuName = "Scrap/Create new Scrap", order = 51)]
    internal class ScrapInfo : ScriptableObject
    {
        [SerializeField] private float _weight;
        [SerializeField] private float _price;
        [SerializeField] private int _rank;

        public float Weight => _weight;
        public float Price => _price;
        public int Rank => _rank;
    }
}