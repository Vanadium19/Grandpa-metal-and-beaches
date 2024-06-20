using UnityEngine;

namespace GMB.GamePlay.Level
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create new Level", order = 52)]
    internal class LevelGoals : ScriptableObject
    {
        [SerializeField] private float _number;
        [SerializeField] private float _targetWeight;

        public float Number => _number;
        public float TargetWeight => _targetWeight;
    }
}