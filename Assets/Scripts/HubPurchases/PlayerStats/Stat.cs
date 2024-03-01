using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new Stat", order = 54)]
public class Stat : ScriptableObject
{
    [Tooltip("Speed, Bag, ScrapCollector")]
    [SerializeField] private string _name;

    [SerializeField] private int _level;
    [SerializeField] private float _value;
    [SerializeField] private float _price;

    public string Name => _name;
    public int Level => _level;
    public float Value => _value;
    public float Price => _price;
}
