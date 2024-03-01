using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create new Level", order = 52)]
public class LevelGoals : ScriptableObject
{
    [SerializeField] private float _number;
    [SerializeField] private float _targetWeight;
    [SerializeField] private float _targetMoney;

    public float Number => _number;
    public float TargetWeight => _targetWeight;
    public float TargetMoney => _targetMoney;
}
